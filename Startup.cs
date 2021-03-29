using HRService.AppServices.LogInAppService;
using HRService.AppServices.PasswordHashAppService;
using HRService.AppServices.RegistrationAppService;
using HRService.AppServices.UserAppService;
using HRService.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("HRDb")));
            services.AddTransient<IRegistration, Registration>();
            services.AddTransient<ILogIn, LogIn>();
            services.AddTransient<IUser, User>();
            services.AddTransient<IPasswordHash, PasswordHash>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                          .AddCookie(options => {
                              options.LoginPath = "/LogIn/SignInPage";
                              options.LogoutPath = "/LogIn/SignInPage";
                          });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=LogIn}/{action=SignInPage}/{Id?}");
            });
        }
    }
}
