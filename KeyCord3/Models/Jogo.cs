using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Jogo")]
[Index("IdFunc", Name = "UQ__Jogo__61295648A0143B6C", IsUnique = true)]
public partial class Jogo
{
    [Key]
    [Column("id_jogo")]
    public int IdJogo { get; set; }

    [Column("nome_jogo")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomeJogo { get; set; } = null!;

    [Column("preco_jogo")]
    [DisplayName("Preço")]
    public int PrecoJogo { get; set; } = 0;

    [Column("desconto")]
    [Unicode(false)]
    [DisplayName("Desconto")]
    public int Desconto { get; set; } = 0;

    [Column("desc_jogo")]
    [DisplayName("Descrição")]
    public string DescJogo { get; set; } = null!;

    [Column("ano_public")]
    [DisplayName("Ano de publicação")]
    public int AnoPublic { get; set; } = 0;

    [Column("foto_jogo")]
    [StringLength(250)]
    [Unicode(false)]
    [DisplayName("Foto")]
    public string FotoJogo { get; set; } = null!;

    [Column("id_cat")]
    [DisplayName("Categoria")]
    public int IdCat { get; set; }

    [Column("id_prod")]
    [DisplayName("Produtora")]
    public int IdProd { get; set; }

    [Column("id_plat")]
    [DisplayName("Plataforma")]
    public int IdPlat { get; set; }

    [Column("id_func")]
    public int IdFunc { get; set; }

    [Column("data_edicao", TypeName = "datetime")]
    [DisplayName("Data da última edição")]
    public DateTime DataEdicao { get; set; }

    [InverseProperty("IdJogoNavigation")]
    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();

    [ForeignKey("IdCat")]
    [InverseProperty("Jogos")]
    public virtual Categorium IdCatNavigation { get; set; } = null!;

    [ForeignKey("IdFunc")]
    [InverseProperty("Jogo")]
    public virtual Funcionario IdFuncNavigation { get; set; } = null!;

    [ForeignKey("IdPlat")]
    [InverseProperty("Jogos")]
    public virtual Plataforma IdPlatNavigation { get; set; } = null!;

    [ForeignKey("IdProd")]
    [InverseProperty("Jogos")]
    public virtual Produtora IdProdNavigation { get; set; } = null!;
}
