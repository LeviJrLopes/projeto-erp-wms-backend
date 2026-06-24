using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string SenhaHash { get; set; } = null!;

    public bool? Ativo { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? DataCriacao { get; set; }

    public DateTime? UltimoLogin { get; set; }

    public int? TentativasLogin { get; set; }

    public virtual ICollection<ContagemImpresso> ContagemImpressos { get; set; } = new List<ContagemImpresso>();

    public virtual ICollection<EtiquetaEndereco> EtiquetaEnderecos { get; set; } = new List<EtiquetaEndereco>();

    public virtual ICollection<EtiquetaGuardum> EtiquetaGuarda { get; set; } = new List<EtiquetaGuardum>();

    public virtual ICollection<EtiquetaVolume> EtiquetaVolumes { get; set; } = new List<EtiquetaVolume>();

    public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; } = new List<UsuarioPerfil>();
}
