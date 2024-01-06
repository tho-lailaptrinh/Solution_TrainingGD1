using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuKhamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhieuKhamRepository _phieuKhamrepo;
        public PhieuKhamController(IPhieuKhamRepository phieukhamrepo, IMapper mapper)
        {
            _phieuKhamrepo = phieukhamrepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListPK()
        {
            var result = await _phieuKhamrepo.GetPhieuKhams();
            var resultDto = result.Select(x => new PhieuKhamDto()
            {
                Name = x.Name,
                Status = x.Status,
                CreateDate = x.CreateDate,
            });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePK(PhieuKhamCreateRequest pk)
        {
            if(!ModelState.IsValid) return BadRequest();
            var result = await _phieuKhamrepo.CreatePK(pk);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatepk(Guid id,PhieuKhamUpdateRequest request)
        {
            var tasks = await _phieuKhamrepo.UpdatePK(id , request);
            return Ok(tasks);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePK(Guid id)
        {
            var tasks = await _phieuKhamrepo.DeletePK(id);
            return Ok(tasks);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdPK(Guid id)
        {
            var result = await _phieuKhamrepo.GetById(id);
            return Ok(result);
        }
    }
}
