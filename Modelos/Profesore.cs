using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cursos_Online.Modelos;

[Table("profesores")]
[Index("Email", Name = "ux_profesores_email", IsUnique = true)]
public partial class Profesore
{
    [Key]
    [Column("profesor_id", TypeName = "int(11)")]
    public int ProfesorId { get; set; }

    [Required]
    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [Column("apellido")]
    [StringLength(100)]
    public string Apellido { get; set; }

    [Required]
    [Column("email")]
    [StringLength(150)]
    public string Email { get; set; }

    [Column("telefono")]
    [StringLength(30)]
    public string Telefono { get; set; }

    [Column("direccion")]
    [StringLength(255)]
    public string Direccion { get; set; }

    /// <summary>
    /// 1=Activo,0=Inactivo (eliminación lógica)
    /// </summary>
    [Required]
    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("fecha_actualizacion", TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; }

    [InverseProperty("Profesor")]
    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    [NotMapped]
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
