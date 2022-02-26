using AkatoshProgrammingInterface.Data.PantheonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Data.GodData
{
    public class God
    {
        [Key]
        public int GodID { get; set; }

        [Required]
        public string GodName { get; set; }

        [Required]
        public string GodDesc { get; set; }

    }
}
