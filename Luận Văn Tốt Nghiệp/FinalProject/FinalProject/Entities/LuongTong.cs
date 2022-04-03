using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class LuongTong
    {
        [ForeignKey("NhanVien")]
        public int Id { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime dateTime { get; set; }
        public double luongLamThem { get; set; }
        public double luongCung { get; set; }
        public double luongKhauTru { get; set; }
        public double luongTong { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public IEnumerable<ChamCong> chamCongs { get; set; }
        public IEnumerable<LuongKhauTru> luongKhauTrus { get; set; }
        public IEnumerable<LuongLamThem> luongLamThems { get; set; }


    }
}
