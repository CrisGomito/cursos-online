
using Cursos_Online.Controladores;
using Cursos_Online.Modelos;

namespace Cursos_Online.Vistas.Estudiantes
{
    public partial class frm_Estudiantes : Form
    {
        private readonly EstudiantesController _controller = new EstudiantesController();
        private int estudianteId_editar = 0;

        public frm_Estudiantes()
        {
            InitializeComponent();
        }

        private void frm_Estudiantes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            var lista = _controller.ObtenerEstudiantes();
            lst_Estudiantes.DataSource = lista;
            lst_Estudiantes.DisplayMember = "NombreCompleto";
            lst_Estudiantes.ValueMember = "EstudianteId";
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ActivarCampos();
            estudianteId_editar = 0;
        }

        private void ActivarCampos()
        {
            txt_Nombre.Enabled = true;
            txt_Apellido.Enabled = true;
            txt_Email.Enabled = true;
            txt_Telefono.Enabled = true;
            txt_Direccion.Enabled = true;

            btn_Nuevo.Enabled = false;
            btn_Editar.Enabled = false;
            lst_Estudiantes.Enabled = false;
            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txt_Nombre.Text = "";
            txt_Apellido.Text = "";
            txt_Email.Text = "";
            txt_Telefono.Text = "";
            txt_Direccion.Text = "";

            txt_Nombre.Enabled = false;
            txt_Apellido.Enabled = false;
            txt_Email.Enabled = false;
            txt_Telefono.Enabled = false;
            txt_Direccion.Enabled = false;

            btn_Nuevo.Enabled = true;
            btn_Editar.Enabled = true;
            lst_Estudiantes.Enabled = true;
            btn_Guardar.Enabled = false;
            btn_Cancelar.Enabled = false;
            estudianteId_editar = 0;
        }

        private bool VerificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) ||
                string.IsNullOrWhiteSpace(txt_Apellido.Text) ||
                string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!txt_Email.Text.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Email.Focus();
                return false;
            }
            return true;
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Email.Text)) return;
            if (_controller.EmailExiste(txt_Email.Text))
            {
                MessageBox.Show("El correo ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Email.Text = "";
                txt_Email.Focus();
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos()) return;

            var estudiante = new Estudiante
            {
                Nombre = txt_Nombre.Text.Trim(),
                Apellido = txt_Apellido.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                Telefono = txt_Telefono.Text.Trim(),
                Direccion = txt_Direccion.Text.Trim(),
                Estado = true
            };

            bool resultado;
            if (estudianteId_editar != 0)
            {
                estudiante.EstudianteId = estudianteId_editar;
                resultado = _controller.ActualizarEstudiante(estudiante);
            }
            else
            {
                resultado = _controller.AgregarEstudiante(estudiante);
            }

            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito.", "Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Error al guardar. Revise la operación.", "Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Estudiantes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estudiante para editar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarUno(1);
        }

        private void lst_Estudiantes_DoubleClick(object sender, EventArgs e)
        {
            CargarUno(0);
        }

        private void CargarUno(int opcion)
        {
            var id = (int)lst_Estudiantes.SelectedValue;
            var est = _controller.ObtenerEstudiantePorId(id);
            if (est == null)
            {
                MessageBox.Show("Estudiante no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txt_Nombre.Text = est.Nombre;
            txt_Apellido.Text = est.Apellido;
            txt_Email.Text = est.Email;
            txt_Telefono.Text = est.Telefono;
            txt_Direccion.Text = est.Direccion;

            if (opcion == 1)
            {
                estudianteId_editar = est.EstudianteId;
                ActivarCampos();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Estudiantes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estudiante para eliminar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = (int)lst_Estudiantes.SelectedValue;
            var confirm = MessageBox.Show("¿Está seguro de eliminar este estudiante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var ok = _controller.EliminarEstudiante(id);
                if (ok)
                {
                    MessageBox.Show("Estudiante eliminado.", "Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar.", "Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Estudiantes_Load_1(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
