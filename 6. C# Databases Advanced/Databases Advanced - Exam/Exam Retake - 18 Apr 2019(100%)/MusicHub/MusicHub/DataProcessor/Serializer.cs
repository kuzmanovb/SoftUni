namespace MusicHub.DataProcessor
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Newtonsoft.Json;

    using Data;
    using MusicHub.DataProcessor.ExportDTO;
    using MusicHub.XMLHelper;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumProducer = context.Albums
                                .Where(p => p.ProducerId == producerId)
                                .Select(p => new
                                {
                                    AlbumName = p.Name,
                                    ReleaseDate = p.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    ProducerName = p.Producer.Name,
                                    Songs = p.Songs.Select(s => new
                                            {
                                                SongName = s.Name,
                                                Price = s.Price.ToString("F2"),
                                                Writer = s.Writer.Name
                                            })
                                            .ToList()
                                            .OrderByDescending(n => n.SongName)
                                            .ThenBy(w => w.Writer)
                                            .ToList(),
                                    AlbumPrice = p.Songs.Sum(s => s.Price).ToString("F2")
                                })
                                .ToList()
                                .OrderByDescending(s => decimal.Parse(s.AlbumPrice))
                                .ToList();

            var albumProducerJSON = JsonConvert.SerializeObject(albumProducer, Formatting.Indented);

            return albumProducerJSON;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsForExport = context.Songs
                                .Where(s => s.Duration.TotalSeconds > duration)
                                .Select(s => new SongWithDurationDTO
                                {
                                    SongName = s.Name,
                                    Writer = s.Writer.Name,
                                    Performer = s.SongPerformers
                                                .Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                                                .FirstOrDefault(),
                                    AlbumProducer = s.Album.Producer.Name,
                                    Duration = s.Duration.ToString("c")
                                })
                                .ToList()
                                .OrderBy(n => n.SongName)
                                .ThenBy(w => w.Writer)
                                .ThenBy(p => p.Performer)
                                .ToList();

            var songsForExportXML = XMLConverter.Serialize(songsForExport, "Songs");

            return songsForExportXML;

        }
    }
}