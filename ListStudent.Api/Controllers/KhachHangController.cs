using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly  IKhachHangRepository _khachHangRepository;
        public KhachHangController(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKH()
        {
            var khachhang = await _khachHangRepository.GetAllKhachHang();
            return Ok(khachhang);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKH(KhachHangRequest request)
        {
            var result = await _khachHangRepository.CreateKhachHang(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKH(KhachHangRequest request)
        {
            var result = await _khachHangRepository.UpdateKhachHang(request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteKH(Guid id, KhachHangRequest request)
        {
            var GetId = _khachHangRepository.GetById(id);
            var result = await _khachHangRepository.DeleteKhachHang(request);
            return Ok(result);
        }
        
       
    }
}
