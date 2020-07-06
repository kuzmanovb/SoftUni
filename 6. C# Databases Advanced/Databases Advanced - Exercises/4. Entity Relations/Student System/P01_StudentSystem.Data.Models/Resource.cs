using System.ComponentModel.DataAnnotations;

using P01_StudentSystem.Data.Models.Enumerates;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public ResorceTypeEnum ResourceType { get; set; }

        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }



    }
}
