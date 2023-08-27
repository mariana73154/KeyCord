using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Models;

[Table("Funcionario")]
[Index("PhoneFunc", Name = "UQ__Funciona__F7C545202352A5F1", IsUnique = true)]
public partial class Funcionario
{
    [Key]
    [Column("id_func")]
    public int IdFunc { get; set; }

    [Column("nome_Func")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Nome")]
    public string NomeFunc { get; set; } = null!;

    [Column("phone_Func")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Número de Telemóvel")]
    public string PhoneFunc { get; set; } = null!;

    [Column("id_add")]
    public int IdAdd { get; set; }

    [ForeignKey("IdAdd")]
    [InverseProperty("Funcionario")]
    public virtual Admini IdAddNavigation { get; set; } = null!;

    [ForeignKey("IdFunc")]
    [InverseProperty("Funcionario")]
    public virtual Utilizador IdFuncNavigation { get; set; } = null!;

    [InverseProperty("IdFuncNavigation")]
    public virtual Jogo? Jogo { get; set; }
}
