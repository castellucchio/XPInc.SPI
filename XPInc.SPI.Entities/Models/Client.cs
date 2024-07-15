﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Entities.Models
{
    /// <summary>
    /// Representa os investidores no sistema. Os clientes podem comprar, vender e acompanhar seus investimentos.
    /// </summary>
    [Table("Clients")]
    public class Client
    {
        public int ClientId { get; set; }
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
        
        public string Account { get; set; }
        public string BranchNumber { get; set; }
    }
}
