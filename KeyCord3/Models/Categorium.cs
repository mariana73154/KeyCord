using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

public partial class Categorium
{
    [Key]
    [Column("id_cat")]
    public int IdCat { get; set; }

    [Column("nome_cat")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomeCat { get; set; } = null!;

    [Column("desc_cat")]
    [StringLength(1000)]
    [Unicode(false)]
    [DisplayName("Descrição")]
    public string DescCat { get; set; } = null!;

    [InverseProperty("IdCatNavigation")]
    public virtual ICollection<Jogo> Jogos { get; } = new List<Jogo>();

    [ForeignKey("IdCat")]
    [InverseProperty("IdCats")]
    public virtual ICollection<Cliente> IdClis { get; } = new List<Cliente>();
}
