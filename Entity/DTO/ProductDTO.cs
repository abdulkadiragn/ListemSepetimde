using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; } //çekilen verinin idsini tut
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } //çekilecek ürünün imageUrl'i
        public string CategoryName { get; set; } //çekilecek ürünün category adı (ürün altına yazacagız.)
        public decimal BasketCount { get; set; }
    }
}
