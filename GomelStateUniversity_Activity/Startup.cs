using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventUserRepository, EventUserRepository>();
            services.AddSingleton<ISubdivisionRepository, SubdivisionRepository>();
            services.AddSingleton<ICreativityTypeRepository, CreativityTypeRepository>();
            services.AddSingleton<ISportTypeRepository, SportTypeRepository>();
            services.AddSingleton<ILaborDirectionRepository, LaborDirectionRepository>();
            services.AddSingleton<IApplicationFormRepository, ApplicationFormRepository>();
            services.AddSingleton<ISubdivisionActivityTypeRepository, SubdivisionActivityTypeRepository>();
            services.AddSingleton<IReviewsRepository, ReviewsRepository>();
            services.AddSingleton<IScheduleRepository, ScheduleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();
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
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                name: "HomeActionOnly",
                pattern: "{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
