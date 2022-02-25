using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete.Context.EntityFramework;
using DataAccessLayer.Context.Concrete.EntityFramework;
using System;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {


        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProduct(new ListemSepetimdeDbContext()));
            productManager.GetEntity();


            //3-Validasyon işlemini kontrol etme

            //CategoryManager db = new CategoryManager(new EfCategory(new ListemSepetimdeDbContext()));
            //var resuly = db.Add(new Entity.POCO.Category() {Name = "X" });
            //switch (resuly.ResultType)
            //{
            //    case Core.BLL.Constant.EntityResultType.Success:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Error:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.NotFound:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.NonValidation:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Warning:
            //        break;
            //    default:
            //        break;
            //}

            //2-kategori ekleme-güncelleme-silme kontrol

            // EfCategory efCategory = new EfCategory(new ListemSepetimdeDbContext());
            // var entity = efCategory.Get(1);
            // //entity.Name = "Bebek";
            // entity.Active = false;
            // entity.Deleted = true;
            //var cikti = efCategory.Update(entity);
            // if (cikti)
            // {
            //     Console.WriteLine("eklendi");
            // }


            //1-ürün ekleme

            //ListemSepetimdeDbContext db = new ListemSepetimdeDbContext();
            //db.Product.Add(new Entity.POCO.Product { Name = "Ayakkabı", Price = 500, Stock = 5 });
            //if (db.SaveChanges()>0)
            //{
            //    Console.WriteLine("eklendi.");
            //}
            //foreach (var item in db.Product.ToList())
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}
