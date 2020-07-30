using System.Collections.Generic;

using Newtonsoft.Json;

namespace BookShop.DataProcessor.ExportDto
{
    public class CraziesAuthorDTO
    {
        public string AuthorName { get; set; }

        [JsonProperty("Books")]
        public List<CraziesAuthorBooksDTO> Books { get; set; }
    }

    public class CraziesAuthorBooksDTO
    {
        [JsonProperty("BookName")]
        public string BookName { get; set; }

        [JsonProperty("BookPrice")]
        public string BookPrice { get; set; }
    }
}
