using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongLamThemController : ControllerBase
    {
        private readonly ILuongLamThemServices luongLamThemServices;
        public LuongLamThemController()
        {
            luongLamThemServices = new LuongLamThemServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachLuongLamThem()
        {
            var res = luongLamThemServices.HienThiDanhSachLuongLamThem();
            return Ok(res); 
        }
        [HttpPost]
        public IActionResult AddLuongLamThem(LuongLamThem luongLamThem)
        {
            var res = luongLamThemServices.ThemLuongLamThem(luongLamThem);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixLuongLamThem(LuongLamThem luongLamThem)
        {
            var res = luongLamThemServices.SuaLuongLamThem(luongLamThem);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteLuongLamThem(int luongLamThemId)
        {
            var res = luongLamThemServices.XoaLuongLamThem(luongLamThemId);
            return Ok(res);
        }
    }
}
