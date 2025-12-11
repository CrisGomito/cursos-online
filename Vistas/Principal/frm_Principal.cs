
using Cursos_Online.Vistas.Profesores;
using Cursos_Online.Vistas.Estudiantes;
using Cursos_Online.Vistas.Cursos;
using Cursos_Online.Vistas.Inscripciones;

namespace DataBase_First.Views.Main
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Reloj.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Cursos frm = new frm_Cursos();
            frm.Show();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Estudiantes frm = new frm_Estudiantes();
            frm.Show();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Inscripciones frm = new frm_Inscripciones();
            frm.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Profesores frm = new frm_Profesores();
            frm.Show();
        }
    }
}
