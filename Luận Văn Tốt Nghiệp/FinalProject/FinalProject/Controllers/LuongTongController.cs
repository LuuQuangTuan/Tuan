using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongTongController : ControllerBase
    {
        private readonly ILuongTongServices luongTongServices;
        public LuongTongController()
        {
            luongTongServices = new LuongTongServices();   
        }
        [HttpGet]
        public IActionResult LayDanhSachLuongTong()
        {
            var res = luongTongServices.HienThiDanhSachLuongTong();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddLuongTong(LuongTong luongTong)
        {
            var res = luongTongServices.ThemLuongTong(luongTong);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixLuongTong(LuongTong luongTong)
        {
            var res = luongTongServices.SuaLuongTong(luongTong);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteLuongTong(int luongTongId)
        {
            var res = luongTongServices.XoaLuongTong(luongTongId);
            return Ok(res);
        }
    }
}
