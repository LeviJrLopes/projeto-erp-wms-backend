using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Parcela
{
    public int IdParcela { get; set; }

    public int IdFinanceiro { get; set; }

    public int NumeroParcela { get; set; }

    public decimal ValorParcela { get; set; }

    public decimal ValorPago { get; set; }

    public decimal? Juros { get; set; }

    public decimal? Multa { get; set; }

    public decimal? Desconto { get; set; }

    public DateOnly DataVencimento { get; set; }

    public DateOnly? DataPagamento { get; set; }

    public string? StatusParcela { get; set; }

    public string? FormaPagamento { get; set; }

    public virtual Financeiro IdFinanceiroNavigation { get; set; } = null!;
}
