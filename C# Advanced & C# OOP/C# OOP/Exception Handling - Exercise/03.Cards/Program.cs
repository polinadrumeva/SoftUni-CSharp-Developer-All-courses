using System;
using System.Collections.Generic;

namespace _03.Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> validCards = new List<Card>(); 
            string[] cards = Console.ReadLine().Split(", ");

            for (int i = 0; i < cards.Length; i++)
            {
                string[] card = cards[i].Split(" ");
                try
                {
                    string face = card[0];
                    string suit = card[1];
                    Card newCard = new Card(face, suit);
                    validCards.Add(newCard);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var card in validCards)
            {
                Console.Write($"[{card.Face}{card.Suit}] ");
            }

            Console.WriteLine();
        }
    }
}
