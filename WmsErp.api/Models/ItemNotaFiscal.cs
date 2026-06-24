using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ItemNotaFiscal
{
    public int IdItemNotaFiscal { get; set; }

    public int NumeroItem { get; set; }

    public int? IdNotaFiscal { get; set; }

    public int? IdProduto { get; set; }

    public int Quantidade { get; set; }

    public decimal ValorUnitario { get; set; }

    public string? Cst { get; set; }

    public decimal? AliquotaIpi { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? AliquotaIbs { get; set; }

    public decimal? AliquotaCbs { get; set; }

    public decimal? AliquotaIcms { get; set; }

    public decimal? ValorIbs { get; set; }

    public decimal? ValorCbs { get; set; }

    public decimal? ValorIcms { get; set; }

    public virtual ICollection<ConferenciaItemCheckin> ConferenciaItemCheckins { get; set; } = new List<ConferenciaItemCheckin>();

    public virtual ICollection<EtiquetaGuardum> EtiquetaGuarda { get; set; } = new List<EtiquetaGuardum>();

    public virtual NotasFiscai? IdNotaFiscalNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
