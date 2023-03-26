using CodeFirstDemo;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.EnsureCreated();
        }
    }
}