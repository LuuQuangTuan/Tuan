using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongKhauTruController : ControllerBase
    {
        private readonly ILuongKhauTruServices luongKhauTruServices;
        public LuongKhauTruController()
        {
            luongKhauTruServices = new LuongKhauTruServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachLuongKhauTru()
        {
            var res = luongKhauTruServices.HienThiDanhSachLuongKhauTru();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddLuongKhauTru(LuongKhauTru luongKhauTru)
        {
            var res = luongKhauTruServices.ThemLuongKhauTru(luongKhauTru);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixLuongKhauTru(LuongKhauTru luongKhauTru)
        {
            var res = luongKhauTruServices.SuaLuongKhauTru(luongKhauTru);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteLuongKhauTru(int luongKhauTruId)
        {
            var res = luongKhauTruServices.XoaLuongKhauTru(luongKhauTruId);
            return Ok(res);
        }

    }
}
