using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class EtiquetasModelo
{
    public int IdEtiquetasModelos { get; set; }

    public string? NomeModelo { get; set; }

    public string? Linguagem { get; set; }

    public string? Layout { get; set; }

    public virtual ICollection<ContagemImpresso> ContagemImpressos { get; set; } = new List<ContagemImpresso>();
}
