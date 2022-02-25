using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.Constant
{
    public static class ExceptionToInnest
    {
        //recorsive metodlar - kendini çağırabilen metodlar (kulanılması çok tavsiye edilmez. Bütün işlemleri ram'de yaptığı için dikkatli kullan.)
        public static Exception ToInnest(this Exception exception)
        {
            if (exception.InnerException!=null)
            {
                return exception.InnerException.ToInnest(); //Ex içinde innerEx varsa yukarı gönder Ana Ex bulana kadar devam et
            }
            return exception;
        }
    }
}
