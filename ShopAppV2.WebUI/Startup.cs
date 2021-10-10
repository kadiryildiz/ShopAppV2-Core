using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAppV2.DataAccess.Concrete.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ShopAppV2.DataAccess.Abstract;
using ShopAppV2.Business.Abstract;
using ShopAppV2.Business.Concrete;
using ShopAppV2.DataAccess.Concrete.EfCore;
using ShopAppV2.WebUI.Identity;
using ShopAppV2.WebUI.Middlewares;
using ShopAppV2.WebUI.EmailServices;

namespace ShopAppV2.WebUI
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
            // Identity kurulum start //
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));  //appsettings.json'da tan�mland�.

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>() //AddEntityFrameworkStores = datalar nerede saklans�n.
                .AddDefaultTokenProviders(); //reset password gibi i�lemlerde benzersiz token �retmesi..

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = true;                //say�sal de�er ister
                options.Password.RequireLowercase = true;            //k���k karakter ister
                options.Password.RequiredLength = 6;                 // min 6 karakter olsun
                options.Password.RequireNonAlphanumeric = true;     // Alfanumeric olmal�
                options.Password.RequireUppercase = true;           // b�y�k harf olmal�

                options.Lockout.MaxFailedAccessAttempts = 5;        // ka� kere yanl�� girme hakk� olsun
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);   //5 dakika boyunca engelle
                options.Lockout.AllowedForNewUsers = true;                          //engelleme yeni kullan�c� i�in de ge�erli olsun.

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;                             // ayn� email'den yeni kullan�c� kay�t olamaz.

                options.SignIn.RequireConfirmedEmail = true;                        // kullan�c�ya email onay kodu g�nderilsin.
                options.SignIn.RequireConfirmedPhoneNumber = false;                 // kullan�c�ya telefon ile onay g�nderilsin
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // taray�c�da saklanma s�resi.
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict // Csrf (Cross Site Request Forgery) attack lar�n� engeller.
                };

            });
            // Identity kurulum end //

            //services.AddScoped<IProductDal, MemoryProductDal>();
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<IProductService, ProductManager>(); // IproductService'i �a��r�rsak bize ProductManager'i g�nder.
            services.AddScoped<ICategoryService, CategoryManager>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IEmailSender, EmailSender>(); //Sendgrid.com  (confirm mail i�in servis)
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) // admin role i�in usermanager ve rolemanager �a�r�ld�.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseAuthentication();  // Identity kullan..
            app.UseStaticFiles();
            app.CustomStaticFiles();  //Middlewares klas�r� i�erisine class eklendi node_modules i�in.
                                      //app.UseMvcWithDefaultRoute();
                                      app.UseMvc(routes =>
                                      {
                                          routes.MapRoute(
                                              name: "adminProducts",
                                              template: "admin/products",
                                              defaults: new { controller = "Admin", action = "ProductList" }
                                          );

                                          routes.MapRoute(
                                              name: "adminProducts",
                                              template: "admin/products/{id?}",
                                              defaults: new { controller = "Admin", action = "EditProduct" }
                                          );

                                          routes.MapRoute(
                                              name: "products",
                                              template: "products/{category?}",
                                              defaults: new { controller = "Shop", action = "List" }
                                          );

                                          routes.MapRoute(
                                              name: "default",
                                              template: "{controller=Home}/{action=Index}/{id?}"
                                          );

                                      });

                                      SeedIdentity.Seed(userManager, roleManager, Configuration).Wait(); // Identity/SeedIdentity.cs de admin role seed edildi.
        }
    }
}
