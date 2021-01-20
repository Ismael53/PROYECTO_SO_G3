using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    //Vamos a crear en esta clase el mazo de 52 cartas para la partida
    public class Deck
    {
        private List<Card> deck = new List<Card>();//El mazo no será más que una lista de cartas
        

        public Deck() //Asignamos una carta de cada tipo al mazo
        {
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    deck.Add(new Card(i, j, false));
                }
            }
        }
        public Deck(bool mostrar)
        {
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    deck.Add(new Card(i, j, mostrar));
                }
            }
        }

        public Deck(Deck otherDeck) // Copiamos a nuestro mazo uno que entramos por parámetro
        {
            foreach (Card card in otherDeck.deck)
            {
                this.deck.Add(new Card(card));
            }
        }

        public void Add(Card card)// Añadimos una carta al mazo
        {
            deck.Add(card);
        }
        
        public void Shuffle() // Este algoritmo nos permite mezclar la baraja
        {
            var rand = new Random();
            for (int i = CardsLeft()-1 ; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                Card temp = deck[i];
                deck[i] = deck[n];
                deck[n] = temp;
            }
        }
        public string Print()
        {
            string output = "";
            foreach (Card card in deck)
            {
                output += card.ToString() + " ";
            }
            return output;
        }
        public int CardsLeft()
        {
            return deck.Count;
        }
        public Card Deal()
        {
            Card dealCard = deck.ElementAt(deck.Count - 1);
            deck.RemoveAt(deck.Count - 1);
            dealCard.FaceUp = true;
            return dealCard;
        }
        public Card Deal(bool faceUp)
        {
            Card dealCard = deck.ElementAt(deck.Count - 1);
            dealCard.FaceUp = faceUp;
            deck.RemoveAt(deck.Count - 1);
            return dealCard;
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= deck.Count)
                throw new ArgumentOutOfRangeException();
            deck.RemoveAt(index);
        }
        public void Remove(Card card)
        {
            for(int i=0;i<deck.Count;i++)
            {
                if (deck[i] == card && deck[i].gettipo() == card.gettipo())
                {
                    deck.RemoveAt(i);
                }
            }
        }
        public Card[] ToArray()
        {
            return deck.ToArray();
        }
        public List<Card> ToList()
        {
            return deck;
        }
    }
}


