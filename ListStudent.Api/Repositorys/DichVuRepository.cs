using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public class DichVuRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public DichVuRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DichVuDto>> GetAllDichVu()
        {
            var result = _context.DichVus.ProjectTo<DichVuDto>(_mapper.ConfigurationProvider);
            var results = await result.ToListAsync();
            return results;
        }
    }
}
