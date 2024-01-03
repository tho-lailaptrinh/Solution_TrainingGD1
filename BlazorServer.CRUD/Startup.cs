using Blazored.Toast;
using BlazorServer.CRUD.Services;
using BlazorServer.CRUD.Services.ForMemBer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace BlazorServer.CRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredToast();

            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001")});

            services.AddTransient<IPhieuKhamService, PhieuKhamService>();
            services.AddTransient<KhachHangService, KhachHangService>();
            services.AddTransient<NhanVienService, NhanVienService>();
            services.AddTransient<DichVuService, DichVuService>();
            services.AddTransient<PhongKhamService, PhongKhamService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
