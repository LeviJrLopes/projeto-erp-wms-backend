using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class EtiquetaGuardum
{
    public int IdEtiquetaGuarda { get; set; }

    public int IdFornecedor { get; set; }

    public int IdItemNotaFiscal { get; set; }

    public int IdEnderecoEstoque { get; set; }

    public int IdUsuario { get; set; }

    public int QuantidadeConferida { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public DateTime? DataImpressao { get; set; }

    public virtual EnderecoEstoque IdEnderecoEstoqueNavigation { get; set; } = null!;

    public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;

    public virtual ItemNotaFiscal IdItemNotaFiscalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
