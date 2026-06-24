using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ConferenciaItemCheckout
{
    public int IdConferenciaItemCheckout { get; set; }

    public int IdItemPedido { get; set; }

    public int QuantidadeConferida { get; set; }

    public string StatusConferencia { get; set; } = null!;

    public DateTime? DataConferencia { get; set; }

    public string Conferente { get; set; } = null!;

    public virtual ItemPedido IdItemPedidoNavigation { get; set; } = null!;
}
