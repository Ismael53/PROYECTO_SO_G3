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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        bool Loged = false;
        bool Connect = false;
        bool Conect_Click = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Conect_Click)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse(IP.Text);
                IPEndPoint ipep = new IPEndPoint(direc, 9600);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
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
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                        MessageBox.Show(mensaje);
                    }

                    else if (Consulta_2.Checked)
                    {
                        string mensaje = "4/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                        MessageBox.Show(mensaje);
                    }
                    else if (Consulta_3.Checked)
                    {
                        string mensaje = "5/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[100];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                        MessageBox.Show(mensaje);
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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                    MessageBox.Show(mensaje);
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
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                        string [] div = mensaje.Split('/');
                        int codigo = Convert.ToInt32(div[0]);
                        string mensaje1 =Convert.ToString(div[1]);
                        if (codigo==0)
                        {
                            MessageBox.Show(mensaje1);
                            Loged = true;
                        }
                        else 
                        {
                            MessageBox.Show(mensaje1);

                        }
  
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
                string mensaje = "0/" + nombre.Text + "/" + pwd.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                MessageBox.Show(mensaje);
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                Connect = false;
                Loged = false;
                Conect_Click = false;
                nombre.Clear();
                pwd.Clear();
                connlbl.Text = " ";
                dataGridView1.Rows.Clear();
                server.Close();
            }
            else
            {
                MessageBox.Show("No hay ninguna conexión no establecida");
            }
        }


        private void conectB_Click(object sender, EventArgs e)
        {
            if (Connect)
            {
                string mensaje = "6/" + nombre.Text + "/" + pwd.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[100];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 1;
                dataGridView1.ColumnHeadersVisible = true;
                if (mensaje != null)
                {
                    char delimeter = '\n';
                    string[] split = mensaje.Split(delimeter);
                    dataGridView1.Rows.Add(split[0]);
                    int i;
                    for (i = 1; i < split.Length; i++)
                    {
                        dataGridView1.Rows.Add(split[i]);
                    }
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    //dataGridView1.Columns.Add("Column",mensaje[0]);
                    //connlbl.Text = mensaje;
                }
                else
                    connlbl.Text = "0 usuarios conectados";
            }
            else
                MessageBox.Show("Inicie conexión");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



     
    }
}
