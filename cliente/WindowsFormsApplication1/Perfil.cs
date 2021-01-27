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
    public partial class Perfil : Form
    {
        Estadísticas Estadisticas;
        public int deposito;
        public string usuario;
        public delegate void delegadoingreso(string mensaje);
        public event delegadoingreso message_ingreso;
        public delegate void delegadobaja(string mensaje);
        public event delegadobaja message_out;
        public delegate void delegadoApagar();
        public event delegadoApagar message_off;
        public Perfil()
        {
            InitializeComponent();
        }
        private void Perfil_Load(object sender, EventArgs e)
        {
            deposito_tb.Text =Convert.ToString(deposito)+"€";
            pwd.UseSystemPasswordChar = true;
            account_panel.BackColor = Color.FromArgb(175, Color.Black);
            delete_panel.BackColor = Color.FromArgb(175, Color.Black);

        }
        public void actualizar_deposito(int Deposito)
        {
            deposito_tb.Text = Convert.ToString(Deposito) + "€";
            deposito = Deposito;
        }
        private void ingresar_btn_Click(object sender, EventArgs e)
        {
            if (ingreso.Text != "")
            {
                try
                {
                    int ig = Convert.ToInt32(ingreso.Text);
                    string mensaje1 = "";
                    mensaje1 = "12/" + usuario + "/" + ingreso.Text;

                    message_ingreso(mensaje1);
                }
                catch (Exception)
                {
                    MessageBox.Show("Introduzca un valor numérico por favor");
                    ingreso.Text = "";

                }

            }
            else
                MessageBox.Show("Introduzca una cantidad");
        }
        public void Recibir_respuesta(int hack, string mensaje)
        {
            if (hack == 1)
            {
                MessageBox.Show("Ingreso realizado correctamente");
                //deposito = deposito + Convert.ToInt32(ingreso.Text);
                //deposito_tb.Text =Convert.ToString(deposito)+"€";
            }
            else
                MessageBox.Show("No se ha podido realizar el ingreso correctamente, vuelva a intentarlo más tarde");
            ingreso.Text = "";
        }

        
        public void RecibirBaja(int hack, string mensaje)
        {
            MessageBox.Show(mensaje);
            switch (hack)
            {
                case 0://usuario incorrecto
                    break;
                case 1://contraseña incorrecta
                    break;
                case 2://fallo del servidor mysql
                    break;
                case 3://
                    message_off();
                    this.Close();
                    break;
            }
            nombre.Text = "";
            pwd.Text = "";
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (nombre.Text != "" & pwd.Text != "")
            {
                string mensajeB = "15/" + nombre.Text + "/" + pwd.Text;
                message_out(mensajeB);
            }
            else
            {
                MessageBox.Show("Rellene usuario y contraseña por favor");
                
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

        
        public void sendmessage(string mensaje)
        {
            message_out(mensaje);
        }
        private void estadisticas_Click(object sender, EventArgs e)
        {
            Estadisticas = new Estadísticas();
            Estadisticas.message_consulta += new Estadísticas.delegadoConsulta(sendmessage);
            Estadisticas.usuario = usuario;
            Estadisticas.limpiarLabel();
            Estadisticas.ShowDialog();

        }
        public void EnviarRespuestaConsultaApuesta(int total, int acertadas, int porcentaje, string apuesta)
        {
            Estadisticas.RecibirResultadoConsulta(total, acertadas, porcentaje, apuesta);

        }
        public void EnviarBeneficio(int beneficios)
        {
            Estadisticas.RecibirBeneficio(beneficios);
        }
    }
}
