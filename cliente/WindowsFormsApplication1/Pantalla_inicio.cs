using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Pantalla_inicio : Form
    {
        Socket server;
        Thread atender;
        delegate void DelegadoParaGrid(string [] mensaje, int codigo);
        delegate void DelegadoParaDesconectar();
        bool Loged = false;
        bool Connect = false;
        bool Conect_Click = false;
        public string usuario;
        public Pantalla_inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pwd.UseSystemPasswordChar = true;
            this.BackColor = Color.FromArgb(41, 44, 51);
            this.ForeColor = Color.FromArgb(62, 120, 138);
            registro.BackColor = Color.FromArgb(41, 44, 51);
            titulo.BackColor = Color.FromArgb(192, 192, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            desconectar.FlatStyle = FlatStyle.Flat;
            desconectar.FlatAppearance.BorderSize = 0;
            
            

                       
        }
                
        public void PonerEnGrid(string [] mensaje, int hack)
        {
            button3.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;
            dataGridView1.ColumnHeadersVisible = true;
            string c = Convert.ToString(hack);
            dataGridView1.Rows.Add(c);
            int i;
            for (i = 0; i < hack; i++)
            {
                dataGridView1.Rows.Add(mensaje[i]);
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        public void Desconectar()
        {
            button3.Visible = false;
            connect_status.BackColor = default(Color);
            connect_status.Text = "Desconectado";
            connect_status.ForeColor = Color.Red;
            nombre.Clear();
            pwd.Clear();
            dataGridView1.Rows.Clear();
            Conect_Click = false;
            Connect = false;
            Loged = false;
                
            


        }
        
        
      
        private void AtenderServidor()
        {
            while (true)
            {
                // Recibimos mensaje del servidor
                byte[] msg2 = new byte[100];
                server.Receive(msg2);
                string[] error_servidor = Encoding.ASCII.GetString(msg2).Split('\0');
                if (error_servidor[0] == "")
                {
                    MessageBox.Show("Servidor en tareas de mantenimiento, vuelva a conectarse más tarde");
                    DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
                    pwd.Invoke(delegado, new object[] { });
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    atender.Abort();
                }

                else
                {
                    string[] trozos = error_servidor[0].Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    switch (codigo)
                    {
                        case 0: //resupesta a desconnectar
                            string mensaje1 = trozos[2].Split('\0')[0];
                            int hack = Convert.ToInt32(trozos[1]);
                            if (hack == 1)
                            {
                                MessageBox.Show(mensaje1);
                            }
                            else
                            {
                                MessageBox.Show(mensaje1);
                                DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
                                pwd.Invoke(delegado, new object[] { });
                                server.Shutdown(SocketShutdown.Both);
                                server.Close();
                                atender.Abort();

                            }

                            break;

                        case 1://respuesta al sign in
                            string mensaje = trozos[1].Split('\0')[0];
                            MessageBox.Show(mensaje);
                            break;
                        case 2: //respuesta al log in
                            string mensaje2 = trozos[2].Split('\0')[0];
                            int hack1 = Convert.ToInt32(trozos[1]);
                            if (hack1 == 0)
                            {
                                MessageBox.Show(mensaje2);
                                Loged = true;
                            }
                            else
                            {
                                MessageBox.Show(mensaje2);
                            }
                            break;
                        case 3: //respuesta a la consulta 1
                            string mensaje3 = trozos[1].Split('\0')[0];
                            MessageBox.Show(mensaje3);
                            break;
                        case 4: //respuesta a la consulta 2
                            string mensaje4 = trozos[1].Split('\0')[0];
                            MessageBox.Show(mensaje4);
                            break;
                        case 5: //respuesta a la consulta 3
                            string mensaje5 = trozos[1].Split('\0')[0];
                            MessageBox.Show(mensaje5);
                            break;
                        case 6:
                            int hack6 = Convert.ToInt32(trozos[1]);
                            if (hack6 == 0)
                                MessageBox.Show("No hay usuarios connectados");
                            else
                            {
                                string[] mensaje6 = new string[hack6];
                                for (int i = 0; i < hack6; i++)
                                {
                                    mensaje6[i] = (trozos[i + 2].Split('\0')[0]);

                                }

                                DelegadoParaGrid delegado = new DelegadoParaGrid(PonerEnGrid);
                                dataGridView1.Invoke(delegado, new object[] { mensaje6, hack6 });
                                //dataGridView1.Columns.Add("Column",mensaje[0]);
                                //connlbl.Text = mensaje;


                            }
                            break;
                    }

                }
            }
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Conect_Click)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse(IP.Text);
                IPEndPoint ipep = new IPEndPoint(direc, 50058);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    connect_status.BackColor = Color.Green;
                    connect_status.Text = "Conectado";
                    connect_status.ForeColor = Color.Black;
                    MessageBox.Show("Conectado");
                    Connect = true;

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                Conect_Click = true;
            }
            else
                MessageBox.Show("Conexión ya establecida");


            //pongo en marcha el thread que atendera los mensajes del servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Connect)
            {
                if (Loged)
                {
                    if (Consulta_1.Checked)
                    {
                        string mensaje = "3/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        
                    }

                    else if (Consulta_2.Checked)
                    {
                        string mensaje = "4/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        
                    }
                    else if (Consulta_3.Checked)
                    {
                        string mensaje = "5/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        
                    }
                    else
                        MessageBox.Show("Ninguna consulta seleccionada");
                }
                else
                    MessageBox.Show("Inicie sesión");
            }
            else if (!Connect)

                MessageBox.Show("Inicie conexión");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void Consulta_3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SIGN_IN_Click_1(object sender, EventArgs e)
        {
            if (Connect)
            {
                if (nombre.Text != "" & pwd.Text != "")
                {
                    string mensaje = "1/" + nombre.Text + "/" + pwd.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    
                }
                else
                {
                    MessageBox.Show("Rellene nombre de usuario y contraseña por favor");
                }
            }
            else
                MessageBox.Show("Inicie conexión");

        }

        private void LOG_IN_Click_1(object sender, EventArgs e)
        {
            if (Connect)
            {
                if (!Loged)
                {
                    if (nombre.Text != "" & pwd.Text != "")
                    {
                        string mensaje = "2/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                     
  
                    }
                    else
                    {
                        MessageBox.Show("Rellene nombre de usuario y contraseña por favor");
                    }
                }
                else
                    MessageBox.Show("Sesión ya iniciada");
            }
            else
                MessageBox.Show("Inicie conexión");

        }

        private void Consulta_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Consulta_1_CheckedChanged(object sender, EventArgs e)
        {

        }
        

        private void desconectar_Click(object sender, EventArgs e)
        {
            if (Connect)
            {
                if (Loged)
                {
                    string mensaje = "0/" + nombre.Text + "/" + pwd.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    
                }
                else
                    MessageBox.Show("No hay ninguna sesión iniciada");

            }
            else
            {
                MessageBox.Show("No hay ninguna conexión no establecida");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connect)
            {
                MessageBox.Show("Por favor asegurese de desconnectarse del servidor antes de cerrar la ventana");
                e.Cancel = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Loged)
            {
                ModoJuego f = new ModoJuego();
                f.usuario = usuario;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Inicie sesión por favor");
            }

        }

        private void mostrar_contrasenya_CheckedChanged(object sender, EventArgs e)
        {
            string text = pwd.Text;
            if (mostrar_contrasenya.Checked)
            {
                pwd.UseSystemPasswordChar = false;
                pwd.Text = text;

            }
            else
            {
                pwd.UseSystemPasswordChar = true;
                pwd.Text = text;
            }
            
        }


        }



     
    }

