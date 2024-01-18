using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly  IKhachHangRepository _khachHangRepository;
        public KhachHangController(IKhachHangRepository khachHangRepository, IMapper mapper)
        {
            _khachHangRepository = khachHangRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKH()
        {
            var khachhang = await _khachHangRepository.GetAllKhachHang();
            return Ok(khachhang);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdKH(Guid id)
        {
            var khachhang = await _khachHangRepository.GetById(id);
            return Ok(new KhachHangRequest()
            {
                Name = khachhang.Name,
                NumberPhone =khachhang.NumberPhone,
                AddressKH = khachhang.AddressKH,
                StatusKH = khachhang.StatusKH,
                Id = khachhang.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateKH(KhachHangCreateRequest request)
        {
            var result = await _khachHangRepository.CreateKhachHang(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateKH(Guid id, KhachHangUpdateRequest request) 
        {
            var result = await _khachHangRepository.UpdateKhachHang(id, request);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteKH(Guid id)
        {
            var khachhang = await _khachHangRepository.GetById(id);
            await _khachHangRepository.DeleteKhachHang(khachhang);
            return Ok(khachhang);
        }

      
    }
}
