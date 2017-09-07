using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Business;
using Example.Business.Interfaces;
using Example.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Web
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
            services.AddDbContext<ExampleDbEntities>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("WpfTestConnection")));
            
            services.AddMvc();

            services.AddTransient<IUsuarioService, UsuarioService>();
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

            app.UseMvc(routes =>
            {                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "usuarios_default",
                    areaName: "usuarios",
                    template: "Usuarios/{controller=Usuario}/{action=Index}/{id?}"
                );
            });
        }
    }
}
