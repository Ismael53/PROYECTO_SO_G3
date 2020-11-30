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
    public partial class Ruleta : Form
    {
        public int partida;
        public Ruleta()
        {
            InitializeComponent();
        }

        private void Ruleta_Load(object sender, EventArgs e)
        {
            Pantalla_inicio get = new Pantalla_inicio();
            label1.Text = "Ruleta Partida:" + partida;
            this.BackColor = Color.FromArgb(32, 30, 45);
        }
    }
}
