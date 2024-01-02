using BlazorServer.CRUD.Pages;
using PhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public interface IPhieuKhamService
    {
        public Task<List<PhieuKhamRequest>> GetListPK();
        public Task<List<PhieuKhamRequest>> GetListPKCT(string id);
        public Task<bool> CreatePhieuKham(PhieuKhamCreateRequest CreatePK);
    }
}
