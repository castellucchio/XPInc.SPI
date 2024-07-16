using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.Exceptions
{
    public class InsuficientCashException : Exception
    {
        public string Message { get; set; }

        public InsuficientCashException(string message) : base(message)
        {
            Message = message;
        }
    }
}
