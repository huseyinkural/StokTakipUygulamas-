using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StokTakipUygulaması.Data;
using StokTakipUygulaması.Data.AltKategoriRepo;
using StokTakipUygulaması.Data.BirimRepo;
using StokTakipUygulaması.Data.Kategoriler;
using StokTakipUygulaması.Data.Kullanicilar;
using StokTakipUygulaması.Data.MusteriRepo;
using StokTakipUygulaması.Data.TedarikciRepo;

namespace StokTakipUygulaması
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
            services.AddDbContext<DataContext>(x => x.UseSqlServer((Configuration.GetConnectionString("DefaultConnection"))));
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config => {
                config.LoginPath = "/Home/Giris";
                config.Cookie.Name = "UserLoginCookie";
                config.AccessDeniedPath = "/Home/Error";

            });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IAltKategoriRepository, AltKategoriRepository>();
            services.AddScoped<IBirimRepository, BirimRepository>();
            services.AddScoped<ITedarikciRepository, TedarikciRepository>();
            services.AddScoped<IMusteriRepository, MusteriRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
