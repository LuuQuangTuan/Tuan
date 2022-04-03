using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public string email { get; set; }
        [MaxLength(20)]
        [MinLength(2)]
        public string hoTen { get; set; }
        [Column("ngaySinh", TypeName = "date")]
        public DateTime ngaySinh { get; set; }
        [MaxLength(11)]
        [MinLength(10)]
        public string sDT { get; set; }
        public string diaChi { get; set; }
        public string chucVu { get; set; }
        [MaxLength(12)]
        [MinLength(2)]
        public string cMND { get; set; }
        public string position { get; set; }
        public string image { get; set; }
        public IEnumerable<DonXinNghiPhep> donXinNghiPheps { get; set; }
        public virtual LuongTong Luong { get; set; }

    }
}
