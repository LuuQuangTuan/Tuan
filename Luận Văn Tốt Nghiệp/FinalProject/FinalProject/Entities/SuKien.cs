using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class SuKien
    {
        [Key]
        public int  Id { get; set; }
        [Column("ngayBatDau", TypeName = "date")]
        public DateTime ngayBatDau { get; set; }
        [Column("ngayKetThuc", TypeName = "date")]
        public DateTime ngayKetThuc { get; set; }
        public string tieuDe { get; set; }
        public string  noiDung { get; set; }

    }
}
