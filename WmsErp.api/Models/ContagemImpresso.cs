using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class ContagemImpresso
{
    public int IdContagemImpressoes { get; set; }

    public int IdModeloEtiquetas { get; set; }

    public int IdUsuario { get; set; }

    public int Quantidade { get; set; }

    public DateTime DataImpressao { get; set; }

    public virtual EtiquetasModelo IdModeloEtiquetasNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
