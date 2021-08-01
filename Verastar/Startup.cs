using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Verastar.Core.IConfiguration;
using Verastar.Data;
using Verastar.Services;
using VueCliMiddleware;

namespace Verastar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<TelecomContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("VerastarDB")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddHttpClient<MobileDataApiService>();
            services.AddScoped<IMobileDataApiService, MobileDataApiService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseVueCli(npmScript: "serve");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }

            });
        }

    }
}
