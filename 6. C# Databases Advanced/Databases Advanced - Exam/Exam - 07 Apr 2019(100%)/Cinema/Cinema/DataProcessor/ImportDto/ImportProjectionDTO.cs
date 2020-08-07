using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    
    
    [XmlType("Projection")]
    public class ImportProjectionDTO
    {
        [Required]
        [ForeignKey("Movie")]
        [XmlElement("MovieId")]
        public int MovieId { get; set; }

        [Required]
        [ForeignKey("Hall")]
        [XmlElement("HallId")]
        public int HallId { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }
    }
}
