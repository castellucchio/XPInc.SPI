using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;

namespace XPInc.SPI.Entities.Models
{
    /// <summary>
    /// Representa transações de compra e venda para fins de auditoria. 
    /// </summary>
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Referência ao produto financeiro envolvido na transação
        /// </summary>
        /// 
        
        public int FinantialProductId { get; set; }
        public FinantialProduct FinancialProduct { get; set; }

        public int ClientId { get; set; }
        /// <summary>
        /// Referencia o cliente que realizou a transação
        /// </summary>
        public Client Client { get; set; }
        /// <summary>
        /// Valor da transação (positivo para compra, negativo para venda)
        /// </summary>
        public decimal Amount { get; set; } // 
        /// <summary>
        /// Tipo de transação: Compra ou Venda
        /// </summary>
        public TransactionType Type { get; set; }
        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// Descrição opcional da transação (por exemplo, detalhes adicionais)
        /// </summary>
        public string Description { get; set; }
    }
}
