using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.RaceModels
{
    public class RaceCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 Character for the name")]
        public string Name { get; set; }
        public bool Playable { get; set; }
        public int ProvinceID { get; set; }
        public int PantheonID { get; set; }
        public int RaceType { get; set; }
    }
}
