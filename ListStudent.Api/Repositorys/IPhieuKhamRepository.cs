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
         Task<PhieuKham> CreatePK(PhieuKhamCreateRequest pk);
         Task<PhieuKham> UpdatePK(Guid id,PhieuKhamUpdateRequest pk);
         Task<PhieuKham> DeletePK(Guid id);
         Task<PhieuKham> GetById(Guid id);
        
    }
}
