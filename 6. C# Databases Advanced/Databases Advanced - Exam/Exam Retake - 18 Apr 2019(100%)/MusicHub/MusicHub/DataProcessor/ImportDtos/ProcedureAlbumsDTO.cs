using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ProcedureAlbumsDTO
    {

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359\s\d{3}\s\d{3}\s\d{3}$")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public List<AlbumDTO> Albums { get; set; }

    }

    public class AlbumDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }


    }
}
