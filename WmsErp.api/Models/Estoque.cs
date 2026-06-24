using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Estoque
{
    public int IdEstoque { get; set; }

    public int IdProduto { get; set; }

    public int IdEnderecoEstoque { get; set; }

    public int QuantidadeAtual { get; set; }

    public int? QuantidadeReservada { get; set; }

    public virtual EnderecoEstoque IdEnderecoEstoqueNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
