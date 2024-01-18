using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.NhanVienCreateRequest;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public interface INhanVienRepository
    {
        Task<IEnumerable<NhanVienDto>> GetAllNhanVien();
        Task<NhanVien> CreateNhanVien(NhanVienCreateRequest request);
    }
}
