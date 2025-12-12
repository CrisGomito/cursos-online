
using Cursos_Online.Config;
using Cursos_Online.Modelos;

namespace Cursos_Online.Controladores
{
    public class EstudiantesController
    {
        private readonly CursoOnlineContext _context = new CursoOnlineContext();

        public List<Estudiante> ObtenerEstudiantes()
        {
            return _context.Estudiantes
                .Where(e => e.Estado == true)
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public Estudiante ObtenerEstudiantePorId(int id)
        {
            return _context.Estudiantes
                .Where(e => e.Estado == true)
                .FirstOrDefault(e => e.EstudianteId == id);
        }

        public bool AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                var est = _context.Estudiantes.Find(estudiante.EstudianteId);
                if (est != null)
                {
                    est.Nombre = estudiante.Nombre;
                    est.Apellido = estudiante.Apellido;
                    est.Email = estudiante.Email;
                    est.Telefono = estudiante.Telefono;
                    est.Direccion = estudiante.Direccion;
                    est.Estado = estudiante.Estado;
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
        public bool EliminarEstudiante(int id)
        {
            try
            {
                var est = _context.Estudiantes.Find(id);
                if (est != null)
                {
                    est.Estado = false;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EmailExiste(string email)
        {
            return _context.Estudiantes.Any(e => e.Email == email && e.Estado == true);
        }
    }
}
