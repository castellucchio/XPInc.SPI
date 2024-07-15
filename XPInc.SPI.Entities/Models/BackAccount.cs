using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int BankAccountId { get; set; }
        /// <summary>
        /// Número de agência do cliente
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// Número da conta do cliente
        /// </summary>
        public string Account { get; set; }

        public Client Client { get; set; }
    }
}
