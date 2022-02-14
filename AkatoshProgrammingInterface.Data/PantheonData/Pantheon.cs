using AkatoshProgrammingInterface.Data.GodData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Data.PantheonData
{
    public class Pantheon
    {
        [Key]
        public int PantheonID { get; set; }

        [Required]
        public string PantheonName { get; set; }

        public virtual ICollection<God> Gods { get; set; } = new List<God>();
    }

}
