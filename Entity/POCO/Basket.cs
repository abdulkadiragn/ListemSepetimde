using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
   public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int Count { get; set; }
    }
}
