using System;
using System.Collections.Generic;

namespace wmserp.api.Models;

public partial class Fornecedore
{
    public int IdFornecedor { get; set; }

    public string NomeRazao { get; set; } = null!;

    public string CpfCnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public string? Cep { get; set; }

    public DateTime? DataCriacao { get; set; }

    public string? InscricaoEstado { get; set; }

    public virtual ICollection<EtiquetaGuardum> EtiquetaGuarda { get; set; } = new List<EtiquetaGuardum>();

    public virtual ICollection<Financeiro> Financeiros { get; set; } = new List<Financeiro>();

    public virtual ICollection<NotasFiscai> NotasFiscais { get; set; } = new List<NotasFiscai>();
}
