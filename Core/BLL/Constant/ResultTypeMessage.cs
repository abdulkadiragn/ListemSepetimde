using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.Constant
{
    public static class ResultTypeMessage
    {
        public static string Add()
        {
            return "Ekleme Gerçekleşti.";
        }
        public static string Warning()
        {
            return "Bir hata ile karşılaşıldı";
        }
        public static string Error(Exception ex)
        {
            return "Beklenmedik Hata : " + ex.ToInnest().Message;
        }
    }
}
