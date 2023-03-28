using Demo.Data;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new NewsContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}