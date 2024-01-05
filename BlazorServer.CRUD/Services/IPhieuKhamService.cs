using BlazorServer.CRUD.Pages;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public interface IPhieuKhamService
    {
        public Task<List<PhieuKhamRequeset>> GetListPK();
        public Task<bool> CreatePhieuKham(PhieuKhamCreateRequest CreatePK);
        public Task<PhieuKhamRequeset> GetByIdPhieuKham(string id);
        public Task<bool> UpdatePhieuKhams(Guid id, PhieuKhamUpdateRequest UpdatePK);
        public Task<bool> DeletePhieuKhams(Guid id);
    }
}
