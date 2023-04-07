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
            //var resultAlbums = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(resultAlbums);


            var resultPerformers = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(resultPerformers);
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
            var sb = new StringBuilder();

            var songs = context.Songs.AsEnumerable().Where(s => s.Duration.TotalSeconds > duration)
                            .Select(s => new
                            { 
                                s.Name, 
                                WriterName = s.Writer.Name, 
                                s.Duration,
                                s.Id, 
                                s.SongPerformers, 
                                ProducerName = s.Album.Producer.Name
                            })
                            .ToArray();
            var number = 0;

            foreach (var song in songs.OrderBy(s=> s.Name).ThenBy(w => w.WriterName))
            {
                number++;
                sb.AppendLine($"-Song #{number}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                var exSong = song.Id;
                var performers = song.SongPerformers.Select(s => new { s.Performer.FirstName, s.Performer.LastName}).ToArray();
                if (performers != null)
                {
                    foreach (var performer in performers.OrderBy(p => p.FirstName))
                    {
                        sb.AppendLine($"---Performer: {performer.FirstName} {performer.LastName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
