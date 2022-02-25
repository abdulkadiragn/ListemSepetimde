using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
   public class AppUser : IdentityUser<int>
    {
        public string Adress { get; set; }

        public virtual ICollection<Basket>  Baskets { get; set; }
       

    }
}
