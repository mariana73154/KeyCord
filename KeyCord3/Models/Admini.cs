using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Admini")]
public partial class Admini
{
    [Key]
    [Column("id_admin")]
    public int IdAdmin { get; set; }

    [Column("id_criador")]
    public int IdCriador { get; set; }

    [InverseProperty("IdAddNavigation")]
    public virtual Funcionario? Funcionario { get; set; }

    [ForeignKey("IdAdmin")]
    [InverseProperty("Admini")]
    public virtual Utilizador IdAdminNavigation { get; set; } = null!;

    [ForeignKey("IdCriador")]
    [InverseProperty("InverseIdCriadorNavigation")]
    public virtual Admini IdCriadorNavigation { get; set; } = null!;

    [InverseProperty("IdCriadorNavigation")]
    public virtual ICollection<Admini> InverseIdCriadorNavigation { get; } = new List<Admini>();
}
