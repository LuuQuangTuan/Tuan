using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuKienController : ControllerBase
    {
        private readonly ISuKienServices suKienServices;
        public SuKienController()
        {
            suKienServices = new SuKienServices();  
        }
        [HttpGet]
        public IActionResult LayDanhSachSuKien()
        {
            var res = suKienServices.HienThiDanhSachSuKien();
            return Ok(res);
        }
        [HttpGet]
        [Route("TimKiem")]
        public IActionResult TimKiemTheoTen(string keyword = null)
        {
            var res = suKienServices.TimKiemDanhSachSuKienTheoTen(keyword);
            return Ok(res);
        }
        [HttpPost]  
        public IActionResult AddSuKien(SuKien suKien)
        {
            var res = suKienServices.ThemSuKien(suKien);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixSuKien(SuKien suKien)
        {
            var res = suKienServices.SuaSuKien(suKien);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteSuKien(int suKienId)
        {
            var res = suKienServices.XoaSuKien(suKienId);
            return Ok(res);
        }
    }
}
