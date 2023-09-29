using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    [Table("khu")]
    public class Khu
    {
        public int id { get; set; }
        public string tenkhu { get; set; }
    }
}
