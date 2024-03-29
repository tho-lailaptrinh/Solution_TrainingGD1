﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Enum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Data
{
    public class MyDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(MyDbContext context, ILogger<MyDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "Tho",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin123");
                context.Users.Add(user);
            }

            if (!context.KhachHangs.Any())
            {
                context.KhachHangs.Add(new Entitis.KhachHang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mr.Tho",
                    NumberPhone = "0353838935",
                    AddressKH = "GiaLam",
                });
            }
            if (!context.NhanViens.Any())
            {
                context.NhanViens.Add(new Entitis.NhanVien()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nguyen Van A",
                    NumberPhone = 093275782,
                    AddressNV = "HaNoi",
                    Position = Position.BacSi,
                });
            }
            if (!context.DichVus.Any())
            {
                context.DichVus.Add(new Entitis.DichVu()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nhổ Răng",
                    Money = 1000000,
                    Description = "là quá trình loại bỏ răng ảnh hưởng tới sức khỏe",
                });
            }
            if (!context.PhongKhams.Any())
            {
                context.PhongKhams.Add(new Entitis.PhongKham()
                {
                    Id = Guid.NewGuid(),
                    Name = "P404",
                    
                });
            }
            if (!context.PhieuKhams.Any())
            {
                context.PhieuKhams.Add(new Entitis.PhieuKham()
                {
                    Id = Guid.NewGuid(),
                    Name = "Phiếu Khám 1",
                    CreateDate = DateTime.Now,
                    Status = Status.DaThanhToan,
                    
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
