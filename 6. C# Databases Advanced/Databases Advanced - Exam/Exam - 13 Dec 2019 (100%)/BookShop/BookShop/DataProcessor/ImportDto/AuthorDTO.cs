using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Books")]
        public List<BookIdDTO> BooksId { get; set; }

    }

    public class BookIdDTO
    {
        [JsonProperty("Id")]
        public int? Id { get; set; }

    }
}
