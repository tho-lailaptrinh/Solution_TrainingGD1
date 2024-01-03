using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.Repositorys;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongKhamController : ControllerBase
    {
        private readonly PhongKhamRepository _phongKhamRepository;
        public PhongKhamController(PhongKhamRepository phongKhamRepository)
        {
            _phongKhamRepository = phongKhamRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPK()
        {
            var phongkham = await _phongKhamRepository.GetAllPhongKham();
            return Ok(phongkham);
        }
    }
}
