using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface ILuongKhauTruServices
    {
        public LuongKhauTru ThemLuongKhauTru(LuongKhauTru luongKhauTru);
        public LuongKhauTru SuaLuongKhauTru(LuongKhauTru luongKhauTru);
        public LuongKhauTru XoaLuongKhauTru(int luongKhauTruId);
        public IEnumerable<LuongKhauTru> HienThiDanhSachLuongKhauTru();
        //public IEnumerable<LuongKhauTru> TimKiemDanhSachLuongKhauTruTheoTen(string keyWord = null);
    }
}
