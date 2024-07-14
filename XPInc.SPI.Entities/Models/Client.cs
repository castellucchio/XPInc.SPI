using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Entities.Models
{
    /// <summary>
    /// Representa os investidores no sistema. Os clientes podem comprar, vender e acompanhar seus investimentos.
    /// </summary>
    public class Client
    {
        public int Id { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Documento: CPF ou CNPJ
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Dados bancários do cliente
        /// </summary>
        public BankAccount Account { get; set; }
    }
}
