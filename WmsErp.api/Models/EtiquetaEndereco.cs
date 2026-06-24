using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class EtiquetaEndereco
{
    public int IdEtiquetaEndereco { get; set; }

    public int IdEnderecoEstoque { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public int IdUsuario { get; set; }

    public DateTime? DataImpressao { get; set; }

    public virtual EnderecoEstoque IdEnderecoEstoqueNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
