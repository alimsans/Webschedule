using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSchedule.DependenciesResolver;
using Microsoft.Extensions.Configuration;
using WebSchedule.API.Middleware;

namespace WebSchedule.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Authorize";
                    options.AccessDeniedPath = "/Account/Forbidden";
                    options.EventsType = typeof(CookieAuthenticationMiddleware);
                });

            services.AddScoped<CookieAuthenticationMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Bootstrapper.Initialize(builder, Configuration);
        }
    }
}