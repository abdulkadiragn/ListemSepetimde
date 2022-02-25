using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı zorunlu Alandır!")]
        public string UserName { get; set; }
        ///
        [Required(ErrorMessage = "Email zorunlu Alandır!")] //kayıt ol'a tıkladıktan sonra email'de hata varsa gösterir
        [EmailAddress(ErrorMessage ="Email Adresiniz geçerli bir Email adresi olmalıdır!")] //yazarken @ işaretini arıyor
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        ///
        [Required(ErrorMessage = "Şifre zorunlu Alandır!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        ///
        [Required(ErrorMessage = "Şifre Tekrar zorunlu Alandır!")] //required ile zorunlu kıldık
        [DataType(DataType.Password)]
        [Compare("Password")] //şifre ile uyuşması için
        public string PasswordConfirm { get; set; }

    }
}
