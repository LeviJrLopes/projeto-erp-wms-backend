using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Descricao { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string? Sku { get; set; }

    public string? CodigoInterno { get; set; }

    public string? Ncm { get; set; }

    public string? CodigoBarras { get; set; }

    public DateTime? DataCriacao { get; set; }

    public decimal? PesoUn { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; } = new List<ItemNotaFiscal>();

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

    public virtual ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = new List<MovimentacaoEstoque>();
}
