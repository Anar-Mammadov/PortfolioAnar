using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.WebUI.Model.DataContexts;

namespace Portfolio.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddDbContext<PortfolioDbContext>(cfg =>
            {

                cfg.UseSqlServer(configuration.GetConnectionString("cstring"));

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(cfg =>
            {

                cfg.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

            });

        }
    }
}
