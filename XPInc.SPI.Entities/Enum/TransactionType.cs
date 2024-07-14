using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Entities.Enum
{
    /// <summary>
    /// Representa uma operação feita por clientes (Compra, venda)
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Compra
        /// </summary>
        Buy = 1,
        /// <summary>
        /// Venda
        /// </summary>
        Sell
    }
}
