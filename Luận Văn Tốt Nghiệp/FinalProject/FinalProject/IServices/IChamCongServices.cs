using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface IChamCongServices
    {
        public ChamCong ThemChamCong(ChamCong chamCong);
        public ChamCong SuaChamCong(ChamCong chamCong);
        public ChamCong XoaChamCong(int chamCongId);
        public IEnumerable<ChamCong> HienThiDanhSachChamCong();
        public IEnumerable<ChamCong> TimKiemDanhSachChamCongTheoTen(string keyWord = null);
    }
}
