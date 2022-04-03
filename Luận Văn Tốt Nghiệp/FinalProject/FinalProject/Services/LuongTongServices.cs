using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class LuongTongServices : ILuongTongServices
    {
        private readonly AppDbContext dbContext;
        public LuongTongServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<LuongTong> HienThiDanhSachLuongTong()
        {
            return dbContext.luongTongs.AsQueryable();
        }

        public LuongTong SuaLuongTong(LuongTong luongTong)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var curLuongTong = dbContext.luongTongs.Include(x => x.luongKhauTrus).Include(y => y.luongLamThems).FirstOrDefault(x => x.Id == luongTong.Id);
                if (dbContext.luongTongs.Any(x => x.Id == luongTong.Id))
                {
                    curLuongTong.dateTime = DateTime.Now;
                    curLuongTong.luongCung = luongTong.luongCung;
                    curLuongTong.luongKhauTru = 0;
                    curLuongTong.luongLamThem = 0;
                    curLuongTong.luongTong = 0;
                    dbContext.Update(curLuongTong);
                    dbContext.SaveChanges();
                    var lstLuongLamThem = dbContext.luongLamThems.Where(x => x.luongTongId == luongTong.Id).ToList();
                    foreach (LuongLamThem luongLamThem in lstLuongLamThem)
                    {
                        luongLamThem.tienThuong = curLuongTong.luongCung / 24 / 8 * 1.5 * luongLamThem.soGioLam;
                        curLuongTong.luongLamThem += luongLamThem.tienThuong;
                        curLuongTong.luongTong += luongLamThem.tienThuong;
                    }
                    var lstLuongKhauTru = dbContext.luongKhauTrus.Where(x => x.luongTongId == luongTong.Id).ToList();
                    foreach (LuongKhauTru luongKhauTru in lstLuongKhauTru)
                    {
                        luongKhauTru.tienKhauTru = luongKhauTru.soNgayMuon * (curLuongTong.luongCung / 24) +
                                                    luongKhauTru.soGioMuon * (curLuongTong.luongCung / 24 / 8);
                        curLuongTong.luongKhauTru += luongKhauTru.tienKhauTru;
                        curLuongTong.luongTong += luongKhauTru.tienKhauTru;
                    }
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Tai Luong Tong Nay!!!");
                }
                trans.Commit();
                return curLuongTong;
            }
        }

        public LuongTong ThemLuongTong(LuongTong luongTong)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var arrNhanVien = dbContext.nhanViens.AsQueryable().ToArray();
                //var arrLuongTong = dbContext.luongTongs.AsQueryable().ToArray();
                luongTong.Id = arrNhanVien[arrNhanVien.Length - 1].Id;
                luongTong.luongKhauTru = 0;
                luongTong.luongTong = 0;
                luongTong.luongLamThem = 0;
                dbContext.Add(luongTong);
                dbContext.SaveChanges();


                trans.Commit();
                return luongTong;
            }


        }

        public LuongTong XoaLuongTong(int luongTongId)
        {

            using (var trans = dbContext.Database.BeginTransaction())
            {
                var curLuongTong = dbContext.luongTongs.Find(luongTongId);
                if (curLuongTong != null)
                {
                    dbContext.luongTongs.Remove(curLuongTong);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Co Nhan Vien Co Luong Nay !!");
                }
                trans.Commit();
                return curLuongTong;
            }
        }
    }
}
