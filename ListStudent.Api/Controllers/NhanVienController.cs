using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.NhanVienCreateRequest;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _nhanVienRepository;
        public NhanVienController(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNV()
        {
            var nhanvien = await _nhanVienRepository.GetAllNhanVien();
            return Ok(nhanvien);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNhanVien(NhanVienCreateRequest request)
        {
            var nhanvien = await _nhanVienRepository.CreateNhanVien(request);
            return Ok(nhanvien);
        }
    }
}
