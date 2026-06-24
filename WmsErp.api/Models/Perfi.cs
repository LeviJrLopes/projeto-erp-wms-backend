using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Perfi
{
    public int IdPerfil { get; set; }

    public string Funcao { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; } = new List<UsuarioPerfil>();
}
