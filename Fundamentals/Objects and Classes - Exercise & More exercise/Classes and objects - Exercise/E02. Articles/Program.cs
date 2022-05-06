using System;
using System.Collections.Generic;

namespace E02._Articles
{
    class Article
    {
        public Article(string name, string content, string author)
        { 
            this.Title = name;
            this.Content = content;
            this.Author = author;
        }
        
        public string Title { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string commands = Console.ReadLine();
            string[] command = commands.Split(", ");
            string name = command[0];
            string content = command[1];
            string author = command[2];

            Article article = new Article(name, content, author);

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                string comand = Console.ReadLine();
                string[] comands = comand.Split(": ");
                switch (comands[0])
                {
                    case "Edit":
                        article.Content = comands[1];
                        break;
                    case "ChangeAuthor":
                        article.Author = comands[1];
                        break;
                    case "Rename":
                        article.Title = comands[1];
                        break;
                   
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

        }
    }
}
