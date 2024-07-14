using XPInc.SPI.Entities.Enum;

namespace XPInc.SPI.Entities.Models;

/// <summary>
/// Representa um ativo financeiro disponível para investimento.
/// </summary>
public class FinantialProduct
{
    public int Id { get; set; }
    /// <summary>
    /// O nome do produto (por exemplo, “Ação da Empresa X” ou “Título ABC”). 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Informações adicionais sobre o produto. 
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// O tipo de produto (ações, títulos, fundos)
    /// </summary>
    public FinantialProductType Type { get; set; }

    /// <summary>
    /// O valor atual do produto no mercado. 
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Se aplicável (para títulos, por exemplo).
    /// </summary>
    public DateTime? ExpireDate { get; set; }

}

