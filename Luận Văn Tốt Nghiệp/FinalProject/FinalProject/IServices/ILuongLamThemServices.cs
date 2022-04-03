using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface ILuongLamThemServices
    {
        public LuongLamThem ThemLuongLamThem(LuongLamThem luongLamThem);
        public LuongLamThem SuaLuongLamThem(LuongLamThem luongLamThem);
        public LuongLamThem XoaLuongLamThem(int luongLamThemId);
        public IEnumerable<LuongLamThem> HienThiDanhSachLuongLamThem();
        //public IEnumerable<LuongLamThem> TimKiemDanhSachLuongLamThemTheoTen(string keyWord = null);
    }
}
