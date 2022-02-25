using BusinessLogicLayer.Abstract;
using Core.BLL.Constant;
using DataAccessLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public EntityResult Add(Product entity)
        {
            throw new NotImplementedException();
        }


        public EntityResult Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<ProductDTO>> GetBasketByProductId(int userId)
        {
            try
            {
                var result = productDAL.GetBasketByProductId(userId);
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<ProductDTO>>(result, "Success");
                }
                return new EntityResult<IEnumerable<ProductDTO>>(null, "NotFound",EntityResultType.NotFound);

            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product, bool>> expression = null, string[] navProperty = null)
        {
            try
            {
                var result = productDAL.GetEntity(expression, navProperty);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<Product>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Product>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Product>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<ProductDTO>> GetProduct()
        {
            try
            {
                var result = productDAL.GetProduct();
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<ProductDTO>>(result, "Success");
                }
                return new EntityResult<IEnumerable<ProductDTO>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<ProductDTO>> GetProductByCategoryId(int categoryid)
        {
            //bize allta yaptığımız işlemlerden bir id gelecek bu id'yi yakalayıp koşullarımızı yazdık
            try
            {
                var result =
                    productDAL.GetProductByCategoryId(categoryid);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<ProductDTO>>(result, "Success");
                }
                return new EntityResult<IEnumerable<ProductDTO>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
