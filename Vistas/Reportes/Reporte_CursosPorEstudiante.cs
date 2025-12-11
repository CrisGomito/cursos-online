
using Cursos_Online.Controladores;
using Cursos_Online.Modelos;
using Microsoft.Reporting.WinForms;

namespace Cursos_Online.Vistas.Reportes
{
    public partial class Reporte_CursosPorEstudiante : Form
    {
        private readonly ReportViewer _reportViewer;
        private readonly InscripcionesController _insController = new InscripcionesController();
        // DTO que coincide con las columnas del DataTable en DS_CursosPorEstudiante.xsd
        private class CursosPorEstudianteDto
        {
            public int EstudianteId { get; set; }
            public string EstudianteNombre { get; set; }
            public int CursoId { get; set; }
            public string NombreCurso { get; set; }
            public DateTime FechaInscripcion { get; set; }
        }
        // Constructor: muestra todas las inscripciones (por defecto)
        public Reporte_CursosPorEstudiante() : this(null) { }

        public Reporte_CursosPorEstudiante(int? estudianteId)
        {
            InitializeComponent();


            _reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill,
                ProcessingMode = ProcessingMode.Local
            };

            this.Controls.Add(_reportViewer);

            // Ajusta la ruta si tu RDLC está en otra carpeta. Tú dijiste "Reportes".
            var rdlcPath = Path.Combine(AppContext.BaseDirectory, "Vistas", "Reportes", "Reporte_CursosPorEstudiante.rdlc");
            if (!File.Exists(rdlcPath))
            {
                // intenta buscar dentro de la carpeta bin\Debug\netX... (solo por resiliencia)
                rdlcPath = Path.Combine(AppContext.BaseDirectory, "Vistas", "Reportes", "Reporte_CursosPorEstudiante.rdlc");
            }

            _reportViewer.LocalReport.ReportPath = rdlcPath;

            // Obtener las inscripciones desde el controller
            List<Inscripcione> inscripciones;
            if (estudianteId.HasValue)
            {
                // llama al método que ya existe en tu controller
                inscripciones = _insController.ObtenerInscripcionesPorEstudiante(estudianteId.Value);
            }
            else
            {
                // método que devuelve todas las inscripciones (con Include de estudiante y curso)
                inscripciones = _insController.ObtenerInscripciones();
            }

            // Mapear a DTO que coincide con las columnas del DataTable en el XSD
            var listaDto = inscripciones
                .Where(i => i.Estudiante != null && i.Curso != null) // seguridad
                .Select(i => new CursosPorEstudianteDto
                {
                    EstudianteId = i.EstudianteId,
                    EstudianteNombre = $"{i.Estudiante.Nombre} {i.Estudiante.Apellido}",
                    CursoId = i.CursoId,
                    NombreCurso = (i.Curso.Titulo ?? i.Curso.Codigo ?? "—").ToString(),
                    FechaInscripcion = i.FechaInscripcion
                })
                .ToList();

            // Asegúrate de que el nombre "DS_CursosPorEstudiante" coincide con el DataSource del RDLC
            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DS_CursosPorEstudiante", listaDto));

            _reportViewer.RefreshReport();
        }
    }
}
