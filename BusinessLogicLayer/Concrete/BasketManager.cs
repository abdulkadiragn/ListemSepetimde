using BusinessLogicLayer.Abstract;
using Core.BLL.Constant;
using DataAccessLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL basketDAL;

        public BasketManager(IBasketDAL basketDAL)
        {
            this.basketDAL = basketDAL;
        }
        public EntityResult<IEnumerable<Basket>> AddToBasket(BasketDTO basketDTO)
        {
            try
            {
                var basket = basketDAL.AddToBasket(basketDTO).ToList();
                if (basket != null && basket.Count() > 0)
                {
                    return new EntityResult<IEnumerable<Basket>>(basket, "Success");
                }
                return new EntityResult<IEnumerable<Basket>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }
        //sepetin kullanıcı ve ürün arasındaki bağın kopmaması için yazdık. (Sepet count gibi şeyleri sıfırlanıyordu sayfa yenilendiğinde).
        public EntityResult<IEnumerable<Basket>> Get(int userId)
        {
            try
            {
                string[] dizi = new string[] { "Product", "AppUser" };
                var result = basketDAL.GetEntity(x => x.AppUserId == userId, dizi);
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Basket>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Basket>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }

        }
    }
}
