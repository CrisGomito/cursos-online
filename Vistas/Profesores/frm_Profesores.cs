
using Cursos_Online.Modelos;
using Cursos_Online.Controladores;

namespace Cursos_Online.Vistas.Profesores
{
    public partial class frm_Profesores : Form
    {
        private readonly ProfesoresController _controller = new ProfesoresController();
        private int profesorId_editar = 0;

        public frm_Profesores()
        {
            InitializeComponent();
        }

        private void frm_Profesores_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            var lista = _controller.ObtenerProfesores();
            lst_Profesores.DataSource = lista;
            lst_Profesores.DisplayMember = "NombreCompleto"; //no se mapea en la DB
            lst_Profesores.ValueMember = "ProfesorId";
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ActivarCampos();
            profesorId_editar = 0;
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
            lst_Profesores.Enabled = false;
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
            lst_Profesores.Enabled = true;
            btn_Guardar.Enabled = false;
            btn_Cancelar.Enabled = false;
            profesorId_editar = 0;
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

            var profesor = new Profesore
            {
                Nombre = txt_Nombre.Text.Trim(),
                Apellido = txt_Apellido.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                Telefono = txt_Telefono.Text.Trim(),
                Direccion = txt_Direccion.Text.Trim(),
                Estado = true
            };

            bool resultado;
            if (profesorId_editar != 0)
            {
                profesor.ProfesorId = profesorId_editar;
                resultado = _controller.ActualizarProfesores(profesor);
            }
            else
            {
                resultado = _controller.AgregarProfesor(profesor);
            }

            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito.", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Error al guardar. Revise la operación.", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Profesores.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un profesor para editar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarUno(1);
        }

        private void lst_Profesores_DoubleClick(object sender, EventArgs e)
        {
            CargarUno(0);
        }

        private void CargarUno(int opcion)
        {
            var id = (int)lst_Profesores.SelectedValue;
            var prof = _controller.ObtenerProfesorPorId(id);
            if (prof == null)
            {
                MessageBox.Show("Profesor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txt_Nombre.Text = prof.Nombre;
            txt_Apellido.Text = prof.Apellido;
            txt_Email.Text = prof.Email;
            txt_Telefono.Text = prof.Telefono;
            txt_Direccion.Text = prof.Direccion;

            if (opcion == 1)
            {
                profesorId_editar = prof.ProfesorId;
                ActivarCampos();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Profesores.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un profesor para eliminar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = (int)lst_Profesores.SelectedValue;
            var confirm = MessageBox.Show("¿Está seguro de eliminar este profesor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var ok = _controller.EliminarProfesor(id);
                if (ok)
                {
                    MessageBox.Show("Profesor eliminado.", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar.", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Profesores_Load_1(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
