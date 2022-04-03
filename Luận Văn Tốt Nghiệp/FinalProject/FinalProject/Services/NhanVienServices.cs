using FinalProject.Context;
using FinalProject.Entities;
using FinalProject.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Services
{
    public class NhanVienServices : INhanVienServices
    {
        private readonly AppDbContext dbContext;
        public NhanVienServices()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<NhanVien> HienThiDanhSachNhanVien()
        {
            return dbContext.nhanViens.AsQueryable();
        }

        public NhanVien SuaNhanVien(NhanVien nhanVien)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if (dbContext.nhanViens.Any(x => x.Id == nhanVien.Id))
                {
                    var curNhanVien = dbContext.nhanViens.Find(nhanVien.Id);
                    curNhanVien.taiKhoan = nhanVien.taiKhoan;
                    curNhanVien.matKhau = nhanVien.matKhau;
                    curNhanVien.email = nhanVien.email;
                    curNhanVien.hoTen = nhanVien.hoTen;
                    curNhanVien.ngaySinh = nhanVien.ngaySinh;
                    curNhanVien.sDT = nhanVien.sDT;
                    curNhanVien.diaChi = nhanVien.diaChi;
                    curNhanVien.chucVu = nhanVien.chucVu;
                    curNhanVien.cMND = nhanVien.cMND;
                    curNhanVien.position = nhanVien.position;
                    curNhanVien.image = nhanVien.image;
                    dbContext.Update(curNhanVien);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Co Nhan Vien Nay!!!!");
                }
                trans.Commit();
                return nhanVien;
            }
        }

        public NhanVien ThemNhanVien(NhanVien nhanVien)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                dbContext.Add(nhanVien);
                dbContext.SaveChanges();

                trans.Commit();
                return nhanVien;
            }
        }

        public IEnumerable<NhanVien> TimKiemDanhSachNhanVienTheoTen(string keyWord = null)
        {
            int Id;
            var lstNhanVien = dbContext.nhanViens.AsQueryable();
            bool check = int.TryParse(keyWord, out Id);
            if (check == true)
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstNhanVien = lstNhanVien.Where(x => x.Id == Id);
                }
                return lstNhanVien;
            }
            else
            {
                if (!string.IsNullOrEmpty(keyWord))
                {
                    lstNhanVien = lstNhanVien.Where(x => x.hoTen.Contains(keyWord));
                }
                return lstNhanVien;
            }
        }

        public NhanVien XoaNhanVien(int nhanVienId)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                var curNhanVien = dbContext.nhanViens.Find(nhanVienId);
                if(curNhanVien !=null)
                {
                    dbContext.nhanViens.Remove(curNhanVien);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Khong Co Nhan Vien Nay !!");
                }
                trans.Commit();
                return curNhanVien;
            }
        }
    }
}
