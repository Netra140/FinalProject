using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.RaceModels
{
    public class RaceList
    {
        [Display(Name="Id")]
        public int RaceId { get; set; }
        public bool Playable { get; set; }
        public string Name { get; set; }
        //public int ProvinceID { get; set; }
        public int PantheonID { get; set; }
        //public int RaceType { get; set; }
        //public object CreatedUtc { get; set; }
    }
}
