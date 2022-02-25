using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context.EntityFramework;
using DataAccessLayer.Context.Concrete.EntityFramework;
using DataAccessLayer.SeedData;
using Entity.POCO;
using ListemSepetimde.ui.CustomValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Dependency inhection baðýmlýlýðýný tek bir yerden yönetebilme(IoC)
            services.AddScoped<ICategoryService, CategoryManager>(); //senden iri IcategoryService istediginde CategoryManager ver dedik.
            services.AddScoped<ICategoryDAL, EfCategory>(); //ICategoryDAl istendiðinde EfCategory ver
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EfProduct>();
            services.AddScoped<IBasketService, BasketManager>(); //sepet iþlemi
            services.AddScoped<IBasketDAL, EfBasket>();  //sepet iþlemi
            services.AddDbContext<ListemSepetimdeDbContext>(); //DbContext'in bu. default olarak addscoped kabul eder.
            services.AddIdentity<AppUser, AppRole>(X =>
            {
                //kayýt olmada default olarak gelen zorunluluklarý kaldýrdýk.
                X.Password.RequiredLength = 3;
                X.Password.RequireLowercase = false; //küçük harf bekleme
                X.Password.RequireUppercase = false; //büyük harf bekleme
                X.Password.RequireNonAlphanumeric = false;
                X.Password.RequireDigit = false; //sayý bekleme

                X.User.RequireUniqueEmail = true; //ayný e-mail'den tekrar eklenebilsin.
                


            }).AddErrorDescriber<ErrorDiscAccount>()//ErrorDiscAccount hatalarýný isteðimize göre düzeltmek için.
                                                    .AddEntityFrameworkStores<ListemSepetimdeDbContext>(); //otantike iþlemi için yazdýk.


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // MyClassSeed.Seed(); //database'ye veri yükledik
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //middle verilerin sýralamasý önemli!!!

            app.UseStaticFiles(); //static dosyalarý kullanabilmek için ekledik.
            app.UseRouting();
            app.UseAuthentication(); //sayfalara eriþim koþulu koyacaðýmýzý belirttik.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                      name: "AreaAdmin",
                      areaName: "Admin",
                      pattern: "Admin/{controller}/{action}/{id?}" /*pattern => url olarak ne yazýldýðýnda yönledireyim.*/); //area'ya baglamak için  
                endpoints.MapDefaultControllerRoute();
               
            });
        }
    }
}
