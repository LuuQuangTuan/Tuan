using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienServices nhanVienServices;
        public NhanVienController()
        {
            nhanVienServices = new NhanVienServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachNhanVien()
        {
            var res = nhanVienServices.HienThiDanhSachNhanVien();
            return Ok(res);
        }
        [HttpGet]
        [Route("TimKiem")]
        public IActionResult TimKiemTheoTen(string keyword = null)
        {
            var res = nhanVienServices.TimKiemDanhSachNhanVienTheoTen(keyword);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddNhanVien(NhanVien nhanVien)
        {
            var res = nhanVienServices.ThemNhanVien(nhanVien);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixNhanVien(NhanVien nhanVien)
        {
            var res = nhanVienServices.SuaNhanVien(nhanVien);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteNhanVien(int nhanVienId)
        {
            var res = nhanVienServices.XoaNhanVien(nhanVienId);
            return Ok(res);
        }
    }   
}
