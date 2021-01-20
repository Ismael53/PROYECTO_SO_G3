using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{//medida optima 1250; 750
    public partial class Main_Display : Form
    {

        public string usuario;
        public int num_conn;
        public string mensaje_invitados;
        public int deposito;

        // Gestion de partidas
        List<String> anadir_partida = new List<String>();
        Poker[] formpartidas_poker = new Poker[100];
        Black_Jack[] formpartidas_BJ = new Black_Jack[100];
        Ruleta[] formpartidas_ruleta = new Ruleta[100];
        int form_poker = 0;
        int form_BJ = 0;
        int form_ruleta = 0;
        int[] VectorPartidas_poker = new int[100];
        int[] VectorPartidas_BJ = new int[100];
        int[] VectorPartidas_ruleta = new int[100];
        int actual_juego = -1;
        int Partida;
        bool enPartida = false;

        int numero_jugadores_poker;
        string[] jugadores_poker;

        // Delegados
        public delegate void enviarString(string mensaje);//delegado para enviar mensajes a la pantalla de inicio
        public event enviarString envio;
        //public delegate void pasar(string invitados);
        //public event pasar pasado;        
        //public delegate void delegadochat(string mensaje);
        //public event delegadochat message_chat;
        public delegate void delegadounirpartida(string mensaje);
        public event delegadounirpartida unirpartida;
        public delegate void delegadomostrarinicio();
        public event delegadomostrarinicio volver_inicio;
        //public delegate void delegadoingreso(string mensaje);
        //public event delegadoingreso mensaje_ingreso;
        public delegate void delegadoApagar();
        public event delegadoApagar message_off;
        public string mensaje_chat;
        public int cont_anadidos = 0;
        bool anadir = true;
        bool profile_open = false;
        Perfil perfil = new Perfil();

        public Main_Display()
        {
            InitializeComponent();
            Design();
        }

        private void Main_Display_Load(object sender, EventArgs e)
        {
            this.Refresh();
            Menu.BackColor = Color.FromArgb(0, 0, 0); //11, 7, 17
            Games.BackColor = Color.FromArgb(35, 32, 39);
            partidas.BackColor = Color.FromArgb(35, 32, 39);
            partidas.Visible = false;
            //panelchildForm.BackColor = Color.FromArgb(32, 30, 45);

            dataGridView1.BackgroundColor = Color.FromArgb(35, 32, 39);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.GridColor = Color.FromArgb(0, 0, 0);
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Green;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            data_partidas.BackgroundColor = Color.FromArgb(35, 32, 39);
            data_partidas.DefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            data_partidas.DefaultCellStyle.ForeColor = Color.White;
            data_partidas.GridColor = Color.FromArgb(0, 0, 0);
            data_partidas.ColumnHeadersVisible = true;
            data_partidas.EnableHeadersVisualStyles = false;
            data_partidas.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            data_partidas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            data_partidas.DefaultCellStyle.SelectionBackColor = Color.Green;
            data_partidas.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Green;
            this.data_partidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            player_1.Text = "";
            player_1.SelectionColor = Color.White;

            player_1.AppendText(usuario);
            player_1.SelectionAlignment = HorizontalAlignment.Center;
            Welcome.BackColor = Color.FromArgb(175, Color.Black);
            

            
            Inicio.FlatAppearance.BorderSize = 0;
            Jugar.FlatAppearance.BorderSize = 0;
            poker.FlatAppearance.BorderSize = 0;
            black_jack.FlatAppearance.BorderSize = 0;
            ruleta.FlatAppearance.BorderSize = 0;
            profile.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            partidas_button.FlatAppearance.BorderSize = 0;
            user_label.FlatAppearance.BorderSize = 0;
            unir_partida.FlatAppearance.BorderSize = 0;
            eliminar_invitacion.FlatAppearance.BorderSize = 0;

            //this.WindowState = FormWindowState.Maximized;
            this.Text = usuario;
            pictureBox1.Location = new Point((pictureBox1.Parent.ClientSize.Width / 2) - (pictureBox1.Width / 2), (pictureBox1.Parent.ClientSize.Height / 2) - (pictureBox1.Height / 2));
            //panelchildForm.BackgroundImage = Properties.Resources.fichas;
            //panelchildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

        }


        #region DesignSubMenu
        //Region para el diseño de los submenus
        private void Design()
        {
            Games.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (Games.Visible == true)
                Games.Visible = false;
        }

        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }
        #endregion
        #region GamesMenu
        // Gestiona la creacion de partidas
        private void Jugar_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(Games);
        }

        public int crearPartida(int juego)
        {
            if (anadir_partida.Count() == 0)
            {
                return -1;
            }
            else
            {
                var random = new Random();
                int partida = random.Next(1000);
                mensaje_invitados = "7/" + juego + "/" + partida + "/" + usuario + "/";

                int i;
                for (i = 0; i < anadir_partida.Count(); i++)
                {
                    mensaje_invitados = mensaje_invitados + anadir_partida[i] + "/";
                }
                return 0;
            }

        }

        public string Darinvitados()
        {
            return mensaje_invitados;
        }

        private void poker_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            int abrir = crearPartida(0);
            if (abrir == 0)
            {
                anadir = false;
                envio(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;

            }
            else
                MessageBox.Show("No hay usuarios seleccionados");
        }

        private void black_jack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disponible próximamente");
            /*
            ocultarSubMenu();
            int abrir = crearPartida(1);
            if (abrir == 0)
            {
                anadir = false;
                envio(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;
            }
            else
                MessageBox.Show("No hay usuarios seleccionados");
             */
        }

        private void ruleta_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            int abrir = crearPartida(2);
            if (abrir == 0)
            {
                anadir = false;
                envio(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;
            }
            else
                MessageBox.Show("No hay usuarios seleccionados");
        }
        #endregion
        #region AbrirForm
        // Gestiona la apertura de los forms cuando nos unimos a una partida
        private Form formAbierto = null;
        private void abrirChildForm(Form childForm)
        {

            formAbierto = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelchildForm.Controls.Add(childForm);
            panelchildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        public int darPosicionPartida(int partida)
        // Retorna la posicion de la partida actual en el vector de partidas
        {
            int i = 0;
            int pos = -1;
            switch (actual_juego)
            {
                case -1:
                    break;
                case 0:
                    while (i < VectorPartidas_poker.Length)
                    {
                        if (VectorPartidas_poker[i] == partida)
                        {
                            pos = i;
                        }
                        i = i + 1;
                    }
                    break;
                case 1:
                    while (i < VectorPartidas_BJ.Length)
                    {
                        if (VectorPartidas_BJ[i] == partida)
                        {
                            pos = i;
                        }
                        i = i + 1;
                    }
                    break;
                case 2:
                    while (i < VectorPartidas_ruleta.Length)
                    {
                        if (VectorPartidas_ruleta[i] == partida)
                        {
                            pos = i;
                        }
                        i = i + 1;
                    }
                    break;
            }
            return pos;
        }

        public void borrar_invitados()
        {
            player_2.Clear();
            player_3.Clear();
            player_4.Clear();
            player_5.Clear();
            cont_anadidos = 0;
        }

        private void Inicio_Click(object sender, EventArgs e)
        // Vuelve a la ventana de inicio, ocultando todos los forms que esten abiertos
        {
            int pos = darPosicionPartida(Partida);
            if ((pos == -1) && !profile_open)
            {
                MessageBox.Show("Ninguna partida iniciada");
            }
            else
            {
                for (int i = 0; i < formpartidas_poker.Count() && formpartidas_poker[i] != null; i++)
                {
                    formpartidas_poker[i].Hide();

                }
                for (int i = 0; i < formpartidas_BJ.Count() && formpartidas_BJ[i] != null; i++)
                {
                    formpartidas_BJ[i].Hide();

                }
                for (int i = 0; i < formpartidas_ruleta.Count() && formpartidas_ruleta[i] != null; i++)
                {
                    formpartidas_ruleta[i].Hide();

                }
                borrar_invitados();
                anadir = true;
                profile_open = false;

            }
            perfil.Hide();
        }

        public void ActualizarConectados(string[] mensaje)
        // Añadimos todos los usuarios conectados que nos llega por mensaje al datagridview 
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;
            int i;
            for (i = 0; i < num_conn; i++)
            {
                if (mensaje[i] != usuario)
                    dataGridView1.Rows.Add(mensaje[i]);
            }
        }

        public void ActualizarPartidas(string[] ID, string[] juego)
        // Añadimos al datagridview las partidas en las que juega el usuario. Expresamos el ID de partida y el tipo de juego de esta.
        {
            data_partidas.Rows.Clear();
            data_partidas.ColumnCount = 2;
            int i;
            string Juego = "";
            for (i = 0; i < ID.Length; i++)
            {
                switch (Convert.ToInt32(juego[i]))
                {
                    case 0:
                        Juego = "Poker";
                        break;
                    case 1:
                        Juego = "Black Jack";
                        break;
                    case 2:
                        Juego = "Ruleta";
                        break;
                }
                data_partidas.Rows.Add(ID[i], Juego);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        // Añade a una nueva partida el usuario seleccionado en el datagridview
        {
            if (anadir)
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    int i;
                    int encontrado = 0;
                    for (i = 0; i < anadir_partida.Count(); i++)
                    {
                        if (anadir_partida[i] == Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value))
                        {
                            MessageBox.Show("El usuario ya ha sido invitado");
                            encontrado = 1;
                            break;
                        }

                    }
                    if (encontrado == 0)
                    {
                        anadir_partida.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        cont_anadidos++;
                        if (cont_anadidos == 1)
                        {
                            
                            player_2.SelectionColor = Color.White;
                            player_2.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_2.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 2)
                        {
                            
                            player_3.SelectionColor = Color.White;
                            player_3.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_3.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 3)
                        {
                            
                            player_4.SelectionColor = Color.White;
                            player_4.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_4.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 4)
                        {
                            
                            player_5.SelectionColor = Color.White;
                            player_5.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_5.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else
                            MessageBox.Show("No se pueden añadir más jugadores");
                    }
                }
                else
                    MessageBox.Show("Seleccione con quien jugar");
            }

            else
            {
                MessageBox.Show("Vuelva a la pantalla de inicio para crear una nueva partida");
            }
        }


        public string DarChat()
        {
            return mensaje_chat;
        }

        public void recibirChat(int juego, int partida, string autor, string msg)
        // Cuando recibe un mensaje de chat del servidor, lo envia al form correspondiente
        {
            int i;
            switch (juego)
            {
                case 0:
                    for (i = 0; i < VectorPartidas_poker.Count(); i++)
                    {
                        if (VectorPartidas_poker[i] == partida)
                        {
                            formpartidas_poker[i].recibirChat(partida, autor, msg);
                        }
                    }
                    break;

                case 1:
                    for (i = 0; i < VectorPartidas_BJ.Count(); i++)
                    {
                        if (VectorPartidas_BJ[i] == partida)
                        {
                            formpartidas_BJ[i].recibirChat(partida, autor, msg);
                        }
                    }
                    break;

                case 2:
                    for (i = 0; i < VectorPartidas_ruleta.Count(); i++)
                    {
                        if (VectorPartidas_ruleta[i] == partida)
                        {
                            formpartidas_ruleta[i].recibirChat(partida, autor, msg);
                        }
                    }
                    break;
            }
        }

        public void recibir_delegado_juegos(string Message_chat)
        {
            envio(Message_chat);
        }
        public void enviarMensaje(string mensaje)
        {
            envio(mensaje);
        }
        public void Iniciar_Partida(int codigo, int partida)
        // Recibe un codigo con el tipo de juego y una ID de partida. Creará una nueva partida con la ID que recibe por parámetro
        {
            enPartida = true;
            Partida = partida;
            if (codigo == 0)
            {
                Poker poker = new Poker();
                poker.partida = partida;
                poker.usuario = usuario;
                poker.deposito = deposito;
                poker.message_chat += new Poker.delegadochat(recibir_delegado_juegos);
                formpartidas_poker[form_poker] = (poker);
                VectorPartidas_poker[form_poker] = partida;
                form_poker = form_poker + 1;
                abrirChildForm(poker);
                actual_juego = 0;
            }
            else if (codigo == 1)
            {
                Black_Jack BJ = new Black_Jack();
                BJ.partida = partida;
                BJ.usuario = usuario;
                BJ.message_chat += new Black_Jack.delegadochat(recibir_delegado_juegos);
                formpartidas_BJ[form_BJ] = (BJ);
                VectorPartidas_BJ[form_BJ] = partida;
                form_BJ = form_BJ + 1;
                abrirChildForm(BJ);
                actual_juego = 1;
            }
            else if (codigo == 2)
            {
                Ruleta ruleta = new Ruleta();
                ruleta.deposito = deposito;
                ruleta.partida = partida;
                ruleta.usuario = usuario;
                ruleta.message_chat += new Ruleta.delegadochat(recibir_delegado_juegos);
                ruleta.apuesta_string += new Ruleta.delegadoApuesta(enviarMensaje);
                formpartidas_ruleta[form_ruleta] = (ruleta);
                VectorPartidas_ruleta[form_ruleta] = partida;
                form_ruleta = form_ruleta + 1;
                abrirChildForm(ruleta);
                actual_juego = 2;
            }
        }

        public void Finalizar_Partida(int codigo, int partida)
        // Recibe por parametro un codigo de juego y una ID de partida, y finaliza la partida
        {
            switch (actual_juego)
            {
                case 0:
                    for (int i = 0; i < formpartidas_poker.Length; i++)
                    {
                        if (VectorPartidas_poker[i] == partida)
                        {
                            formpartidas_poker[i].Close();
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < formpartidas_BJ.Length; i++)
                    {
                        if (VectorPartidas_BJ[i] == partida)
                        {
                            formpartidas_BJ[i].Close();
                        }
                    }
                    break;

                case 2:
                    for (int i = 0; i < formpartidas_ruleta.Length; i++)
                    {
                        if (VectorPartidas_ruleta[i] == partida)
                        {
                            formpartidas_ruleta[i].Close();
                        }
                    }
                    break;
            }
            borrar_invitados();
        }

        private void partidas_button_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(partidas);
        }

        private void unir_partida_Click(object sender, EventArgs e)
        // Se une a la partida seleccionada en el datagridview
        {
            if (data_partidas.CurrentRow != null && data_partidas.CurrentRow.Cells[0].Value != null)
            {
                int juego;
                int pu = Convert.ToInt32(data_partidas.CurrentRow.Cells[0].Value);
                if (Convert.ToString(data_partidas.CurrentRow.Cells[1].Value) == "Poker")
                {
                    juego = 0;
                    int i;
                    for (i = 0; i < form_poker; i++)
                    {
                        if (VectorPartidas_poker[i] == pu)
                        {
                            abrirChildForm(formpartidas_poker[i]);
                            Partida = pu;
                            break;
                        }
                    }
                }
                else if (Convert.ToString(data_partidas.CurrentRow.Cells[1].Value) == "Black Jack")
                {
                    juego = 1;
                    int i;
                    for (i = 0; i < form_BJ; i++)
                    {
                        if (VectorPartidas_BJ[i] == pu)
                        {
                            abrirChildForm(formpartidas_BJ[i]);
                            Partida = pu;
                            break;
                        }
                    }
                }
                else
                {
                    juego = 2;
                    int i;
                    for (i = 0; i < form_ruleta; i++)
                    {
                        if (VectorPartidas_ruleta[i] == pu)
                        {
                            abrirChildForm(formpartidas_ruleta[i]);
                            Partida = pu;
                            break;
                        }
                    }
                }
                string mensajeUP = "12/" + juego + "/" + pu + "/" + usuario;
                actual_juego = juego;
                anadir = false;
            }
            else
                MessageBox.Show("Seleccione una partida para unirse");
        }

        private void Main_Display_FormClosed(object sender, FormClosedEventArgs e)
        {
            volver_inicio();
        }
        public bool ing = false;
        public void setING(string Message_ingreso)
        {
            if (ing == false)
            {
                envio(Message_ingreso);
                ing = true;
            }
        }
        public void enviar_ingreso(string Message_ingreso, bool ingresado)
        {
            if (!ingresado)
            {

                ingresado = true;
            }
        }
        private void profile_Click(object sender, EventArgs e)
        {
            perfil.message_ingreso += new Perfil.delegadoingreso(setING);
            perfil.message_out += new Perfil.delegadobaja(enviarMensaje);
            perfil.message_off += new Perfil.delegadoApagar(Desconectar);
            perfil.usuario = usuario;
            update_cash(deposito);
            anadir = false;
            profile_open = true;
            abrirChildForm(perfil);
        }
        public void Actualizar_deposito(int deposito)
        {
            update_cash(deposito);
            perfil.actualizar_deposito(deposito);
            int i;
            
            for (i = 0; i < form_poker; i++)
            {
                formpartidas_poker[i].actualizar_deposito(deposito);
            }
            /*
            for (i = 0; i < form_BJ; i++)
            {
                formpartidas_BJ[i].Close();
            }
             */
            for (i = 0; i < form_ruleta; i++)
            {
                formpartidas_ruleta[i].actualizar_deposito(deposito);
            }
        }
        public void update_cash(int deposito)
        {
            perfil.actualizar_deposito(deposito);

        }
        
        /*
        public void IniciarTimerRuleta(int juego, int partida)
        {
            int i;
            for (i = 0; i < form_ruleta; i++)
            {
                if (VectorPartidas_ruleta[i] == partida)
                {
                    break;
                }
            }
            formpartidas_ruleta[i].IniciarTimer();

        }
         */
        public void Recibir_Respuesta(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            int codigo = Convert.ToInt32(trozos[0]);
            switch (codigo)
            {
                case 12:
                    int hack12 = Convert.ToInt32(trozos[1]);
                    string mensaje12 = trozos[2];
                    perfil.Recibir_respuesta(hack12, mensaje12);
                    ing = false;
                    break;
            }
        }
        public void Recibir_jugadores_poker(int numero, string[] jugadores, int partida)
        {
            for (int i = 0; i < form_poker; i++)
            {
                if (VectorPartidas_poker[i] == partida)
                {
                    formpartidas_poker[i].RecibirJugadores(numero, jugadores);
                    break;
                }
            }
        }
        public void iniciar_partida_poker(int partida)
        {
            for (int i = 0; i < form_poker; i++)
            {
                if (VectorPartidas_poker[i] == partida)
                {
                    formpartidas_poker[i].iniciar_partida();
                    break;
                }
            }
        }
        public void enviar_cartas_poker(int partida, string[] cartas)
        {
            for (int i = 0; i < form_poker; i++)
            {
                if (VectorPartidas_poker[i] == partida)
                {
                    formpartidas_poker[i].RecibirCartas(cartas);
                    break;
                }
            }

        }
        public void enviar_jugada_poker(int partida, string jugador, int jugada,int apuesta,int deposito)
        {
            for (int i = 0; i < form_poker; i++)
            {
                if (VectorPartidas_poker[i] == partida)
                {
                    formpartidas_poker[i].RecibirJugada(jugador,jugada,apuesta,deposito);
                    break;
                }
            }
        }
        public void enviar_table_cards_poker(int partida, int ronda, string[] cartas)
        {
            for (int i = 0; i < form_poker; i++)
            {
                if (VectorPartidas_poker[i] == partida)
                {
                    formpartidas_poker[i].recieve_table_cards(ronda,cartas);
                    break;
                }
            }
        }
    
        public void resultado_Ruleta(int partida, string mensaje, int ganancias)
        {
            for (int i = 0; i < form_ruleta; i++)
            {
                if (VectorPartidas_ruleta[i] == partida)
                {
                    formpartidas_ruleta[i].resultado(mensaje, ganancias);
                    break;
                }
            }

        }
        public void Desconectar()
        {
            Cerrar_forms();
            message_off();
        }
        public void Cerrar_forms()
        {
            perfil.Close();
            int i;
            for (i = 0; i < form_poker; i++)
            {
                formpartidas_poker[i].Close();
            }

            for (i = 0; i < form_BJ; i++)
            {
                formpartidas_BJ[i].Close();
            }
            for (i = 0; i < form_ruleta; i++)
            {
                formpartidas_ruleta[i].Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void RecibirBaja(int hack, string mensaje)
        {
            perfil.RecibirBaja(hack,mensaje);
        }
        public void AbandonarPartida(int juego, int partida, int hack)
        {
            switch (juego)
            {
                /*
            case 0:
                for (int i = 0; i < form_poker; i++)
                {
                    if (VectorPartidas_poker[i] == partida)
                    {
                        formpartidas_poker[i].Close();
                    }
                }
                break;

            case 1:
                for (int i = 0; i < form_BJ; i++)
                {
                    if (VectorPartidas_BJ[i] == partida)
                    {
                        formpartidas_BJ[i].Close();
                    }
                }
                break;
            */
                case 2:
                    for (int i = 0; i < form_ruleta; i++)
                    {
                        if (VectorPartidas_ruleta[i] == partida)
                        {
                            if (hack == 1)
                            {
                                VectorPartidas_ruleta[i] = 0;
                                formpartidas_ruleta[i].Close();
                                anadir = true;
                                borrar_invitados();

                            }
                            else if (hack == 2)
                            {
                                formpartidas_ruleta[i].AbandonarPartida(hack);
                                VectorPartidas_ruleta[i] = 0;
                                formpartidas_ruleta[i].Close();
                                anadir = true;
                                borrar_invitados();
                            }
                            else
                            {
                                formpartidas_ruleta[i].AbandonarPartida(hack);

                            }
                            break;
                        }
                    }
                    break;
            }

        }

        private void eliminar_invitacion_Click(object sender, EventArgs e)
        // Elimina el ultimo usuario añadido a la invitación
        {
            if (cont_anadidos != 0)
            {
                anadir_partida.Remove(anadir_partida[cont_anadidos - 1]);

                if (cont_anadidos == 1)
                {
                    player_2.Clear();
                }
                else if (cont_anadidos == 2)
                {
                    player_3.Clear();
                }
                else if (cont_anadidos == 3)
                {
                    player_4.Clear();
                }
                else if (cont_anadidos == 4)
                {
                    player_5.Clear();
                }
                cont_anadidos = cont_anadidos - 1;
            }

            else
            {
                MessageBox.Show("Ningún usuario añadido");
            }
        }

        private void anadir_player_Click(object sender, EventArgs e)
        {
            if (anadir)
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    int i;
                    int encontrado = 0;
                    for (i = 0; i < anadir_partida.Count(); i++)
                    {
                        if (anadir_partida[i] == Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value))
                        {
                            MessageBox.Show("El usuario ya ha sido invitado");
                            encontrado = 1;
                            break;
                        }

                    }
                    if (encontrado == 0)
                    {
                        anadir_partida.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        cont_anadidos++;
                        if (cont_anadidos == 1)
                        {

                            player_2.SelectionColor = Color.White;
                            player_2.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_2.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 2)
                        {

                            player_3.SelectionColor = Color.White;
                            player_3.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_3.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 3)
                        {

                            player_4.SelectionColor = Color.White;
                            player_4.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_4.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 4)
                        {

                            player_5.SelectionColor = Color.White;
                            player_5.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            player_5.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else
                            MessageBox.Show("No se pueden añadir más jugadores");
                    }
                }
                else
                    MessageBox.Show("Seleccione con quien jugar");
            }

            else
            {
                MessageBox.Show("Vuelva a la pantalla de inicio para crear una nueva partida");
            }
        }

        private void eliminar_player_Click(object sender, EventArgs e)
        {
            if (cont_anadidos != 0)
            {
                anadir_partida.Remove(anadir_partida[cont_anadidos - 1]);

                if (cont_anadidos == 1)
                {
                    player_2.Clear();
                }
                else if (cont_anadidos == 2)
                {
                    player_3.Clear();
                }
                else if (cont_anadidos == 3)
                {
                    player_4.Clear();
                }
                else if (cont_anadidos == 4)
                {
                    player_5.Clear();
                }
                cont_anadidos = cont_anadidos - 1;
            }

            else
            {
                MessageBox.Show("Ningún usuario añadido");
            }
        }
    }
}

