using System.Collections.Generic;

using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class InboxPrisonerDTO
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }
        [XmlArray("EncryptedMessages")]
        public List<MasageDTO> EncryptedMessages { get; set; }

    }


    [XmlType("Message")]
    public class MasageDTO
    {
        [XmlElement("Description")]
        public string Description { get; set; }

    }
}
