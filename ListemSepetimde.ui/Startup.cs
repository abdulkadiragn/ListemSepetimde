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
            //Dependency inhection ba��ml�l���n� tek bir yerden y�netebilme(IoC)
            services.AddScoped<ICategoryService, CategoryManager>(); //senden iri IcategoryService istediginde CategoryManager ver dedik.
            services.AddScoped<ICategoryDAL, EfCategory>(); //ICategoryDAl istendi�inde EfCategory ver
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EfProduct>();
            services.AddScoped<IBasketService, BasketManager>(); //sepet i�lemi
            services.AddScoped<IBasketDAL, EfBasket>();  //sepet i�lemi
            services.AddDbContext<ListemSepetimdeDbContext>(); //DbContext'in bu. default olarak addscoped kabul eder.
            services.AddIdentity<AppUser, AppRole>(X =>
            {
                //kay�t olmada default olarak gelen zorunluluklar� kald�rd�k.
                X.Password.RequiredLength = 3;
                X.Password.RequireLowercase = false; //k���k harf bekleme
                X.Password.RequireUppercase = false; //b�y�k harf bekleme
                X.Password.RequireNonAlphanumeric = false;
                X.Password.RequireDigit = false; //say� bekleme

                X.User.RequireUniqueEmail = true; //ayn� e-mail'den tekrar eklenebilsin.
                


            }).AddErrorDescriber<ErrorDiscAccount>()//ErrorDiscAccount hatalar�n� iste�imize g�re d�zeltmek i�in.
                                                    .AddEntityFrameworkStores<ListemSepetimdeDbContext>(); //otantike i�lemi i�in yazd�k.


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // MyClassSeed.Seed(); //database'ye veri y�kledik
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //middle verilerin s�ralamas� �nemli!!!

            app.UseStaticFiles(); //static dosyalar� kullanabilmek i�in ekledik.
            app.UseRouting();
            app.UseAuthentication(); //sayfalara eri�im ko�ulu koyaca��m�z� belirttik.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                      name: "AreaAdmin",
                      areaName: "Admin",
                      pattern: "Admin/{controller}/{action}/{id?}" /*pattern => url olarak ne yaz�ld���nda y�nledireyim.*/); //area'ya baglamak i�in  
                endpoints.MapDefaultControllerRoute();
               
            });
        }
    }
}
