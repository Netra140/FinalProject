using AkatoshProgrammingInterface.Data.GodData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //One Pantheon Can Have Many Gods//
        public virtual ICollection<God> Gods { get; set; } = new List<God>();

    }

}
