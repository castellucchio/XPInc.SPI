using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ValidationErrorException(string message, IEnumerable<string> errors) : base(message)
        {
            Message = message;
            Errors = errors;
        }
    }
}
