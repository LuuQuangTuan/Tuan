using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Entities;

namespace FinalProject.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChamCong> chamCongs { get; set; }
        public DbSet<DonXinNghiPhep> donXinNghiPheps { get; set; }
        public DbSet<DuAn> duAns { get; set; }
        public DbSet<LuongTong> luongTongs { get; set; }
        public DbSet<LuongKhauTru> luongKhauTrus { get; set; }
        public DbSet<LuongLamThem> luongLamThems { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<SuKien> suKiens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =DESKTOP-5B7FN29; initial catalog =TinasoftDB; integrated security = SSPI;");
        }
    }
}
