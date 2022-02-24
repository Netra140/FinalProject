using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Data
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key
        [Required]
        public int NativeRaceId { get; set; }

        [Required]
        public string CapitalCity { get; set; }

        [Required]
        public string Government { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
