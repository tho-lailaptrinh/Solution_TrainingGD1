using BlazorServer.CRUD.Pages;
using PhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public interface IPhieuKhamService
    {
        public Task<List<PhieuKhamRequeset>> GetListPK();
        public Task<PhieuKhamRequeset> GetListPKCT(string id);
        public Task<bool> CreatePhieuKham(PhieuKhamCreateRequest CreatePK);

    }
}
