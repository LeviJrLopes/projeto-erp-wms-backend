using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class UsuarioPerfil
{
    public int IdUsuarioPerfil { get; set; }

    public int IdUsuario { get; set; }

    public int IdPerfil { get; set; }

    public virtual Perfi IdPerfilNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
