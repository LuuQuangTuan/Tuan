using FinalProject.Entities;
using System.Collections.Generic;

namespace FinalProject.IServices
{
    public interface IDonXinNghiPhepServices
    {
        public DonXinNghiPhep ThemDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep);
        public DonXinNghiPhep SuaDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep);
        public DonXinNghiPhep XoaDonXinNghiPhep(int donXinNghiPhepId);
        public IEnumerable<DonXinNghiPhep> HienThiDanhSachDonXinNghiPhep();
        //public IEnumerable<DonXinNghiPhep> TimKiemDanhSachDonXinNghiPhepTheoSoNgayNghi(int keyWord );
    }
}
