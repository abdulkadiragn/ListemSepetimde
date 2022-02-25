using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using ListemSepetimde.ui.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ListemSepetimdeDbContext db;

        public ProductController(ListemSepetimdeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            //çok veri çok client oldmadığı için include kullanabildik. (sayfa sadece admin sayfasından oluşmadığı için de rahat kullanabiliyoruz.)
            var product =
                db.Product.Include(x => x.ProductImages)
                .Include(x => x.ProductCategories).ThenInclude(x => x.Category) //ThenInclude EntityFrameworkCore'da var 
                .ToList();
            return View(product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await db.Product.Include(x => x.ProductImages)
                .Include(x => x.ProductCategories).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }


        [HttpGet] //new Create Dedigimizde yeni bir sayfa olustursun
        public async Task<IActionResult> Create()
        {
            //dynamic => var gibidir ama runtime(okunma) anında verilen degeri alır var direk derleme aşamasında belirlenir.
            //admin sayfasında ürün eklerken kategoriyi databaseden çekip ui'a gönderebilmek için yazdık.

            ViewBag.Category = new SelectList(db.Category.Where(x => x.Active && !x.Deleted)
                .Select(x => new Category { Id = x.Id, Name = x.Name }).ToList(), "Id", "Name");
            return View();
        }


        [HttpPost] //form ile göndericez
        public async Task<IActionResult> Create(ProductDto productDto) //productDto(Areas) gelen verileri yakala
        {
            //bu işlemler(transection işlemleri) DataAccessLayer(Admin sayfası degilse) yapılması daha uygun olur (back-data tarafında kontrol etmek.)
            if (ModelState.IsValid)
            {
                var fileInfo = new FileInfo(productDto.Images[0].FileName).Extension; //yüklenen dosya uzantısını gösterir.

                //foreach ile döne döne ekleme yapacagında strategy ekle ki hata alma (1 isim 3 fotograf) (ÖNEMLİ!!!!)
                var strategy = db.Database.CreateExecutionStrategy();
                strategy.Execute(() =>
                {

                    var transection = db.Database.BeginTransaction(); //farklı işlem parçacıklarını tek işlem parcacıgı olarak degerlendirme.(farklı tabolar tek zorunluluk)
                    try
                    {
                        Product product = new Product
                        {
                            Name = productDto.Name,
                            Price = productDto.Price,
                            Stock = productDto.Stock,
                        };
                        db.Product.Add(product);
                        if (db.SaveChanges() > 0) //aşşağıda id lazım oldugu için kontrol ediyoruz.
                        {
                            List<ProductCategory> productCategories = new List<ProductCategory>();
                            foreach (var item in productDto.Categories) //1den fazla kategori gelebilecegi için.
                            {
                                ProductCategory productCategory = new ProductCategory
                                {
                                    ProductId = product.Id,
                                    CategoryId = item
                                };
                                productCategories.Add(productCategory);
                            }
                            db.ProductCategory.AddRange(productCategories);
                            //resim yüklendiyse gir
                            if (productDto.Images != null && productDto.Images.Count > 0)
                            {
                                foreach (var item in productDto.Images)
                                {
                                    string path = Guid.NewGuid().ToString() + new FileInfo(item.FileName).Extension; //fileInfo ile uzantı yakaladık.
                                    string pathKontrol = new FileInfo(item.FileName).Extension; //uzantısı sadece .jpeg olanlar eklenebilmesi için.
                                    if (pathKontrol == ".jpg")
                                    {
                                        //C:\Users\Abdulkadir\Desktop\ListemSepetimde\ListemSepetimde.ui\wwwroot\ProdctImage\
                                        //guid yüklenen dosyayı uniq yapmaya yarar.
                                        string dataBasepath = "/ProdctImage/" + path;
                                        string serverPath = Directory.GetCurrentDirectory() + @"\wwwroot\ProdctImage\" + path;
                                        db.ProductImage.Add(new ProductImage { ProductId = product.Id, Url = dataBasepath });
                                        FileStream fileStream = new FileStream(serverPath, FileMode.Create); //1.(serverPath) Nereye kaydedecek
                                        item.CopyTo(fileStream);
                                    }
                                }
                                db.SaveChanges();
                                transection.Commit();
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        transection.Rollback();
                        throw;
                    }
                });
                return RedirectToAction("Index");

            }
            //hata gelirse formun boş dönmemesi için tekrar bunu yazdık.
            ViewBag.Category = new SelectList(db.Category.Where(x => x.Active && !x.Deleted)
           .Select(x => new Category { Id = x.Id, Name = x.Name }).ToList(), "Id", "Name");
            return View(productDto);
        }
    }
}
