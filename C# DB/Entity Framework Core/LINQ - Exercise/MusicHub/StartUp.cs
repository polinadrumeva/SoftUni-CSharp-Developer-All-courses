namespace MusicHub
{
    using System;
    using System.Text;
    using Castle.DynamicProxy.Generators;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            ////Test your solutions here
            var resultAlbums = ExportAlbumsInfo(context, 9);
            Console.WriteLine(resultAlbums);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Albums.Where(p => p.ProducerId == producerId).ToArray();
            foreach (var album in albums.OrderByDescending(a => a.Price)) 
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.Producer.Name}");
                sb.AppendLine($"-Songs:");
                var number = 0;
                foreach (var song in album.Songs.OrderByDescending(s => s.Name).ThenBy(w => w.Name))
                {
                    number++;
                    sb.AppendLine($"---#{number}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
