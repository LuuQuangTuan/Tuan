using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class LuongKhauTru
    {
        [Key]
        public int Id { get; set; }
        public int luongTongId { get; set; }
        public int soNgayMuon { get; set; } 
        public int soGioMuon { get; set; }
        public double tienKhauTru { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime dateTime { get; set; }
        public virtual LuongTong Luong { get; set; }


    }
}
