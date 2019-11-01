using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IUOSAT.DAL.EF;
using IUOSAT.DAL.EF.Repositories;
using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Web.UI.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IUOSAT.Web.UI
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json").Build();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("IUOSAT")));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
           Configuration.GetConnectionString("IUOSAT")));
            services.AddScoped<IPersonRepository, EFPersonRepository>();
            services.AddScoped<ICommentRepository, EFCommentRepository>();
            services.AddScoped<IGradeRepository, EFGradeRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IPersonSkillRepository, EFPersonSkillRepository>();
            services.AddScoped<ISkillRepository, EFSkillRepository>();
            services.AddScoped<IArticleRepository, EFArticleRepository>();
            services.AddScoped<ICourceRepository, EFCourceRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddResponseCaching();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddResponseCompression();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
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
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseResponseCompression();
            app.UseResponseCaching();

            app.UseMvc(routes => {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
  
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
