using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class ProductImage : BaseEntity
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } //çok burda olması lazım ama productId ile yakaladığımız için satır satır database'de yapacak
    }
}
