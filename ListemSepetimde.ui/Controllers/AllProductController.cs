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
    [Authorize]
    public class AllProductController : Controller
    {
        private readonly IProductService productService;

        public AllProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult IndexP()
        {

            var result = productService.GetProduct();
            switch (result.ResultType)
            {
                case EntityResultType.Success:
                    return View(result.Data.ToList());
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
    }
}
