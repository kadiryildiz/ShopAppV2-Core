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
using ShopAppV2.DataAccess.Abstract;
using ShopAppV2.Business.Abstract;
using ShopAppV2.Business.Concrete;
using ShopAppV2.DataAccess.Concrete.EfCore;
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
