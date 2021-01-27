using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Poker : Form
    {
        public int partida;
        public string mensaje_chat;
        public string usuario;
        public int deposito;

        public delegate void delegadochat(string mensaje);
        public event delegadochat message_chat;

        Table pokerTable;
        PlayerList playerList;
        PlayerList mejores_manos;
        int cont_invitados = 0;
        string anfitrion;
        int acabar = 0;

        string actual_player;
        int playing;
        int dealer = 0;
        string big_blind;
        string small_blind;
        int amount_small = 5;
        int amount_big = 10;
        int pot;
        int last_bet_amount;
        int mi_apuesta;
        bool retirar=false;
        string jugada;
        int posicion_lista = 0;
        string table_cards;
        int flop_river_turn = 0; 
        int round = 0;

        public string enviar_cartas;
        public string fin_partida;

        public Poker()
        {
            InitializeComponent();
        }

        private void poker_Load(object sender, EventArgs e)
        {
            Pantalla_inicio get = new Pantalla_inicio();
            this.BackColor = Color.FromArgb(32, 30, 45);
            main_chat.BackColor = Color.FromArgb(11, 7, 17);
            main_chat.Size = new System.Drawing.Size(882, 110);
            main_chat.Text = "";
            chat_background.BackColor = Color.FromArgb(11, 7, 17);
            user_name.Text = usuario;
            user_name.SelectionAlignment = HorizontalAlignment.Center;
            deposito_display.Text = Convert.ToString(deposito);
            deposito_display.SelectionAlignment = HorizontalAlignment.Center;
            Player me = new Player(usuario, deposito);// numero con el que desea jugar
            playerList = new PlayerList();
            playerList.Add(me);
            
            
                    

        }

        public void iniciar_partida()
        {
            pokerTable = new Table(playerList);
            pokerTable.DealHoleCards();
            
            
            playing = dealer;
            actual_player = playerList[dealer].name;
            string big_blind = playerList[dealer - 1].name;
            string small_blind = playerList[dealer - 2].name;
            enviar_cartas = "14/" + Convert.ToString(partida)+"/"+Convert.ToString(playerList.Count());
            for (int i = 0; i < playerList.Count(); i++)
            {
                enviar_cartas = enviar_cartas + "/" + playerList[i].name + "/" + playerList[i].getHand().getCard(0).numero + "/" + playerList[i].getHand().getCard(0).tipo + "/" + playerList[i].getHand().getCard(1).numero + "/" + playerList[i].getHand().getCard(1).tipo ;
            }
            enviar_cartas = enviar_cartas + "/" + actual_player + "/" + big_blind + "/" + small_blind;
            
            message_chat(DarCartas());
            Hand mine = playerList[0].getHand();
            Card card1 = mine.getCard(0);
            Card card2 = mine.getCard(1);
            drawCard(card1, hand1);
            drawCard(card2, hand2);
            resaltar_actual_player(actual_player);
            update_actual(playerList[dealer - 1].name, amount_big, playerList[dealer - 1].deposito);
            update_actual(playerList[dealer - 2].name, amount_small, playerList[dealer - 2].deposito);

            if (cont_invitados > 0)
            {
                Hand player2 = playerList[1].getHand();
                Card card3 = player2.getCard(0);
                Card card4 = player2.getCard(1);
                //drawCard(card3, player2_card1);
                //drawCard(card4, player2_card2);
            }
            if(cont_invitados>1)
            {
            Hand player3 = playerList[2].getHand();
            Card card5 = player3.getCard(0);
            Card card6 = player3.getCard(1);
            //drawCard(card5, player3_card1);
            //drawCard(card6, player3_card2);
            }
            if(cont_invitados>2)
            {
            Hand player4 = playerList[3].getHand();
            Card card7 = player4.getCard(0);
            Card card8 = player4.getCard(1);
            //drawCard(card7, player4_card1);
            //drawCard(card8, player4_card2);
            }
            if (cont_invitados > 3)
            {
                Hand player5 = playerList[4].getHand();
                Card card9 = player5.getCard(0);
                Card card10 = player5.getCard(1);
                //drawCard(card9, player5_card1);
                //drawCard(card10, player5_card2);
            }
            
            if (big_blind == usuario)
            {
                mi_apuesta = amount_big;
                apuesta_actual_player1.Text = Convert.ToString(mi_apuesta);
            }
            if (small_blind == usuario)
            {
                mi_apuesta = amount_small;
                apuesta_actual_player1.Text = Convert.ToString(mi_apuesta);
            }

            pot = amount_small + amount_big;
            total_pot.Text = Convert.ToString(pot);
            total_pot.SelectionAlignment = HorizontalAlignment.Center;
            last_bet_amount = amount_big;        
            
            
            
            
            
 
        }

        public void actualizar_deposito(int Deposito)
        {
            deposito = Deposito;
            deposito_display.Text = deposito + "€";
            deposito_display.SelectionAlignment = HorizontalAlignment.Center;
        }
        
        public string DarCartas()
        {
            return enviar_cartas;
        }
        public string DarJugada()
        {
            return jugada;
        }
        public string DarFinPartida()
        {
            return fin_partida;
        }

        public string DarTablero()
        {
            return table_cards;
        }
        public void RecibirJugadores(int numero_jugadores, string[] jugadores)
        {
            anfitrion = jugadores[0];
            if (anfitrion == usuario)
            {
                for (int i = 0; i < numero_jugadores; i++)
                {
                    if (jugadores[i] != usuario)
                        anadirPlayers(playerList, jugadores[i], Convert.ToInt32(jugadores[i+numero_jugadores]));
                }
            }
            else
            {
                playerList.Remove(playerList[0]);
                for (int i = 0; i < numero_jugadores; i++)
                {
                    anadirPlayers(playerList, jugadores[i], Convert.ToInt32(jugadores[i + numero_jugadores]));
                }
            }
        }
        public void RecibirCartas(string[] cartas)
        {
            int index = 0;
            int pos=0;
            if (usuario != anfitrion)
            {
                
                for (int i = 1; i < playerList.Count()*5; i=i+5)
                {
                    Card anadir1 = new Card(Convert.ToInt32(cartas[i + 1]), Convert.ToInt32(cartas[i + 2]));
                    Card anadir2 = new Card(Convert.ToInt32(cartas[i + 3]), Convert.ToInt32(cartas[i + 4]));
                    playerList[index].AddToHand(anadir1);
                    playerList[index].AddToHand(anadir2);
                    if (cartas[i] == usuario)
                    {
                        posicion_lista = index;
                        drawCard(anadir1, hand1);
                        drawCard(anadir2, hand2);
                    }                   
                    
                    
                    index = index + 1;
                    pos = i;
                    
                    
                }
                int counter = 0;
                while (counter < cont_invitados)
                {
                    if (posicion_lista < cont_invitados)
                        posicion_lista = posicion_lista + 1;
                    else
                        posicion_lista = 0;
                    if (counter == 0)
                    {
                        //drawCard(playerList[posicion_lista].getHand().getCard(0), player2_card1);
                        //drawCard(playerList[posicion_lista].getHand().getCard(1), player2_card2);
                        name_player2.Text = playerList[posicion_lista].name;
                        amount_player2.Text = Convert.ToString(playerList[posicion_lista].deposito);
                        name_player2.SelectionAlignment = HorizontalAlignment.Center;
                        amount_player2.SelectionAlignment = HorizontalAlignment.Center;

                    }
                    else if (counter == 1)
                    {
                        //drawCard(playerList[posicion_lista].getHand().getCard(0), player3_card1);
                        //drawCard(playerList[posicion_lista].getHand().getCard(1), player3_card2);
                        name_player3.Text = playerList[posicion_lista].name;
                        amount_player3.Text = Convert.ToString(playerList[posicion_lista].deposito);
                        name_player3.SelectionAlignment = HorizontalAlignment.Center;
                        amount_player3.SelectionAlignment = HorizontalAlignment.Center;
                    }
                    else if (counter == 2)
                    {
                        //drawCard(playerList[posicion_lista].getHand().getCard(0), player4_card1);
                        //drawCard(playerList[posicion_lista].getHand().getCard(1), player4_card2);
                        name_player4.Text = playerList[posicion_lista].name;
                        amount_player4.Text = Convert.ToString(playerList[posicion_lista].deposito);
                        name_player4.SelectionAlignment = HorizontalAlignment.Center;
                        amount_player4.SelectionAlignment = HorizontalAlignment.Center;
                    }
                    else
                    {
                        //drawCard(playerList[posicion_lista].getHand().getCard(0), player5_card1);
                        //drawCard(playerList[posicion_lista].getHand().getCard(1), player5_card2);
                        name_player5.Text = playerList[posicion_lista].name;
                        amount_player5.Text = Convert.ToString(playerList[posicion_lista].deposito);
                        name_player5.SelectionAlignment = HorizontalAlignment.Center;
                        amount_player5.SelectionAlignment = HorizontalAlignment.Center;
                    }

                    counter++;
                }
                
                actual_player = cartas[pos + 5];
                big_blind = cartas[pos + 6];
                small_blind = cartas[pos + 7];
                if (actual_player == usuario)
                {
                    
                    

                }
                if (big_blind == usuario)
                {
                    
                    apostar(amount_big);
                    apuesta_actual_player1.Text = Convert.ToString(amount_big);
                    deposito_display.Text = Convert.ToString(deposito);
                    deposito_display.SelectionAlignment = HorizontalAlignment.Center;
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                }
                if (small_blind == usuario)
                {
                    
                    apostar(amount_small);
                    apuesta_actual_player1.Text = Convert.ToString(amount_small);
                    deposito_display.Text = Convert.ToString(deposito);
                    deposito_display.SelectionAlignment = HorizontalAlignment.Center;
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;

                }
                resaltar_actual_player(actual_player);
                playing = dealer;
                pot = amount_small + amount_big;
                total_pot.Text = Convert.ToString(pot);
                total_pot.SelectionAlignment = HorizontalAlignment.Center;
                last_bet_amount = amount_big;
            }
            
            

        }
        public void RecibirJugada(string jugador, int jugada,int apuesta,int deposito)
        {

            if (jugada == 0)
            {
                
                playerList.Remove(playerList[playing]);
                cont_invitados--;
                if (playing < cont_invitados)
                    playing = playing - 1;
                else
                    playing = 0;
                update_actual(playerList[playing].name, apuesta, deposito);
            }
            else
            {

                last_bet_amount = apuesta;
                pot = pot + last_bet_amount;
                total_pot.Text = Convert.ToString(pot);
                total_pot.SelectionAlignment = HorizontalAlignment.Center;
                update_actual(playerList[playing].name, apuesta, deposito);
            }
             if (playing < cont_invitados)
                playing = playing + 1;
            else
                playing = 0;
             if (playerList.Count > 1)
             {
                 actual_player = playerList[playing].name;
                 resaltar_actual_player(actual_player);
             }
             else
             {
                 fin_partida = "20/" + Convert.ToString(partida) + "/1/"+playerList[0].name;
                 message_chat(DarFinPartida());
             }
        }
        public void anadirPlayers(PlayerList lista, string nombre,int cantidad)
        {
            Player guest = new Player(nombre, cantidad);
            lista.Add(guest);
            if (nombre != usuario)
            {                
                cont_invitados++;
                if (cont_invitados == 1)
                {
                    image_player2.Visible = true;
                    name_player2.Visible = true;
                    amount_player2.Visible = true;
                    player2_card1.Visible = true;
                    player2_card2.Visible = true;
                    apuesta_actual_player2.Visible = true;
                    apuesta_2.Visible = true;
                    credit_2.Visible = true;
                    name_player2.Text = nombre;
                    name_player2.SelectionAlignment = HorizontalAlignment.Center;
                    amount_player2.Text = Convert.ToString(cantidad);
                    amount_player2.SelectionAlignment = HorizontalAlignment.Center;
                }
                else if (cont_invitados == 2)
                {
                    image_player3.Visible = true;
                    name_player3.Visible = true;
                    amount_player3.Visible = true;
                    player3_card1.Visible = true;
                    player3_card2.Visible = true;
                    apuesta_actual_player3.Visible = true;
                    apuesta_3.Visible = true;
                    credit_3.Visible = true;
                    name_player3.Text = nombre;
                    name_player3.SelectionAlignment = HorizontalAlignment.Center;
                    amount_player3.Text = Convert.ToString(cantidad);
                    amount_player3.SelectionAlignment = HorizontalAlignment.Center;
                }
                else if (cont_invitados == 3)
                {
                    image_player4.Visible = true;
                    name_player4.Visible = true;
                    amount_player4.Visible = true;
                    player4_card1.Visible = true;
                    player4_card2.Visible = true;
                    apuesta_actual_player4.Visible = true;
                    apuesta_4.Visible = true;
                    credit_4.Visible = true;
                    name_player4.Text = nombre;
                    name_player4.SelectionAlignment = HorizontalAlignment.Center;
                    amount_player4.Text = Convert.ToString(cantidad);
                    amount_player4.SelectionAlignment = HorizontalAlignment.Center;
                }
                else if (cont_invitados == 4)
                {
                    image_player5.Visible = true;
                    name_player5.Visible = true;
                    amount_player5.Visible = true;
                    player5_card1.Visible = true;
                    player5_card2.Visible = true;
                    apuesta_actual_player5.Visible = true;
                    apuesta_5.Visible = true;
                    credit_5.Visible = true;
                    name_player5.Text = nombre;
                    name_player5.SelectionAlignment = HorizontalAlignment.Center;
                    amount_player5.Text = Convert.ToString(cantidad);
                    amount_player5.SelectionAlignment = HorizontalAlignment.Center;
                }
            }
            

        }
        public void resaltar_actual_player(string actual_player)
        {
            if (name_player2.Text == actual_player)
            {
                image_player2.BackColor = Color.Red;
                image_player3.BackColor = Color.Black;
                image_player4.BackColor = Color.Black;
                image_player5.BackColor = Color.Black;
                user_name.BackColor = Color.Black;
                Fold.Visible = false;
                check_call.Visible = false;
                Raise.Visible = false;
                amount.Visible = false;
                increase_amount.Visible = false;
            }
            if (name_player3.Text == actual_player)
            {
                image_player2.BackColor = Color.Black;
                image_player3.BackColor = Color.Red;
                image_player4.BackColor = Color.Black;
                image_player5.BackColor = Color.Black;
                user_name.BackColor = Color.Black;
                Fold.Visible = false;
                check_call.Visible = false;
                Raise.Visible = false;
                amount.Visible = false;
                increase_amount.Visible = false;
            }
            if (name_player4.Text == actual_player)
            {
                image_player2.BackColor = Color.Black;
                image_player3.BackColor = Color.Black;
                image_player4.BackColor = Color.Red;
                image_player5.BackColor = Color.Black;
                user_name.BackColor = Color.Black;
                Fold.Visible = false;
                check_call.Visible = false;
                Raise.Visible = false;
                amount.Visible = false;
                increase_amount.Visible = false;
            }
            if (name_player5.Text == actual_player)
            {
                image_player2.BackColor = Color.Black;
                image_player3.BackColor = Color.Black;
                image_player4.BackColor = Color.Black;
                image_player5.BackColor = Color.Red;
                user_name.BackColor = Color.Black;
                Fold.Visible = false;
                check_call.Visible = false;
                Raise.Visible = false;
                amount.Visible = false;
                increase_amount.Visible = false;
            }
            if (user_name.Text == actual_player)
            {
                image_player2.BackColor = Color.Black;
                image_player3.BackColor = Color.Black;
                image_player4.BackColor = Color.Black;
                image_player5.BackColor = Color.Black;
                user_name.BackColor = Color.Red;
                Fold.Visible = true;
                check_call.Visible = true;
                Raise.Visible = true;
                amount.Visible = true;
                increase_amount.Visible = true;

            }

        }
        public void update_actual(string actual_player, int apuesta,int deposito)
        {
            if (name_player2.Text == actual_player)
            {
                amount_player2.Text = deposito.ToString()+"€";
                apuesta_actual_player2.Text = apuesta.ToString();
                amount_player2.SelectionAlignment = HorizontalAlignment.Center;
                apuesta_actual_player2.SelectionAlignment = HorizontalAlignment.Center;


            }
            if (name_player3.Text == actual_player)
            {
                amount_player3.Text = deposito.ToString()+"€";
                apuesta_actual_player3.Text = apuesta.ToString();
                amount_player3.SelectionAlignment = HorizontalAlignment.Center;
                apuesta_actual_player3.SelectionAlignment = HorizontalAlignment.Center;
            }
            if (name_player4.Text == actual_player)
            {
                amount_player4.Text = deposito.ToString() + "€";
                apuesta_actual_player4.Text = apuesta.ToString();
                amount_player4.SelectionAlignment = HorizontalAlignment.Center;
                apuesta_actual_player4.SelectionAlignment = HorizontalAlignment.Center;
            }
            if (name_player5.Text == actual_player)
            {
                amount_player5.Text = deposito.ToString() + "€";
                apuesta_actual_player5.Text = apuesta.ToString();
                amount_player5.SelectionAlignment = HorizontalAlignment.Center;
                apuesta_actual_player5.SelectionAlignment = HorizontalAlignment.Center;
            }
        }
        public void drawCard(Card card, PictureBox picturebox)
        {
            int tipo = card.tipo;
            int numero = card.numero;
            switch (tipo)
            {
                case 1:
                    if (numero == 2)
                        picturebox.BackgroundImage = Properties.Resources._12;
                    else if (numero == 3)
                        picturebox.BackgroundImage = Properties.Resources._13;
                    else if (numero == 4)
                        picturebox.BackgroundImage = Properties.Resources._14;
                    else if (numero == 5)
                        picturebox.BackgroundImage = Properties.Resources._15;
                    else if (numero == 6)
                        picturebox.BackgroundImage = Properties.Resources._16;
                    else if (numero == 7)
                        picturebox.BackgroundImage = Properties.Resources._17;
                    else if (numero == 8)
                        picturebox.BackgroundImage = Properties.Resources._18;
                    else if (numero == 9)
                        picturebox.BackgroundImage = Properties.Resources._19;
                    else if (numero == 10)
                        picturebox.BackgroundImage = Properties.Resources._110;
                    else if (numero == 11)
                        picturebox.BackgroundImage = Properties.Resources._111;
                    else if (numero == 12)
                        picturebox.BackgroundImage = Properties.Resources._112;
                    else if (numero == 13)
                        picturebox.BackgroundImage = Properties.Resources._113;
                    else if (numero == 14)
                        picturebox.BackgroundImage = Properties.Resources._114;
                    
                    break;
                case 2:
                    if (numero == 2)
                        picturebox.BackgroundImage = Properties.Resources._22;
                    else if (numero == 3)
                        picturebox.BackgroundImage = Properties.Resources._23;
                    else if (numero == 4)
                        picturebox.BackgroundImage = Properties.Resources._24;
                    else if (numero == 5)
                        picturebox.BackgroundImage = Properties.Resources._25;
                    else if (numero == 6)
                        picturebox.BackgroundImage = Properties.Resources._26;
                    else if (numero == 7)
                        picturebox.BackgroundImage = Properties.Resources._27;
                    else if (numero == 8)
                        picturebox.BackgroundImage = Properties.Resources._28;
                    else if (numero == 9)
                        picturebox.BackgroundImage = Properties.Resources._29;
                    else if (numero == 10)
                        picturebox.BackgroundImage = Properties.Resources._210;
                    else if (numero == 11)
                        picturebox.BackgroundImage = Properties.Resources._211;
                    else if (numero == 12)
                        picturebox.BackgroundImage = Properties.Resources._212;
                    else if (numero == 13)
                        picturebox.BackgroundImage = Properties.Resources._213;
                    else if (numero == 14)
                        picturebox.BackgroundImage = Properties.Resources._214;
                    
                    break;

                case 3:
                    if (numero == 2)
                        picturebox.BackgroundImage = Properties.Resources._32;
                    else if (numero == 3)
                        picturebox.BackgroundImage = Properties.Resources._33;
                    else if (numero == 4)
                        picturebox.BackgroundImage = Properties.Resources._34;
                    else if (numero == 5)
                        picturebox.BackgroundImage = Properties.Resources._35;
                    else if (numero == 6)
                        picturebox.BackgroundImage = Properties.Resources._36;
                    else if (numero == 7)
                        picturebox.BackgroundImage = Properties.Resources._37;
                    else if (numero == 8)
                        picturebox.BackgroundImage = Properties.Resources._38;
                    else if (numero == 9)
                        picturebox.BackgroundImage = Properties.Resources._39;
                    else if (numero == 10)
                        picturebox.BackgroundImage = Properties.Resources._310;
                    else if (numero == 11)
                        picturebox.BackgroundImage = Properties.Resources._311;
                    else if (numero == 12)
                        picturebox.BackgroundImage = Properties.Resources._312;
                    else if (numero == 13)
                        picturebox.BackgroundImage = Properties.Resources._313;
                    else if (numero == 14)
                        picturebox.BackgroundImage = Properties.Resources._314;
                    
                    
                    break;
                case 4:
                    if (numero == 2)
                        picturebox.BackgroundImage = Properties.Resources._42;
                    else if (numero == 3)
                        picturebox.BackgroundImage = Properties.Resources._43;
                    else if (numero == 4)
                        picturebox.BackgroundImage = Properties.Resources._44;
                    else if (numero == 5)
                        picturebox.BackgroundImage = Properties.Resources._45;
                    else if (numero == 6)
                        picturebox.BackgroundImage = Properties.Resources._46;
                    else if (numero == 7)
                        picturebox.BackgroundImage = Properties.Resources._47;
                    else if (numero == 8)
                        picturebox.BackgroundImage = Properties.Resources._48;
                    else if (numero == 9)
                        picturebox.BackgroundImage = Properties.Resources._49;
                    else if (numero == 10)
                        picturebox.BackgroundImage = Properties.Resources._410;
                    else if (numero == 11)
                        picturebox.BackgroundImage = Properties.Resources._411;
                    else if (numero == 12)
                        picturebox.BackgroundImage = Properties.Resources._412;
                    else if (numero == 13)
                        picturebox.BackgroundImage = Properties.Resources._413;
                    else if (numero == 14)
                        picturebox.BackgroundImage = Properties.Resources._414;
                    
                    break;

            }

        }
        // Poker moves
        

        public int enviarChat()
        {
            if (enviar_chat.Text == "")
            {
                return -1;
            }
            else
            {
                mensaje_chat = "9/0/" + partida + "/" + usuario + "/" + chat_text.Text;
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
            

        private void hide_chat_Click(object sender, EventArgs e)
        {
            //chat_background.Visible = false;
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

        public void apostar(int cantidad)
        {
            deposito = deposito - cantidad;
            deposito_display.Text = Convert.ToInt32(deposito) + "€";
            deposito_display.SelectionAlignment = HorizontalAlignment.Center;
            mi_apuesta = cantidad;
            apuesta_actual_player1.Text = mi_apuesta + "€";
        }

        private void Fold_Click(object sender, EventArgs e)
        {
            retirar = true;
            jugada = "17/" + Convert.ToString(partida) + "/" + usuario + "/0";
            message_chat(DarJugada());
            round++;
        }
        private void send_flop()
        {
            Card flop1 = pokerTable.getDeck().Deal();
            Card flop2 = pokerTable.getDeck().Deal();
            Card flop3 = pokerTable.getDeck().Deal();
            for (int i = 0; i < playerList.Count(); i++)
            {
                playerList[i].AddToHand(flop1);
                playerList[i].AddToHand(flop2);
                playerList[i].AddToHand(flop3);
            }
            drawCard(flop1, card1);
            drawCard(flop2, card2);
            drawCard(flop3, card3);
            
            table_cards = "19/" + Convert.ToString(partida) + "/" + Convert.ToString(flop_river_turn) + "/" + flop1.numero + "/" + flop1.tipo + "/" + flop2.numero + "/" + flop2.tipo + "/" + flop3.numero + "/" + flop3.tipo;
            flop_river_turn++;
            message_chat(DarTablero());
        }
        private void send_river()
        {
            Card river = pokerTable.getDeck().Deal();
            for (int i = 0; i < playerList.Count(); i++)
            {
                playerList[i].AddToHand(river);
                
            }
            drawCard(river, card4);
            table_cards = "19/" + Convert.ToString(partida) + "/" + Convert.ToString(flop_river_turn) + "/" + river.numero + "/" + river.tipo;
            flop_river_turn++;
            message_chat(DarTablero());

        }
        private void send_turn()
        {
            Card turn = pokerTable.getDeck().Deal();
            for (int i = 0; i < playerList.Count(); i++)
            {
                playerList[i].AddToHand(turn);

            }
            drawCard(turn, card5);
            table_cards = "19/" + Convert.ToString(partida) + "/" + Convert.ToString(flop_river_turn) + "/" + turn.numero + "/" + turn.tipo;
            flop_river_turn++;
            message_chat(DarTablero());

        }
        public void recieve_table_cards(int round,string [] table_cards)
        {
            if (round == 0)
            {
                Card flop1 = new Card(Convert.ToInt32(table_cards[0]), Convert.ToInt32(table_cards[1]));
                Card flop2 = new Card(Convert.ToInt32(table_cards[2]), Convert.ToInt32(table_cards[3]));
                Card flop3 = new Card(Convert.ToInt32(table_cards[4]), Convert.ToInt32(table_cards[5]));
                drawCard(flop1, card1);
                drawCard(flop2, card2);
                drawCard(flop3, card3); 
            }
            if (round == 1)
            {
                Card river = new Card(Convert.ToInt32(table_cards[0]), Convert.ToInt32(table_cards[1]));
                drawCard(river, card4);
            }
            if (round == 2)
            {
                Card turn = new Card(Convert.ToInt32(table_cards[0]), Convert.ToInt32(table_cards[1]));
                drawCard(turn, card5);
            }
 
        }
        public void resaltar_ganador(Player player)
        {
            if (user_name.Text == player.name)
            {
                user_name.BackColor = Color.Gold;
                user_name.ForeColor = Color.Black;
                
 
            }
            else if (name_player2.Text == player.name)
            {
                image_player2.BackColor = Color.Gold;
                name_player2.BackColor = Color.Gold;
                name_player2.ForeColor = Color.Black;
            }
            else if (name_player3.Text == player.name)
            {
                image_player3.BackColor = Color.Gold;
                name_player3.BackColor = Color.Gold;
                name_player3.ForeColor = Color.Black;
            }
            else if (name_player4.Text == player.name)
            {
                image_player4.BackColor = Color.Gold;
                name_player4.BackColor = Color.Gold;
                name_player4.ForeColor = Color.Black;
            }
            else if (name_player5.Text == player.name)
            {
                image_player5.BackColor = Color.Gold;
                name_player5.BackColor = Color.Gold;
                name_player5.ForeColor = Color.Black;
            } 
            
 
        }
        public void finalizar_partida()
        {
            
            PlayerList copia = new PlayerList(playerList);
            mejores_manos = QuickSortBestHand(copia);
            List<int> ganadores=new List<int>();
            for (int i = 0; i < mejores_manos.Count; i++)
            {
                for (int j = 0; j < playerList.Count; j++)
                    if (playerList[j] == mejores_manos[i])
                    {
                        ganadores.Add(j);
                    }
                if (HandCombination.getBestHand(new Hand(mejores_manos[i].getHand())) != HandCombination.getBestHand(new Hand(mejores_manos[i + 1].getHand())))
                    break;
            }

            fin_partida = "20/" + Convert.ToString(partida) + "/" + Convert.ToString(ganadores.Count());
            for (int i = 0; i < ganadores.Count(); i++)
            {
                fin_partida = fin_partida + "/" + playerList[ganadores[i]].name;
            }
            message_chat(DarFinPartida());                 
            
 
        }

        public void acabar_partida(int ganadores, string[] nombre_ganadores)
        {
            for (int j = 0; j < playerList.Count(); j++)
            {
                if(playerList[j].name==name_player2.Text)
                {
                    drawCard(playerList[j].getHand().getCard(0), player2_card1);
                    drawCard(playerList[j].getHand().getCard(1), player2_card2);
                }
                if (playerList[j].name == name_player3.Text)
                {
                    drawCard(playerList[j].getHand().getCard(0), player3_card1);
                    drawCard(playerList[j].getHand().getCard(1), player3_card2);
                }
                if (playerList[j].name == name_player4.Text)
                {
                    drawCard(playerList[j].getHand().getCard(0), player4_card1);
                    drawCard(playerList[j].getHand().getCard(1), player4_card2);
                }
                if (playerList[j].name == name_player5.Text)
                {
                    drawCard(playerList[j].getHand().getCard(0), player5_card1);
                    drawCard(playerList[j].getHand().getCard(1), player5_card2);
                }
            }
            for (int i = 0; i < ganadores; i++)
            {
                for (int z = 0; z < playerList.Count(); z++)
                {
                    if (playerList[z].name == nombre_ganadores[ganadores-1])
                    {
                        resaltar_ganador(playerList[z]);
                        //System.Threading.Thread.Sleep(5000);
                    }
                }
            }
            
            MessageBox.Show("La partida ha terminado, se cerrará la sesión en breves instantes");
            this.Close();
        }
        private void check_call_Click(object sender, EventArgs e)
        {
            if (usuario == playerList[dealer].name && last_bet_amount == mi_apuesta && flop_river_turn == 0 && round!=0|| usuario == playerList[dealer].name && last_bet_amount < deposito && round!=0 && flop_river_turn == 0)
            {
                if (last_bet_amount < deposito)
                {
                    apostar(last_bet_amount);
                    apuesta_actual_player1.Text = Convert.ToString(last_bet_amount);
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                    round = 0;
                    last_bet_amount = 0;
                    send_flop();
                }
                else 
                {
                    MessageBox.Show("Crédito insuficiente, hacer ingreso en perfil");
                }

                
            }
            else if (usuario == playerList[dealer].name && last_bet_amount == mi_apuesta && flop_river_turn == 1 && round != 0 || usuario == playerList[dealer].name && last_bet_amount < deposito && round != 0 && flop_river_turn == 1)
            {
                if (last_bet_amount < deposito)
                {
                    apostar(last_bet_amount);
                    apuesta_actual_player1.Text = Convert.ToString(last_bet_amount);
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                    round = 0;
                    last_bet_amount = 0;
                    send_river();
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente, hacer ingreso en perfil");
                }

            }
            else if (usuario == playerList[dealer].name && last_bet_amount == mi_apuesta && flop_river_turn == 2 && round != 0 || usuario == playerList[dealer].name && last_bet_amount < deposito && round != 0 && flop_river_turn == 2)
            {
                if (last_bet_amount < deposito)
                {
                    apostar(last_bet_amount);
                    apuesta_actual_player1.Text = Convert.ToString(last_bet_amount);
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                    round = 0;
                    last_bet_amount = 0;
                    send_turn();
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente, hacer ingreso en perfil");
                }

            }
            else if (usuario == playerList[dealer].name && last_bet_amount == mi_apuesta && flop_river_turn == 3 && round != 0 || usuario == playerList[dealer].name && last_bet_amount < deposito && round != 0 && flop_river_turn == 3)
            {
                if (last_bet_amount < deposito)
                {
                    apostar(last_bet_amount);
                    apuesta_actual_player1.Text = Convert.ToString(last_bet_amount);
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                    finalizar_partida();
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente, hacer ingreso en perfil");
                }

            }

            else
            {
                if (last_bet_amount == 0)
                {
                    jugada = "17/" + Convert.ToString(partida) + "/" + usuario + "/1/0/" + Convert.ToString(deposito);
                    message_chat(DarJugada());
                    round++;
                }
                else if (last_bet_amount < deposito)
                {
                    apostar(last_bet_amount);
                    apuesta_actual_player1.Text = Convert.ToString(last_bet_amount);
                    apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                    jugada = "17/" + Convert.ToString(partida) + "/" + usuario + "/2" + "/" + Convert.ToString(last_bet_amount) + "/" + Convert.ToString(deposito);
                    message_chat(DarJugada());
                    round++;
                }
                else
                {
                    MessageBox.Show("Crédito insuficiente, hacer ingreso en perfil");
                }
            }
            
        }

        private void Raise_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(amount.Text) > last_bet_amount )
            {

                apostar(Convert.ToInt32(amount.Text));
                apuesta_actual_player1.Text = Convert.ToString(amount.Text);
                apuesta_actual_player1.SelectionAlignment = HorizontalAlignment.Center;
                jugada = "17/" + Convert.ToString(partida) + "/" + usuario + "/3" + "/" + Convert.ToInt32(amount.Text) + "/" + Convert.ToString(deposito);
                message_chat(DarJugada());
                int rise = deposito * increase_amount.Value / 10;
                amount.Text = rise.ToString();                
                amount.BackColor = Color.Black;
                round++;

            }
            else
            {
                amount.BackColor = Color.Red;
            }
        }

        private void increase_amount_Scroll(object sender, EventArgs e)
        {
            int rise = deposito * increase_amount.Value / 10;
            amount.Text = rise.ToString();
        }
        
        PlayerList QuickSortBestHand(PlayerList myPlayers)
        {
            Player pivot;
            Random ran = new Random();

            if (myPlayers.Count() <= 1)
                return myPlayers;
            pivot = myPlayers[ran.Next(myPlayers.Count())];
            myPlayers.Remove(pivot);

            var less = new PlayerList();
            var greater = new PlayerList();
            // Assign values to less or greater list
            foreach (Player player in myPlayers)
            {
                if (HandCombination.getBestHand(new Hand(player.getHand())) > HandCombination.getBestHand(new Hand(pivot.getHand())))
                {
                    greater.Add(player);
                }
                else if (HandCombination.getBestHand(new Hand(player.getHand())) <= HandCombination.getBestHand(new Hand(pivot.getHand())))
                {
                    less.Add(player);
                }
            }
            // Recurse for less and greaterlists
            var list = new PlayerList();
            list.AddRange(QuickSortBestHand(greater));
            list.Add(pivot);
            list.AddRange(QuickSortBestHand(less));
            return list;
        }

        

        
        

        
    }
}
