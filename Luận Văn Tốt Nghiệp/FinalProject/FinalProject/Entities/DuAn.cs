using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class DuAn
    {
        [Key]
        public int Id { get; set; }
        public string tenDuAn { get; set; }
        public double luongThuong { get; set; }
        public IEnumerable<LuongLamThem> luongLamThems { get; set; }


    }
}
