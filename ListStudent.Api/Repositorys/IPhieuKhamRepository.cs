using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public interface IPhieuKhamRepository
    {
         Task<IEnumerable<PhieuKhamDto>> GetPhieuKhams();
         Task<PhieuKhamDto> CreatePK(PhieuKhamCreateRequest pk);
         Task<PhieuKhamDto> UpdatePK(Guid id,PhieuKhamUpdateRequest pk);
         Task<bool> DeletePK(Guid id);
         Task<PhieuKhamDto> GetById(Guid id);
        
    }
}
