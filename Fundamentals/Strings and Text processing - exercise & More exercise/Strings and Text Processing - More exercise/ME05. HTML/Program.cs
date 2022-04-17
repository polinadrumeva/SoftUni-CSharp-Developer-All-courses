using System;

namespace ME05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {titleOfArticle}");
            Console.WriteLine("</h1>");
            string contentOfArticle  = Console.ReadLine();
            string comment;
            Console.WriteLine("<article>");
            Console.WriteLine($"    {contentOfArticle}");
            Console.WriteLine("</article>");
            while ((comment = Console.ReadLine()) != "end of comments")
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {comment}");
                Console.WriteLine("</div>");
            }
        }
    }
}
