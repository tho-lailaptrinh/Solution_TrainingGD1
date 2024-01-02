
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Repositorys
{
    public class PhieuKhamRepository : IPhieuKhamRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        
        public PhieuKhamRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PhieuKhamDto>> GetPhieuKhams()
        {
            var result =  _context.PhieuKhams.ProjectTo<PhieuKhamDto>(_mapper.ConfigurationProvider);
            var tolistResult = await result.ToListAsync();
            return tolistResult;
        }

        public async Task<PhieuKhamDto> CreatePK(PhieuKhamCreateRequest pkcr)
        {
            PhieuKham phieuKham = new PhieuKham()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                IdKhachHang = pkcr.IdKhachHang,
                IdDichVu = pkcr.IdDichVu,
                IdPhongKham = pkcr.IdPhongKham,
                Name = pkcr.Name,
            };
            _context.PhieuKhams.Add(phieuKham);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<PhieuKhamDto> UpdatePK(PhieuKhamDto pk)
        {
            var updatepk = await _context.PhieuKhams.FindAsync(pk.Id);
            updatepk.Name = pk.Name;
            updatepk.CreateDate = pk.CreateDate;
            updatepk.Status = pk.Status;
            _context.PhieuKhams.Update(updatepk);
            await _context.SaveChangesAsync();  
            return pk;
        }

        public async Task<PhieuKhamDto> DeletePK(PhieuKhamDto pk)
        {
            PhieuKham deletePK = _mapper.Map<PhieuKham>(pk);
            _context.PhieuKhams.Remove(deletePK);
            await _context.SaveChangesAsync();
            return pk;
        }

        public async Task<PhieuKhamDto> GetById(Guid id)
        {
            
            PhieuKham getId = await _context.PhieuKhams.FindAsync(id);
            return _mapper.Map<PhieuKhamDto>(getId);
        }
        // sau đó khai báo bên program cho API
    }
}
