using Core.DAL;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDAL : IRepository<Category> //sonradan eklenecek zorunlu metodlar için bu class'ı açtık amaç farklı teknolojiler için de zorunlu hale getirme(Entity katmanının üstüne taşıma)
    {
        IEnumerable<Category> GetCategory();
    }
}
