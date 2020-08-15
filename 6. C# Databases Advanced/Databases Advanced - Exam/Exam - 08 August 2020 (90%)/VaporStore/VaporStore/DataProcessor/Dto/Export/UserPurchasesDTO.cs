using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserPurchasesDTO
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public List<PurchasesDTO> Purchases { get; set; }
        
        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
    
    
    [XmlType("Purchase")]
    public class PurchasesDTO
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public GameDTO Game { get; set; }

    }

    [XmlType("Game")]
    public class GameDTO
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }


}
