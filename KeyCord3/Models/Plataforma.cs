using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Plataforma")]
public partial class Plataforma
{
    [Key]
    [Column("id_plat")]
    public int IdPlat { get; set; }

    [Column("nome_plat")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomePlat { get; set; } = null!;

    [Column("desc_plat")]
    [StringLength(1000)]
    [Unicode(false)]
    [DisplayName("Descrição")]
    public string DescPlat { get; set; } = null!;

    [InverseProperty("IdPlatNavigation")]
    public virtual ICollection<Jogo> Jogos { get; } = new List<Jogo>();
}
