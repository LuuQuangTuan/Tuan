using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Entities;
using FinalProject.IServices;
using FinalProject.Services;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonXinNghiPhepController : ControllerBase
    {
        private readonly IDonXinNghiPhepServices donXinNghiPhepServices;
        public DonXinNghiPhepController()
        {
            donXinNghiPhepServices = new DonXinNghiPhepServices();
        }
        [HttpGet]
        public IActionResult LayDanhSachDonXinNghi()
        {
            var res = donXinNghiPhepServices.HienThiDanhSachDonXinNghiPhep();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep)
        {
            var res = donXinNghiPhepServices.ThemDonXinNghiPhep(donXinNghiPhep);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult FixDonXinNghiPhep(DonXinNghiPhep donXinNghiPhep)
        {
            var res = donXinNghiPhepServices.SuaDonXinNghiPhep(donXinNghiPhep);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteDonXinNghiPhep(int donXinNghiPhepId)
        {
            var res = donXinNghiPhepServices.XoaDonXinNghiPhep(donXinNghiPhepId);
            return Ok(res);
        }
    }
}
