using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class DonXinNghiPhepServices : IDonXinNghiPhepServices
    {

        private readonly AppDbContext dbContext;
        public DonXinNghiPhepServices()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<DonXinNghiPhep> HienThiDanhSachDonXinNghiPhep()
        {
            return dbContext.donXinNghiPheps.AsQueryable();
        }

        public DonXinNghiPhep SuaDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.donXinNghiPheps.Any(x => x.Id == donXinNghiPhep.Id))
                {
                    var curDonXinNghiPhep = dbContext.donXinNghiPheps.Find(donXinNghiPhep.Id);
                    curDonXinNghiPhep.soNgayNghi = donXinNghiPhep.soNgayNghi;
                    curDonXinNghiPhep.lyDo = donXinNghiPhep.lyDo;
                    curDonXinNghiPhep.lyDoTuChoi = donXinNghiPhep.lyDoTuChoi;
                    curDonXinNghiPhep.dateTime = DateTime.Now;
                    dbContext.Update(curDonXinNghiPhep);
                    dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Khong Ton Don Xin Nghi Nay!!!");
                }
                trans.Commit();
                return donXinNghiPhep;
            }
        }

        public DonXinNghiPhep ThemDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.nhanViens.Any(x => x.Id == donXinNghiPhep.nhanVienId))
                {
                    donXinNghiPhep.dateTime = DateTime.Now;
                    dbContext.donXinNghiPheps.Add(donXinNghiPhep);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Chua Co Nhan Vien Nay De Xin Nghi!!!");
                }
                trans.Commit();
                return donXinNghiPhep;
            }
        }

        public DonXinNghiPhep XoaDonXinNghiPhep(int donXinNghiPhepId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var donXinNghiPhep = dbContext.donXinNghiPheps.FirstOrDefault(x => x.Id == donXinNghiPhepId);
                if (donXinNghiPhep != null)
                {
                    dbContext.Remove(donXinNghiPhep);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Ton Tai Don Xin Nghi Nay!!");

                }
                trans.Commit();
                return donXinNghiPhep;


            }
        }

        //public IEnumerable<DonXinNghiPhep> TimKiemDanhSachDonXinNghiPhepTheoSoNgayNghi(string keyWord = null)
        //{

        //    var lstDonXinNghiPhep = dbContext.donXinNghiPheps.AsQueryable();

        //        if (!string.IsNullOrEmpty(keyWord))
        //        {
        //            lstDonXinNghiPhep = lstDonXinNghiPhep.Where(x => x.Id == Id);
        //        }
        //        return lstDonXinNghiPhep;


        //}
    }
}
