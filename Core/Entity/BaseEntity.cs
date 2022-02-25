using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public interface IBaseEntity
    {

    }

    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            //bunları kendimiz vermememiz için yapıyoruz.
            Active = true;
            Deleted = false;
            Created = DateTime.Now;
            Updated = DateTime.Now;

        }
        public int Id { get; set; }
        public bool Active { get; set; }//ürün kullanımda True //geçici devre dışı False //ürün kalktı Fasle
        public bool Deleted { get; set; }//ürün kullanımda False //geçici devre dışı False //ürün kalktı True
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
