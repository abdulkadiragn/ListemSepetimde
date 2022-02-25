using Core.BLL.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL
{
   public interface IGenericService<T>
    {
        EntityResult Add(T entity);
        EntityResult Update(T entity);
        EntityResult Delete(T entity);
        EntityResult<IEnumerable<T>> Get();
        EntityResult<T> Get(int id);
    }
}
