

using P02_FootballBetting.Data;

namespace P02_FootballBetting
{
    public class StartUp
    {
        static void Main()
        {
            var db = new FootballBettingContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}