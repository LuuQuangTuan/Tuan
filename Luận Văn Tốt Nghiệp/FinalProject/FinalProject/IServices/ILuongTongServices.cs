using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface ILuongTongServices
    {
        public LuongTong ThemLuongTong(LuongTong luongTong);
        public LuongTong SuaLuongTong(LuongTong luongTong);
        public LuongTong XoaLuongTong(int luongTongId);
        public IEnumerable<LuongTong> HienThiDanhSachLuongTong();
        //public IEnumerable<LuongTong> TimKiemDanhSachLuongTongTheoTen(string keyWord = null);
    }
}
