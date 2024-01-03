using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.Repositorys;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly DichVuRepository _dichVuRepository;
        public DichVuController(DichVuRepository dichVuRepository)
        {
            _dichVuRepository = dichVuRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDV()
        {
            var result = await _dichVuRepository.GetAllDichVu();
            return Ok(result);
        }
    }
}
