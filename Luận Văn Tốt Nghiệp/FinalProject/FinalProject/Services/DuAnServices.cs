using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class DuAnServices : IDuAnServices
    {
        private readonly AppDbContext dbContext;
        public DuAnServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<DuAn> HienThiDanhSachDuAn()
        {
            return dbContext.duAns.AsQueryable();
        }

        public DuAn SuaDuAn(DuAn duAn)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.duAns.Any(x => x.Id == duAn.Id))
                {
                    var curDuAn = dbContext.duAns.Find(duAn.Id);
                    curDuAn.tenDuAn = duAn.tenDuAn;
                    curDuAn.luongThuong = duAn.luongThuong;
                    dbContext.Update(curDuAn);
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Tai Cham Cong Nay!!!");
                }
                trans.Commit();
                return duAn;
            }
        }

        public DuAn ThemDuAn(DuAn duAn)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {

                dbContext.duAns.Add(duAn);
                dbContext.SaveChanges();
                trans.Commit();
                return duAn;
            }
        }

        public IEnumerable<DuAn> TimKiemDanhDuAnTheoTen(string keyWord = null)
        {
            int Id;
            var lstDuAn = dbContext.duAns.AsQueryable();
            bool check = int.TryParse(keyWord, out Id);
            if (check == true)
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstDuAn = lstDuAn.Where(x => x.Id == Id);
                }
                return lstDuAn;
            }
            else
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstDuAn = lstDuAn.Where(x => x.tenDuAn.Contains(keyWord));
                }
                return lstDuAn;
            }
        }

        public DuAn XoaDuAn(int duAnId)
        {
            using ( var trans = dbContext.Database.BeginTransaction())
            {
                var duAn = dbContext.duAns.FirstOrDefault(x => x.Id == duAnId);
                if(duAn == null)
                {
                    throw new Exception("Khong Ton Tai Du An Nay!!!");

                }
                else
                {
                    var lstLuongLamThem =  dbContext.luongLamThems.Where(x=>x.duAnId == duAnId).ToList();
                    if(lstLuongLamThem.Count() > 0)
                    {
                        dbContext.RemoveRange(lstLuongLamThem);
                        dbContext.SaveChanges();
                    }
                    dbContext.Remove(duAn);
                    dbContext.SaveChanges();
                }
                trans.Commit();
                return duAn;
            }
        }
    }
}
