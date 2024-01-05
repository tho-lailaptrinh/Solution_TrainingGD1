using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model.Enum;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public KhachHangRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<KhachHangDto>> GetAllKhachHang()
        {
            var result = _context.KhachHangs.Where(x => x.StatusKH != StatusKH.DaXoa).ProjectTo<KhachHangDto>(_mapper.ConfigurationProvider);
            var results = await result.ToListAsync();
            return results;
        }

        public  async Task<KhachHang> GetById(Guid id)
        {
            var result = await _context.KhachHangs.FindAsync(id);
            return result;
        }

        public async Task<KhachHang> CreateKhachHang(KhachHangCreateRequest request)
        {
            KhachHang khachhang = new KhachHang()
            {
                Name = request.Name,
                AddressKH = request.AddressKH,
                NumberPhone = request.NumberPhone,
                StatusKH = StatusKH.DangHoatDong,
                Id = Guid.NewGuid()
            };
            _context.KhachHangs.Add(khachhang);
            await _context.SaveChangesAsync();
            return khachhang;
        }

        public async Task<KhachHang> UpdateKhachHang(Guid id,KhachHangUpdateRequest request)
        {
            var khachhang = await _context.KhachHangs.FirstOrDefaultAsync(x => x.Id == id);
            khachhang.Name = request.Name;
            khachhang.NumberPhone = request.NumberPhone;
            khachhang.AddressKH = request.AddressKH;
            _context.KhachHangs.Update(khachhang);
            await _context.SaveChangesAsync();
            return khachhang;
        }

        public async Task<KhachHang> DeleteKhachHang(KhachHang request)
        {
            request.StatusKH = StatusKH.DaXoa;
            _context.KhachHangs.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

    }
}
