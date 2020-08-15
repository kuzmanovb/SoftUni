using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersPrisonersDTO
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public  List<PrisonerDTO> Prisoners { get; set; }



    }

    [XmlType("Prisoner")]
    public class PrisonerDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}
