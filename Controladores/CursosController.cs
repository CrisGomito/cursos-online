
using Cursos_Online.Config;
using Cursos_Online.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Cursos_Online.Controladores
{
    public class CursosController
    {
        private readonly CursoOnlineContext _context = new CursoOnlineContext();

        public List<Curso> ObtenerCursos()
        {
            return _context.Cursos
                .Where(c => c.Estado == true)
                .Include(c => c.Profesor) //incluye info del profe
                .OrderBy(c => c.Titulo)
                .ToList();
        }

        public Curso ObtenerCursoPorId(int id)
        {
            return _context.Cursos
                .Where(c => c.Estado == true)
                .Include(c => c.Profesor)
                .FirstOrDefault(c => c.CursoId == id);
        }

        public bool AgregarCurso(Curso curso)
        {
            try
            {
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarCurso(Curso curso)
        {
            try
            {
                var c = _context.Cursos.Find(curso.CursoId);
                if (c != null)
                {
                    c.Titulo = curso.Titulo;
                    c.Codigo = curso.Codigo;
                    c.Descripcion = curso.Descripcion;
                    c.FechaInicio = curso.FechaInicio;
                    c.FechaFin = curso.FechaFin;
                    c.Capacidad = curso.Capacidad;
                    c.Precio = curso.Precio;
                    c.ProfesorId = curso.ProfesorId;
                    c.Estado = curso.Estado;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //eliminación lógica
        public bool EliminarCurso(int id)
        {
            try
            {
                var curso = _context.Cursos.Find(id);
                if (curso != null)
                {
                    curso.Estado = false;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CodigoExiste(string codigo)
        {
            return _context.Cursos.Any(c => c.Codigo == codigo && c.Estado == true);
        }

        /// <summary>
        /// Cuenta inscripciones activas (no canceladas) para el curso
        /// </summary>
        public int ContarInscritos(int cursoId)
        {
            return _context.Inscripciones
                .Count(i => i.CursoId == cursoId && i.Estado != "Cancelado");
        }
    }
}
