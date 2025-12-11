
using Cursos_Online.Controladores;
using Cursos_Online.Modelos;
using System.Globalization;

namespace Cursos_Online.Vistas.Cursos
{
    public partial class frm_Cursos : Form
    {
        private readonly CursosController _controller = new CursosController();
        private readonly ProfesoresController _profController = new ProfesoresController();
        private int cursoId_editar = 0;

        public frm_Cursos()
        {
            InitializeComponent();
        }

        private void frm_Cursos_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarProfesores();
        }

        private void CargarLista()
        {
            var lista = _controller.ObtenerCursos();
            lst_Cursos.DataSource = lista;
            lst_Cursos.DisplayMember = "Titulo";
            lst_Cursos.ValueMember = "CursoId";
        }

        private void CargarProfesores()
        {
            var profesores = _profController.ObtenerProfesores();
            cmb_Profesor.DataSource = profesores;
            cmb_Profesor.DisplayMember = "NombreCompleto";
            cmb_Profesor.ValueMember = "ProfesorId";
            cmb_Profesor.SelectedIndex = -1;
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ActivarCampos();
            cursoId_editar = 0;
            txt_Precio.Text = "0.00";
            nud_Capacidad.Value = 0;
        }

        private void ActivarCampos()
        {
            txt_Titulo.Enabled = true;
            txt_Codigo.Enabled = true;
            txt_Descripcion.Enabled = true;
            dtp_FechaInicio.Enabled = true;
            dtp_FechaFin.Enabled = true;
            nud_Capacidad.Enabled = true;
            txt_Precio.Enabled = true;
            cmb_Profesor.Enabled = true;

            btn_Nuevo.Enabled = false;
            btn_Editar.Enabled = false;
            lst_Cursos.Enabled = false;
            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txt_Titulo.Text = "";
            txt_Codigo.Text = "";
            txt_Descripcion.Text = "";
            dtp_FechaInicio.Value = DateTime.Now;
            dtp_FechaFin.Value = DateTime.Now;
            nud_Capacidad.Value = 0;
            txt_Precio.Text = "";
            cmb_Profesor.SelectedIndex = -1;

            txt_Titulo.Enabled = false;
            txt_Codigo.Enabled = false;
            txt_Descripcion.Enabled = false;
            dtp_FechaInicio.Enabled = false;
            dtp_FechaFin.Enabled = false;
            nud_Capacidad.Enabled = false;
            txt_Precio.Enabled = false;
            cmb_Profesor.Enabled = false;

            btn_Nuevo.Enabled = true;
            btn_Editar.Enabled = true;
            lst_Cursos.Enabled = true;
            btn_Guardar.Enabled = false;
            btn_Cancelar.Enabled = false;
            cursoId_editar = 0;
        }

        private bool VerificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Titulo.Text) ||
                string.IsNullOrWhiteSpace(txt_Codigo.Text))
            {
                MessageBox.Show("Complete los campos obligatorios (Título, Código).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // validar código único si es nuevo
            if (cursoId_editar == 0 && _controller.CodigoExiste(txt_Codigo.Text.Trim()))
            {
                MessageBox.Show("El código ya existe. Ingrese uno diferente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Codigo.Focus();
                return false;
            }
            decimal precioParsed;
            if (!decimal.TryParse(txt_Precio.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precioParsed))
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Precio.Focus();
                return false;
            }
            return true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos()) return;

            int? profesorId = null;
            if (cmb_Profesor.SelectedIndex != -1)
                profesorId = (int)cmb_Profesor.SelectedValue;

            var curso = new Curso
            {
                Titulo = txt_Titulo.Text.Trim(),
                Codigo = txt_Codigo.Text.Trim(),
                Descripcion = txt_Descripcion.Text.Trim(),
                FechaInicio = dtp_FechaInicio.Value,
                FechaFin = dtp_FechaFin.Value,
                Capacidad = (nud_Capacidad.Value == 0) ? (int?)null : (int)nud_Capacidad.Value,
                Precio = decimal.Parse(txt_Precio.Text, CultureInfo.InvariantCulture),
                ProfesorId = profesorId,
                Estado = true
            };

            bool resultado;
            if (cursoId_editar != 0)
            {
                curso.CursoId = cursoId_editar;
                resultado = _controller.ActualizarCurso(curso);
            }
            else
            {
                resultado = _controller.AgregarCurso(curso);
            }

            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito.", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Error al guardar el curso.", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Cursos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un curso para editar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarUno(1);
        }

        private void lst_Cursos_DoubleClick(object sender, EventArgs e)
        {
            CargarUno(0);
        }

        private void CargarUno(int opcion)
        {
            var id = (int)lst_Cursos.SelectedValue;
            var curso = _controller.ObtenerCursoPorId(id);
            if (curso == null)
            {
                MessageBox.Show("Curso no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txt_Titulo.Text = curso.Titulo;
            txt_Codigo.Text = curso.Codigo;
            txt_Descripcion.Text = curso.Descripcion ?? "";
            dtp_FechaInicio.Value = curso.FechaInicio ?? DateTime.Now;
            dtp_FechaFin.Value = curso.FechaFin ?? DateTime.Now;
            nud_Capacidad.Value = curso.Capacidad ?? 0;
            //txt_Precio.Text = curso.Precio.ToString("0.00", CultureInfo.InvariantCulture);
            txt_Precio.Text = curso.Precio?.ToString("0.00", CultureInfo.InvariantCulture) ?? "0.00";
            if (curso.Profesor != null)
            {
                cmb_Profesor.SelectedValue = curso.ProfesorId;
            }
            else
            {
                cmb_Profesor.SelectedIndex = -1;
            }

            if (opcion == 1)
            {
                cursoId_editar = curso.CursoId;
                ActivarCampos();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Cursos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un curso para eliminar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = (int)lst_Cursos.SelectedValue;
            var confirm = MessageBox.Show("¿Está seguro de eliminar este curso? (Eliminación lógica)", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var ok = _controller.EliminarCurso(id);
                if (ok)
                {
                    MessageBox.Show("Curso eliminado.", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar.", "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Cursos_Load_1(object sender, EventArgs e)
        {
            CargarLista();
            CargarProfesores();
        }
    }
}
