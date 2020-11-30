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
        Form [] formpartidas=new Form[100];
        int fpInd = 0;
        int[] VectorPartidas=new int [100];
        int VpInd = 0;
        public delegate void pasar(string invitados);
        public event pasar pasado;

        public delegate void delegadochat(string mensaje);
        public event delegadochat message_chat;

        public string mensaje_chat;

        public int cont_anadidos = 2;

        

        public Main_Display()
        {
            InitializeComponent();
            Design();
            
        }

        private void Main_Display_Load(object sender, EventArgs e)
        {
            this.Refresh();
            Menu.BackColor = Color.FromArgb(11,7,17);
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

            player_1.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            player_1.SelectionColor = Color.White;
            player_1.AppendText("Player 1:\r\n");
            player_1.SelectionFont = new Font("Microsoft Sans Serif", 13);
            player_1.SelectionColor = Color.White;
            player_1.AppendText(usuario);

            player_2.Text = "";
            player_3.Text = "";
            player_4.Text = "";
            player_5.Text = "";
            

            chat_background.BackColor = Color.FromArgb(11, 7, 17);
            main_chat.BackColor = Color.FromArgb(11, 7, 17);
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
            main_chat.Size = new System.Drawing.Size(882, 110);
            this.WindowState = FormWindowState.Maximized;
            this.Text = usuario;

            MessageBox.Show("Bienvenido al mejor Casino Online\nPara poder comenzar una partida debes de seleccionar jugadores\nque esten connectados y añadirlos a una nuva partida\nSelecciona el modo de juego y que empieze la diversion");
            pictureBox1.Location = new Point((pictureBox1.Parent.ClientSize.Width / 2) - (pictureBox1.Width / 2),(pictureBox1.Parent.ClientSize.Height / 2) - (pictureBox1.Height / 2));

            
            
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
                int partida = random.Next();
                mensaje_invitados = "7/"+juego+"/" +partida+"/"+ usuario + "/";

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

                pasado(Darinvitados());
                anadir_partida.Clear();
                
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
                
                pasado(Darinvitados());
                anadir_partida.Clear();
               

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
                
                pasado(Darinvitados());
                anadir_partida.Clear();
            
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

        private void Inicio_Click(object sender, EventArgs e)
        {
            
            
        }
        
        public void ActualizarConectados(string[] mensaje)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;            
            int i;
            for (i = 0; i < num_conn; i++)
            {
                if(mensaje[i]!=usuario)
                    dataGridView1.Rows.Add(mensaje[i]);
            }
            

        }

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                anadir_partida.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                if (cont_anadidos == 2)
                {
                    player_2.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                    player_2.SelectionColor = Color.White;
                    player_2.AppendText("Player" + Convert.ToString(cont_anadidos) + ":\r\n");
                    player_2.SelectionFont = new Font("Microsoft Sans Serif", 13);
                    player_2.SelectionColor = Color.White;
                    player_2.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (cont_anadidos == 3)
                {
                    player_3.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                    player_3.SelectionColor = Color.White;
                    player_3.AppendText("Player" + Convert.ToString(cont_anadidos) + ":\r\n");
                    player_3.SelectionFont = new Font("Microsoft Sans Serif", 13);
                    player_3.SelectionColor = Color.White;
                    player_3.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (cont_anadidos == 4)
                {
                    player_4.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                    player_4.SelectionColor = Color.White;
                    player_4.AppendText("Player" + Convert.ToString(cont_anadidos) + ":\r\n");
                    player_4.SelectionFont = new Font("Microsoft Sans Serif", 13);
                    player_4.SelectionColor = Color.White;
                    player_4.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (cont_anadidos == 5)
                {
                    player_5.SelectionFont = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                    player_5.SelectionColor = Color.White;
                    player_5.AppendText("Player" + Convert.ToString(cont_anadidos) + ":\r\n");
                    player_5.SelectionFont = new Font("Microsoft Sans Serif", 13);
                    player_5.SelectionColor = Color.White;
                    player_5.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else
                    MessageBox.Show("No se pueden añadir más jugadores");
                cont_anadidos++;
                
            }
            else
                MessageBox.Show("Seleccione con quien jugar");
        }
        public int enviarChat()
        {
            if (enviar_chat.Text=="")
            {
                return -1;
            }
            else
            {
                mensaje_chat = "9/" + usuario + "/" + chat_text.Text;
                return 0;                
            }

        }
        public string DarChat()
        {
            return mensaje_chat;
        }

        public void recibirChat(string autor, string msg)
        {
            main_chat.SelectionFont = new Font("Microsoft Sans Serif",9,FontStyle.Bold);
            main_chat.SelectionColor = Color.Green;
            main_chat.AppendText(autor);
            main_chat.SelectionFont = new Font("Microsoft Sans Serif", 8);
            main_chat.SelectionColor = Color.White;
            main_chat.AppendText(" :\n" + msg + "\r\n");
            main_chat.ScrollToCaret();
            
        }
        

        private void enviar_chat_Click(object sender, EventArgs e)
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

        private void chat_text_KeyDown(object sender, KeyEventArgs e)
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

        private void hide_chat_Click(object sender, EventArgs e)
        {
            chat_background.Visible = false;
        }

        public void Iniciar_Partida(int codigo, int partida)
        {
            if (codigo == 0)
            {
                Poker poker = new Poker();
                poker.partida = partida;
                formpartidas[fpInd]=(poker);
                VectorPartidas[VpInd] = partida;
                fpInd = fpInd + 1;
                VpInd = VpInd + 1;
                abrirChildForm(poker);
            }
            else if (codigo == 1)
            {
                Black_Jack BJ = new Black_Jack();
                BJ.partida = partida;
                formpartidas[fpInd] = (BJ);
                VectorPartidas[VpInd] = partida;
                fpInd = fpInd + 1;
                VpInd = VpInd + 1;
                abrirChildForm(BJ);
            }
            else if (codigo == 2)
            {
                Ruleta ruleta = new Ruleta();
                ruleta.partida = partida;
                formpartidas[fpInd] = (ruleta);
                VectorPartidas[VpInd] = partida;
                fpInd = fpInd + 1;
                VpInd = VpInd + 1;
                abrirChildForm(ruleta);
            }


        }

        public void Finalizar_Partida(int codigo, int partida)
        {
            for (int i = 0; i < formpartidas.Length; i++)
            {
                if (VectorPartidas[i] == partida)
                {
                    formpartidas[i].Close();
                }
            }


        }
        private void partidas_button_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(partidas);
        }

        

        
         
        
 
        
    }
}
