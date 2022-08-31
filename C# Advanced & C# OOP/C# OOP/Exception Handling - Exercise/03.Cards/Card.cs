using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Cards
{
    public class Card
    {
        private string face;
        private string suit;
        public string Face
        {
            get
            {
                return this.face;
            }

            set
            {
                //Valid card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
                if (value != "2" && value != "3" && value != "4" && value != "5" && value != "6" && value != "7" && value != "8" && value != "9" && value != "10" && value != "J" && value != "Q" && value != "K" && value != "A")
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }
        public string Suit
        {
            get
            {
                return this.suit;
            }

            set
            {
                //Valid card suits are: S (♠), H (♥), D (♦), C (♣)
                if (value != "S" && value != "H" && value != "D" && value != "C")
                {
                    throw new ArgumentException("Invalid card!");
                }

                if (value == "S")
                {
                    this.suit = "\u2660";
                }
                else if (value == "H")
                {
                    this.suit = "\u2665";
                }
                else if (value == "D")
                {
                    this.suit = "\u2666";
                }
                else if (value == "C")
                {
                    this.suit = "\u2663";
                }
            }

        }

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }
    }
}
