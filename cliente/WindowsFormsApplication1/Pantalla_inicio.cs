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
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Pantalla_inicio : Form
    {
        SoundPlayer Player;
        Socket server;
        Thread atender;
        delegate void DelegadoParaGrid(string[] mensaje, int codigo);
        delegate void DelegadoParaConectados(string[] mensaje, int codigo);
        delegate void DelegadoParaDesconectar();
        delegate void DelegadoParaEnviarChatMain(int juego, int partida, string autor, string mensaje);
        delegate void DelegadoParaEnviarJugadoresPoker(int numero, string[] jugadores,int partida);
        delegate void DelegadoParaEnviarCartasAlPoker(int partida, string[] cartas);
        delegate void DelegadoParaIniciarPartidaPoker(int partida);
        delegate void DelegadoParaEnviarJugadaPoker(int partida, string jugador, int jugada,int apuesta,int deposito);
        delegate void DelegadoParaEnviarCartasMesaPoker(int partida, int ronda, string[] cartas_mesa);
        delegate void DelegadoParaEmpezarPartida(int juego, int partida);
        delegate void DelegadoParaFinalizarPartida(int juego, int partida);
        delegate void DelegadoParaRecibirPartidas(string[] ID, string[] tipo_juego);
        //delegate void DelegadoTimerRuleta(int juego, int partida);
        delegate void DelegadoRespuesta(string mensaje);
        delegate void DelegadoDeposito(int Deposito);
        delegate void DelegadoCerrar();
        delegate void DelegadoResultadoRuleta(int partida13, string mensaje13, int ganancias);
        delegate void DelegadoParaRespuestaBaja(int hack, string mensaje);
        delegate void DelegadoParaAbandonarPartida(int juego, int partida, int hack);
        bool Loged = false;
        bool Connect = false;
        int puerto = 9000;
        //ip shiva 147.83.117.22
        //ip local 192.168.56.102 
        public string mensaje_chat;
        public string chat_autor;
        public int deposito;
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
            desconn.BackColor = Color.FromArgb(0, 50, 137);
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
            desconn.Visible = true;
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
            desconn.Visible = false;
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
        /*
        public void IniciarTimerRuleta(int juego, int partida)
        {
            main.IniciarTimerRuleta(juego, partida);
        }
        */
        public void EnviarRespuesta(string mensaje)//función para pasar respuestas al formulario main
        {
            main.Recibir_Respuesta(mensaje);
        }
        public void EnviarJugadoresPoker(int numero, string[] jugadores,int partida)
        {
            main.Recibir_jugadores_poker(numero, jugadores,partida);
        }
        public void Iniciar_poker(int partida)
        {
            main.iniciar_partida_poker(partida);
        }
        public void EnviarCartasPoker(int partida, string[] jugadores)
        {
            main.enviar_cartas_poker(partida, jugadores); 
        }
        public void EnviarJugadaPoker(int partida, string usuario, int jugada,int apuesta,int deposito)
        {
            main.enviar_jugada_poker(partida, usuario, jugada,apuesta,deposito);
        }
        public void EnviarCartasMesaPoker(int partida, int ronda, string[] cartas_mesa)
        {
            main.enviar_table_cards_poker(partida, ronda, cartas_mesa);
        }
        public void actualizar_deposito(int Deposito)
        {
            main.deposito = Deposito;
            main.Actualizar_deposito(Deposito);
        }
        public void cerrar()
        {
            main.Cerrar_forms();
        }
        public void resultado_ronda_Ruleta(int partida, string mensaje, int ganancias)
        {
            main.resultado_Ruleta(partida, mensaje, ganancias);
        }
        public void EnviarBaja(int hack, string mensaje)
        {
            main.RecibirBaja(hack, mensaje);
        }
        public void AbandonarPartida(int juego, int partida, int hack)
        {
            main.AbandonarPartida(juego, partida, hack);
        }
        private void AtenderServidor() // Threat para atender al servidor
        {
            while (true)
            {
                // Recibimos mensaje del servidor
                byte[] msg2 = new byte[200];
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
                                DelegadoCerrar delegadoC = new DelegadoCerrar(cerrar);
                                pwd.Invoke(delegadoC, new object[] { });
                                main.Close();
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
                                main = new Main_Display();
                                deposito = Convert.ToInt32(trozos[3]);
                                main.usuario = nombre.Text;
                                main.deposito = deposito;
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
                            /*
                            else if (hack8 == 3)//iniciar el timmer para la ruleta
                            {
                                DelegadoTimerRuleta delegado83 = new DelegadoTimerRuleta(IniciarTimerRuleta);
                                this.Invoke(delegado83, new object[] { juego8, partida8 });

                            }
                             */
                            else if (hack8 == 4) // recibimos los jugadores que participan en la partida de poker en el buen orden
                            {
                                int juego8_4 = Convert.ToInt32(trozos[2]);
                                int partida8_4 = Convert.ToInt32(trozos[3]);
                                int numero_jugadores = Convert.ToInt32(trozos[4]);
                                string[] jugadores_8_4=new string[numero_jugadores*2];
                                for (int i_8_4 = 0; i_8_4 < numero_jugadores*2; i_8_4++)
                                {
                                    jugadores_8_4[i_8_4] = trozos[i_8_4 + 5]; 
                                }
                                DelegadoParaEnviarJugadoresPoker delegado8_4 = new DelegadoParaEnviarJugadoresPoker(EnviarJugadoresPoker);
                                this.Invoke(delegado8_4, new object[] { numero_jugadores, jugadores_8_4, partida8_4 });
 
                            }
                            else if (hack8 == 5) // se notifica al anfitrion que inicie la partida de poker
                            {
                                System.Threading.Thread.Sleep(500);
                                int juego8_5 = Convert.ToInt32(trozos[2]);
                                int partida8_5 = Convert.ToInt32(trozos[3]);
                                if (juego8_5 == 0)
                                {
                                    DelegadoParaIniciarPartidaPoker delegado8_5 = new DelegadoParaIniciarPartidaPoker(Iniciar_poker);
                                    this.Invoke(delegado8_5, new object[] { partida8_5 });
 
                                }
 
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
                        case 12: //el servidor nos envía la respuesta de hacer un ingreso
                            int hack12 = Convert.ToInt32(trozos[1]);
                            deposito = deposito + Convert.ToInt32(trozos[2]);
                            string mensaje12 =codigo+"/"+trozos[1]+"/"+trozos[2];
                            DelegadoRespuesta delegado12 = new DelegadoRespuesta(EnviarRespuesta);
                            this.Invoke(delegado12, new object[] { mensaje12 });
                            DelegadoDeposito delegadoD = new DelegadoDeposito(actualizar_deposito);
                            this.Invoke(delegadoD, new object[] { deposito });
                            break;
                        case 13://RECIBIMOS EL RESULTADO DE LA RULETA
                            int hack13 = Convert.ToInt32(trozos[1]);
                            int partida13 = Convert.ToInt32(trozos[2]);
                            int ganancias = Convert.ToInt32(trozos[(trozos.Length) - 1]);
                            int depos = Convert.ToInt32(trozos[3]);
                            deposito = depos;
                            DelegadoDeposito delegadoD1 = new DelegadoDeposito(actualizar_deposito);
                            this.Invoke(delegadoD1, new object[] { deposito });
                            int numG = Convert.ToInt32(trozos[4]);
                            string mensaje13 = "El número ganador es " + numG + ", ";
                            if (numG != 0)//si se diese el caso especial del 0 no cuenta como par ni tiene color ni pertenece a ningún grupo
                            {
                                int i = 5;
                                while (i < trozos.Length - 1)
                                {
                                    mensaje13 = mensaje13 + trozos[i] + ", ";
                                    i = i + 1;
                                }
                                DelegadoResultadoRuleta delegado13 = new DelegadoResultadoRuleta(resultado_ronda_Ruleta);
                                this.Invoke(delegado13, new object[] { partida13, mensaje13, ganancias });


                            }
                            break;

                        case 14: // Recibimos que cartas va a tener cada jugador
                            int partida_14 = Convert.ToInt32(trozos[1]);
                            int jugadores_poker = Convert.ToInt32(trozos[2]);
                            string[] cartas=new string [jugadores_poker*5+4];
                            for (int i_14 = 0; i_14 < jugadores_poker * 5 + 4; i_14++)
                            {
                                cartas[i_14] = trozos[i_14+2];
                            }
                            DelegadoParaEnviarCartasAlPoker delegado14 = new DelegadoParaEnviarCartasAlPoker(EnviarCartasPoker);
                            this.Invoke(delegado14, new object[] { partida_14, cartas });
                                break;
                        case 15: //el servidor nos envia la respuesta al intentar dar de baja una cuenta
                            int hack15 = Convert.ToInt32(trozos[1]);
                            string mensaje15 = trozos[2];
                            DelegadoParaRespuestaBaja delegado15 = new DelegadoParaRespuestaBaja(EnviarBaja);
                            this.Invoke(delegado15, new object[] { hack15, mensaje15 });
                            break;
                        case 16://el servidor nos envia la respuesta al abandonar una partida
                            int hack16 = Convert.ToInt32(trozos[3]);
                            int juego16 = Convert.ToInt32(trozos[1]);
                            int partida16 = Convert.ToInt32(trozos[2]);
                            DelegadoParaAbandonarPartida delegado16 = new DelegadoParaAbandonarPartida(AbandonarPartida);
                            this.Invoke(delegado16, new object[] { juego16, partida16, hack16 });
                            break;

                        case 17: // recibimos jugada
                            int partida_17 = Convert.ToInt32(trozos[1]);
                            string usuario_17 = trozos[2];
                            int jugada_17 = Convert.ToInt32(trozos[3]);
                            int apuesta_17 = 0;
                            int deposito_17 = 0;
                            if (jugada_17 != 0)
                            {
                                apuesta_17 = Convert.ToInt32(trozos[4]);
                                deposito_17 = Convert.ToInt32(trozos[5]);
                            }
                            DelegadoParaEnviarJugadaPoker delegado_17 = new DelegadoParaEnviarJugadaPoker(EnviarJugadaPoker);
                            this.Invoke(delegado_17, new object[] { partida_17, usuario_17, jugada_17,apuesta_17,deposito_17 });

                            break;
                        case 18:
                            int dep = Convert.ToInt32(trozos[1]);
                            DelegadoDeposito delegadoD18 = new DelegadoDeposito(actualizar_deposito);
                            this.Invoke(delegadoD18, new object[] { dep });
                            int hack18 = Convert.ToInt32(trozos[2]);
                            if (hack18 == 1)
                            {
                                int num_partidas1 = Convert.ToInt32(trozos[3]);
                                string[] ID111 = new string[num_partidas1];
                                string[] juego111 = new string[num_partidas1];
                                int indice1 = 0;
                                int counter1 = 0;
                                while (indice1 < num_partidas1)
                                {
                                    ID111[indice1] = (trozos[counter1 + 4]);
                                    juego111[indice1] = (trozos[counter1 + 5]);
                                    counter1 = counter1 + 2;
                                    indice1 = indice1 + 1;

                                }
                                DelegadoParaRecibirPartidas delegado18 = new DelegadoParaRecibirPartidas(RecibirPartidas);
                                this.Invoke(delegado18, new object[] { ID111, juego111 });
                                break;
                            }
                            break;
                        case 19:
                            int partida_19 = Convert.ToInt32(trozos[1]);
                            int ronda = Convert.ToInt32(trozos[2]);
                            string [] cartas_19;
                            if (ronda == 0)
                            {
                                cartas_19 = new string[6];
                                for(int i_19=0;i_19<6;i_19++)
                                {
                                    cartas_19[i_19] = trozos[i_19 + 3];
                                }
                            }
                            else if (ronda == 1)
                            {
                                cartas_19 = new string[2]; 
                                for (int i_19 = 0; i_19 < 2; i_19++)
                                {
                                    cartas_19[i_19] = trozos[i_19 + 3];
                                }
                            }
                            else 
                            {
                                cartas_19 = new string[2];
                                for (int i_19 = 0; i_19 < 2; i_19++)
                                {
                                    cartas_19[i_19] = trozos[i_19 + 3];
                                }
                            }
                            DelegadoParaEnviarCartasMesaPoker delegado_19 = new DelegadoParaEnviarCartasMesaPoker(EnviarCartasMesaPoker);
                            this.Invoke(delegado_19, new object[] { partida_19, ronda, cartas_19 });

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
                main.deposito = deposito;
                main.envio += new Main_Display.enviarString(EnviarServidorForeignForm);
                //main.pasado += new Main_Display.pasar(EnviarServidorForeignForm);
                //main.message_chat += new Main_Display.delegadochat(EnviarServidorForeignForm);
                //main.mensaje_ingreso += new Main_Display.delegadoingreso(EnviarServidorForeignForm);
                main.volver_inicio += new Main_Display.delegadomostrarinicio(mostrar_inicio);
                main.message_off += new Main_Display.delegadoApagar(Baja);
                this.Visible = false;
                main.ShowDialog();
            }

            else
            {
                MessageBox.Show("Inicie sesión por favor");
            }
        }
        public void Baja()
        {
            DelegadoParaDesconectar delegado = new DelegadoParaDesconectar(Desconectar);
            pwd.Invoke(delegado, new object[] { });
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            DelegadoCerrar delegadoC = new DelegadoCerrar(cerrar);
            pwd.Invoke(delegadoC, new object[] { });
            main.Close();
            atender.Abort();
            
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

        private void music_CheckedChanged(object sender, EventArgs e)
        {
            if (music.Checked)
            {
                Player = new SoundPlayer(Application.StartupPath + @"\sonidos\1.wav");
                Player.Play();
            }
            else
            {
                Player = new SoundPlayer(Application.StartupPath + @"\sonidos\1.wav");
                Player.Stop();
            }
        }
    }
}