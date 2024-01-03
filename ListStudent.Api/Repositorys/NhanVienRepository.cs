using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public NhanVienRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<NhanVienDto>> GetAllNhanVien()
        {
            var result = _context.NhanViens.ProjectTo<NhanVienDto>(_mapper.ConfigurationProvider);
            var results = await result.ToListAsync();
            return results;
        }
    }
}
