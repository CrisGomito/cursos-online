namespace Cursos_Online.Vistas.Inscripciones
{
    partial class frm_Inscripciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lst_Inscripciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmb_Estudiante;
        private System.Windows.Forms.ComboBox cmb_Curso;
        private System.Windows.Forms.Button btn_Inscribir;
        private System.Windows.Forms.Button btn_CancelarInscripcion;
        private System.Windows.Forms.Button btn_Refrescar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label labelEstudiante;
        private System.Windows.Forms.Label labelCurso;

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
            lst_Inscripciones = new ListBox();
            lblTitulo = new Label();
            cmb_Estudiante = new ComboBox();
            cmb_Curso = new ComboBox();
            btn_Inscribir = new Button();
            btn_CancelarInscripcion = new Button();
            btn_Refrescar = new Button();
            btn_Salir = new Button();
            labelEstudiante = new Label();
            labelCurso = new Label();
            btn_Reportes = new Button();
            SuspendLayout();
            // 
            // lst_Inscripciones
            // 
            lst_Inscripciones.FormattingEnabled = true;
            lst_Inscripciones.ItemHeight = 25;
            lst_Inscripciones.Location = new Point(309, 62);
            lst_Inscripciones.Name = "lst_Inscripciones";
            lst_Inscripciones.Size = new Size(446, 329);
            lst_Inscripciones.TabIndex = 0;
            lst_Inscripciones.DoubleClick += lst_Inscripciones_DoubleClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(230, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(269, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE INSCRIPCIONES";
            // 
            // cmb_Estudiante
            // 
            cmb_Estudiante.Location = new Point(24, 110);
            cmb_Estudiante.Name = "cmb_Estudiante";
            cmb_Estudiante.Size = new Size(266, 33);
            cmb_Estudiante.TabIndex = 2;
            // 
            // cmb_Curso
            // 
            cmb_Curso.Location = new Point(24, 180);
            cmb_Curso.Name = "cmb_Curso";
            cmb_Curso.Size = new Size(266, 33);
            cmb_Curso.TabIndex = 3;
            // 
            // btn_Inscribir
            // 
            btn_Inscribir.Location = new Point(24, 460);
            btn_Inscribir.Name = "btn_Inscribir";
            btn_Inscribir.Size = new Size(110, 36);
            btn_Inscribir.TabIndex = 4;
            btn_Inscribir.Text = "Inscribir";
            btn_Inscribir.Click += btn_Inscribir_Click;
            // 
            // btn_CancelarInscripcion
            // 
            btn_CancelarInscripcion.ForeColor = Color.FromArgb(192, 0, 0);
            btn_CancelarInscripcion.Location = new Point(140, 460);
            btn_CancelarInscripcion.Name = "btn_CancelarInscripcion";
            btn_CancelarInscripcion.Size = new Size(150, 36);
            btn_CancelarInscripcion.TabIndex = 5;
            btn_CancelarInscripcion.Text = "Cancelar Inscripción";
            btn_CancelarInscripcion.Click += btn_CancelarInscripcion_Click;
            // 
            // btn_Refrescar
            // 
            btn_Refrescar.Location = new Point(296, 460);
            btn_Refrescar.Name = "btn_Refrescar";
            btn_Refrescar.Size = new Size(110, 36);
            btn_Refrescar.TabIndex = 6;
            btn_Refrescar.Text = "Refrescar";
            btn_Refrescar.Click += btn_Refrescar_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(412, 460);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(90, 36);
            btn_Salir.TabIndex = 7;
            btn_Salir.Text = "Salir";
            btn_Salir.Click += btn_Salir_Click;
            // 
            // labelEstudiante
            // 
            labelEstudiante.AutoSize = true;
            labelEstudiante.Location = new Point(24, 80);
            labelEstudiante.Name = "labelEstudiante";
            labelEstudiante.Size = new Size(108, 25);
            labelEstudiante.TabIndex = 8;
            labelEstudiante.Text = "Estudiante*";
            // 
            // labelCurso
            // 
            labelCurso.AutoSize = true;
            labelCurso.Location = new Point(24, 150);
            labelCurso.Name = "labelCurso";
            labelCurso.Size = new Size(69, 25);
            labelCurso.TabIndex = 9;
            labelCurso.Text = "Curso*";
            // 
            // btn_Reportes
            // 
            btn_Reportes.Location = new Point(631, 428);
            btn_Reportes.Name = "btn_Reportes";
            btn_Reportes.Size = new Size(124, 68);
            btn_Reportes.TabIndex = 10;
            btn_Reportes.Text = "Reportes";
            btn_Reportes.UseVisualStyleBackColor = true;
            btn_Reportes.Click += btn_Reportes_Click;
            // 
            // frm_Inscripciones
            // 
            ClientSize = new Size(781, 520);
            Controls.Add(btn_Reportes);
            Controls.Add(lst_Inscripciones);
            Controls.Add(lblTitulo);
            Controls.Add(cmb_Estudiante);
            Controls.Add(cmb_Curso);
            Controls.Add(btn_Inscribir);
            Controls.Add(btn_CancelarInscripcion);
            Controls.Add(btn_Refrescar);
            Controls.Add(btn_Salir);
            Controls.Add(labelEstudiante);
            Controls.Add(labelCurso);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_Inscripciones";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Inscripciones";
            Load += frm_Inscripciones_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Reportes;
    }
}