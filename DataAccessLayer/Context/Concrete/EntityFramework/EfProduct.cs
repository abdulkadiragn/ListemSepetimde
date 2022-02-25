using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Context.Concrete.EntityFramework
{
    public class EfProduct : EfRepository<Product, ListemSepetimdeDbContext>, IProductDAL
    {
        private readonly ListemSepetimdeDbContext db;

        public EfProduct(ListemSepetimdeDbContext db) : base(db)
        {
            this.db = db;
        }
        //saf sorgu uygulamnın hızını arttırır.
        public IEnumerable<ProductDTO> GetProductByCategoryId(int categoryid) //productları dönebilmek için yazdık
        {
            //çoka çok tablolarda eğer birden fazla veri varsa sorgu önemli (ürünlerin db'de birden fazla resmi olsaydı böyle db sorgusu yapmak lazım.)
            var result =
                from product in db.Product //db içindeki product
                join productCategory in db.ProductCategory
                on product.Id equals productCategory.ProductId
                join category in db.Category
                on productCategory.CategoryId equals category.Id
                where productCategory.CategoryId == categoryid //hepsini çekmemesi için categoryidleri eşitledik.
                select new ProductDTO //productDTO dön
                {
                    Name = product.Name,
                    CategoryName = category.Name, //categoryName i db category'den gelen name olsun
                    Id = product.Id, //id'si db product'dan gelen id olsun
                    Price = product.Price, //price'ı db product'dan gelen price olsun
                    Stock = product.Stock, //stoğu db product'dan gelen stok olsun
                    //Aşşağıda db'den gelen productImage'den bir tane çek. Bu çektiginin productId'si de bende bulunan productId ile eşit olsun ve bunun url'ini çek
                    ImageUrl = db.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).Url
                };
            return result;
        }

        //bütün ürünleri çekebilmek için yukardaki metodun aynısı(categoryİd'ye göre degil direk bütün ürünleri çekmek için id,where sorgusunu kaldırdık)
        public IEnumerable<ProductDTO> GetProduct()
        {

            var result =
                from product in db.Product
                join productCategory in db.ProductCategory
                on product.Id equals productCategory.ProductId
                join category in db.Category
                on productCategory.CategoryId equals category.Id
                select new ProductDTO
                {
                    Name = product.Name,
                    CategoryName = category.Name,
                    Id = product.Id,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageUrl = db.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).Url
                };
            return result;
        }
        //userId'ye göre sepete ürün eklemek için bu metodu yazdık.
        public IEnumerable<ProductDTO> GetBasketByProductId(int userId)
        {
            var result =
                    from product in db.Product
                    join basket in db.Basket on product.Id equals basket.ProductId //productId'yi basket productId ile joinle birleştirdil
                    join user in db.Users on basket.AppUserId equals user.Id //useril ile basket'in appuserid'sini birleştirdik.
                    where user.Id == userId //join sorgusundan gelen id'yi parametre olan id'ye atadık
                    select new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock,
                        ImageUrl = db.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).Url,
                        BasketCount = basket.Count

                    };
            return result;
        }
    }

}
