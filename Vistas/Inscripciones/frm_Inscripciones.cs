
using Cursos_Online.Controladores;
using Cursos_Online.Modelos;
using Cursos_Online.Vistas.Reportes;
using System.Data;

namespace Cursos_Online.Vistas.Inscripciones
{
    public partial class frm_Inscripciones : Form
    {
        private readonly InscripcionesController _insController = new InscripcionesController();
        private readonly EstudiantesController _estController = new EstudiantesController();
        private readonly CursosController _cursoController = new CursosController();

        public frm_Inscripciones()
        {
            InitializeComponent();
        }

        private void frm_Inscripciones_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarLista();
        }

        private void CargarCombos()
        {
            var estudiantes = _estController.ObtenerEstudiantes();
            cmb_Estudiante.DataSource = estudiantes;
            cmb_Estudiante.DisplayMember = "NombreCompleto";
            cmb_Estudiante.ValueMember = "EstudianteId";
            cmb_Estudiante.SelectedIndex = -1;

            var cursos = _cursoController.ObtenerCursos();
            cmb_Curso.DataSource = cursos;
            cmb_Curso.DisplayMember = "Titulo";
            cmb_Curso.ValueMember = "CursoId";
            cmb_Curso.SelectedIndex = -1;
        }

        private void CargarLista()
        {
            var list = _insController.ObtenerInscripciones();
            lst_Inscripciones.DataSource = list.Select(i => new
            {
                Texto = $"{i.Estudiante.Nombre} {i.Estudiante.Apellido} -> {i.Curso.Titulo} ({i.Estado})",
                Id = i.InscripcionId
            }).ToList();
            lst_Inscripciones.DisplayMember = "Texto";
            lst_Inscripciones.ValueMember = "Id";
        }

        private void btn_Inscribir_Click(object sender, EventArgs e)
        {
            if (cmb_Estudiante.SelectedIndex == -1 || cmb_Curso.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione estudiante y curso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var estudianteId = (int)cmb_Estudiante.SelectedValue;
            var cursoId = (int)cmb_Curso.SelectedValue;

            //en controlador ya hay lógica de validación
            var nueva = new Inscripcione
            {
                EstudianteId = estudianteId,
                CursoId = cursoId,
                Estado = "Inscripto"
            };

            var resultado = _insController.AgregarInscripcion(nueva);
            if (resultado)
            {
                MessageBox.Show("Inscripción registrada.", "Inscripciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
            }
            else
            {
                MessageBox.Show("No se pudo inscribir (posible: duplicado / curso completo / alumno o curso inactivo).", "Inscripciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CancelarInscripcion_Click(object sender, EventArgs e)
        {
            if (lst_Inscripciones.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una inscripción para cancelar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var inscripcionId = (int)((dynamic)lst_Inscripciones.SelectedValue);
            var confirm = MessageBox.Show("¿Confirmar cancelar la inscripción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var ok = _insController.EliminarInscripcion(inscripcionId); // marca como Cancelado
                if (ok)
                {
                    MessageBox.Show("Inscripción cancelada.", "Inscripciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al cancelar inscripción.", "Inscripciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Refrescar_Click(object sender, EventArgs e)
        {
            CargarCombos();
            CargarLista();
        }

        private void lst_Inscripciones_DoubleClick(object sender, EventArgs e)
        {
            //muestra detalles simples
            if (lst_Inscripciones.SelectedItem == null) return;
            var id = (int)((dynamic)lst_Inscripciones.SelectedValue);
            var ins = _insController.ObtenerInscripcionPorId(id);
            if (ins != null)
            {
                MessageBox.Show($"Estudiante: {ins.Estudiante.NombreCompleto}\nCurso: {ins.Curso.Titulo}\nFecha: {ins.FechaInscripcion}\nEstado: {ins.Estado}",
                    "Detalle Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Inscripciones_Load_1(object sender, EventArgs e)
        {
            CargarCombos();
            CargarLista();
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            Reporte_CursosPorEstudiante reporte = new Reporte_CursosPorEstudiante();
            reporte.ShowDialog();
        }
    }
}
