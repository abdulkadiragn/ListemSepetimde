using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Validation;
using Core.BLL.Constant;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context.EntityFramework;
using DataAccessLayer.Context.Concrete.EntityFramework;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            this.categoryDAL = categoryDAL;
        }
        public EntityResult Add(Category entity)
        {
            try
            {
                var vali = new CategoryValidation(categoryDAL).Validate(entity);
                if (!vali.IsValid) //validasyon sağlam değilse bir hata varsa gir (baştaki ünlem olmasa true dönerse girer)
                {
                    List<string> errorMessage = new List<string>();
                    foreach (var item in vali.Errors) //hatadan gelen mesajları dön listeye at
                    {
                        errorMessage.Add(item.ErrorMessage);
                    }
                    return new EntityResult(errorMessage, EntityResultType.NonValidation);
                }

                if (categoryDAL.Add(entity))
                {
                    return new EntityResult(ResultTypeMessage.Add());
                }
                return new EntityResult(ResultTypeMessage.Warning(),EntityResultType.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultTypeMessage.Error(ex),EntityResultType.Error);
            }
        } 

        public EntityResult Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> GetCategory()
        {
            try
            {
                var result = categoryDAL.GetCategory();
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Category>>(result,"Success");
                }
                return new EntityResult<IEnumerable<Category>>(null, "NotFound", EntityResultType.NotFound);
                    
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Category>>(null, "Error : " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
