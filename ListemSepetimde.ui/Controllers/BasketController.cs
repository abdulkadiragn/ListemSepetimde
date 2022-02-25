using BusinessLogicLayer.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Controllers
{
    [Authorize(Roles = "UserApp")]
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly UserManager<AppUser> userManager;
        private readonly IProductService productService;

        public BasketController(IBasketService basketService, UserManager<AppUser> userManager,IProductService productService)
        {
            this.basketService = basketService;
            this.userManager = userManager;
            this.productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int count, int productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.AddToBasket(new Entity.DTO.BasketDTO
            {
                Count = count,
                ProductId = productId,
                UserId = user.Id
            });
            switch (result.ResultType)
            {
                //result.Data.ToList()
                case Core.BLL.Constant.EntityResultType.Success:
                    return Ok(/*result.Data.Sum(x => x.Count)*/);

                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.NotFound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }
        [HttpPost]
        //sayfa yenilediğinde sepet bilgileri gelmesi için
        public async Task<IActionResult> RefreshBaketCount()
        {
            var usr = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.Get(usr.Id);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return Ok(result.Data.Sum(x => x.Count));
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.NotFound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();

        }

        public async Task<IActionResult> Sepet()
        {
            var usr = await userManager.FindByNameAsync(User.Identity.Name);
            var result = productService.GetBasketByProductId(usr.Id);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return View(result.Data);
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.NotFound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }
    }
}
