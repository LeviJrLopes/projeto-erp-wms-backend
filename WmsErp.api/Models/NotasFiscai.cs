using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class NotasFiscai
{
    public int IdNotaFiscal { get; set; }

    public string NumeroNotaFiscal { get; set; } = null!;

    public string? ChaveAcesso { get; set; }

    public string? Serie { get; set; }

    public string? StatusSefaz { get; set; }

    public int? IdPedido { get; set; }

    public int? IdCliente { get; set; }

    public int? IdFornecedor { get; set; }

    public int? IdTransportador { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime DataEmissao { get; set; }

    public decimal ValorTotal { get; set; }

    public virtual ICollection<EtiquetaVolume> EtiquetaVolumes { get; set; } = new List<EtiquetaVolume>();

    public virtual ICollection<Financeiro> Financeiros { get; set; } = new List<Financeiro>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Fornecedore? IdFornecedorNavigation { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual Transportadore? IdTransportadorNavigation { get; set; }

    public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; } = new List<ItemNotaFiscal>();
}
