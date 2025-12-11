namespace Cursos_Online.Vistas.Cursos
{
    partial class frm_Cursos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lst_Cursos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txt_Titulo;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.DateTimePicker dtp_FechaInicio;
        private System.Windows.Forms.DateTimePicker dtp_FechaFin;
        private System.Windows.Forms.NumericUpDown nud_Capacidad;
        private System.Windows.Forms.TextBox txt_Precio;
        private System.Windows.Forms.ComboBox cmb_Profesor;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label labelFechas;
        private System.Windows.Forms.Label labelCapacidad;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelProfesor;

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
            lst_Cursos = new ListBox();
            lblTitulo = new Label();
            txt_Titulo = new TextBox();
            txt_Codigo = new TextBox();
            txt_Descripcion = new TextBox();
            dtp_FechaInicio = new DateTimePicker();
            dtp_FechaFin = new DateTimePicker();
            nud_Capacidad = new NumericUpDown();
            txt_Precio = new TextBox();
            cmb_Profesor = new ComboBox();
            btn_Nuevo = new Button();
            btn_Guardar = new Button();
            btn_Editar = new Button();
            btn_Cancelar = new Button();
            btn_Eliminar = new Button();
            btn_Salir = new Button();
            labelTitulo = new Label();
            labelCodigo = new Label();
            labelDescripcion = new Label();
            labelFechas = new Label();
            labelCapacidad = new Label();
            labelPrecio = new Label();
            labelProfesor = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_Capacidad).BeginInit();
            SuspendLayout();
            // 
            // lst_Cursos
            // 
            lst_Cursos.FormattingEnabled = true;
            lst_Cursos.ItemHeight = 25;
            lst_Cursos.Location = new Point(460, 60);
            lst_Cursos.Name = "lst_Cursos";
            lst_Cursos.Size = new Size(340, 379);
            lst_Cursos.TabIndex = 0;
            lst_Cursos.DoubleClick += lst_Cursos_DoubleClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(360, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE CURSOS";
            // 
            // txt_Titulo
            // 
            txt_Titulo.Enabled = false;
            txt_Titulo.Location = new Point(24, 90);
            txt_Titulo.Name = "txt_Titulo";
            txt_Titulo.Size = new Size(400, 32);
            txt_Titulo.TabIndex = 2;
            // 
            // txt_Codigo
            // 
            txt_Codigo.Enabled = false;
            txt_Codigo.Location = new Point(24, 160);
            txt_Codigo.Name = "txt_Codigo";
            txt_Codigo.Size = new Size(200, 32);
            txt_Codigo.TabIndex = 3;
            // 
            // txt_Descripcion
            // 
            txt_Descripcion.Enabled = false;
            txt_Descripcion.Location = new Point(24, 230);
            txt_Descripcion.Multiline = true;
            txt_Descripcion.Name = "txt_Descripcion";
            txt_Descripcion.Size = new Size(400, 80);
            txt_Descripcion.TabIndex = 4;
            // 
            // dtp_FechaInicio
            // 
            dtp_FechaInicio.Enabled = false;
            dtp_FechaInicio.Location = new Point(24, 350);
            dtp_FechaInicio.Name = "dtp_FechaInicio";
            dtp_FechaInicio.Size = new Size(200, 32);
            dtp_FechaInicio.TabIndex = 5;
            // 
            // dtp_FechaFin
            // 
            dtp_FechaFin.Enabled = false;
            dtp_FechaFin.Location = new Point(260, 350);
            dtp_FechaFin.Name = "dtp_FechaFin";
            dtp_FechaFin.Size = new Size(200, 32);
            dtp_FechaFin.TabIndex = 6;
            // 
            // nud_Capacidad
            // 
            nud_Capacidad.Enabled = false;
            nud_Capacidad.Location = new Point(24, 420);
            nud_Capacidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_Capacidad.Name = "nud_Capacidad";
            nud_Capacidad.Size = new Size(120, 32);
            nud_Capacidad.TabIndex = 7;
            // 
            // txt_Precio
            // 
            txt_Precio.Enabled = false;
            txt_Precio.Location = new Point(160, 420);
            txt_Precio.Name = "txt_Precio";
            txt_Precio.Size = new Size(120, 32);
            txt_Precio.TabIndex = 8;
            // 
            // cmb_Profesor
            // 
            cmb_Profesor.Enabled = false;
            cmb_Profesor.Location = new Point(300, 420);
            cmb_Profesor.Name = "cmb_Profesor";
            cmb_Profesor.Size = new Size(200, 33);
            cmb_Profesor.TabIndex = 9;
            // 
            // btn_Nuevo
            // 
            btn_Nuevo.Location = new Point(24, 480);
            btn_Nuevo.Name = "btn_Nuevo";
            btn_Nuevo.Size = new Size(110, 36);
            btn_Nuevo.TabIndex = 10;
            btn_Nuevo.Text = "Nuevo";
            btn_Nuevo.Click += btn_Nuevo_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Enabled = false;
            btn_Guardar.Location = new Point(150, 480);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(110, 36);
            btn_Guardar.TabIndex = 11;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.Location = new Point(460, 460);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(110, 36);
            btn_Editar.TabIndex = 12;
            btn_Editar.Text = "Editar";
            btn_Editar.Click += btn_Editar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Enabled = false;
            btn_Cancelar.Location = new Point(280, 480);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(110, 36);
            btn_Cancelar.TabIndex = 13;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.ForeColor = Color.FromArgb(192, 0, 0);
            btn_Eliminar.Location = new Point(590, 460);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(110, 36);
            btn_Eliminar.TabIndex = 14;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(700, 460);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(100, 36);
            btn_Salir.TabIndex = 15;
            btn_Salir.Text = "Salir";
            btn_Salir.Click += btn_Salir_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Location = new Point(24, 60);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(68, 25);
            labelTitulo.TabIndex = 16;
            labelTitulo.Text = "Título*";
            // 
            // labelCodigo
            // 
            labelCodigo.AutoSize = true;
            labelCodigo.Location = new Point(24, 130);
            labelCodigo.Name = "labelCodigo";
            labelCodigo.Size = new Size(81, 25);
            labelCodigo.TabIndex = 17;
            labelCodigo.Text = "Código*";
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(24, 200);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(111, 25);
            labelDescripcion.TabIndex = 18;
            labelDescripcion.Text = "Descripción";
            // 
            // labelFechas
            // 
            labelFechas.AutoSize = true;
            labelFechas.Location = new Point(24, 320);
            labelFechas.Name = "labelFechas";
            labelFechas.Size = new Size(162, 25);
            labelFechas.TabIndex = 19;
            labelFechas.Text = "Fechas Inicio / Fin";
            // 
            // labelCapacidad
            // 
            labelCapacidad.AutoSize = true;
            labelCapacidad.Location = new Point(24, 390);
            labelCapacidad.Name = "labelCapacidad";
            labelCapacidad.Size = new Size(225, 25);
            labelCapacidad.TabIndex = 20;
            labelCapacidad.Text = "Capacidad (0 = ilimitado)";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(160, 390);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(65, 25);
            labelPrecio.TabIndex = 21;
            labelPrecio.Text = "Precio";
            // 
            // labelProfesor
            // 
            labelProfesor.AutoSize = true;
            labelProfesor.Location = new Point(300, 390);
            labelProfesor.Name = "labelProfesor";
            labelProfesor.Size = new Size(83, 25);
            labelProfesor.TabIndex = 22;
            labelProfesor.Text = "Profesor";
            // 
            // frm_Cursos
            // 
            ClientSize = new Size(820, 560);
            Controls.Add(lst_Cursos);
            Controls.Add(lblTitulo);
            Controls.Add(txt_Titulo);
            Controls.Add(txt_Codigo);
            Controls.Add(txt_Descripcion);
            Controls.Add(dtp_FechaInicio);
            Controls.Add(dtp_FechaFin);
            Controls.Add(nud_Capacidad);
            Controls.Add(txt_Precio);
            Controls.Add(cmb_Profesor);
            Controls.Add(btn_Nuevo);
            Controls.Add(btn_Guardar);
            Controls.Add(btn_Editar);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Eliminar);
            Controls.Add(btn_Salir);
            Controls.Add(labelTitulo);
            Controls.Add(labelCodigo);
            Controls.Add(labelDescripcion);
            Controls.Add(labelFechas);
            Controls.Add(labelCapacidad);
            Controls.Add(labelPrecio);
            Controls.Add(labelProfesor);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_Cursos";
            Text = "Gestión de Cursos";
            Load += frm_Cursos_Load_1;
            ((System.ComponentModel.ISupportInitialize)nud_Capacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}