using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IBasketService
    {
        EntityResult<IEnumerable<Basket>> AddToBasket(BasketDTO basketDTO);
        public EntityResult<IEnumerable<Basket>> Get(int userId);

    }
}
