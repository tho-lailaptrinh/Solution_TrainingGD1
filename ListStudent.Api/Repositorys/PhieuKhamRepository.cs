﻿
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
using System.Linq;
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
            var result =  _context.PhieuKhams.Where(x => x.Status != Enum.Status.DaHuy).ProjectTo<PhieuKhamDto>(_mapper.ConfigurationProvider);
            var tolistResult = await result.ToListAsync();
            return tolistResult;
        }

        public async Task<PhieuKhamDto> CreatePK(PhieuKhamCreateRequest pkcr)
        {
            PhieuKham phieuKham = new PhieuKham()
            {
                Name = pkcr.Name,
                CreateDate = DateTime.Now,
                IdKhachHang = pkcr.IdKhachHang,
                IdDichVu = pkcr.IdDichVu,
                IdPhongKham = pkcr.IdPhongKham,
                IdNhanVien = pkcr.IdNhanVien,
                Id = Guid.NewGuid(),

            };
            _context.PhieuKhams.Add(phieuKham);
            await _context.SaveChangesAsync();
            return _mapper.Map<PhieuKhamDto>(phieuKham);
        }

        public async Task<PhieuKhamDto> UpdatePK(Guid id,PhieuKhamUpdateRequest pk)
        {
            var updatepk = await _context.PhieuKhams.FirstOrDefaultAsync(x => x.Id == id);
            updatepk.Name = pk.Name;
            updatepk.CreateDate = pk.CreateDate;
            updatepk.Status = pk.Status;
            updatepk.IdDichVu = pk.IdDichVu;
            updatepk.IdNhanVien = pk.IdNhanVien;
            updatepk.IdKhachHang = pk.IdKhachHang;
            updatepk.IdPhongKham = pk.IdPhongKham;
            _context.PhieuKhams.Update(updatepk);
            await _context.SaveChangesAsync();
            return _mapper.Map<PhieuKhamDto>(updatepk);
        }

        public async Task<bool> DeletePK(Guid id)
        {
            var deletePK = await _context.PhieuKhams.FirstOrDefaultAsync(x => x.Id == id);
            deletePK.Status = Enum.Status.DaHuy; 
            _context.PhieuKhams.Update(deletePK);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> GetById(Guid id)
        {
            var getId = await _context.PhieuKhams.FindAsync(id);
            return true;
        }
        // sau đó khai báo bên program cho API
    }
}
