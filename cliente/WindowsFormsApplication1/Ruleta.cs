using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
namespace WindowsFormsApplication1
{
    public partial class Ruleta : Form
    {
        public int partida;
        public string mensaje_chat;
        public string usuario;
        public int deposito;
        public int ficha_actual = 0;
        public delegate void delegadochat(string mensaje);
        public event delegadochat message_chat;
        public delegate void delegadoApuesta(string mensaje);
        public event delegadoApuesta apuesta_string;
        public string[] apuestas = new string[49];
        public int[] CantidadApostada = new int[49];
        PictureBox[] casillas = new PictureBox[49];
        public int Napuestas;
        public string ficha_act;
        public int total_apostado;
        string apuesta_actual;
        public bool enviado = false;
        public Ruleta()
        {
            InitializeComponent();
        }

        private void Ruleta_Load(object sender, EventArgs e)
        {
            Pantalla_inicio get = new Pantalla_inicio();
            //label1.Text = "Ruleta Partida:" + partida;
            this.BackColor = Color.FromArgb(32, 30, 45);
            main_chat.BackColor = Color.FromArgb(11, 7, 17);
            main_chat.Size = new System.Drawing.Size(882, 110);
            chat_background.BackColor = Color.FromArgb(11, 7, 17);
            main_chat.Text = "";
            total_deposito.Text = deposito + "€";
            panel_apuestas.BackColor = Color.FromArgb(175, Color.Black);

        }
        public int enviarChat()
        {
            if (enviar_chat.Text == "")
            {
                return -1;
            }
            else
            {
                mensaje_chat = "9/2/" + partida + "/" + usuario + "/" + chat_text.Text;
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



        private void total_deposito_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        public int counter;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time_label.Text =Convert.ToString(counter);
            counter = counter - 1;
            if (counter == 0)
            {
                timer1.Stop();
                counter = 60;
                MessageBox.Show("No va más");
            }

        }
        public void IniciarTimer()
        {
            counter = 60;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            MessageBox.Show("Hagan sus apuestas");
        }
         */
        public void reiniciarRonda()
        {
            enviado = false;
            cantidad_apostada.Text = "";
            int i = 0;
            while (i < Napuestas)
            {
                apuestas[i] = "";
                CantidadApostada[i] = 0;
                casillas[i].Image = null;
                i = i + 1;
            }
            Napuestas = 0;
            ficha_act = "";
            total_apostado = 0; ;
            apuesta_actual = "";
            label4.Text = "";
            ficha_tb.Text = "";
        }
        public void actualizar_deposito(int Deposito)
        {
            deposito = Deposito;
            total_deposito.Text = deposito + "€";
        }
        public void resultado(string mensaje, int ganancias)
        {
            if (ganancias == 0)
            {
                MessageBox.Show(mensaje + "\n" + "Lo sentimos " + usuario + ", pruebe otra vez suerte");
            }
            else
                MessageBox.Show(mensaje + "\n" + "Felicidades " + usuario + " ha ganado " + ganancias + "€");

            reiniciarRonda();
        }

        // sección de selección de fichas

        //ficha 1€
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 1 && ficha_actual != 1)
                {
                    ficha_actual = 1;
                    ficha_tb.Text = "1€";
                    ficha_act = "ficha_1_e_p";
                }
                else if (ficha_actual == 1)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                    MessageBox.Show("Crédito insuficiente");
            }
            else
                MessageBox.Show("Apuesta ya enviada");
        }

        //ficha 5€
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 5 && ficha_actual != 5)
                {
                    ficha_actual = 5;
                    ficha_tb.Text = "5€";
                }
                else if (ficha_actual == 5)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                    MessageBox.Show("Crédito insuficiente");

            }
            else
                MessageBox.Show("Apuesta ya enviada");
        }

        //ficha 10€
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 10 && ficha_actual != 10)
                {
                    ficha_actual = 10;
                    ficha_tb.Text = "10€";
                }
                else if (ficha_actual == 10)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente");
                }
            }
            else
                MessageBox.Show("Apuesta ya enviada");
        }

        //ficha 50€
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 50 && ficha_actual != 50)
                {
                    ficha_actual = 50;
                    ficha_tb.Text = "50€";
                }
                else if (ficha_actual == 50)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente");
                }
            }
            else
                MessageBox.Show("Apuesta ya enviada");

        }

        //ficha 100€
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 100 && ficha_actual != 100)
                {
                    ficha_actual = 100;
                    ficha_tb.Text = "100€";
                }
                else if (ficha_actual == 100)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente");
                }
            }
            else
                MessageBox.Show("Apuesta ya enviada");
        }

        //ficha 500€
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 500 && ficha_actual != 500)
                {
                    ficha_actual = 500;
                    ficha_tb.Text = "500€";
                }
                else if (ficha_actual == 500)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente");
                }
            }
            else
                MessageBox.Show("Apuesta ya enviada");

        }

        //ficha 1000€
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (deposito >= 1000 && ficha_actual != 1000)
                {
                    ficha_actual = 1000;
                    ficha_tb.Text = "1000€";
                }
                else if (ficha_actual == 1000)
                {
                    ficha_tb.Text = "0";
                    ficha_actual = 0;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente");
                }
            }
            else
                MessageBox.Show("Apuesta ya enviada");

        }


        //anular apuestas
        /*
        private void Borrar_todo_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (Napuestas > 0)
                {
                    for (int i = 0; i < Napuestas; i++)
                    {
                        apuestas[i] = "";
                        CantidadApostada[i] = 0;
                        casillas[i].Image = null;
                    }
                    Napuestas = 0;
                    deposito = deposito + total_apostado;
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    total_apostado = 0;
                    cantidad_apostada.Text = total_apostado + "€";
                }
                else
                {
                    MessageBox.Show("No hay apuestas todavía");
                }
            }
        }

         */
        /*
        private void Borrar_anterior_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (Napuestas > 0)
                {
                    deposito = deposito + CantidadApostada[Napuestas - 1];
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    apuestas[Napuestas - 1] = "";
                    total_apostado = total_apostado - CantidadApostada[Napuestas - 1];
                    cantidad_apostada.Text = total_apostado + "€";
                    CantidadApostada[Napuestas - 1] = 0;
                    casillas[Napuestas - 1].Image = null;
                    Napuestas = Napuestas - 1;
                }
                else
                    MessageBox.Show("No hay apuestas todavía");
            }
        }
        */

        public int eliminarApuesta(string apuesta)
        {

            int encontrado = 0;
            int i;
            for (i = 0; i < Napuestas; i++)
            {

                if (apuestas[i] == apuesta_actual)
                {
                    encontrado = 1;
                    deposito = deposito + CantidadApostada[i];
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    apuestas[i] = "";
                    total_apostado = total_apostado - CantidadApostada[i];
                    cantidad_apostada.Text = total_apostado + "€";
                    CantidadApostada[i] = 0;
                    casillas[i].Image = null;
                    Napuestas = Napuestas - 1;
                }
                if (encontrado == 1 && i < (Napuestas - 1))
                {
                    apuestas[i] = apuestas[i + 1];
                    CantidadApostada[i] = CantidadApostada[i + 1];
                    casillas[i] = casillas[i + 1];
                }
            }
            if (encontrado == 1)
            {
                return 1;//ha podido eliminar la apuesta seleccionada
            }
            else
                return 0;//no hay ninguna apuesta en la casilla seleccionada
        }
        private void borrar_selec_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (apuesta_actual == "")
                {
                    MessageBox.Show("Seleccione la apuesta que desea eliminar");
                }
                else
                {
                    int a = eliminarApuesta(apuesta_actual);
                    if (a == 1)
                    {
                        string mensaje = "Apuesta en " + apuesta_actual + " eliminada correctamente";
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        string mensaje = "No hay ninguna apuesta en " + apuesta_actual;
                        MessageBox.Show(mensaje);
                    }

                }
            }


        }

        //sección selección apuesta
        public void anadir_apuesta(string apuesta, int cantidad, PictureBox pb)
        {
            if (deposito >= cantidad)
            {
                int encontrado = 0;
                int i;
                for (i = 0; i < Napuestas; i++)
                {
                    if (apuestas[i] == apuesta)
                    {
                        encontrado = 1;
                        break;
                    }
                }
                if (encontrado == 1)
                {
                    CantidadApostada[i] = CantidadApostada[i] + cantidad;

                }
                else
                {
                    apuestas[Napuestas] = apuesta;
                    CantidadApostada[Napuestas] = cantidad;
                    casillas[Napuestas] = pb;
                    Napuestas = Napuestas + 1;

                }
                deposito = deposito - cantidad;
                total_deposito.Text = Convert.ToInt32(deposito) + "€";
                total_apostado = total_apostado + cantidad;
                cantidad_apostada.Text = total_apostado + "€";
            }
            else
                MessageBox.Show("Crédito insuficiente");

        }
        public int apuestaYaRealizada(string apuesta) //método para saber si se ha apostado en una casilla
        {
            int encontrado = 0;
            int i;
            for (i = 0; i < Napuestas; i++)
            {
                if (apuestas[i] == apuesta)
                {
                    encontrado = 1;
                    break;
                }
            }
            if (encontrado == 1)
            {
                return 1;

            }
            else
            {
                return 0;
            }

        }
        public void colocarFicha(int ficha_actual, PictureBox pb)
        {
            if (deposito >= ficha_actual)
            {
                switch (ficha_actual)
                {
                    case 1:
                        pb.Image = Properties.Resources.ficha_1_e_p;
                        break;
                    case 5:
                        pb.Image = Properties.Resources.ficha_5_e_p;
                        break;
                    case 10:
                        pb.Image = Properties.Resources.ficha_10_e_p;
                        break;
                    case 50:
                        pb.Image = Properties.Resources.ficha_50_e_p;
                        break;
                    case 100:
                        pb.Image = Properties.Resources.ficha_100_e_p;
                        break;
                    case 500:
                        pb.Image = Properties.Resources.ficha_500_e_p;
                        break;
                    case 1000:
                        pb.Image = Properties.Resources.ficha_1000_e_p;
                        break;

                }
            }

        }
        //casilla 0
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox9;
                apuesta_actual = "0";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);

                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }

        }
        //casilla 1
        private void pictureBox57_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox57;
                apuesta_actual = "1";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla 2
        private void pictureBox44_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox44;
                apuesta_actual = "2";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }

        }

        //casilla rojo
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox15;
                apuesta_actual = "ROJO";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla primera columna
        private void pictureBox56_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox56;
                apuesta_actual = "1C";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }

        //casilla 3
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox19;
                apuesta_actual = "3";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla 4
        private void pictureBox53_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox53;
                apuesta_actual = "4";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }


        //casilla 5
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox40;
                apuesta_actual = "5";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }

        //casilla 6
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox21;
                apuesta_actual = "6";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }

        //casilla 7
        private void pictureBox52_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox52;
                apuesta_actual = "7";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }

        }
        //casilla 8
        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox39;
                apuesta_actual = "8";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 9
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox22;
                apuesta_actual = "9";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 10
        private void pictureBox51_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox51;
                apuesta_actual = "10";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }

        }
        // casilla 11
        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox38;
                apuesta_actual = "11";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 12
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox23;
                apuesta_actual = "12";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 13
        private void pictureBox55_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox55;
                apuesta_actual = "13";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 14
        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox42;
                apuesta_actual = "14";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 15
        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox32;
                apuesta_actual = "15";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 16
        private void pictureBox54_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox54;
                apuesta_actual = "16";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 17
        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox41;
                apuesta_actual = "17";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 18
        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox33;
                apuesta_actual = "18";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 19
        private void pictureBox50_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox50;
                apuesta_actual = "19";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 20
        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox37;
                apuesta_actual = "20";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 21
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox20;
                apuesta_actual = "21";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 22
        private void pictureBox49_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox49;
                apuesta_actual = "22";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 23
        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox36;
                apuesta_actual = "23";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 24
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox24;
                apuesta_actual = "24";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 25
        private void pictureBox48_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox48;
                apuesta_actual = "25";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 26
        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox35;
                apuesta_actual = "26";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 27
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox25;
                apuesta_actual = "27";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 28
        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox47;
                apuesta_actual = "28";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 29
        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox34;
                apuesta_actual = "29";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 30
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox26;
                apuesta_actual = "30";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 31
        private void pictureBox46_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox46;
                apuesta_actual = "31";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 32
        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox30;
                apuesta_actual = "32";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }

        //casilla 33
        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox27;
                apuesta_actual = "33";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 34
        private void pictureBox45_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox45;
                apuesta_actual = "34";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 35
        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox29;
                apuesta_actual = "35";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla 36
        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox28;
                apuesta_actual = "36";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");
                }
            }
        }
        //casilla segunda columna
        private void pictureBox43_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox43;
                apuesta_actual = "2C";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla tercera columna
        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox31;
                apuesta_actual = "3C";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla primera docena
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox10;
                apuesta_actual = "1D";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla segunda docena
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox11;
                apuesta_actual = "2D";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }

        }
        //casilla tercera docena
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox12;
                apuesta_actual = "3D";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //casilla falta (1-18)
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox13;
                apuesta_actual = "FALTA";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //CASILLA PAR
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox14;
                apuesta_actual = "PAR";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }

        }
        //CASILLA NEGRO
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox16;
                apuesta_actual = "NEGRO";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //CASILLA IMPAR
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox17;
                apuesta_actual = "IMPAR";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
        //CASILLA PASA (19-36)
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                PictureBox name = pictureBox18;
                apuesta_actual = "PASA";
                int apostado = apuestaYaRealizada(apuesta_actual);
                if (ficha_actual != 0)
                {
                    colocarFicha(ficha_actual, name);
                    anadir_apuesta(apuesta_actual, ficha_actual, name);
                }
                else if (ficha_actual == 0 && apostado == 0)
                {
                    MessageBox.Show("Seleccione una cantidad");

                }
            }
        }
