using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    [Table("ke")]
    public class Ke
    {
        public int id { get; set; }
        public string tenke { get; set; }
    }
}
