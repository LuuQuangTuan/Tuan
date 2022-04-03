using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class LuongLamThem
    {
        [Key]
        public int Id { get; set; }
        public int luongTongId { get; set; }
        public int duAnId { get; set; }
        public int soGioLam { get; set; }
        public double tienThuong { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime dateTime { get; set; }
        public virtual LuongTong Luong { get; set; }
    }
}
