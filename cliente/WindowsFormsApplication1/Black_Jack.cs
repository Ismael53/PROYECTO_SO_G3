using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Black_Jack : Form
    {
        public int partida;
        public string mensaje_chat;
        public string usuario;

        public delegate void delegadochat(string mensaje);
        public event delegadochat message_chat;

        public Black_Jack()
        {
            InitializeComponent();
        }

        private void Black_Jack_Load(object sender, EventArgs e)
        {
            Pantalla_inicio get = new Pantalla_inicio();
            label1.Text = "Black Jack Partida:" + partida;
            this.BackColor = Color.FromArgb(32, 30, 45);
            main_chat.BackColor = Color.FromArgb(11, 7, 17);
            main_chat.Size = new System.Drawing.Size(882, 110);
            main_chat.Text = "";
            chat_background.BackColor = Color.FromArgb(11, 7, 17);
        }
        public int enviarChat()
        {
            if (enviar_chat.Text == "")
            {
                return -1;
            }
            else
            {
                mensaje_chat = "9/1/" + partida + "/" + usuario + "/" + chat_text.Text;
                return 0;
            }

        }
        public string DarChat()
        {
            return mensaje_chat;
        }

        public void recibirChat(int Partida, string autor, string msg)
        {
            if (Partida == partida)
            {
                main_chat.SelectionFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                main_chat.SelectionColor = Color.Green;
                main_chat.AppendText(autor);
                main_chat.SelectionFont = new Font("Microsoft Sans Serif", 8);
                main_chat.SelectionColor = Color.White;
                main_chat.AppendText(" :\n" + msg + "\r\n");
                main_chat.ScrollToCaret();
            }

        }


       
        private void hide_chat_Click(object sender, EventArgs e)
        {
            //chat_background.Visible = false;
        }

        private void enviar_chat_Click_1(object sender, EventArgs e)
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

        private void chat_text_KeyDown_1(object sender, KeyEventArgs e)
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

        
    }
}
