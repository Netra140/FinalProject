using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Models.PantheonModels
{
    public class PantheonCreate
    {
        [Required]
        public string PantheonName { get; set; }
    }
}
