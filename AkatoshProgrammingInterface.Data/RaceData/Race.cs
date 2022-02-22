using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Data.RaceData
{
    public class Race
    {
        [Key]
        public int RaceID { get; set; }
        [Required]
        public bool Playable { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProvinceID { get; set; } //must match a province ID will be input from a string
        [Required]
        public int PantheonID { get; set; }
        [Required]
        public int RaceType { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
