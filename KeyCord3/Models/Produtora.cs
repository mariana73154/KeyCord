using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Produtora")]
public partial class Produtora
{
    [Key]
    [Column("id_prod")]
    public int IdProd { get; set; }

    [Column("nome_prod")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomeProd { get; set; } = null!;

    [Column("desc_prod")]
    [StringLength(1000)]
    [Unicode(false)]
    [DisplayName("Descrição")]
    public string DescProd { get; set; } = null!;

    [InverseProperty("IdProdNavigation")]
    public virtual ICollection<Jogo> Jogos { get; } = new List<Jogo>();
}
