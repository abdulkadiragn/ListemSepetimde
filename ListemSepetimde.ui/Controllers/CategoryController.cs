using BusinessLogicLayer.Abstract;
using Core.BLL.Constant;
using ListemSepetimde.ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Controllers
{
    [Authorize(Roles = "UserApp")]
    public class CategoryController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index(int id, int page=1)
        {
            int take = 3;
            int skip = take * (page - 1);
            CategoryDetailViewModel model = new CategoryDetailViewModel();
            model.Category = categoryService.GetCategory().Data.ToList();
            var result = productService.GetProductByCategoryId(id); //click olduğunda gelen id'yi metod içine gönderdik.(altta ona göre sorgu yapıp product cekecek)
            var productCount = result.Data.Count();
            ViewBag.PageCount = Math.Ceiling(Convert.ToDecimal(productCount) / take); //decimal'e bilerek cevirdik celling ile de yukarıya yukarladık(arada geçerken ürün kaybı olmaması için. / int/int oldugunda küsüratlı degeri atlayacagı için)
            ViewBag.CategoryId = id;
            switch (result.ResultType)
            {
                case EntityResultType.Success:
                    model.ProductDto = result.Data.Skip(skip).Take(take).ToList(); //skip => kaçtan başlayarak getirecek.  Take => kaç tane getirecek
                    return View(model);
                case EntityResultType.Error:
                    break;
                case EntityResultType.NotFound:
                    break;
                case EntityResultType.NonValidation:
                    break;
                case EntityResultType.Warning:
                    break;
            }
            return View();
        }
        //pagınation işlemi YUKARIDAKİ METOD İLE PAGEINATİON İŞLEMİNİ BİRLEŞTİRDİK

        //public IActionResult CategoryPage(int id, int page = 1)
        //{
        //    int take = 3;
        //    int skip = take * (page - 1);
        //    CategoryDetailViewModel model = new CategoryDetailViewModel();
        //    model.Category = categoryService.GetCategory().Data.ToList();
        //    var result = productService.GetBasketByProductId(id);
        //    var productCount = result.Data.Count();
        //    ViewBag.PageCount = Math.Ceiling(Convert.ToDecimal(productCount) / take);
        //    ViewBag.CategoryId = id;
        //    switch (result.ResultType)
        //    {
        //        case EntityResultType.Success:
        //            model.ProductDto = result.Data.Skip(skip).Take(take).ToList();
        //            return View(model);
        //        case EntityResultType.Error:
        //            break;
        //        case EntityResultType.NotFound:
        //            break;
        //        case EntityResultType.NonValidation:
        //            break;
        //        case EntityResultType.Warning:
        //            break;
        //        default:
        //            break;
        //    }
        //    return View();
        //}

    }
}
