using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface ISuKienServices
    {
        public SuKien ThemSuKien(SuKien suKien);
        public SuKien SuaSuKien(SuKien suKien);
        public SuKien XoaSuKien(int suKienId);
        public IEnumerable<SuKien> HienThiDanhSachSuKien();
        public IEnumerable<SuKien> TimKiemDanhSachSuKienTheoTen(string keyWord = null);
        
    }
}
