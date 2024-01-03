using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public class PhongKhamRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public PhongKhamRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PhongKhamDto>> GetAllPhongKham()
        {
            var result = _context.PhongKhams.ProjectTo<PhongKhamDto>(_mapper.ConfigurationProvider);
            var results = await result.ToListAsync();
            return results;
        }
    }
}
