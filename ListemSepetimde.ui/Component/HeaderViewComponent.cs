using BusinessLogicLayer.Abstract;
using Core.BLL.Constant;
using ListemSepetimde.ui.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Component
{
    public class HeaderViewComponent : ViewComponent //ViewComponent olduğunu anlaması için kalıtmak gerekir. Amaç databaseden veri cekip header'a taşımak
    {
        private readonly ICategoryService categoryService;

        public HeaderViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
       public IViewComponentResult Invoke()
        {
            ///Views/Shared/Components/Header/Default.cshtml   Bu dosyayı oluştur(Uzantıyı bulması için.)

            HeaderViewModel model = new HeaderViewModel();

            var categories = categoryService.GetCategory(); //database'den category verilerini çek
            switch (categories.ResultType) //kontrollerini yap
            {
                case EntityResultType.Success:
                    model.Category = categories.Data.ToList();
                    break;
                case EntityResultType.Error:
                    break;
                case EntityResultType.NotFound:
                    break;
                case EntityResultType.NonValidation:
                    break;
                case EntityResultType.Warning:
                    break;
            }

            return View(model);
        }
    }
}
