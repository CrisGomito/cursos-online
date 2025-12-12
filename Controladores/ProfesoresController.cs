
using Cursos_Online.Modelos;
using Cursos_Online.Config;

namespace Cursos_Online.Controladores
{
    public class ProfesoresController
    {
        private readonly CursoOnlineContext _context = new CursoOnlineContext();

        public List<Profesore> ObtenerProfesores()
        {
            return _context.Profesores
                .Where(p => p.Estado == true)
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public Profesore ObtenerProfesorPorId(int id)
        {
            return _context.Profesores
                .Where(p => p.Estado == true)
                .FirstOrDefault(p => p.ProfesorId == id);
        }

        public bool AgregarProfesor(Profesore profesor)
        {
            try
            {
                _context.Profesores.Add(profesor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarProfesores(Profesore profesor)
        {
            try
            {
                var prof = _context.Profesores.Find(profesor.ProfesorId);
                if (prof != null)
                {
                    prof.Nombre = profesor.Nombre;
                    prof.Apellido = profesor.Apellido;
                    prof.Email = profesor.Email;
                    prof.Telefono = profesor.Telefono;
                    prof.Direccion = profesor.Direccion;
                    //no tocamos fecha de creacion ni id
                    prof.Estado = profesor.Estado;
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
        public bool EliminarProfesor(int id)
        {
            try
            {
                var prof = _context.Profesores.Find(id);
                if (prof != null)
                {
                    prof.Estado = false;
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
            return _context.Profesores.Any(p => p.Email == email && p.Estado == true);
        }
    }
}
