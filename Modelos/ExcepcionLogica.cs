using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class ExcepcionLogica : Exception
    {
        public ExcepcionLogica(string message) : base(message)
        {
        }
    }
}
