using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    [Table("xuatkho")]
    public class XuatKho
    {
        public string masanpham { get; set; }
        public string tensanpham { get; set; }
        public int soluong { get; set; }
        [ForeignKey("khu")]
        public int khuid { get; set; }
        [ForeignKey("hang")]
        public int hangid { get; set; }
        [ForeignKey("ke")]
        public int keid { get; set; }
        public string nguoilay { get; set; } = null!;
        public DateTime ngaylay { get; set; }
    }
}
