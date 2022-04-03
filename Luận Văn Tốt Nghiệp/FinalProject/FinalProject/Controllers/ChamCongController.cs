using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamCongController : ControllerBase
    {
        private readonly IChamCongServices chamCongServices;
        public ChamCongController()
        {
            chamCongServices = new ChamCongServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachChamCong()
        {
            var res = chamCongServices.HienThiDanhSachChamCong();
            return Ok(res); 
        }
        [HttpGet]
        [Route("TimKiem")]
        public IActionResult TimKiemTheoTen(string keyword = null)
        {
            var res = chamCongServices.TimKiemDanhSachChamCongTheoTen(keyword);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddChamCong(ChamCong chamCong)
        {
            var res = chamCongServices.ThemChamCong(chamCong);
            return Ok(res);
        }
        [HttpPut] 
        public IActionResult FixChamCong(ChamCong chamCong)
        {
            var res = chamCongServices.SuaChamCong(chamCong);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteChamCong(int chamCongId)
        {
            var res = chamCongServices.XoaChamCong(chamCongId);
            return Ok(res);
        }
    }
}
