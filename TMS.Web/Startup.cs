using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Dapper.Implementations;
using TMS.Dapper.Interfaces;
using TMS.Data.Implementations;
using TMS.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TMS.Web
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
            services.AddRazorPages();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.Configure<CookiePolicyOptions>(p =>
            {
                p.CheckConsentNeeded = context => true;
                p.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", Configuration =>
            {
                Configuration.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None;
                Configuration.Cookie.Name = "TMS";
                Configuration.LoginPath = "/Admin/Login";
                Configuration.ExpireTimeSpan = TimeSpan.FromDays(1);

            });
            services.AddSingleton<ICrypto, Crypto>();
            services.AddSingleton<IAdmin, Admin>();
            services.AddSingleton<IMaster, Master>();
            services.AddSingleton<IUserMaster, UserCustomer>();
            services.AddSingleton<IDapperRepository, DapperRepository>();
            services.AddSession();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers(); //Routes for my API controllers
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); //Routes for pages
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}");
            });
        }
    }
}
