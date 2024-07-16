using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.Exceptions
{
    public class InsuficientProductsException : Exception
    {
        public string Message {  get; set; }

        public InsuficientProductsException(string message) : base(message)
        {
            Message = message;
        }
    }
}
