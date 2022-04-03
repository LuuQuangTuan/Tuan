using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        private readonly IDuAnServices duAnServices;
        public DuAnController()
        {
            duAnServices = new DuAnServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachDuAn()
        {
            var res = duAnServices.HienThiDanhSachDuAn();
            return Ok(res);
        }
        [HttpGet]
        [Route("TimKiem")]
        public IActionResult TimKiemTheoTen(string keyword = null)
        {
            var res = duAnServices.TimKiemDanhDuAnTheoTen(keyword);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddDuAn(DuAn duAn)
        {
            var res = duAnServices.ThemDuAn(duAn);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixDuAn(DuAn duAn)
        {
            var res = duAnServices.SuaDuAn(duAn);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteDuAn(int duAnId)
        {
            var res = duAnServices.XoaDuAn(duAnId);
            return Ok(res);
        }
    }
}
