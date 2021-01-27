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
    public partial class Estadísticas : Form
    {
        public delegate void delegadoConsulta(string mensaje);
        public event delegadoConsulta message_consulta;
        public string usuario;
        
        public Estadísticas()
        {
            InitializeComponent();
        }

        private void porcentaje_Click(object sender, EventArgs e)
        {
            if (apuesta_tb.Text != "")
            {
                string apuesta = apuesta_tb.Text.ToUpper();
                if (apuesta == "PRIMERA COLUMNA")
                {
                    apuesta = "1C";
                }
                else if (apuesta == "SEGUNDA COLUMNA")
                {
                    apuesta = "2C";
                }
                else if (apuesta == "TERCERA COLUMNA")
                {
                    apuesta = "3C";
                }
                else if (apuesta == "PRIMERA DOCENA")
                {
                    apuesta = "1D";
                }
                else if (apuesta == "SEGUNDA DOCENA")
                {
                    apuesta = "2D";
                }
                else if (apuesta == "TERCERA DOCENA")
                {
                    apuesta = "3D";
                }
                
                string mensaje = "21/0/" + usuario + "/" + apuesta;
                message_consulta(mensaje);
            }
            else
                MessageBox.Show("Introduzca una apuesta");
            apuesta_tb.Text = "";
        }

        private void Estadísticas_Load(object sender, EventArgs e)
        {
            limpiarLabel();
            consultas.BackColor = Color.FromArgb(175, Color.Black);
            panel1.BackColor = Color.FromArgb(175, Color.Black);
            panel2.BackColor = Color.FromArgb(175, Color.Black);
            panel3.BackColor = Color.FromArgb(175, Color.Black);
            panel4.BackColor = Color.FromArgb(175, Color.Black);
            panel6.BackColor = Color.FromArgb(175, Color.Black);
            panel7.BackColor = Color.FromArgb(175, Color.Black);
        }
        public void RecibirResultadoConsulta(int total, int acertadas, int porcentaje, string apuesta)
        {
            MessageBox.Show("El porcentaje de acierto en "+apuesta+" es del "+porcentaje+" % \nCon un total de "+acertadas+" apuestas acertadas sobre un total de "+total+" apuestas realizadas");
        }

        private void BENEFICIOS_Click(object sender, EventArgs e)
        {
            string mensaje = "22/" + usuario;
            message_consulta(mensaje);
        }
        public void limpiarLabel()
        {
            beneficios_lbl.Text = "";
        }
        public void RecibirBeneficio(int beneficios)
        {
            beneficios_lbl.Text =beneficios+"€";
        }
    }
}
