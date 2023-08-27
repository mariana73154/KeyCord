using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[PrimaryKey("IdJogo", "IdCli")]
[Table("Compra")]
public partial class Compra
{
    [Key]
    [Column("id_jogo")]
    public int IdJogo { get; set; }

    [Key]
    [Column("id_cli")]
    public int IdCli { get; set; }

    [Column("data_compra", TypeName = "datetime")]
    public DateTime DataCompra { get; set; }

    [Column("preco_compra")]
    public int PrecoCompra { get; set; }

    [ForeignKey("IdCli")]
    [InverseProperty("Compras")]
    public virtual Cliente IdCliNavigation { get; set; } = null!;

    [ForeignKey("IdJogo")]
    [InverseProperty("Compras")]
    public virtual Jogo IdJogoNavigation { get; set; } = null!;
}
