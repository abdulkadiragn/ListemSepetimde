using Core.DAL;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IBasketDAL : IRepository<Basket>
    {
        IEnumerable<Basket> AddToBasket(BasketDTO basketDTO);
    }
}
