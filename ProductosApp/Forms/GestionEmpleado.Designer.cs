namespace ProductosApp.Forms
{
    partial class GestionEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnDocente = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.rtbEmpleados = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnDocente
            // 
            this.btnDocente.Location = new System.Drawing.Point(12, 36);
            this.btnDocente.Name = "btnDocente";
            this.btnDocente.Size = new System.Drawing.Size(153, 31);
            this.btnDocente.TabIndex = 0;
            this.btnDocente.Text = "Crear Docente";
            this.btnDocente.UseVisualStyleBackColor = true;
            this.btnDocente.Click += new System.EventHandler(this.BtnDocente_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(171, 36);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(222, 31);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Crear Administrativo";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.BtnAdmin_Click);
            // 
            // rtbEmpleados
            // 
            this.rtbEmpleados.Location = new System.Drawing.Point(12, 73);
            this.rtbEmpleados.Name = "rtbEmpleados";
            this.rtbEmpleados.Size = new System.Drawing.Size(776, 365);
            this.rtbEmpleados.TabIndex = 2;
            this.rtbEmpleados.Text = "";
            // 
            // GestionEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbEmpleados);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnDocente);
            this.Name = "GestionEmpleado";
            this.Text = "GestionEmpleado";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocente;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.RichTextBox rtbEmpleados;
    }
}