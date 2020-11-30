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
    public partial class ModoJuego : Form
    {
        public string usuario;
        public ModoJuego()
        {
            InitializeComponent();
            User_label.Text = usuario;
        }

        private void ModoJuego_Load(object sender, EventArgs e)
        {

        }

        private void Poker_Click(object sender, EventArgs e)
        {
            if (Online_rb.Checked)
            {
                Poker f = new Poker();
                f.ShowDialog();
                //Recibimos la respuesta del servidor

            }

            else if (Individual_rb.Checked)
            {
                Poker f = new Poker();
                f.ShowDialog();

                //Recibimos la respuesta del servidor

            }
        }

        private void Ruleta_Click(object sender, EventArgs e)
        {
            if (Online_rb.Checked)
            {
                Ruleta f = new Ruleta();
                f.ShowDialog();
                //Recibimos la respuesta del servidor

            }

            else if (Individual_rb.Checked)
            {
                Ruleta f = new Ruleta();
                f.ShowDialog();

                //Recibimos la respuesta del servidor

            }
        }

        private void Black_Jack_Click(object sender, EventArgs e)
        {
            if (Online_rb.Checked)
            {
                Black_Jack f = new Black_Jack();
                f.ShowDialog();
                //Recibimos la respuesta del servidor

            }

            else if (Individual_rb.Checked)
            {
                Black_Jack f = new Black_Jack();
                f.ShowDialog();  
                //Recibimos la respuesta del servidor

            }
        }
    }
}
