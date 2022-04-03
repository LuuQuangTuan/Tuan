using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Services
{
    public class ChamCongServices : IChamCongServices
    {
        private readonly AppDbContext dbContext;
        public ChamCongServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<ChamCong> HienThiDanhSachChamCong()
        {
            return dbContext.chamCongs.AsQueryable();
        }

        public ChamCong SuaChamCong(ChamCong chamCong)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.chamCongs.Any(x => x.Id == chamCong.Id))
                {
                    var curChamCong = dbContext.chamCongs.Find(chamCong.Id);
                    curChamCong.trangThai = chamCong.trangThai;
                    curChamCong.dateTime = DateTime.Now;
                    dbContext.Update(curChamCong);
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Tai Cham Cong Nay!!!");
                }
                trans.Commit();
                return chamCong;
            }
        }

        public ChamCong ThemChamCong(ChamCong chamCong)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.luongTongs.Any(x => x.Id == chamCong.luongTongId))
                {
                    chamCong.dateTime = DateTime.Now;
                    dbContext.chamCongs.Add(chamCong);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Chua Co Nhan Vien Nay De Cham Cong!!!");
                }
                trans.Commit();
                return chamCong;
            }

        }

        public IEnumerable<ChamCong> TimKiemDanhSachChamCongTheoTen(string keyWord = null)
        {
            int Id;
            var lstChamCong = dbContext.chamCongs.AsQueryable();
            bool check = int.TryParse(keyWord, out Id);
            if (check == true)
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstChamCong = lstChamCong.Where(x => x.Id == Id);
                }
                return lstChamCong;
            }
            else
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstChamCong = lstChamCong.Where(x => x.trangThai.Contains(keyWord));
                }
                return lstChamCong;
            }
        }

        public ChamCong XoaChamCong(int chamCongId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var chamCong = dbContext.chamCongs.FirstOrDefault(x => x.Id == chamCongId);
                if (chamCong != null)
                {
                    dbContext.Remove(chamCong);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Cham Cong Nay!!");

                }
                trans.Commit();
                return chamCong;
            }
        }
    }
}
