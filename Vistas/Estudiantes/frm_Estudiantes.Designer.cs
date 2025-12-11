namespace Cursos_Online.Vistas.Estudiantes
{
    partial class frm_Estudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lst_Estudiantes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelDireccion;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lst_Estudiantes = new ListBox();
            lblTitulo = new Label();
            txt_Nombre = new TextBox();
            txt_Apellido = new TextBox();
            txt_Email = new TextBox();
            txt_Telefono = new TextBox();
            txt_Direccion = new TextBox();
            btn_Nuevo = new Button();
            btn_Guardar = new Button();
            btn_Editar = new Button();
            btn_Cancelar = new Button();
            btn_Eliminar = new Button();
            btn_Salir = new Button();
            labelNombre = new Label();
            labelApellido = new Label();
            labelEmail = new Label();
            labelTelefono = new Label();
            labelDireccion = new Label();
            SuspendLayout();
            // 
            // lst_Estudiantes
            // 
            lst_Estudiantes.FormattingEnabled = true;
            lst_Estudiantes.ItemHeight = 25;
            lst_Estudiantes.Location = new Point(360, 60);
            lst_Estudiantes.Name = "lst_Estudiantes";
            lst_Estudiantes.Size = new Size(340, 379);
            lst_Estudiantes.TabIndex = 0;
            lst_Estudiantes.DoubleClick += lst_Estudiantes_DoubleClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(270, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(253, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE ESTUDIANTES";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new Point(24, 90);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(300, 32);
            txt_Nombre.TabIndex = 2;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Enabled = false;
            txt_Apellido.Location = new Point(24, 160);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(300, 32);
            txt_Apellido.TabIndex = 3;
            // 
            // txt_Email
            // 
            txt_Email.Enabled = false;
            txt_Email.Location = new Point(24, 230);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(300, 32);
            txt_Email.TabIndex = 4;
            txt_Email.Leave += txt_Email_Leave;
            // 
            // txt_Telefono
            // 
            txt_Telefono.Enabled = false;
            txt_Telefono.Location = new Point(24, 300);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(300, 32);
            txt_Telefono.TabIndex = 5;
            // 
            // txt_Direccion
            // 
            txt_Direccion.Enabled = false;
            txt_Direccion.Location = new Point(24, 370);
            txt_Direccion.Name = "txt_Direccion";
            txt_Direccion.Size = new Size(300, 32);
            txt_Direccion.TabIndex = 6;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.Location = new Point(24, 430);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new Size(110, 36);
            btn_Nuevo.TabIndex = 7;
            btn_Nuevo.Text = "Nuevo";
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Enabled = false;
            btn_Guardar.Location = new Point(150, 430);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(110, 36);
            btn_Guardar.TabIndex = 8;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.Location = new Point(360, 460);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(110, 36);
            btn_Editar.TabIndex = 9;
            btn_Editar.Text = "Editar";
            btn_Editar.Click += btn_Editar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Enabled = false;
            btn_Cancelar.Location = new Point(280, 430);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(110, 36);
            btn_Cancelar.TabIndex = 10;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.ForeColor = Color.FromArgb(192, 0, 0);
            btn_Eliminar.Location = new Point(490, 460);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(110, 36);
            btn_Eliminar.TabIndex = 11;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(610, 460);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(90, 36);
            btn_Salir.TabIndex = 12;
            btn_Salir.Text = "Salir";
            btn_Salir.Click += btn_Salir_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(24, 60);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(97, 25);
            labelNombre.TabIndex = 13;
            labelNombre.Text = "Nombres*";
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Location = new Point(24, 130);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(98, 25);
            labelApellido.TabIndex = 14;
            labelApellido.Text = "Apellidos*";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(24, 200);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(177, 25);
            labelEmail.TabIndex = 15;
            labelEmail.Text = "Correo Electrónico*";
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Location = new Point(24, 270);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(84, 25);
            labelTelefono.TabIndex = 16;
            labelTelefono.Text = "Teléfono";
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Location = new Point(24, 340);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(92, 25);
            labelDireccion.TabIndex = 17;
            labelDireccion.Text = "Dirección";
            // 
            // frm_Estudiantes
            // 
            ClientSize = new Size(720, 540);
            Controls.Add(lst_Estudiantes);
            Controls.Add(lblTitulo);
            Controls.Add(txt_Nombre);
            Controls.Add(txt_Apellido);
            Controls.Add(txt_Email);
            Controls.Add(txt_Telefono);
            Controls.Add(txt_Direccion);
            Controls.Add(btn_Nuevo);
            Controls.Add(btn_Guardar);
            Controls.Add(btn_Editar);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Eliminar);
            Controls.Add(btn_Salir);
            Controls.Add(labelNombre);
            Controls.Add(labelApellido);
            Controls.Add(labelEmail);
            Controls.Add(labelTelefono);
            Controls.Add(labelDireccion);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_Estudiantes";
            Text = "Gestión de Estudiantes";
            Load += frm_Estudiantes_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}