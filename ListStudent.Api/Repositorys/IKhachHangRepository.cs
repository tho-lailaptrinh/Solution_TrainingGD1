using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Entitis;
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
        Task<KhachHang> CreateKhachHang(KhachHangCreateRequest request);
        Task<KhachHang> UpdateKhachHang(Guid id, KhachHangUpdateRequest request);
        Task<KhachHang> DeleteKhachHang(KhachHang request);
        Task<KhachHang> GetById(Guid id);
     }
}
