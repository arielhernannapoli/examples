using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAAPU.Data.EF;
using SAAPU.Data.Identity;

namespace SAAPU.Web
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
            services.AddDbContext<SAAPUDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("identityConnection"), b => b.MigrationsAssembly("SAAPU.Web")));

            services.AddDbContext<SAAPUIdentityDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("identityConnection"), b=> b.MigrationsAssembly("SAAPU.Web")));
                
            services.AddIdentity<SAAPUIdentityUser, SAAPUIdentityRole>()
                .AddEntityFrameworkStores<SAAPUIdentityDbContext>()
                .AddDefaultTokenProviders();
                
            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            
                routes.MapAreaRoute(
                    name: "admin_default",
                    areaName: "security",
                    template: "{controller}/{action=Index}/{id?}"
                );
            });   
        }
    }
}
