using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class SongPerformersDTO
    {

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(18, 70)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Range(0, Double.MaxValue)]
        [XmlElement("NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public List<SongToPerformer> PerformersSongs { get; set; }

    }

    [XmlType("Song")]
    public class SongToPerformer
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
