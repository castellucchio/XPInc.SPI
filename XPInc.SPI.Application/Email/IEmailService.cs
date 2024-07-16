using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync();
    }
}
