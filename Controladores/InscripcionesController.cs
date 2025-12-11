
using Cursos_Online.Config;
using Cursos_Online.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Cursos_Online.Controladores
{
    public class InscripcionesController
    {
        private readonly CursoOnlineContext _context = new CursoOnlineContext();

        public List<Inscripcione> ObtenerInscripciones()
        {
            return _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .OrderByDescending(i => i.FechaInscripcion)
                .ToList();
        }

        public Inscripcione ObtenerInscripcionPorId(int id)
        {
            return _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .FirstOrDefault(i => i.InscripcionId == id);
        }

        public bool AgregarInscripcion(Inscripcione ins)
        {
            try
            {
                // Validaciones de negocio:
                // 1) estudiante y curso activos
                var estudiante = _context.Estudiantes.Find(ins.EstudianteId);
                var curso = _context.Cursos.Find(ins.CursoId);
                if (estudiante == null || estudiante.Estado == false) return false;
                if (curso == null || curso.Estado == false) return false;

                // 2) evitar duplicados (unique enforced en BD, pero validamos antes)
                if (InscripcionExiste(ins.EstudianteId, ins.CursoId)) return false;

                // 3) verificar capacidad si está definida
                if (curso.Capacidad.HasValue)
                {
                    var inscritos = _context.Inscripciones.Count(i => i.CursoId == ins.CursoId && i.Estado != "Cancelado");
                    if (inscritos >= curso.Capacidad.Value) return false;
                }

                _context.Inscripciones.Add(ins);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarInscripcion(Inscripcione ins)
        {
            try
            {
                var existente = _context.Inscripciones.Find(ins.InscripcionId);
                if (existente != null)
                {
                    // solo actualizamos campos permitidos
                    existente.Estado = ins.Estado;
                    existente.Nota = ins.Nota;
                    existente.FechaActualizacion = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Eliminación lógica: marcar como Cancelado
        public bool EliminarInscripcion(int id)
        {
            try
            {
                var ins = _context.Inscripciones.Find(id);
                if (ins != null)
                {
                    ins.Estado = "Cancelado";
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InscripcionExiste(int estudianteId, int cursoId)
        {
            return _context.Inscripciones.Any(i => i.EstudianteId == estudianteId && i.CursoId == cursoId && i.Estado != "Cancelado");
        }

        /// <summary>
        /// Para el reporte: inscripciones por estudiante (activos)
        /// </summary>
        public List<Inscripcione> ObtenerInscripcionesPorEstudiante(int estudianteId)
        {
            return _context.Inscripciones
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .Where(i => i.EstudianteId == estudianteId && i.Estado != "Cancelado")
                .OrderByDescending(i => i.FechaInscripcion)
                .ToList();
        }
    }
}
