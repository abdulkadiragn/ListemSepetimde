using Core.BLL;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        EntityResult<IEnumerable<ProductDTO>> GetProductByCategoryId(int categoryid);
        EntityResult<IEnumerable<ProductDTO>> GetProduct();
        EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product, bool>> expression = null, string[] navProperty = null);
        EntityResult<IEnumerable<ProductDTO>> GetBasketByProductId(int userId);

    }
}
