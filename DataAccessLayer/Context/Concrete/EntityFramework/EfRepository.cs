using Core.DAL;
using Core.Entity;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Context.Concrete.EntityFramework
{
    public class EfRepository<TEntity, TDbContext> : IRepository<TEntity> //Tentity'i kabul et kalıttıgımız yerde IRepository için generic verecegiz.
        where TEntity : class, IBaseEntity, new() //Tentity : IBaseEntity barındınlar(kalıtanlar) kullanabilir. / yapısı class(interface olmaz) kullanabilir //newlenebilir(abstract,static class gelemez) kullanabilir.
        where TDbContext : DbContext //TDbContext : DbContext barındıranlar(kalıtanlar) kullanabilir.
    {

        private readonly TDbContext db; //ctor'dan gelen database'i bu field'a atadık

        public EfRepository(TDbContext db) //(dependency injection) bu class'ı kullanmak isteyen bana bir db versin amaç, her metod için database newlemek yerine bir kere newlemek. / yukarıda(UI katmanında) IoC kullanacağız.
        {
            this.db = db;
        }
        public bool Add(TEntity entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0 ? true : false;

        }
        public bool Update(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
        public bool Delete(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
        public IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null) //ürün detayları için yazdık.(EntityFramework teknolojisi kullandığımz için çalışır.)
        {

            IQueryable<TEntity> entities = null;
            if (expression == null)
            {
                entities = db.Set<TEntity>();
            }
            else
            {
                entities = db.Set<TEntity>().Where(expression);
            }
            if (navProperty == null)
            {
                return entities; //join atmaya gerek yoksa entities dön
            }
            else
            {
                foreach (var item in navProperty)
                {
                    entities = entities.Include(item); //include atabilmemizin sebebi EntityFramework kullandığımız için. (include bizim için join atar)
                }
                return entities;
            }
        }

        public IEnumerable<TEntity> Get()
        {
            return db.Set<TEntity>(); //metod tipi Ienumerable olsa bile burası Iquaryable döndügü için ve Ienumerable Iquaeryable'nin üst tipi olduğu için sonuç Iquaeryable dönüyor.
        }
        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }
    }
}
