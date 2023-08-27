using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    [Column("id_cli")]
    public int IdCli { get; set; }

    [Column("nome_cli")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomeCli { get; set; } = null!;

    [Column("morada_cli")]
    [StringLength(1000)]
    [Unicode(false)]
    [DisplayName("Morada")]
    public string MoradaCli { get; set; } = null!;

    [Column("estado_cli")]
    public bool EstadoCli { get; set; }

    [InverseProperty("IdCliNavigation")]
    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();

    [ForeignKey("IdCli")]
    [InverseProperty("Cliente")]
    public virtual Utilizador IdCliNavigation { get; set; }

    [ForeignKey("IdCli")]
    [InverseProperty("IdClis")]
    public virtual ICollection<Categorium> IdCats { get; } = new List<Categorium>();
}
