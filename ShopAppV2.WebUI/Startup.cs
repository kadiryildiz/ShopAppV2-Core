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
using Microsoft.EntityFrameworkCore;
using ShopAppV2.DataAccess.Abstract;
using ShopAppV2.Business.Abstract;
using ShopAppV2.Business.Concrete;
using ShopAppV2.DataAccess.Concrete.EfCore;
using ShopAppV2.WebUI.Identity;
using ShopAppV2.WebUI.Middlewares;

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
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));  //appsettings.json'da tanýmlandý.

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>() //AddEntityFrameworkStores = datalar nerede saklansýn.
                .AddDefaultTokenProviders(); //reset password gibi iþlemlerde benzersiz token üretmesi..

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = true;                //sayýsal deðer ister
                options.Password.RequireLowercase = true;            //küçük karakter ister
                options.Password.RequiredLength = 6;                 // min 6 karakter olsun
                options.Password.RequireNonAlphanumeric = true;     // Alfanumeric olmalý
                options.Password.RequireUppercase = true;           // büyük harf olmalý

                options.Lockout.MaxFailedAccessAttempts = 5;        // kaç kere yanlýþ girme hakký olsun
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);   //5 dakika boyunca engelle
                options.Lockout.AllowedForNewUsers = true;                          //engelleme yeni kullanýcý için de geçerli olsun.

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;                             // ayný email'den yeni kullanýcý kayýt olamaz.

                options.SignIn.RequireConfirmedEmail = true;                        // kullanýcýya email onay kodu gönderilsin.
                options.SignIn.RequireConfirmedPhoneNumber = false;                 // kullanýcýya telefon ile onay gönderilsin
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // tarayýcýda saklanma süresi.
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie"
                };

            });
            // Identity kurulum end //

            //services.AddScoped<IProductDal, MemoryProductDal>();
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<IProductService, ProductManager>(); // IproductService'i çaðýrýrsak bize ProductManager'i gönder.
            services.AddScoped<ICategoryService, CategoryManager>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.CustomStaticFiles();  //Middlewares klasörü içerisine class eklendi node_modules için.
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
        }
    }
}
