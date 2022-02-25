using Core.DAL;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IProductDAL : IRepository<Product>
    {
        IEnumerable<ProductDTO> GetProductByCategoryId(int categoryid);
        IEnumerable<ProductDTO> GetProduct();
        public IEnumerable<ProductDTO> GetBasketByProductId(int userId);
    }
}
