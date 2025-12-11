using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cursos_Online.Modelos;

[Table("cursos")]
[Index("ProfesorId", Name = "ix_cursos_profesor_id")]
[Index("Codigo", Name = "ux_cursos_codigo", IsUnique = true)]
public partial class Curso
{
    [Key]
    [Column("curso_id", TypeName = "int(11)")]
    public int CursoId { get; set; }

    [Required]
    [Column("titulo")]
    [StringLength(200)]
    public string Titulo { get; set; }

    [Required]
    [Column("codigo")]
    [StringLength(50)]
    public string Codigo { get; set; }

    [Column("descripcion", TypeName = "text")]
    public string Descripcion { get; set; }

    [Column("fecha_inicio", TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column("fecha_fin", TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    /// <summary>
    /// Cantidad máxima de estudiantes (NULL = sin límite)
    /// </summary>
    [Column("capacidad", TypeName = "int(11)")]
    public int? Capacidad { get; set; }

    [Column("precio")]
    [Precision(10, 2)]
    public decimal? Precio { get; set; }

    [Column("profesor_id", TypeName = "int(11)")]
    public int? ProfesorId { get; set; }

    /// <summary>
    /// 1=Activo,0=Inactivo
    /// </summary>
    [Required]
    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("fecha_actualizacion", TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; }

    [InverseProperty("Curso")]
    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    [ForeignKey("ProfesorId")]
    [InverseProperty("Cursos")]
    public virtual Profesore Profesor { get; set; }
}
