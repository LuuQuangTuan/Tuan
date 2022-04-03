
using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class LuongLamThemServices : ILuongLamThemServices
    {
        private readonly AppDbContext dbContext;
        public LuongLamThemServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<LuongLamThem> HienThiDanhSachLuongLamThem()
        {
            return dbContext.luongLamThems.AsQueryable();
        }

        public double TinhLuongLamThem(int luongLamThemId)
        {
            var luongLamThem = dbContext.luongLamThems.Include(x => x.Luong).FirstOrDefault(x => x.Id == luongLamThemId);
            return luongLamThem.Luong.luongCung / 24 / 8 * 1.5 * luongLamThem.soGioLam;
        }
        
        public double TinhTongLuongLamThem(int luongTongId)
        {
            var lstLuongLamThem = dbContext.luongLamThems.Where(x => x.luongTongId == luongTongId).ToList();
            return lstLuongLamThem.Sum(x => x.tienThuong);
        }

        public LuongLamThem SuaLuongLamThem(LuongLamThem luongLamThem)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var curLuongLamThem = dbContext.luongLamThems.Find(luongLamThem.Id);
                if (dbContext.luongKhauTrus.Any(x => x.Id == luongLamThem.Id))
                {

                    curLuongLamThem.soGioLam = luongLamThem.soGioLam;
                    curLuongLamThem.dateTime = DateTime.Now;
                    curLuongLamThem.tienThuong = TinhLuongLamThem(curLuongLamThem.Id);
                    dbContext.Update(curLuongLamThem);
                    dbContext.SaveChanges();
                    curLuongLamThem.Luong.luongLamThem = TinhTongLuongLamThem(curLuongLamThem.Luong.Id);
                    curLuongLamThem.Luong.luongTong += curLuongLamThem.Luong.luongLamThem;
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Luong Lam Them Nay!!!");
                }
                trans.Commit();
                return curLuongLamThem;
            }
        }

        public LuongLamThem ThemLuongLamThem(LuongLamThem luongLamThem)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.luongTongs.Any(x => x.Id == luongLamThem.luongTongId))
                {
                    if (dbContext.duAns.Any(x => x.Id == luongLamThem.duAnId))
                    {
                        dbContext.luongLamThems.Add(luongLamThem);
                        dbContext.SaveChanges();

                        luongLamThem.tienThuong = TinhLuongLamThem(luongLamThem.Id);
                        luongLamThem.dateTime = DateTime.Now;
                        dbContext.Update(luongLamThem);
                        dbContext.SaveChanges();
                        luongLamThem.Luong.luongLamThem += luongLamThem.tienThuong;
                        luongLamThem.Luong.luongTong += luongLamThem.tienThuong;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Chua Co Du An Nay De Co Luong Lam Them!!!");
                    }

                }
                else
                {
                    throw new Exception("Chua Co Nhan Vien Nay De Co Luong Lam Them!!!");
                }
                trans.Commit();
                return luongLamThem;
            }
        }

        public LuongLamThem XoaLuongLamThem(int luongLamThemId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var luongLamThem = dbContext.luongLamThems.FirstOrDefault(x => x.Id == luongLamThemId);
                if (luongLamThem != null)
                {
                    dbContext.Remove(luongLamThem);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Luong Lam Them Nay!!");

                }
                trans.Commit();
                return luongLamThem;
            }
        }
    }
}
