using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.CustomValidation
{
    public class ErrorDiscAccount : IdentityErrorDescriber //identity ile kayıt olma işlemleri kontrol
    {
        public override IdentityError PasswordRequiresLower()
        {
            var error = new IdentityError();
            error.Code = "";
            error.Description = " Şifre'de Küçük harf zorunludur";
            return error;
        }
    }
}
