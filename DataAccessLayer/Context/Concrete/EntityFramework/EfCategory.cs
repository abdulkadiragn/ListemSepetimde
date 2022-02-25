using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Context.Concrete.EntityFramework
{
    public class EfCategory : EfRepository<Category,ListemSepetimdeDbContext>,ICategoryDAL
    {
        private readonly ListemSepetimdeDbContext db;

        public EfCategory(ListemSepetimdeDbContext db):base(db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetCategory()
        {
            return db.Category
                .Include(x => x.ProductCategories) //productcategories tablosuna git
                .ThenInclude(x => x.Product) //productcategories tablosundan Product tablosuna git
                .Where(x => x.Active && !x.Deleted); //active'i true delete'i false olanları getir

        }
    }
}
