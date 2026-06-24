using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Financeiro
{
    public int IdFinanceiro { get; set; }

    public string Tipo { get; set; } = null!;

    public int? IdCliente { get; set; }

    public int? IdFornecedor { get; set; }

    public int IdNotaFiscal { get; set; }

    public decimal ValorTotal { get; set; }

    public DateOnly? DataEmissao { get; set; }

    public string Status { get; set; } = null!;

    public string? Observacao { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Fornecedore? IdFornecedorNavigation { get; set; }

    public virtual NotasFiscai IdNotaFiscalNavigation { get; set; } = null!;

    public virtual ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();
}
