using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Entities.Models
{
    /// <summary>
    /// Representa os dados bancários do cliente
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Número de agência do cliente
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// Número da conta do cliente
        /// </summary>
        public string Account { get; set; }
    }
}
