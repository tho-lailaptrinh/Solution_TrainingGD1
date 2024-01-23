using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PhongKhamNhaKhoa.Api.AutoMapper.Config;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Api.Repositorys.Image;
using PhongKhamNhaKhoa.Repositorys;
using System.Reflection;
using System.Text;

namespace PhongKhamNhaKhoa.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefautConnection")));

            services.AddTransient<IPhieuKhamRepository, PhieuKhamRepository>(); // ?? api sd
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            services.AddTransient<IKhachHangRepository, KhachHangRepository>();
            services.AddTransient<DichVuRepository, DichVuRepository>();
            services.AddTransient<PhongKhamRepository, PhongKhamRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<MyDbContext>(); // add identity
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"])) // dây là nh?ng thông server s? ??c ra và validile bên d??i 
                };
            });  // add cái scheme và add thêm ?? nó very file


            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingConfigProfile()));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ListStudent.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ListStudent.Api v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // ph?i có cái này m?i ch?ng th?c ???c
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
