using System;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class SongsDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Range(0, Double.MaxValue)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }
     
        [XmlElement("WriterId")]
        public int WriterId { get; set; }


    }
}
