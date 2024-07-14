using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Entities.Enum
{
    /// <summary>
    /// O tipo de produto: ações(Stock), títulos(Bond), fundos(Fund)
    /// </summary>
    public enum FinantialProductType
    {
        /// <summary>
        /// Ações(Stock)
        /// </summary>
        Stock = 1,
        /// <summary>
        /// Títulos(Bond)
        /// </summary>
        Bond,
        /// <summary>
        /// Fundos(Fund)
        /// </summary>
        Fund
    }
}
}
