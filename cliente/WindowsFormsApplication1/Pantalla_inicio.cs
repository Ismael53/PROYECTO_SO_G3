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
        delegate void DelegadoParaGrid(string[] mensaje, int codigo);
        delegate void DelegadoParaConectados(string[] mensaje, int codigo);
        delegate void DelegadoParaDesconectar();
        delegate void DelegadoParaEnviarChatMain(int juego, int partida, string autor, string mensaje);
        delegate void DelegadoParaEmpezarPartida(int juego, int partida);
        delegate void DelegadoParaFinalizarPartida(int juego, int partida);
        delegate void DelegadoParaRecibirPartidas(string[] ID, string[] tipo_juego);
        bool Loged = false;
        bool Connect = false;
        int puerto = 50057;
        //ip shiva 147.83.117.22
        //ip local 192.168.56.102 
        public string mensaje_chat;
        public string chat_autor;
        int startGame;
        int partida;
        Main_Display main = new Main_Display();

        public Pantalla_inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage=Properties.Resources.distorsionada;
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            //Custom main background
            this.BackColor = Color.FromArgb(8, 20, 50);
            //0,89,76 green
            //42,42,46 grey
            this.ForeColor = Color.White;
            // Custom title
            //Custom LogIn
            //Custom buttons
            //conn.BackColor = Color.FromArgb(0,50,137);
            //desconn.BackColor = Color.FromArgb(0,50,137);
            jugar.BackColor = Color.FromArgb(0, 50, 137);
            SIGN_IN.BackColor = Color.FromArgb(0, 50, 137);
            LOG_IN.BackColor = Color.FromArgb(0, 50, 137);
            button2.BackColor = Color.FromArgb(0, 50, 137);
            //conn.FlatAppearance.BorderSize = 0;
            desconn.FlatAppearance.BorderSize = 0;
            jugar.FlatAppearance.BorderSize = 0;
            dataGridView1.BackgroundColor = Color.FromArgb(0, 50, 137);
            pwd.UseSystemPasswordChar = true;
        }

        public void PonerEnGrid(string[] mensaje, int hack)
        // Añade al datagridview los nombres de los usuarios conectados. Recibe un mensaje con todos los usuarios, y un integer con el numero de usuarios totales
        {
            jugar.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            dataGridView1.GridColor = Color.FromArgb(8, 20, 50);
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            //dataGridView1.Columns[0].HeaderText = "Usuarios connectados "+Convert.ToString(hack);
            //num_usuarios.Text = Convert.ToString(hack);
            //dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.FromArgb(62, 120, 138);
            //dataGridView1.Columns[0].HeaderCell.Style.ForeColor = Color.FromArgb(41, 44, 51);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 50, 137);
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Green;
            loading_text.Text = "Bienvenido de nuevo " + mensaje[hack - 1];
            int i;
            main.num_conn = hack;
            main.ActualizarConectados(mensaje);
            for (i = 0; i < hack; i++)
            {
                dataGridView1.Rows.Add(mensaje[i]);
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public void Desconectar()
        // Cambia ciertos aspectos del form cuando el usuario se desconecta.
        {
            jugar.Visible = false;
            connect_status.BackColor = default(Color);
            num_usuarios.Text = "No disponible";
            //dataGridView1.Columns[0].HeaderText = "Usuarios connectados";
            connect_status.Text = "Desconectado";
            connect_status.BackColor = Color.Red;
            loading_text.Text = "";

            nombre.Clear();
            pwd.Clear();
            dataGridView1.Rows.Clear();
            Connect = false;
            Loged = false;

        }

        public void EnviarServidorForeignForm(string mensaje)
        // Sirve para enviar un mensaje al servidor desde cualquier form.
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        public void EnviarChatMain(int juego, int partida, string autor, string msg)
        // enviamos al main el mensaje por chat que envia un jugador.
        {
            main.recibirChat(juego, partida, autor, msg);
        }

        public void IniciarPartida(int codigo, int partida)
        // iniciamos una partida del tipo de juego que nos indique el codigo, y con ID partida.
        {
            main.Iniciar_Partida(codigo, partida);
        }

        public void FinalizarPartida(int codigo, int partida)
        // finalizamos una partida del tipo de juego que nos indique el codigo, y con ID partida.
        {
            main.Finalizar_Partida(codigo, partida);
        }

        public void RecibirPartidas(string[] ID_partida, string[] tipo_juego)
        // enviamos una lista de partidas, así como el tipo de juego de cada una al main
        {
            main.ActualizarPartidas(ID_partida, tipo_juego);
        }

        private void AtenderServidor() // Threat para atender al servidor
        {
            while (true)
            {
                // Recibimos mensaje del servidor
                byte[] msg2 = new byte[100];
                server.Receive(msg2);
                string[] error_servidor = Encoding.ASCII.GetString(msg2).Split('\0');
                if (error_servidor[0] == "") //El servidor nos envía un código vacío, de error
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
                            if (hack == 1) // Error en la desconexion
                            {
                                loading_text.Text = (mensaje1);
                            }

                            else // Se puede desconectar correctamente
                            {
                                DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
                                pwd.Invoke(delegado, new object[] { });
                                server.Shutdown(SocketShutdown.Both);
                                server.Close();
                                atender.Abort();
                            }
                            break;

                        case 1://respuesta al sign in
                            string mensaje = trozos[2].Split('\0')[0];
                            int hackS = Convert.ToInt32(trozos[1]);
                            if (hackS == 1) // Se ha iniciado sesion correctamente
                            {
                                MessageBox.Show(mensaje);
                                Loged = true;
                            }

                            else // No se ha podido iniciar sesion, desconectamos al usuario
                            {
                                MessageBox.Show(mensaje);
                                DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
                                pwd.Invoke(delegado, new object[] { });
                                server.Shutdown(SocketShutdown.Both);
                                server.Close();
                                atender.Abort();
                            }
                            break;

                        case 2: //respuesta al log in
                            string mensaje2 = trozos[2].Split('\0')[0];
                            int hack1 = Convert.ToInt32(trozos[1]);
                            if (hack1 == 0) // Se ha iniciado sesion correctamente
                            {
                                Loged = true;
                                main.usuario = nombre.Text;
                            }

                            else// No se ha podido iniciar sesion, desconectamos al usuario
                            {
                                MessageBox.Show(mensaje2);
                                DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
                                pwd.Invoke(delegado, new object[] { });
                                server.Shutdown(SocketShutdown.Both);
                                server.Close();
                                atender.Abort();
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

                        case 6: //el servidor nos envía la lista de conectados actualizada
                            int hack6 = Convert.ToInt32(trozos[1]); // numero de usuarios conectados
                            if (hack6 == 0) // El numero de usuarios conectados es 0
                                MessageBox.Show("No hay usuarios connectados");

                            else
                            {
                                string[] mensaje6 = new string[hack6];
                                for (int i = 0; i < hack6; i++) // añadimos a los usuarios al datagridview
                                {
                                    mensaje6[i] = (trozos[i + 2].Split('\0')[0]);
                                }
                                DelegadoParaGrid delegado = new DelegadoParaGrid(PonerEnGrid);
                                dataGridView1.Invoke(delegado, new object[] { mensaje6, hack6 });
                                this.Invoke(delegado, new object[] { mensaje6, hack6 });
                                //dataGridView1.Columns.Add("Column",mensaje[0]);
                                //connlbl.Text = mensaje;
                            }
                            break;

                        case 7://respuesta en caso de invitar a jugadores a unirse a una partida
                            int hack7 = Convert.ToInt32(trozos[1]);
                            int juego = Convert.ToInt32(trozos[2]);
                            int partida = Convert.ToInt32(trozos[3]);
                            string game;
                            if (juego == 0)
                                game = "Poker";
                            else if (juego == 1)
                                game = "Black Jack";
                            else
                                game = "Ruleta";

                            if (hack7 == 0)// respuesta para el anfitrión
                            {
                                DelegadoParaEmpezarPartida delegado7 = new DelegadoParaEmpezarPartida(IniciarPartida);
                                this.Invoke(delegado7, new object[] { juego, partida });
                                int num_invitados = Convert.ToInt32(trozos[4]);
                                //MessageBox.Show("Los jugadores a los que se ha invitado a la partida " + partida + "del juego" + game);
                                string[] invitados = new string[num_invitados];
                                for (int i = 0; i < num_invitados; i++)
                                {
                                    invitados[i] = (trozos[i + 5].Split('\0')[0]);
                                    //MessageBox.Show(invitados[i]);
                                }
                            }

                            else //respuesta para el invitado
                            {
                                string anfitrion = trozos[4];
                                string MessageBoxTitle = "Invitación de partida";
                                string MessageBoxContent = anfitrion + " te ha retado a una partida de " + game + "\nDeseas aceptarla?";
                                string respuesta_invitation;
                                DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        MessageBox.Show("La partida se iniciará en unos instantes");
                                        respuesta_invitation = "8/" + juego + "/" + partida + "/" + anfitrion + "/" + nombre.Text + "/" + Convert.ToString(result) + "/1";
                                        byte[] accept = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);
                                        server.Send(accept);
                                        break;
                                    case DialogResult.No:
                                        MessageBox.Show("Bet hard or go home");
                                        respuesta_invitation = "8/" + juego + "/" + partida + "/" + anfitrion + "/" + nombre.Text + "/" + Convert.ToString(result) + "/0";
                                        byte[] decline = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);
                                        server.Send(decline);
                                        break;
                                }
                            }
                            break;

                        case 8://respuestas de aceptar o declinar la invitación
                            int hack8 = Convert.ToInt32(trozos[1]);
                            int juego8 = Convert.ToInt32(trozos[2]);
                            int partida8 = Convert.ToInt32(trozos[3]);
                            string game8;
                            if (juego8 == 0)
                                game8 = "Poker";
                            else if (juego8 == 1)
                                game8 = "Black Jack";
                            else
                                game8 = "Ruleta";

                            if (hack8 == 0)// respuesta para invitado
                            {
                                MessageBox.Show("La respuesta a la partida " + partida8 + " del juego " + game8 + " se ha enviado correctamente");
                            }

                            else if (hack8 == 1)//respuesta para anfitrion de los distintos invitados
                            {
                                string invitado = trozos[4];
                                string respuesta_inv = trozos[5];
                                MessageBox.Show("Respuesta del invitado " + invitado + " a la partida " + partida8 + " del juego " + game8 + " es " + respuesta_inv);
                                if (respuesta_inv == "Yes")
                                {
                                    string partidaStart = "10/" + invitado + "/" + juego8 + "/" + partida8;
                                    startGame = startGame + 1;

                                    byte[] gameStart = System.Text.Encoding.ASCII.GetBytes(partidaStart);
                                    server.Send(gameStart);
                                    /* if (startGame == 1)
                                     {
                                         DelegadoParaEmpezarPartida delegado8 = new DelegadoParaEmpezarPartida(IniciarPartida);
                                         this.Invoke(delegado8, new object[] { juego8, partida8 });
                                     }
                                     */
                                }
                            }

                            else if (hack8 == 2)// respuesta para anfitrion para cancelar la partida
                            {
                                MessageBox.Show("La partida " + partida8 + "del juego " + game8 + " se canceló");
                                DelegadoParaFinalizarPartida delegado8 = new DelegadoParaFinalizarPartida(FinalizarPartida);
                                this.Invoke(delegado8, new object[] { juego8, partida8 });
                            }

                            else if (hack8 == -1)//respuesta para el invitado si el anfitrion se desconnecta
                            {
                                MessageBox.Show("El anfitrion se desconecto");
                            }
                            break;

                        case 9://el servidor nos envía un mensaje que alguien ha escrito por el chat de la partida
                            int juego9 = Convert.ToInt32(trozos[1]);
                            int partida9 = Convert.ToInt32(trozos[2]);
                            chat_autor = trozos[3];
                            mensaje_chat = trozos[4];
                            DelegadoParaEnviarChatMain delegado9 = new DelegadoParaEnviarChatMain(EnviarChatMain);
                            this.Invoke(delegado9, new object[] { juego9, partida9, chat_autor, mensaje_chat });
                            break;

                        case 10: // el servidor nos envía una orden de inicio de partida
                            int juego10 = Convert.ToInt32(trozos[1]);
                            int partida10 = Convert.ToInt32(trozos[2]);
                            DelegadoParaEmpezarPartida delegado10 = new DelegadoParaEmpezarPartida(IniciarPartida);
                            this.Invoke(delegado10, new object[] { juego10, partida10 });
                            break;

                        case 11://el servidor nos envía la lista de partidas
                            int num_partidas = Convert.ToInt32(trozos[1]);
                            string[] ID11 = new string[num_partidas];
                            string[] juego11 = new string[num_partidas];
                            int indice = 0;
                            int counter = 0;
                            while (indice < num_partidas)
                            {
                                ID11[indice] = (trozos[counter + 2]);
                                juego11[indice] = (trozos[counter + 3]);
                                counter = counter + 2;
                                indice = indice + 1;

                            }
                            DelegadoParaRecibirPartidas delegado11 = new DelegadoParaRecibirPartidas(RecibirPartidas);
                            this.Invoke(delegado11, new object[] { ID11, juego11 });
                            break;
                    }
                }
            }
        }

        private void desconn_Click(object sender, EventArgs e)
        // Si hay una sesion iniciada, envia al servidor una peticion de desconectar. De lo contrario, indica que no hay ninguna sesion abierta.
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

        private void button2_Click(object sender, EventArgs e)
        // Boton para realizar una de las tres consultas al servidor
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
                    }

                    else if (Consulta_2.Checked)
                    {
                        string mensaje = "4/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }

                    else if (Consulta_3.Checked)
                    {
                        string mensaje = "5/" + nombre.Text + "/" + pwd.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
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

        private void SIGN_IN_Click_1(object sender, EventArgs e)
        {
            if (!Loged)
            {
                if (nombre.Text != "" & pwd.Text != "")
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse(IP.Text);
                    IPEndPoint ipep = new IPEndPoint(direc, puerto);
                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        connect_status.BackColor = Color.Green;
                        connect_status.Text = "Conectado";
                        connect_status.ForeColor = Color.Black;
                        Connect = true;
                        loading_text.Text = "Conexion establecida comprovando credenciales...";
                    }

                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        loading_text.Text = "No he podido conectar con el servidor" + ex.ErrorCode;
                        return;
                    }
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
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
                MessageBox.Show("Cierre la sesión actual primero por favor");
        }

        private void LOG_IN_Click_1(object sender, EventArgs e)
        {
            if (!Loged)
            {
                if (nombre.Text != "" & pwd.Text != "")
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse(IP.Text);
                    IPEndPoint ipep = new IPEndPoint(direc, puerto);
                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        connect_status.BackColor = Color.Green;
                        connect_status.Text = "Conectado";
                        connect_status.ForeColor = Color.Black;
                        Connect = true;
                        loading_text.Text = "Connexión establecida\nComprobando credenciales";
                    }

                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        loading_text.Text = "No he podido conectar con el servidor" + ex.ErrorCode;
                        return;
                    }

                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                    string mensaje = "2/" + nombre.Text + "/" + pwd.Text;
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
                MessageBox.Show("Sesión ya iniciada");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connect)
            {
                MessageBox.Show("Por favor asegurese de desconnectarse del servidor antes de cerrar la ventana");
                e.Cancel = true;
            }
        }

        private void mostrar_inicio()
        {
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Loged)
            {
                main.usuario = nombre.Text;
                main.pasado += new Main_Display.pasar(EnviarServidorForeignForm);
                main.message_chat += new Main_Display.delegadochat(EnviarServidorForeignForm);
                main.volver_inicio += new Main_Display.delegadomostrarinicio(mostrar_inicio);
                this.Visible = false;
                main.ShowDialog();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //TopMost = true;
        }
    }
}