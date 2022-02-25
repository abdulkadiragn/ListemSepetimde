using Entity.POCO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Areas.Admin.Data
{
    public class ProductDto //product'dan gelen uzantılar değil dosyanın kendisi lazım olduğu için burayı oluşturduk (Entity'de bulunan product uzantı olarak verdigi için kullanamadık.)
    {
        [Required (ErrorMessage ="Ürün Adı girmek zorunludur")] //name zorunlu olması için
        [Display(Name = "Ürün İsmi")] //UI için property ismi olarak gözükmesin bu gözüksün.
        public string Name { get; set; }
        [Required (ErrorMessage ="Ürün fiyatı belirlemek zorunludur")] //decimal zaten zorunludur(decimal? degilse) zaten eror mesajı türkce yapmak için yaptık.
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Ürün stoğu belirlemek zorunludur!")] //int zaten zorunludur(int? degilse) zaten eror mesajı türkce yapmak için yaptık.
        [Display(Name = "Ürün Stoğu")]
        public int Stock { get; set; }
        [Required(ErrorMessage ="Ürüne ait en az 1 resim girmek zorunludur.")]
        [Display(Name="Ürün Resmi")]
        public List<IFormFile> Images  { get; set; }
        [Display(Name = "Ürün kategorisi")]

        public int[] Categories { get; set; } //eklenen ürünün idsini eklemesi için.
    }
}
