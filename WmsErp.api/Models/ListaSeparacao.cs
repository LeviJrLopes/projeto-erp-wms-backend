using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ListaSeparacao
{
    public int IdListaSeparacao { get; set; }

    public int? IdPedido { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DataGeracao { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public string Separador { get; set; } = null!;

    public string? Prioridade { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
