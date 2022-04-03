using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class LuongKhauTruServices : ILuongKhauTruServices
    {
        private readonly AppDbContext dbContext;

        public LuongKhauTruServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<LuongKhauTru> HienThiDanhSachLuongKhauTru()
        {
            return dbContext.luongKhauTrus.AsQueryable();
        }
        
        public double TinhTienKhauTru(int luongKhauTruId)
        {
            // LuongKhauTru = soNgayDiMuon*(luongCung/24) + soGioDiMuon*(luongCung/24/8)
            var luongKhauTru = dbContext.luongKhauTrus.Include(x => x.Luong).FirstOrDefault(x => x.Id == luongKhauTruId);
            return luongKhauTru.soNgayMuon * (luongKhauTru.Luong.luongCung / 24) +
                    luongKhauTru.soGioMuon * (luongKhauTru.Luong.luongCung / 24 / 8);
        }
        
        public double TinhTongLuongKhauTru(int luongTongId)
        {
            var lstLuongKhauTru = dbContext.luongKhauTrus.Where(x => x.luongTongId == luongTongId).ToList();
            return lstLuongKhauTru.Sum(x => x.tienKhauTru);
        }

        public LuongKhauTru SuaLuongKhauTru(LuongKhauTru luongKhauTru)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var curLuongKhauTru = dbContext.luongKhauTrus.Find(luongKhauTru.Id);
                if (dbContext.luongKhauTrus.Any(x => x.Id == luongKhauTru.Id))
                {
                    curLuongKhauTru.soNgayMuon = luongKhauTru.soNgayMuon;
                    curLuongKhauTru.soGioMuon = luongKhauTru.soGioMuon;
                    curLuongKhauTru.tienKhauTru = TinhTienKhauTru(luongKhauTru.Id);
                    curLuongKhauTru.dateTime = DateTime.Now;
                    dbContext.Update(curLuongKhauTru);
                    dbContext.SaveChanges();
                    curLuongKhauTru.Luong.luongKhauTru = TinhTongLuongKhauTru(curLuongKhauTru.Luong.Id);
                    curLuongKhauTru.Luong.luongTong += curLuongKhauTru.Luong.luongKhauTru;
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Tai Luong Khau Tru Nay!!!");
                }
                trans.Commit();
                return curLuongKhauTru;
            }
        }

        public LuongKhauTru ThemLuongKhauTru(LuongKhauTru luongKhauTru)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.luongTongs.Any(x => x.Id == luongKhauTru.luongTongId))
                {
                    dbContext.luongKhauTrus.Add(luongKhauTru);
                    dbContext.SaveChanges();

                    luongKhauTru.tienKhauTru = TinhTienKhauTru(luongKhauTru.Id);
                    luongKhauTru.dateTime = DateTime.Now;
                    dbContext.Update(luongKhauTru);
                    dbContext.SaveChanges();
                    luongKhauTru.Luong.luongKhauTru += luongKhauTru.tienKhauTru;
                    luongKhauTru.Luong.luongTong += luongKhauTru.tienKhauTru;
                    dbContext.SaveChanges();


                }
                else
                {
                    throw new Exception("Chua Co Nhan Vien Nay De Co Luong Khau Tru!!!");
                }
                trans.Commit();
                return luongKhauTru;
            }
        }

        public LuongKhauTru XoaLuongKhauTru(int luongKhauTruId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var luongKhauTru = dbContext.luongKhauTrus.FirstOrDefault(x => x.Id == luongKhauTruId);
                if (luongKhauTru != null)
                {
                    dbContext.Remove(luongKhauTru);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Luong Khau Tru Nay!!");

                }
                trans.Commit();
                return luongKhauTru;
            }
        }
    }
}
