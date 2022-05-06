using System;
using System.Collections.Generic;
using System.Linq;

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
       
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticle = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticle; i++)
            {
                string command = Console.ReadLine();
                string[] commands = command.Split(", ");
                string name = commands[0];
                string content = commands[1];
                string author = commands[2];

                Article article = new Article(name, content, author);
                articles.Add(article);
            }
            
            string typeOfOrderList = Console.ReadLine();
            if (typeOfOrderList == "title")
            {
                articles = articles.OrderBy(article => article.Title).ToList();
               
            }
            else if (typeOfOrderList == "content") 
            {
                articles = articles.OrderBy(article => article.Content).ToList();
                
            }
            else if (typeOfOrderList == "author")
            {
                articles = articles.OrderBy(article => article.Author).ToList();
               
            }
            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
}
