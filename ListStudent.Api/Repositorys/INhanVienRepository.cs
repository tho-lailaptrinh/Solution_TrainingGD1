using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys
{
    public interface INhanVienRepository
    {
        Task<IEnumerable<NhanVienDto>> GetAllNhanVien();
    }
}
