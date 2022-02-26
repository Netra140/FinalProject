using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models
{
    public class ProvinceCreate
    {
        [Required]
        public string Name { get; set; }

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