/*
        private void Enviar_apuesta_Click(object sender, EventArgs e)
        {
            if (!enviado)
            {
                string MessageBoxContent = "Está seguro que quiere hacer esta apuesta?";
                string MessageBoxTitle = "Finalizar apuesta";
                DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        enviado = true;
                        int i = 0;
                        string apuestaE;
                        string mensajeA = "13/2/" + partida + "/" + usuario + "/" + total_apostado + "/";
                        while (i < Napuestas)
                        {
                            apuestaE = apuestas[i] + "/" + CantidadApostada[i] + "/";
                            mensajeA = mensajeA + apuestaE;
                            i = i + 1;
                        }
                        apuesta_string(mensajeA);
                        label4.ForeColor = System.Drawing.Color.Red;
                        label4.BackColor = System.Drawing.Color.Aqua;
                        label4.Text = "Apuesta enviada";
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Apuesta ya enviada");
            }
        }
*/
        public void AbandonarPartida(int hack)
        {
            if (hack == 0)//
            {
                MessageBox.Show("No se ha podido abandonar la partida");
            }
            else if (hack == 2)
            {
                MessageBox.Show("Todos los jugadores han abandonado la partida, la partida ha finalizado");
                string mensaje = "18/" + usuario;
                apuesta_string(mensaje);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!enviado)
            {
                string mensaje = "11/2/" + partida + "/" + usuario;
                apuesta_string(mensaje);
            }


        }

        private void Enviar_apuesta_Click_1(object sender, EventArgs e)
        {
            if (!enviado)
            {
                string MessageBoxContent = "Está seguro que quiere hacer esta apuesta?";
                string MessageBoxTitle = "Finalizar apuesta";
                DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        enviado = true;
                        int i = 0;
                        string apuestaE;
                        string mensajeA = "13/2/" + partida + "/" + usuario + "/" + total_apostado + "/";
                        while (i < Napuestas)
                        {
                            apuestaE = apuestas[i] + "/" + CantidadApostada[i] + "/";
                            mensajeA = mensajeA + apuestaE;
                            i = i + 1;
                        }
                        apuesta_string(mensajeA);
                        label4.Text = "Apuesta enviada";
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Apuesta ya enviada");
            }
        }

        private void Borrar_todo_Click_1(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (Napuestas > 0)
                {
                    for (int i = 0; i < Napuestas; i++)
                    {
                        apuestas[i] = "";
                        CantidadApostada[i] = 0;
                        casillas[i].Image = null;
                    }
                    Napuestas = 0;
                    deposito = deposito + total_apostado;
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    total_apostado = 0;
                    cantidad_apostada.Text = total_apostado + "€";
                }
                else
                {
                    MessageBox.Show("No hay apuestas todavía");
                }
            }
        }

        private void Borrar_anterior_Click_1(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (Napuestas > 0)
                {
                    deposito = deposito + CantidadApostada[Napuestas - 1];
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    apuestas[Napuestas - 1] = "";
                    total_apostado = total_apostado - CantidadApostada[Napuestas - 1];
                    cantidad_apostada.Text = total_apostado + "€";
                    CantidadApostada[Napuestas - 1] = 0;
                    casillas[Napuestas - 1].Image = null;
                    Napuestas = Napuestas - 1;
                }
                else
                    MessageBox.Show("No hay apuestas todavía");
            }

        }

        private void borrar_selec_Click_1(object sender, EventArgs e)
        {
            if (!enviado)
            {
                if (Napuestas > 0)
                {
                    deposito = deposito + CantidadApostada[Napuestas - 1];
                    total_deposito.Text = Convert.ToInt32(deposito) + "€";
                    apuestas[Napuestas - 1] = "";
                    total_apostado = total_apostado - CantidadApostada[Napuestas - 1];
                    cantidad_apostada.Text = total_apostado + "€";
                    CantidadApostada[Napuestas - 1] = 0;
                    casillas[Napuestas - 1].Image = null;
                    Napuestas = Napuestas - 1;
                }
                else
                    MessageBox.Show("No hay apuestas todavía");
            }

        }












    }
}
