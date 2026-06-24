using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public int IdTransportador { get; set; }

    public string Status { get; set; } = null!;

    public decimal ValorTotal { get; set; }

    public DateTime? DataCriacao { get; set; }

    public DateTime? DataFechamento { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Transportadore IdTransportadorNavigation { get; set; } = null!;

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

    public virtual ListaSeparacao? ListaSeparacao { get; set; }

    public virtual ICollection<NotasFiscai> NotasFiscais { get; set; } = new List<NotasFiscai>();
}
