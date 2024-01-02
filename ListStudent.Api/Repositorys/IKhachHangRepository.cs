using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public interface IKhachHangRepository
    {
        Task<IEnumerable<KhachHangDto>> GetAllKhachHang();
        Task<KhachHangDto> CreateKhachHang(KhachHangRequest request);
        Task<KhachHangDto> UpdateKhachHang(KhachHangRequest request);
        Task<KhachHangDto> DeleteKhachHang(KhachHangRequest request);
        Task<KhachHangDto> GetById(Guid id);
     }
}
