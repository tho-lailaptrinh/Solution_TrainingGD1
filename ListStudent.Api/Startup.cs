using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhongKhamNhaKhoa.Api.AutoMapper.Config;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Repositorys;
using PhongKhamNhaKhoa.Repositorys;
using System.Reflection;

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
