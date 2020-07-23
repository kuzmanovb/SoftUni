
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public List<PartsDTO> Parts { get; set; }

    }

    [XmlType("partId")]
    public class PartsDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }

}
