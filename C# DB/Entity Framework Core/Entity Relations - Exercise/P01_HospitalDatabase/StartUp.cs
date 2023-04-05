using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           var db = new HospitalContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}