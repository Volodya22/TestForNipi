using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestForNipi.Core.Models;
using TestForNipi.DataLayer;
using TestForNipi.Web.Models;

namespace TestForNipi.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // setting infromation about database
            var connection = Configuration["ConnectionString"];
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            // creatin DI
            services.AddScoped<IDbContext, AppDbContext>();

            // setting automapper
            services.AddAutoMapper();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, DataViewModel>();
                cfg.CreateMap<Location, DataViewModel>();
                cfg.CreateMap<Section, DataViewModel>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
