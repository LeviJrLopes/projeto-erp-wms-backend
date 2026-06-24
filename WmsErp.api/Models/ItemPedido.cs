using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ItemPedido
{
    public int IdItemPedido { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public virtual ICollection<ConferenciaItemCheckout> ConferenciaItemCheckouts { get; set; } = new List<ConferenciaItemCheckout>();

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
