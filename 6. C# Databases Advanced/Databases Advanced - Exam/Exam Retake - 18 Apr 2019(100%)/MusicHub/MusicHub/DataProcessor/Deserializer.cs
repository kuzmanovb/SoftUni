namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using MusicHub.XMLHelper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersFromJSON = JsonConvert.DeserializeObject<List<Writer>>(jsonString);

            var writerForAdd = new List<Writer>();
            var sb = new StringBuilder();

            foreach (var writer in writersFromJSON)
            {
                if (!IsValid(writer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newWriter = new Writer
                {
                    Name = writer.Name,
                    Pseudonym = writer.Pseudonym
                };

                writerForAdd.Add(newWriter);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));

            }

            context.Writers.AddRange(writerForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd(); 
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAlbumsFromJSON = JsonConvert.DeserializeObject<List<ProcedureAlbumsDTO>>(jsonString);

            var producersForAdd = new List<Producer>();
            var albumsForAdd = new List<Album>();
            var sb = new StringBuilder();

            foreach (var pa in producersAlbumsFromJSON)
            {

                if (!IsValid(pa))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newProducer = new Producer
                {
                    Name = pa.Name,
                    Pseudonym = string.IsNullOrEmpty(pa.Pseudonym) ? null : pa.Pseudonym,
                    PhoneNumber = string.IsNullOrEmpty(pa.PhoneNumber) ? null : pa.PhoneNumber
                };

                var checkForErrorAlbum = false;
                var curentAlbums = new List<Album>();

                foreach (var a in pa.Albums)
                {
                    if (!IsValid(a))
                    {
                        sb.AppendLine(ErrorMessage);
                        checkForErrorAlbum = true;
                        break;
                    }

                    var newAlbum = new Album
                    {
                        Name = a.Name,
                        ReleaseDate = DateTime.ParseExact(a.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Producer = newProducer
                    };

                    curentAlbums.Add(newAlbum);
                }

                if (!checkForErrorAlbum)
                {
                    producersForAdd.Add(newProducer);
                    albumsForAdd.AddRange(curentAlbums);

                    if (string.IsNullOrEmpty(pa.PhoneNumber))
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, pa.Name, curentAlbums.Count));
                    }
                    else
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, pa.Name, pa.PhoneNumber, curentAlbums.Count));
                    }
                }

            }

            context.Producers.AddRange(producersForAdd);
            context.Albums.AddRange(albumsForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var songsFromXML = XMLConverter.Deserializer<SongsDTO>(xmlString, "Songs");

            var sb = new StringBuilder();
            var songsForAdd = new List<Song>();

            var albumsId = context.Albums.Select(i => i.Id).ToList();
            var writersId = context.Writers.Select(w => w.Id).ToList();

            foreach (var s in songsFromXML)
            {
                if (!IsValid(s))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var checkGenre = Enum.IsDefined(typeof(Genre), s.Genre);
                var checkAlbumId = s.AlbumId != null ? albumsId.Contains((int)s.AlbumId) : true;
                var checkWritersId = writersId.Contains(s.WriterId);

                if (!checkGenre || !checkAlbumId || !checkWritersId)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newSong = new Song
                {
                    Name = s.Name,
                    Duration = TimeSpan.ParseExact(s.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(s.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = (Genre)Enum.Parse(typeof(Genre), s.Genre),
                    Price = s.Price,
                    AlbumId = s.AlbumId,
                    WriterId = s.WriterId
                };

                songsForAdd.Add(newSong);

                sb.AppendLine(string.Format(SuccessfullyImportedSong, s.Name, s.Genre, s.Duration));

            }

            context.AddRange(songsForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var performersSongsFromXML = XMLConverter.Deserializer<SongPerformersDTO>(xmlString, "Performers");

            var sb = new StringBuilder();
            var performersForeAdd = new List<Performer>();
            var songPerformersForAdd = new List<SongPerformer>();

            var songsId = context.Songs.Select(i => i.Id).ToList();

            foreach (var ps in performersSongsFromXML)
            {
                if (!IsValid(ps))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newPerformer = new Performer
                {
                    FirstName = ps.FirstName,
                    LastName = ps.LastName,
                    Age = ps.Age,
                    NetWorth = ps.NetWorth
                };

                var checkSongId = true;
                var curentSongPerformers = new List<SongPerformer>();

                foreach (var si in ps.PerformersSongs)
                {
                    if (!songsId.Contains(si.Id))
                    {
                        sb.AppendLine(ErrorMessage);
                        checkSongId = false;
                        break;
                    }

                    var newSongPerformer = new SongPerformer
                    {
                        Performer = newPerformer,
                        SongId = si.Id
                    };

                    curentSongPerformers.Add(newSongPerformer);
                }

                if (checkSongId)
                {

                    performersForeAdd.Add(newPerformer);
                    songPerformersForAdd.AddRange(curentSongPerformers);
                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer, ps.FirstName, ps.PerformersSongs.Count));
                }

            }

            context.Performers.AddRange(performersForeAdd);
            context.SongsPerformers.AddRange(songPerformersForAdd);
            context.SaveChanges();


            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, results, true);

        }
    }
}