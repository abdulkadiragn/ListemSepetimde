using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using Core.BLL.Constant;
using DataAccessLayer.Concrete.Context.EntityFramework;
using DataAccessLayer.Context.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService) //senden böyle bir class istendiğinde bunu ver dememiz için startup'da IoC kullandık.(Tek başına hata verir.)
        {
            this.categoryService = categoryService;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hakkinda()
        {
            return View();
        }
        public IActionResult BizeUlasin()
        {
            return View();
        }
    }
}
