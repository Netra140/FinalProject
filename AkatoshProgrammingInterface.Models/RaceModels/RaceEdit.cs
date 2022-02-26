using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.RaceModels
{
    public class RaceEdit
    {
        [Required]
        public bool Playable { get; set; }
        [Required]
        public string Name { get; set; }

       // [Required]
       // public int ProvinceID { get; set; }
        [Required]
        public int PantheonID { get; set; }
        //[Required]
        //public int RaceType { get; set; }
        [Key]
        public int RaceID { get; set; }
    }
}
