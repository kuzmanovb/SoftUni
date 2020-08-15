using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [Required]
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

        [Required]
        [ForeignKey("Officer")]
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
    }
}
