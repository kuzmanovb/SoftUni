using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsCells
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string Name { get; set; }

        public ICollection<CellDTO> Cells { get; set; }

    }

    public class CellDTO
    {
        [Required]
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}
