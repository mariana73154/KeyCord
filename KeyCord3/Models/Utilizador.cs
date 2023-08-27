using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Utilizador")]
[Index("UserUt", Name = "UQ__Utilizad__B9B11AFD7F1EF4A9", IsUnique = true)]
public partial class Utilizador
{
    [Key]
    [Column("id_ut")]
    public int IdUt { get; set; }

    [Column("user_ut")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Username")]
    public string UserUt { get; set; } = null!;

    [Column("foto_ut")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Foto")]
    public string? FotoUt { get; set; }

    [Column("id_AspNet")]
    [StringLength(50)]
    [Unicode(false)]
    public string IdAspNet { get; set; } = null!;

    [InverseProperty("IdAdminNavigation")]
    public virtual Admini? Admini { get; set; }

    [InverseProperty("IdCliNavigation")]
    public virtual Cliente? Cliente { get; set; }

    [InverseProperty("IdFuncNavigation")]
    public virtual Funcionario? Funcionario { get; set; }
}
