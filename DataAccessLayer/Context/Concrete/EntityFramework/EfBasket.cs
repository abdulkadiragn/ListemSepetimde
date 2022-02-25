using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Context.Concrete.EntityFramework
{
    public class EfBasket : EfRepository<Basket, ListemSepetimdeDbContext>, IBasketDAL
    {
        private readonly ListemSepetimdeDbContext db;

        public EfBasket(ListemSepetimdeDbContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Basket> AddToBasket(BasketDTO basketDTO)
        {
            var basket = db.Basket.FirstOrDefault(x => x.AppUserId == basketDTO.UserId && x.ProductId == basketDTO.ProductId); //eklenip eklenmediğini kontrol ettik
            if (basket == null)
            {
                db.Basket.Add(new Basket
                {
                    AppUserId = basketDTO.UserId,
                    ProductId = basketDTO.ProductId,
                    Count = basketDTO.Count

                });
                db.SaveChanges();
            }
            else
            {
                basket.Count = basket.Count + basketDTO.Count; //eklenmiş varsa üzerine ekledik
                db.SaveChanges();
            }
            return db.Basket.Where(x => x.AppUserId == basketDTO.UserId);
        }
    }
}
