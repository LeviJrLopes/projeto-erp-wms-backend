using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class EnderecoEstoque
{
    public int IdEnderecoEstoque { get; set; }

    public string Rua { get; set; } = null!;

    public string Vertical { get; set; } = null!;

    public string Andar { get; set; } = null!;

    public string Posicao { get; set; } = null!;

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual EtiquetaEndereco? EtiquetaEndereco { get; set; }

    public virtual ICollection<EtiquetaGuardum> EtiquetaGuarda { get; set; } = new List<EtiquetaGuardum>();

    public virtual ICollection<MovimentacaoEstoque> MovimentacaoEstoqueIdEnderecoDestinoNavigations { get; set; } = new List<MovimentacaoEstoque>();

    public virtual ICollection<MovimentacaoEstoque> MovimentacaoEstoqueIdEnderecoOrigemNavigations { get; set; } = new List<MovimentacaoEstoque>();
}
