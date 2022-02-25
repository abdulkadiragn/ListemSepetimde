using BusinessLogicLayer.Abstract;
using Core.BLL.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            string[] sdizi = new string[] { "ProductImages" };
            var result = productService.GetEntity(x => x.Id == id, sdizi);
            switch (result.ResultType)
            {
                case EntityResultType.Success:
                    var entity = result.Data.ToList()[0];
                    return View(entity);
                case EntityResultType.Error:
                    break;
                case EntityResultType.NotFound:
                    break;
                case EntityResultType.NonValidation:
                    break;
                case EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
