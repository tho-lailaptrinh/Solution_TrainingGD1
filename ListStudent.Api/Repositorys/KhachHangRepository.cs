using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
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
            var result = _context.KhachHangs.ProjectTo<KhachHangDto>(_mapper.ConfigurationProvider);
            var results = await result.ToListAsync();
            return results;
        }
        public async Task<KhachHangDto> CreateKhachHang(KhachHangRequest request)
        {
            KhachHang khachhang = new KhachHang()
            {
                Name = request.Name,
                AddressKH = request.AddressKH,
                NumberPhone = request.NumberPhone,
                Id = Guid.NewGuid(),
            };
            _context.KhachHangs.Add(khachhang);
            await _context.SaveChangesAsync();
            return _mapper.Map<KhachHangDto>(khachhang);
        }

        public async Task<KhachHangDto> UpdateKhachHang(KhachHangRequest request)
        {
            var updatekh = await _context.KhachHangs.FindAsync(request.Id);
            updatekh.Name = request.Name;
            updatekh.NumberPhone = request.NumberPhone;
            updatekh.AddressKH = request.AddressKH;
            _context.KhachHangs.Update(updatekh);
            await _context.SaveChangesAsync();
            return _mapper.Map<KhachHangDto>(updatekh);

        }

        public async Task<KhachHangDto> DeleteKhachHang(KhachHangRequest request)
        {
            //KhachHang khach = _mapper.Map<KhachHangDto>(request);
            //_context.KhachHangs.Remove(request);
            //await _context.SaveChangesAsync();
            //return request;
            return null;
        }

        public async Task<KhachHangDto> GetById(Guid id)
        {
            var result = await _context.KhachHangs.FindAsync(id);
            return _mapper.Map<KhachHangDto>(result);
        } 
    }
}
