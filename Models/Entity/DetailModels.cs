using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    [Table("detailmodels")]
    public class DetailModels
    {
        public int id { get; set; }
        [ForeignKey("Modelss")]
        public int modelid { get; set; }
        public string barcode { get; set; } = null!;
        public string pathimage { get; set; } = null!;
        public DateTime created_at { get; set; }
        public byte status { get; set; }

        //public Modelss? Modelss { get; set; } = null!;

        //public DetailModels()
        //{
        //}
        //public DetailModels(int modelid, string barcode, string pathimage, Modelss Modelss)
        //{
        //    this.modelid = modelid;
        //    this.barcode = barcode;
        //    this.pathimage = pathimage;
        //    this.Modelss = Modelss;
        //}

    }
}
