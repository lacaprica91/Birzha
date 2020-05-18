using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BirzhaApp.Models;
using BirzhaApp.Infrastructure;

namespace BirzhaApp
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
                options.UseSqlServer(Configuration["Data:BirzhaApp:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:BirzhaAppIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>(options => {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }) .AddEntityFrameworkStores<AppIdentityDbContext>()
               .AddDefaultTokenProviders();
            services.AddTransient<IUserValidator<User>, CustomUserValidator>();
            services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>();
            services.AddTransient<ICompanyRepository, EFCompanyRepository>();
            services.AddTransient<IJobRepository, EFJobRepository>();
            services.AddTransient<IJobTypeRepository, EFJobTypeRepository>();
            services.AddTransient<IEducationRepository, EFEducationRepository>();
            services.AddTransient<IExperienceRepository, EFExperienceRepository>();
            services.AddTransient<IVolunteeringRepository, EFVolunteeringRepository>();

            services.AddMvc();
            //services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            //app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Company/Page{companyPage}",
                    defaults: new { Controller = "Company", action = "List"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
