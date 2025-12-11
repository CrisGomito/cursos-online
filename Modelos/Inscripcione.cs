using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cursos_Online.Modelos;

[Table("inscripciones")]
[Index("CursoId", Name = "ix_inscripciones_curso_id")]
[Index("EstudianteId", Name = "ix_inscripciones_estudiante_id")]
[Index("EstudianteId", "CursoId", Name = "ux_inscripciones_estudiante_curso", IsUnique = true)]
public partial class Inscripcione
{
    [Key]
    [Column("inscripcion_id", TypeName = "int(11)")]
    public int InscripcionId { get; set; }

    [Column("estudiante_id", TypeName = "int(11)")]
    public int EstudianteId { get; set; }

    [Column("curso_id", TypeName = "int(11)")]
    public int CursoId { get; set; }

    [Column("fecha_inscripcion", TypeName = "datetime")]
    public DateTime FechaInscripcion { get; set; }

    [Required]
    [Column("estado", TypeName = "enum('Inscripto','Cancelado','Completado')")]
    public string Estado { get; set; }

    /// <summary>
    /// Calificación final (opcional)
    /// </summary>
    [Column("nota")]
    [Precision(5, 2)]
    public decimal? Nota { get; set; }

    [Column("fecha_actualizacion", TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; }

    [ForeignKey("CursoId")]
    [InverseProperty("Inscripciones")]
    public virtual Curso Curso { get; set; }

    [ForeignKey("EstudianteId")]
    [InverseProperty("Inscripciones")]
    public virtual Estudiante Estudiante { get; set; }
}
