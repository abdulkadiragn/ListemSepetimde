using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SeedData
{
    public static class MyClassSeed
    {
        public static void Seed()
        {
            ListemSepetimdeDbContext db = new ListemSepetimdeDbContext();
            List<Category> categories = new List<Category>
            {
                new Category{ Name="Kadın",
                    ImageUrl="/images/categories/category17.jpg"},//1
                new Category{ Name="Erkek",
                ImageUrl="/images/categories/category20.jpg"},//2
            };
            db.Category.AddRange(categories);
            List<Product> products = new List<Product>()
            {
                new Product{Name="Kadın Mont",Price=150,Stock=1000 },//1
                new Product{Name="Kadın Mont-2",Price=50,Stock=150 },//2
                new Product{Name="Kadın Çanta",Price=10,Stock=75 },//3
                new Product{Name="Kadın Elbise ",Price=125,Stock=25 },//4
                new Product{Name="Kadın Ayakkabı",Price=52,Stock=35 },//5
                new Product{Name="Erkek Bere",Price=85,Stock=45 },//6
                new Product{Name="Erkek Ayakkabı",Price=24,Stock=55 },//7
                new Product{Name="Erkek Mont",Price=25,Stock=75 },//8
                new Product{Name="Erkek Çanta",Price=35,Stock=35 },//9
                new Product{Name="Erkek Bot",Price=75,Stock=87 },//10
                new Product{Name="Erkek Mont-2",Price=12,Stock=70 },//11
                new Product{Name="Erkek Şapka",Price=15,Stock=30 },//12
            };
            db.Product.AddRange(products);
            db.SaveChanges();

            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory{ CategoryId=1,ProductId=1},
                new ProductCategory{ CategoryId=1,ProductId=2},
                new ProductCategory{ CategoryId=1,ProductId=3},
                new ProductCategory{ CategoryId=1,ProductId=4},
                new ProductCategory{ CategoryId=1,ProductId=5},
                new ProductCategory{ CategoryId=2,ProductId=6},
                new ProductCategory{ CategoryId=2,ProductId=7},
                new ProductCategory{ CategoryId=2,ProductId=8},
                new ProductCategory{ CategoryId=2,ProductId=9},
                new ProductCategory{ CategoryId=2,ProductId=10},
                new ProductCategory{ CategoryId=2,ProductId=11},
                new ProductCategory{ CategoryId=2,ProductId=12},
            };
            db.ProductCategory.AddRange(productCategories);
            db.SaveChanges();

            List<ProductImage> productImages = new List<ProductImage>
            {
                new ProductImage{ ProductId=1, Url="/images/shop/1.jpg"},
                new ProductImage{ ProductId=2, Url="/images/shop/2.jpg"},
                new ProductImage{ ProductId=3, Url="/images/shop/3.jpg"},
                new ProductImage{ ProductId=4, Url="/images/shop/13.jpg"},
                new ProductImage{ ProductId=5, Url="/images/shop/15.jpg"},
                new ProductImage{ ProductId=6, Url="/images/shop/6.jpg"},
                new ProductImage{ ProductId=7, Url="/images/shop/7.jpg"},
                new ProductImage{ ProductId=8, Url="/images/shop/8.jpg"},
                new ProductImage{ ProductId=9, Url="/images/shop/9.jpg"},
                new ProductImage{ ProductId=10,Url="/images/shop/10.jpg"},
                new ProductImage{ ProductId=11,Url="/images/shop/11.jpg"},
                new ProductImage{ ProductId=12,Url="/images/shop/12.jpg"},
            };
            db.ProductImage.AddRange(productImages);
            db.SaveChanges();
        }

    }
}
