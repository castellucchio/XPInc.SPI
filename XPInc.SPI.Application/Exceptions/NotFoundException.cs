using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        private string _message { get; }

        public NotFoundException(string message) : base(message)
        {
            _message = message;
        }
    }
}
