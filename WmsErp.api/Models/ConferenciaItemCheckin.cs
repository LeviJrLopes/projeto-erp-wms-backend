using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ConferenciaItemCheckin
{
    public int IdConferenciaItemCheckin { get; set; }

    public int IdItemNotaFiscal { get; set; }

    public int QuantidadeConferida { get; set; }

    public DateOnly? DataValidade { get; set; }

    public string StatusConferencia { get; set; } = null!;

    public DateTime? DataConferencia { get; set; }

    public string Conferente { get; set; } = null!;

    public virtual ItemNotaFiscal IdItemNotaFiscalNavigation { get; set; } = null!;
}
