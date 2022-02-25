using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.Constant
{
    public class EntityResult
    {
        public object Message { get; }
        public EntityResultType ResultType { get; }
        public EntityResult(object Message ,EntityResultType resultType=EntityResultType.Success) //opsiyonel parametreler en sonda olmak zorunda.
        {
            this.Message = Message;
            ResultType = resultType;
        }

      
    }
    public class EntityResult<T> : EntityResult
    {
        public T Data { get; }

        public EntityResult(T data, object Message, EntityResultType resultType = EntityResultType.Success) :base(Message, resultType)
        {
            Data = data;
        }

    }
}
