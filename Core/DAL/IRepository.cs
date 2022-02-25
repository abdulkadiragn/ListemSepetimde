using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseEntity, new() //IbaseEntity'i class dan sonra ekleyebilmemizin sebebi aynı katmanda olmaları //tentity class,IbaseEntity barındıran yenilenebilir olacak.
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null);

    }
}
