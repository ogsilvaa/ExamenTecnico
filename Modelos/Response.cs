using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Response<T>
    {
        public Response(T result, int status)
        {
            Status = status;
            Result = result;
        }
        public int Status { get; set; }
        public T Result { get; set; }
    }
}
