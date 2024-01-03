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

        [HttpPost]
        public async Task<IActionResult> CreateKH(KhachHangRequest request)
        {
            var result = await _khachHangRepository.CreateKhachHang(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateKH(Guid id, KhachHangUpdate request)
        {
            var getkhachhang = await _khachHangRepository.GetById(id);

            getkhachhang.Name = request.Name;
            getkhachhang.NumberPhone = request.NumberPhone;
            getkhachhang.AddressKH = request.AddressKH;

            var updatedKhachHang = await _khachHangRepository.UpdateKhachHang(getkhachhang);
            //var khachHangDto = _mapper.Map<KhachHangDto>(updatedKhachHang);
            //return Ok(khachHangDto);
            return Ok(updatedKhachHang);
            //return null;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteKH(Guid id)
        {
            var khachhang = await _khachHangRepository.GetById(id);
            await _khachHangRepository.DeleteKhachHang(khachhang);
            var khachHangDto = _mapper.Map<KhachHangDto>(khachhang);
            return Ok(khachHangDto);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var khachhang = await _khachHangRepository.GetById(id);
        //    return Ok(khachhang);
        //}
    }
}
