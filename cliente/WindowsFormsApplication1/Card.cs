using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Resources;
namespace WindowsFormsApplication1
{
    // Esta clase nos permite trabajar con las cartas
    //Asignaremos un numero a la carta
    public enum NUMERO
    {
        TWO=2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }
    //Asignaremos a que familia pertenece la carta
    public enum TIPO
    {
        DIAMONDS = 1,
        CLUBS,
        HEARTS,
        SPADES
    }
    
    public class Card
    {
        public int numero, tipo; // definir numero y tipo de carta
        private Bitmap Image;
        private bool mostrar;//definir si se debe mostrar la carta o no
        private bool destacar;//definir si la carta forma parte de la mano final o no

        public bool FaceUp
        {
            get { return mostrar; }
            set 
            { 
                mostrar = value;
                getImageFromFile();
            }
        }
        //default two of diamonds
        public Card()
        {
            numero = (int)NUMERO.TWO;
            tipo = (int)TIPO.DIAMONDS;
            mostrar = false;
            destacar = false;
        }

        public Card(NUMERO numero,TIPO tipo)
        {
            this.numero = (int)numero;
            this.tipo = (int)tipo;
            mostrar = false;
            destacar = false;
        }
        public Card(int numero, int tipo)
        {
            if (numero < 1 || numero > 14 || tipo < 1 || tipo > 4)
                throw new ArgumentOutOfRangeException();
            this.numero=numero;
            this.tipo=tipo;
            mostrar=false;
            destacar = false;
        }
        public Card(NUMERO numero, TIPO tipo,bool mostrar)
        {
            this.numero = (int)numero;
            this.tipo = (int)tipo;
            this.mostrar = mostrar;
            destacar = false;
        }
        public Card(int numero, int tipo,bool mostrar)
        {
            if (numero < 1 || numero > 14 || tipo < 1 || tipo > 4)
                throw new ArgumentOutOfRangeException();
            this.numero = numero;
            this.tipo = tipo;
            this.mostrar = mostrar;
            destacar = false;
        }
        public Card(Card card)
        {
            this.numero = card.numero;
            this.tipo = card.tipo;
            this.mostrar = card.mostrar;
            destacar = false;
        }
        public static string numeroToString(int numero)
        {
            switch (numero)
            {
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
                default:
                    return numero.ToString();
            }
        }
        public static string tipoToString(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "Diamonds";
                case 2:
                    return "Clubs";
                case 3:
                    return "Hearts";
                default:
                    return "Spades";
            }
        }
        public int getnumero()
        {
            return numero;
        }
        public int gettipo()
        {
            return tipo;
        }
        //get image from depending on if the card is faceup or down
        
        public void getImageFromFile()
        {
            if (mostrar)
                this.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Convert.ToString(tipo) + Convert.ToString(numero));
            else
                this.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Convert.ToString(tipo) + Convert.ToString(numero));
        }
        
        //get the current image
        public Bitmap getImage()
        {
            if(Image==null)
                getImageFromFile();
            return this.Image;
        }
        public void setNumero(NUMERO numero)
        {
            this.numero = (int)numero;
        }
        public void setCard(NUMERO numero, TIPO tipo)
        {
            this.numero = (int)numero;
            this.tipo = (int)tipo;
        }
        public void setCard(int numero, int tipo)
        {
            if(numero<1||numero>14||tipo<1||tipo>4)
                throw new ArgumentOutOfRangeException();
            this.numero=numero;
            this.tipo=tipo;
        }
        public override string ToString()
        {
            if (mostrar == true)
                return numeroToString(numero) + " of " + tipoToString(tipo);
            return "The card is facedown, you cannot see it!";
        }
        
        //extract green channel from image to highlight image
        public void Highlight()
        {
            if (mostrar == false)
                return;

            this.mostrar = true;

            if (this.Image == null)
                getImageFromFile();
            Bitmap HighlightedBitmap = new Bitmap(Image.Width, Image.Height);
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    int green = Image.GetPixel(i, j).G;
                    HighlightedBitmap.SetPixel(i, j, Color.FromArgb(255, 0, green, 0));
                }
            }
            Image = new Bitmap(HighlightedBitmap);
        }
        //reload original image to unhighlight
        public void UnHighlight()
        {
            if (mostrar == false)
                return;
            this.destacar = false;
            getImageFromFile();
        }
        public bool isHighlighted()
        {
            return this.destacar;
        }

        //compare rank of cards
        public static bool operator ==(Card a, Card b)
        {
            if (a.numero == b.numero)
                return true;
            else
                return false;
        }
        public static bool operator !=(Card a, Card b)
        {
            if (a.numero != b.numero)
                return true;
            else
                return false;
        }
        public static bool operator <(Card a, Card b)
        {
            if (a.numero < b.numero)
                return true;
            else
                return false;
        }
        public static bool operator >(Card a, Card b)
        {
            if (a.numero > b.numero)
                return true;
            else
                return false;
        }
        public static bool operator <=(Card a, Card b)
        {
            if (a.numero <= b.numero)
                return true;
            else
                return false;
        }
        public static bool operator >=(Card a, Card b)
        {
            if (a.numero >= b.numero)
                return true;
            else
                return false;
        }
    }
    
}

