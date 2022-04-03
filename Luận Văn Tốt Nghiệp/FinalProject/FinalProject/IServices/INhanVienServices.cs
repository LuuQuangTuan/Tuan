using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface INhanVienServices
    {
        public NhanVien ThemNhanVien(NhanVien nhanVien);
        public NhanVien SuaNhanVien(NhanVien nhanVien);
        public NhanVien XoaNhanVien(int nhanVienId);
        public IEnumerable<NhanVien> HienThiDanhSachNhanVien();
        public IEnumerable<NhanVien> TimKiemDanhSachNhanVienTheoTen(string keyWord = null);

    }
}
