using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    [Table("nhapkho")]
    public class NhapKho
    {
        public int id { get; set; }
        public string masanpham { get; set; }
        public string tensanpham { get; set; }
        public int soluong { get; set; }
        [ForeignKey("khu")]
        public int khuid { get; set; }
        [ForeignKey("hang")]
        public int hangid { get; set; }
        [ForeignKey("ke")]
        public int keid { get; set; }
        public string nguoinhap { get; set; }

        public string nhasanxuat { get; set; }
        public DateTime ngaynhapkho { get; set; }
        public DateTime thoihansudung { get; set; }


        //them
        public string tenkhu { get; set; }
        public string tenhang { get; set; }
        public string tenke { get; set; }
    }
}
