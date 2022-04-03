using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class SuKienServices : ISuKienServices
    {
        private readonly AppDbContext dbContext;
        public SuKienServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<SuKien> HienThiDanhSachSuKien()
        {
            return dbContext.suKiens.AsQueryable();
        }

        public SuKien SuaSuKien(SuKien suKien)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.suKiens.Any(x => x.Id == suKien.Id))
                {
                    var curSuKien = dbContext.suKiens.Find(suKien.Id);
                    curSuKien.ngayBatDau = suKien.ngayBatDau;
                    curSuKien.ngayKetThuc = suKien.ngayKetThuc;
                    curSuKien.tieuDe = suKien.tieuDe;
                    curSuKien.noiDung = suKien.noiDung;
                    dbContext.Update(curSuKien);
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Tai Su Kien Nay!!!");
                }
                trans.Commit();
                return suKien;
            }
        }

        public SuKien ThemSuKien(SuKien suKien)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                
                    dbContext.suKiens.Add(suKien);
                    dbContext.SaveChanges();
                
              
                trans.Commit();
                return suKien;
            }
        }

        public SuKien XoaSuKien(int suKienId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var suKien = dbContext.suKiens.FirstOrDefault(x => x.Id == suKienId);
                if (suKien != null)
                {
                    dbContext.Remove(suKien);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Su Kien Nay!!");

                }
                trans.Commit();
                return suKien;
            }
        }

        public IEnumerable<SuKien> TimKiemDanhSachSuKienTheoTen(string keyWord = null)
        {
            int Id;    
            var lstSuKien = dbContext.suKiens.AsQueryable();
            bool check = int.TryParse(keyWord, out Id);
            if(check == true)
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstSuKien = lstSuKien.Where(x => x.Id == Id);
                }
                return lstSuKien;
            }    
            else
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstSuKien = lstSuKien.Where(x => x.tieuDe.Contains(keyWord));
                }
                return lstSuKien;
            }

        }
    }
}
