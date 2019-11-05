using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSite.Areas.Identity;
using WebSite.db;
using WebSite.db.EntityModels;

namespace WebSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddRazorPagesOptions(options => {
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Register");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Pages/Account/Register");
                    options.Conventions.AuthorizePage("/Identity/Account/Register");
                    options.Conventions.AuthorizePage("/Account/Register");
                    options.Conventions.AuthorizePage("/Identity/Pages/Account/Register");
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                    Configuration.GetConnectionString("fit")));
            services.AddDefaultIdentity<ApplicationUser>()
               .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IdentityErrorDescriber, BiHIdentityErrorDescriber>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                     name: "areas",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                   );
            });
        }
    }
}
