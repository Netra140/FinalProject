using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.GodModels
{
    public class GodCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter At Least 1 Character")]
        public string GodName { get; set; }
        
        public string GodDesc { get; set; }

    }
}
