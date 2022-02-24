using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.RaceModels
{
    public class RaceDetail
    {
        public int RaceID { get; set; }
        public bool Playable { get; set; }
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public int PantheonID { get; set; }
        public int RaceType { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}