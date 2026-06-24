using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class EtiquetaVolume
{
    public int IdEtiquetaVolume { get; set; }

    public int IdNotaFiscal { get; set; }

    public int IdTransportador { get; set; }

    public int IdUsuario { get; set; }

    public int NumeroVolume { get; set; }

    public int TotalVolume { get; set; }

    public decimal? Peso { get; set; }

    public string CodBarras { get; set; } = null!;

    public DateTime? DataImpressao { get; set; }

    public virtual NotasFiscai IdNotaFiscalNavigation { get; set; } = null!;

    public virtual Transportadore IdTransportadorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
