using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    [Table("hang")]
    public class Hang
    {
        public int id { get; set; }
        public string tenhang { get; set; }
    }
}
