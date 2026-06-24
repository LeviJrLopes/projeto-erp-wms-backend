using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace wmserp.api.Models;

public partial class SistemaWmsComErpContext : DbContext
{
    public SistemaWmsComErpContext()
    {
    }

    public SistemaWmsComErpContext(DbContextOptions<SistemaWmsComErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConferenciaItemCheckin> ConferenciaItemCheckins { get; set; }

    public virtual DbSet<ConferenciaItemCheckout> ConferenciaItemCheckouts { get; set; }

    public virtual DbSet<ContagemImpresso> ContagemImpressoes { get; set; }

    public virtual DbSet<EnderecoEstoque> EnderecoEstoques { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<EtiquetaEndereco> EtiquetaEnderecos { get; set; }

    public virtual DbSet<EtiquetaGuardum> EtiquetaGuarda { get; set; }

    public virtual DbSet<EtiquetaVolume> EtiquetaVolumes { get; set; }

    public virtual DbSet<EtiquetasModelo> EtiquetasModelos { get; set; }

    public virtual DbSet<Financeiro> Financeiros { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<ItemNotaFiscal> ItemNotaFiscals { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<ListaSeparacao> ListaSeparacaos { get; set; }

    public virtual DbSet<MovimentacaoEstoque> MovimentacaoEstoques { get; set; }

    public virtual DbSet<NotasFiscai> NotasFiscais { get; set; }

    public virtual DbSet<Parcela> Parcelas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Perfi> Perfis { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Transportadore> Transportadores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sistema_wms_com_erp;Username=postgres;Password=984603");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");

            entity.ToTable("clientes", "erp");

            entity.HasIndex(e => e.CpfCnpj, "clientes_cpf_cnpj_key").IsUnique();

            entity.HasIndex(e => e.Email, "clientes_email_key").IsUnique();

            entity.Property(e => e.IdCliente)
                .HasDefaultValueSql("nextval('erp.clientes_id_seq'::regclass)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(14)
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.InscricaoEstado)
                .HasMaxLength(10)
                .HasColumnName("inscricao_estado");
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(100)
                .HasColumnName("nome_razao");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(200)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("uf");
        });

        modelBuilder.Entity<ConferenciaItemCheckin>(entity =>
        {
            entity.HasKey(e => e.IdConferenciaItemCheckin).HasName("conferencia_item_checkin_pkey");

            entity.ToTable("conferencia_item_checkin", "wms");

            entity.Property(e => e.IdConferenciaItemCheckin).HasColumnName("id_conferencia_item_checkin");
            entity.Property(e => e.Conferente)
                .HasMaxLength(100)
                .HasColumnName("conferente");
            entity.Property(e => e.DataConferencia)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_conferencia");
            entity.Property(e => e.DataValidade).HasColumnName("data_validade");
            entity.Property(e => e.IdItemNotaFiscal).HasColumnName("id_item_nota_fiscal");
            entity.Property(e => e.QuantidadeConferida).HasColumnName("quantidade_conferida");
            entity.Property(e => e.StatusConferencia)
                .HasMaxLength(10)
                .HasColumnName("status_conferencia");

            entity.HasOne(d => d.IdItemNotaFiscalNavigation).WithMany(p => p.ConferenciaItemCheckins)
                .HasForeignKey(d => d.IdItemNotaFiscal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_nota_fiscal");
        });

        modelBuilder.Entity<ConferenciaItemCheckout>(entity =>
        {
            entity.HasKey(e => e.IdConferenciaItemCheckout).HasName("conferencia_item_checkout_pkey");

            entity.ToTable("conferencia_item_checkout", "wms");

            entity.Property(e => e.IdConferenciaItemCheckout).HasColumnName("id_conferencia_item_checkout");
            entity.Property(e => e.Conferente)
                .HasMaxLength(100)
                .HasColumnName("conferente");
            entity.Property(e => e.DataConferencia)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_conferencia");
            entity.Property(e => e.IdItemPedido).HasColumnName("id_item_pedido");
            entity.Property(e => e.QuantidadeConferida).HasColumnName("quantidade_conferida");
            entity.Property(e => e.StatusConferencia)
                .HasMaxLength(15)
                .HasColumnName("status_conferencia");

            entity.HasOne(d => d.IdItemPedidoNavigation).WithMany(p => p.ConferenciaItemCheckouts)
                .HasForeignKey(d => d.IdItemPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_pedido");
        });

        modelBuilder.Entity<ContagemImpresso>(entity =>
        {
            entity.HasKey(e => e.IdContagemImpressoes).HasName("contagem_impressoes_pkey");

            entity.ToTable("contagem_impressoes", "etiquetas");

            entity.Property(e => e.IdContagemImpressoes).HasColumnName("id_contagem_impressoes");
            entity.Property(e => e.DataImpressao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_impressao");
            entity.Property(e => e.IdModeloEtiquetas).HasColumnName("id_modelo_etiquetas");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.IdModeloEtiquetasNavigation).WithMany(p => p.ContagemImpressos)
                .HasForeignKey(d => d.IdModeloEtiquetas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_modelo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ContagemImpressos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<EnderecoEstoque>(entity =>
        {
            entity.HasKey(e => e.IdEnderecoEstoque).HasName("endereco_estoque_pkey");

            entity.ToTable("endereco_estoque", "wms");

            entity.HasIndex(e => new { e.Rua, e.Vertical, e.Andar, e.Posicao }, "unique_endereco").IsUnique();

            entity.Property(e => e.IdEnderecoEstoque).HasColumnName("id_endereco_estoque");
            entity.Property(e => e.Andar)
                .HasMaxLength(5)
                .HasColumnName("andar");
            entity.Property(e => e.Posicao)
                .HasMaxLength(5)
                .HasColumnName("posicao");
            entity.Property(e => e.Rua)
                .HasMaxLength(5)
                .HasColumnName("rua");
            entity.Property(e => e.Vertical)
                .HasMaxLength(5)
                .HasColumnName("vertical");
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.IdEstoque).HasName("estoque_pkey");

            entity.ToTable("estoque", "wms");

            entity.HasIndex(e => new { e.IdProduto, e.IdEnderecoEstoque }, "unique_estoque").IsUnique();

            entity.Property(e => e.IdEstoque).HasColumnName("id_estoque");
            entity.Property(e => e.IdEnderecoEstoque).HasColumnName("id_endereco_estoque");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.QuantidadeAtual).HasColumnName("quantidade_atual");
            entity.Property(e => e.QuantidadeReservada)
                .HasDefaultValue(0)
                .HasColumnName("quantidade_reservada");

            entity.HasOne(d => d.IdEnderecoEstoqueNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.IdEnderecoEstoque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_estoque");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto");
        });

        modelBuilder.Entity<EtiquetaEndereco>(entity =>
        {
            entity.HasKey(e => e.IdEtiquetaEndereco).HasName("etiqueta_endereco_pkey");

            entity.ToTable("etiqueta_endereco", "etiquetas");

            entity.HasIndex(e => e.CodigoBarras, "etiqueta_endereco_codigo_barras_key").IsUnique();

            entity.HasIndex(e => e.IdEnderecoEstoque, "unique_endereco").IsUnique();

            entity.Property(e => e.IdEtiquetaEndereco).HasColumnName("id_etiqueta_endereco");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(100)
                .HasColumnName("codigo_barras");
            entity.Property(e => e.DataImpressao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_impressao");
            entity.Property(e => e.IdEnderecoEstoque).HasColumnName("id_endereco_estoque");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdEnderecoEstoqueNavigation).WithOne(p => p.EtiquetaEndereco)
                .HasForeignKey<EtiquetaEndereco>(d => d.IdEnderecoEstoque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_estoque");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EtiquetaEnderecos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<EtiquetaGuardum>(entity =>
        {
            entity.HasKey(e => e.IdEtiquetaGuarda).HasName("etiqueta_guarda_pkey");

            entity.ToTable("etiqueta_guarda", "etiquetas");

            entity.HasIndex(e => e.CodigoBarras, "etiqueta_guarda_codigo_barras_key").IsUnique();

            entity.HasIndex(e => new { e.IdItemNotaFiscal, e.IdEnderecoEstoque }, "unique_etiquetas_duplicidade").IsUnique();

            entity.Property(e => e.IdEtiquetaGuarda).HasColumnName("id_etiqueta_guarda");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(100)
                .HasColumnName("codigo_barras");
            entity.Property(e => e.DataImpressao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_impressao");
            entity.Property(e => e.IdEnderecoEstoque).HasColumnName("id_endereco_estoque");
            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");
            entity.Property(e => e.IdItemNotaFiscal).HasColumnName("id_item_nota_fiscal");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.QuantidadeConferida).HasColumnName("quantidade_conferida");

            entity.HasOne(d => d.IdEnderecoEstoqueNavigation).WithMany(p => p.EtiquetaGuarda)
                .HasForeignKey(d => d.IdEnderecoEstoque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_estoque");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.EtiquetaGuarda)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fornecedor");

            entity.HasOne(d => d.IdItemNotaFiscalNavigation).WithMany(p => p.EtiquetaGuarda)
                .HasForeignKey(d => d.IdItemNotaFiscal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_nota_fiscal");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EtiquetaGuarda)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<EtiquetaVolume>(entity =>
        {
            entity.HasKey(e => e.IdEtiquetaVolume).HasName("etiqueta_volume_pkey");

            entity.ToTable("etiqueta_volume", "etiquetas");

            entity.HasIndex(e => e.CodBarras, "etiqueta_volume_cod_barras_key").IsUnique();

            entity.HasIndex(e => new { e.IdNotaFiscal, e.NumeroVolume }, "unique_nf_volume").IsUnique();

            entity.Property(e => e.IdEtiquetaVolume).HasColumnName("id_etiqueta_volume");
            entity.Property(e => e.CodBarras)
                .HasMaxLength(100)
                .HasColumnName("cod_barras");
            entity.Property(e => e.DataImpressao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_impressao");
            entity.Property(e => e.IdNotaFiscal).HasColumnName("id_nota_fiscal");
            entity.Property(e => e.IdTransportador).HasColumnName("id_transportador");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NumeroVolume).HasColumnName("numero_volume");
            entity.Property(e => e.Peso)
                .HasPrecision(10, 2)
                .HasColumnName("peso");
            entity.Property(e => e.TotalVolume).HasColumnName("total_volume");

            entity.HasOne(d => d.IdNotaFiscalNavigation).WithMany(p => p.EtiquetaVolumes)
                .HasForeignKey(d => d.IdNotaFiscal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nota_fiscal");

            entity.HasOne(d => d.IdTransportadorNavigation).WithMany(p => p.EtiquetaVolumes)
                .HasForeignKey(d => d.IdTransportador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transportador");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EtiquetaVolumes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<EtiquetasModelo>(entity =>
        {
            entity.HasKey(e => e.IdEtiquetasModelos).HasName("id_etiquetas_modelos");

            entity.ToTable("etiquetas_modelos", "etiquetas");

            entity.Property(e => e.IdEtiquetasModelos)
                .HasDefaultValueSql("nextval('etiquetas.etiquetas_modelos_id_seq'::regclass)")
                .HasColumnName("id_etiquetas_modelos");
            entity.Property(e => e.Layout).HasColumnName("layout");
            entity.Property(e => e.Linguagem)
                .HasMaxLength(10)
                .HasColumnName("linguagem");
            entity.Property(e => e.NomeModelo)
                .HasMaxLength(100)
                .HasColumnName("nome_modelo");
        });

        modelBuilder.Entity<Financeiro>(entity =>
        {
            entity.HasKey(e => e.IdFinanceiro).HasName("financeiro_pkey");

            entity.ToTable("financeiro", "erp");

            entity.Property(e => e.IdFinanceiro).HasColumnName("id_financeiro");
            entity.Property(e => e.DataEmissao).HasColumnName("data_emissao");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");
            entity.Property(e => e.IdNotaFiscal).HasColumnName("id_nota_fiscal");
            entity.Property(e => e.Observacao).HasColumnName("observacao");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasColumnName("tipo");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(12, 2)
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Financeiros)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("fk_clientes");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Financeiros)
                .HasForeignKey(d => d.IdFornecedor)
                .HasConstraintName("fk_fornecedores");

            entity.HasOne(d => d.IdNotaFiscalNavigation).WithMany(p => p.Financeiros)
                .HasForeignKey(d => d.IdNotaFiscal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_notas_fiscais");
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("fornecedores_pkey");

            entity.ToTable("fornecedores", "erp");

            entity.HasIndex(e => e.CpfCnpj, "fornecedores_cpf_cnpj_key").IsUnique();

            entity.HasIndex(e => e.Email, "fornecedores_email_key").IsUnique();

            entity.Property(e => e.IdFornecedor)
                .HasDefaultValueSql("nextval('erp.fornecedores_id_seq'::regclass)")
                .HasColumnName("id_fornecedor");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(14)
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.InscricaoEstado)
                .HasMaxLength(10)
                .HasColumnName("inscricao_estado");
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(100)
                .HasColumnName("nome_razao");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("uf");
        });

        modelBuilder.Entity<ItemNotaFiscal>(entity =>
        {
            entity.HasKey(e => e.IdItemNotaFiscal).HasName("item_nota_fiscal_pkey");

            entity.ToTable("item_nota_fiscal", "erp");

            entity.HasIndex(e => new { e.IdNotaFiscal, e.NumeroItem }, "unique_item_nota_fiscal").IsUnique();

            entity.Property(e => e.IdItemNotaFiscal).HasColumnName("id_item_nota_fiscal");
            entity.Property(e => e.AliquotaCbs)
                .HasPrecision(5, 2)
                .HasColumnName("aliquota_cbs");
            entity.Property(e => e.AliquotaIbs)
                .HasPrecision(5, 2)
                .HasColumnName("aliquota_ibs");
            entity.Property(e => e.AliquotaIcms)
                .HasPrecision(5, 2)
                .HasColumnName("aliquota_icms");
            entity.Property(e => e.AliquotaIpi)
                .HasPrecision(5, 2)
                .HasColumnName("aliquota_ipi");
            entity.Property(e => e.Cst)
                .HasMaxLength(5)
                .HasColumnName("cst");
            entity.Property(e => e.IdNotaFiscal).HasColumnName("id_nota_fiscal");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.NumeroItem).HasColumnName("numero_item");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.ValorCbs)
                .HasPrecision(12, 2)
                .HasColumnName("valor_cbs");
            entity.Property(e => e.ValorIbs)
                .HasPrecision(12, 2)
                .HasColumnName("valor_ibs");
            entity.Property(e => e.ValorIcms)
                .HasPrecision(12, 2)
                .HasColumnName("valor_icms");
            entity.Property(e => e.ValorIpi)
                .HasPrecision(12, 2)
                .HasColumnName("valor_ipi");
            entity.Property(e => e.ValorUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("valor_unitario");

            entity.HasOne(d => d.IdNotaFiscalNavigation).WithMany(p => p.ItemNotaFiscals)
                .HasForeignKey(d => d.IdNotaFiscal)
                .HasConstraintName("fk_notas_fiscais");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemNotaFiscals)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("fk_produtos");
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("item_pedido_pkey");

            entity.ToTable("item_pedido", "erp");

            entity.HasIndex(e => new { e.IdPedido, e.IdProduto }, "uk_item_pedido").IsUnique();

            entity.HasIndex(e => new { e.IdPedido, e.IdProduto }, "unique_pedido").IsUnique();

            entity.Property(e => e.IdItemPedido).HasColumnName("id_item_pedido");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.PrecoUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("preco_unitario");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedidos");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produtos");
        });

        modelBuilder.Entity<ListaSeparacao>(entity =>
        {
            entity.HasKey(e => e.IdListaSeparacao).HasName("lista_separacao_pkey");

            entity.ToTable("lista_separacao", "wms");

            entity.HasIndex(e => e.IdPedido, "unique_lista_pedido").IsUnique();

            entity.Property(e => e.IdListaSeparacao).HasColumnName("id_lista_separacao");
            entity.Property(e => e.DataFim)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_fim");
            entity.Property(e => e.DataGeracao)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_geracao");
            entity.Property(e => e.DataInicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_inicio");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Prioridade)
                .HasMaxLength(20)
                .HasColumnName("prioridade");
            entity.Property(e => e.Separador)
                .HasMaxLength(50)
                .HasColumnName("separador");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.IdPedidoNavigation).WithOne(p => p.ListaSeparacao)
                .HasForeignKey<ListaSeparacao>(d => d.IdPedido)
                .HasConstraintName("fk_pedido");
        });

        modelBuilder.Entity<MovimentacaoEstoque>(entity =>
        {
            entity.HasKey(e => e.IdMovimentacao).HasName("movimentacao_estoque_pkey");

            entity.ToTable("movimentacao_estoque", "wms");

            entity.Property(e => e.IdMovimentacao).HasColumnName("id_movimentacao");
            entity.Property(e => e.DataMovimentacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_movimentacao");
            entity.Property(e => e.IdEnderecoDestino).HasColumnName("id_endereco_destino");
            entity.Property(e => e.IdEnderecoOrigem).HasColumnName("id_endereco_origem");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.Origem)
                .HasMaxLength(50)
                .HasColumnName("origem");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.TipoOperacao)
                .HasMaxLength(15)
                .HasColumnName("tipo_operacao");

            entity.HasOne(d => d.IdEnderecoDestinoNavigation).WithMany(p => p.MovimentacaoEstoqueIdEnderecoDestinoNavigations)
                .HasForeignKey(d => d.IdEnderecoDestino)
                .HasConstraintName("fk_endereco_destino");

            entity.HasOne(d => d.IdEnderecoOrigemNavigation).WithMany(p => p.MovimentacaoEstoqueIdEnderecoOrigemNavigations)
                .HasForeignKey(d => d.IdEnderecoOrigem)
                .HasConstraintName("fk_endereco_origem");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.MovimentacaoEstoques)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto");
        });

        modelBuilder.Entity<NotasFiscai>(entity =>
        {
            entity.HasKey(e => e.IdNotaFiscal).HasName("notas_fiscais_pkey");

            entity.ToTable("notas_fiscais", "erp");

            entity.HasIndex(e => e.ChaveAcesso, "notas_fiscais_chave_acesso_key").IsUnique();

            entity.HasIndex(e => e.NumeroNotaFiscal, "notas_fiscais_numero_nota_fiscal_key").IsUnique();

            entity.Property(e => e.IdNotaFiscal).HasColumnName("id_nota_fiscal");
            entity.Property(e => e.ChaveAcesso)
                .HasMaxLength(44)
                .HasColumnName("chave_acesso");
            entity.Property(e => e.DataEmissao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_emissao");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdTransportador).HasColumnName("id_transportador");
            entity.Property(e => e.NumeroNotaFiscal)
                .HasMaxLength(20)
                .HasColumnName("numero_nota_fiscal");
            entity.Property(e => e.Serie)
                .HasMaxLength(5)
                .HasColumnName("serie");
            entity.Property(e => e.StatusSefaz)
                .HasMaxLength(15)
                .HasDefaultValueSql("'PENDENTE'::character varying")
                .HasColumnName("status_sefaz");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasColumnName("tipo");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(12, 2)
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("fk_clientes");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdFornecedor)
                .HasConstraintName("fk_fornecedores");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("fk_pedidos");

            entity.HasOne(d => d.IdTransportadorNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdTransportador)
                .HasConstraintName("fk_transportadores");
        });

        modelBuilder.Entity<Parcela>(entity =>
        {
            entity.HasKey(e => e.IdParcela).HasName("parcela_pkey");

            entity.ToTable("parcela", "erp");

            entity.HasIndex(e => new { e.IdFinanceiro, e.NumeroParcela }, "unique_parcela").IsUnique();

            entity.Property(e => e.IdParcela).HasColumnName("id_parcela");
            entity.Property(e => e.DataPagamento).HasColumnName("data_pagamento");
            entity.Property(e => e.DataVencimento).HasColumnName("data_vencimento");
            entity.Property(e => e.Desconto)
                .HasPrecision(12, 2)
                .HasDefaultValue(0m)
                .HasColumnName("desconto");
            entity.Property(e => e.FormaPagamento)
                .HasMaxLength(30)
                .HasColumnName("forma_pagamento");
            entity.Property(e => e.IdFinanceiro).HasColumnName("id_financeiro");
            entity.Property(e => e.Juros)
                .HasPrecision(12, 2)
                .HasDefaultValue(0m)
                .HasColumnName("juros");
            entity.Property(e => e.Multa)
                .HasPrecision(12, 2)
                .HasDefaultValue(0m)
                .HasColumnName("multa");
            entity.Property(e => e.NumeroParcela).HasColumnName("numero_parcela");
            entity.Property(e => e.StatusParcela)
                .HasMaxLength(20)
                .HasColumnName("status_parcela");
            entity.Property(e => e.ValorPago)
                .HasPrecision(12, 2)
                .HasColumnName("valor_pago");
            entity.Property(e => e.ValorParcela)
                .HasPrecision(12, 2)
                .HasColumnName("valor_parcela");

            entity.HasOne(d => d.IdFinanceiroNavigation).WithMany(p => p.Parcelas)
                .HasForeignKey(d => d.IdFinanceiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_financeiro");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("pedidos_pkey");

            entity.ToTable("pedidos", "erp");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.DataFechamento)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_fechamento");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdTransportador).HasColumnName("id_transportador");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(12, 2)
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente");

            entity.HasOne(d => d.IdTransportadorNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdTransportador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transportadores");
        });

        modelBuilder.Entity<Perfi>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("perfis_pkey");

            entity.ToTable("perfis", "auth");

            entity.HasIndex(e => e.Funcao, "perfis_funcao_key").IsUnique();

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.Funcao)
                .HasMaxLength(50)
                .HasColumnName("funcao");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("produtos_pkey");

            entity.ToTable("produtos", "erp");

            entity.HasIndex(e => e.CodigoBarras, "produtos_codigo_barras_key").IsUnique();

            entity.HasIndex(e => e.CodigoInterno, "produtos_codigo_interno_key").IsUnique();

            entity.HasIndex(e => e.Sku, "produtos_sku_key").IsUnique();

            entity.Property(e => e.IdProduto)
                .HasDefaultValueSql("nextval('erp.produtos_id_seq'::regclass)")
                .HasColumnName("id_produto");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(50)
                .HasColumnName("codigo_barras");
            entity.Property(e => e.CodigoInterno)
                .HasMaxLength(10)
                .HasColumnName("codigo_interno");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .HasColumnName("descricao");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("marca");
            entity.Property(e => e.Ncm)
                .HasMaxLength(10)
                .HasColumnName("ncm");
            entity.Property(e => e.PesoUn)
                .HasPrecision(10, 2)
                .HasColumnName("peso_un");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
        });

        modelBuilder.Entity<Transportadore>(entity =>
        {
            entity.HasKey(e => e.IdTransportador).HasName("transportadores_pkey");

            entity.ToTable("transportadores", "erp");

            entity.HasIndex(e => e.CpfCnpj, "transportadores_cpf_cnpj_key").IsUnique();

            entity.HasIndex(e => e.Email, "transportadores_email_key").IsUnique();

            entity.Property(e => e.IdTransportador)
                .HasDefaultValueSql("nextval('erp.transportadores_id_seq'::regclass)")
                .HasColumnName("id_transportador");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(14)
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.InscricaoEstado)
                .HasMaxLength(10)
                .HasColumnName("inscricao_estado");
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(100)
                .HasColumnName("nome_razao");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Observacao)
                .HasMaxLength(255)
                .HasColumnName("observacao");
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .HasColumnName("tipo");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("uf");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios", "auth");

            entity.HasIndex(e => e.Email, "usuarios_email_key").IsUnique();

            entity.HasIndex(e => e.Login, "usuarios_login_key").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Ativo)
                .HasDefaultValue(true)
                .HasColumnName("ativo");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.SenhaHash)
                .HasMaxLength(100)
                .HasColumnName("senha_hash");
            entity.Property(e => e.TentativasLogin)
                .HasDefaultValue(0)
                .HasColumnName("tentativas_login");
            entity.Property(e => e.UltimoLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimo_login");
        });

        modelBuilder.Entity<UsuarioPerfil>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioPerfil).HasName("usuario_perfil_pkey");

            entity.ToTable("usuario_perfil", "auth");

            entity.HasIndex(e => new { e.IdUsuario, e.IdPerfil }, "unique_usuario_perfil").IsUnique();

            entity.Property(e => e.IdUsuarioPerfil).HasColumnName("id_usuario_perfil");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.UsuarioPerfils)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_perfil");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioPerfils)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
