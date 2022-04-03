using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface IDuAnServices
    {
        public DuAn ThemDuAn(DuAn duAn);
        public DuAn SuaDuAn(DuAn duAn);
        public DuAn XoaDuAn(int duAnId);
        public IEnumerable<DuAn> HienThiDanhSachDuAn();
        public IEnumerable<DuAn> TimKiemDanhDuAnTheoTen(string keyWord = null);
    }
}
