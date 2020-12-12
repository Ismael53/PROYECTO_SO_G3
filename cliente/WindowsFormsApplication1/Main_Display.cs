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
        int actual_juego=-1;

        public delegate void pasar(string invitados);
        public event pasar pasado;
        
        public delegate void delegadochat(string mensaje);
        public event delegadochat message_chat;

        public delegate void delegadounirpartida(string mensaje);
        public event delegadounirpartida unirpartida;

        public delegate void delegadomostrarinicio();
        public event delegadomostrarinicio volver_inicio;


        public string mensaje_chat;

        public int cont_anadidos = 0;
        int Partida;
        bool enPartida = false;

        bool anadir = true;



        public Main_Display()
        {
            InitializeComponent();
            Design();

        }

        private void Main_Display_Load(object sender, EventArgs e)
        {
            this.Refresh();
            Menu.BackColor = Color.FromArgb(11, 7, 17);
            Games.BackColor = Color.FromArgb(35, 32, 39);
            partidas.BackColor = Color.FromArgb(35, 32, 39);
            partidas.Visible = false;
            panelchildForm.BackColor = Color.FromArgb(32, 30, 45);

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
            player_1.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            player_1.SelectionColor = Color.White;
            player_1.AppendText("Player 1:\r\n");
            player_1.SelectionFont = new Font("Microsoft Sans Serif", 13);
            player_1.SelectionColor = Color.White;
            player_1.AppendText(usuario);



            
            
            player_1.BackColor = Color.FromArgb(32, 30, 45);
            player_2.BackColor = Color.FromArgb(32, 30, 45);
            player_3.BackColor = Color.FromArgb(32, 30, 45);
            player_4.BackColor = Color.FromArgb(32, 30, 45);
            player_5.BackColor = Color.FromArgb(32, 30, 45);
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
           
            this.WindowState = FormWindowState.Maximized;
            this.Text = usuario;

            pictureBox1.Location = new Point((pictureBox1.Parent.ClientSize.Width / 2) - (pictureBox1.Width / 2), (pictureBox1.Parent.ClientSize.Height / 2) - (pictureBox1.Height / 2));



        }


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
        #region GamesMenu
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
                pasado(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;

            }
            else
                MessageBox.Show("No hay usuarios seleccionados");



        }

        private void black_jack_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            int abrir = crearPartida(1);
            if (abrir == 0)
            {
                anadir = false;
                pasado(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;


            }
            else
                MessageBox.Show("No hay usuarios seleccionados");
        }

        private void ruleta_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            int abrir = crearPartida(2);
            if (abrir == 0)
            {
                anadir = false;
                pasado(Darinvitados());
                anadir_partida.Clear();
                cont_anadidos = 0;

            }
            else
                MessageBox.Show("No hay usuarios seleccionados");
        }
        #endregion
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

        public int darPosicionPartida(int partida)
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
        {
            int pos = darPosicionPartida(Partida);
            
            if (pos == -1)
            {
                MessageBox.Show("Ninguna partida iniciada");
            }
            else
            {
                for (int i=0; i < formpartidas_poker.Count() && formpartidas_poker[i]!=null; i++)
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
            }


        }

        public void ActualizarConectados(string[] mensaje)
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
                            player_2.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                            player_2.SelectionColor = Color.White;
                            player_2.AppendText("Player" + Convert.ToString(cont_anadidos + 1) + ":\r\n");
                            player_2.SelectionFont = new Font("Microsoft Sans Serif", 13);
                            player_2.SelectionColor = Color.White;
                            player_2.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        }
                        else if (cont_anadidos == 2)
                        {
                            player_3.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                            player_3.SelectionColor = Color.White;
                            player_3.AppendText("Player" + Convert.ToString(cont_anadidos + 1) + ":\r\n");
                            player_3.SelectionFont = new Font("Microsoft Sans Serif", 13);
                            player_3.SelectionColor = Color.White;
                            player_3.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        }
                        else if (cont_anadidos == 3)
                        {
                            player_4.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                            player_4.SelectionColor = Color.White;
                            player_4.AppendText("Player" + Convert.ToString(cont_anadidos + 1) + ":\r\n");
                            player_4.SelectionFont = new Font("Microsoft Sans Serif", 13);
                            player_4.SelectionColor = Color.White;
                            player_4.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        }
                        else if (cont_anadidos == 4)
                        {
                            player_5.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                            player_5.SelectionColor = Color.White;
                            player_5.AppendText("Player" + Convert.ToString(cont_anadidos + 1) + ":\r\n");
                            player_5.SelectionFont = new Font("Microsoft Sans Serif", 13);
                            player_5.SelectionColor = Color.White;
                            player_5.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
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
        /*
        public int enviarChat()
        {
            if (enviar_chat.Text == "")
            {
                return -1;
            }
            else
            {
                mensaje_chat = "9/" + Partida + "/" + usuario + "/" + chat_text.Text;
                return 0;
            }

        }
        */
        public string DarChat()
        {
            return mensaje_chat;
        }

        public void recibirChat(int juego,int partida,string autor, string msg)
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

        /*
        private void enviar_chat_Click(object sender, EventArgs e)
        {
            if (enPartida)
            {
                int enviar_chat = enviarChat();
                if (enviar_chat != -1)
                {
                    message_chat(DarChat());
                    chat_text.Text = "";
                }
                else
                {
                    MessageBox.Show("Escribe alguna cosa");
                }
            }
            else
                MessageBox.Show("Primero cree o entre en una partida");

        }
        

        private void chat_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (enPartida)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int enviar_chat = enviarChat();
                    if (enviar_chat != -1)
                    {
                        message_chat(DarChat());
                        chat_text.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Escribe alguna cosa");
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero cree o entre en una partida");
                chat_text.Text = "";
            }
        }

        private void hide_chat_Click(object sender, EventArgs e)
        {
            //chat_background.Visible = false;
        }
        */
        public void recibir_delegado_juegos(string Message_chat)
        {
            message_chat(Message_chat);

        }
        public void Iniciar_Partida(int codigo, int partida)
        {
            enPartida = true;
            Partida = partida;
            
            if (codigo == 0)
            {
                Poker poker = new Poker();
                poker.partida = partida;
                poker.usuario = usuario;
                poker.message_chat+=new Poker.delegadochat(recibir_delegado_juegos);
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
                ruleta.partida = partida;
                ruleta.usuario = usuario;
                ruleta.message_chat += new Ruleta.delegadochat(recibir_delegado_juegos);
                formpartidas_ruleta[form_ruleta] = (ruleta);
                VectorPartidas_ruleta[form_ruleta] = partida;
                form_ruleta = form_ruleta + 1;
                abrirChildForm(ruleta);
                actual_juego = 2;
            }


        }

        public void Finalizar_Partida(int codigo, int partida)
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

        private void chat_background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void unir_partida_Click(object sender, EventArgs e)
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

        private void chat_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void main_chat_TextChanged(object sender, EventArgs e)
        {

        }

        private void Main_Display_FormClosed(object sender, FormClosedEventArgs e)
        {
            volver_inicio();
            
        }








    }
}
