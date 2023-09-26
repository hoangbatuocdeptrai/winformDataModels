using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels
{
    [Table("models")]
    public class Modelss
    {
        public int id { get; set; }
        public string? modelsname { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public float traythicknessmm { get; set; }
        public int traycount { get; set; }

        //public virtual ICollection<DetailModels>? detailModels { get; set; }
    }
}
