namespace MusicHub.Data
{
    public static class Configuration
    {
        public static string ConnectionString =
            @"Server=.;Database=MusicHub;Integrated security=true;Trusted_Connection=True";

        public const int maxLengthForName = 20;

        public const int maxLengthForNameAlbum = 40;

        public const int maxLengthForNameProducer = 30;


    }
}
