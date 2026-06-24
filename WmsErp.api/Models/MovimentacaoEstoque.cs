using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class MovimentacaoEstoque
{
    public int IdMovimentacao { get; set; }

    public int IdProduto { get; set; }

    public int? IdEnderecoOrigem { get; set; }

    public int? IdEnderecoDestino { get; set; }

    public string TipoOperacao { get; set; } = null!;

    public int Quantidade { get; set; }

    public string? Origem { get; set; }

    public DateTime? DataMovimentacao { get; set; }

    public virtual EnderecoEstoque? IdEnderecoDestinoNavigation { get; set; }

    public virtual EnderecoEstoque? IdEnderecoOrigemNavigation { get; set; }

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
