using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class DonXinNghiPhep
    {
        [Key]
        public int Id { get; set; }
        public int nhanVienId { get; set; }
        public int soNgayNghi { get; set; }
        public string lyDo { get; set; }
        public string lyDoTuChoi { get; set; }
        [Column("dateTime", TypeName = "date")]
        public DateTime dateTime { get; set; }
        public virtual NhanVien NhanVien { get; set; }

    }
}
