using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Entity
{
    //[Table("luutru")]
    public class LuuTru
    {
        public string masanpham { get; set; }
        public string tensanpham { get; set; }
        public int soluong { get; set; }
        public string khu { get; set; }
        public string hang { get; set; }
        public string ke { get; set; }
        public string nguoixuli { get; set; }
        //public DateTime thoigian { get; set; }
        public string nhaporxuat { get; set; }
        public DateTime ngayxuli { get; set; }

        public LuuTru()
        {
            
        }

        public LuuTru(string masanpham, string tensanpham, int soluong, string khu, string hang, string ke, string nguoixuli, string nhaporxuat, DateTime ngayxuli)
        {
            this.masanpham = masanpham;
            this.tensanpham = tensanpham;
            this.soluong = soluong;
            this.khu = khu;
            this.hang = hang;
            this.ke = ke;
            this.nguoixuli = nguoixuli;
            this.nhaporxuat = nhaporxuat;
            this.ngayxuli = ngayxuli;
        }
    }
}
