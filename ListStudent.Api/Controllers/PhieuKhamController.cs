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
        private readonly IPhieuKhamRepository _phieuKhamrepo;
        public PhieuKhamController(IPhieuKhamRepository phieukhamrepo)
        {
            _phieuKhamrepo = phieukhamrepo;
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
        [HttpPut]
        public async Task<IActionResult> UpdatePK(Guid id,PhieuKhamDto dto)
        {
            var task = await _phieuKhamrepo.GetById(id);
            task.Name = dto.Name;
            task.Status = dto.Status;

            var tasks = await _phieuKhamrepo.UpdatePK(task);
            return Ok(new PhieuKhamDto()
            {
                Name = dto.Name,
                Status = dto.Status,
                Id = dto.Id,
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePK(Guid id,PhieuKhamDto dto)
        {
            var task = await _phieuKhamrepo.GetById(id);

            var tasks = await _phieuKhamrepo.DeletePK(task);
            return Ok(tasks);
        }
    }
}
