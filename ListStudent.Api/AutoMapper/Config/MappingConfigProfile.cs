using AutoMapper;
using PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto;
using PhongKhamNhaKhoa.Api.Entitis;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PhongKhamNhaKhoa.Api.AutoMapper.Config
{
    public class MappingConfigProfile : Profile
    {
        public MappingConfigProfile() 
        {

            CreateMap<PhieuKham, PhieuKhamDto>().ForMember(des => des.NameKH, src => src.MapFrom(act => act.KhachHang.Name))
                .ForMember(des => des.NameNV, src => src.MapFrom(act => act.NhanViens.Name))
                .ForMember(des => des.NameDV, src => src.MapFrom(act => act.DichVus.Name))
                .ForMember(des => des.NamePK, src => src.MapFrom(act => act.PhongKham.Name));
                                                 
        }

    }
}
