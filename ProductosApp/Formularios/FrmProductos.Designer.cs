namespace ProductosApp.Formularios
{
    partial class FrmProductos
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbFinderType = new System.Windows.Forms.ComboBox();
            this.cmbMeasureUnit = new System.Windows.Forms.ComboBox();
            this.txtFinder = new System.Windows.Forms.TextBox();
            this.rtbProductView = new System.Windows.Forms.RichTextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 396);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 42);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(673, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(567, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Modificar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(461, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // cmbFinderType
            // 
            this.cmbFinderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinderType.FormattingEnabled = true;
            this.cmbFinderType.Items.AddRange(new object[] {
            "Id",
            "Rango Precio",
            "Fecha vencimiento",
            "Unidad Medida"});
            this.cmbFinderType.Location = new System.Drawing.Point(12, 12);
            this.cmbFinderType.Name = "cmbFinderType";
            this.cmbFinderType.Size = new System.Drawing.Size(217, 24);
            this.cmbFinderType.TabIndex = 1;
            this.cmbFinderType.SelectedIndexChanged += new System.EventHandler(this.CmbFinderType_SelectedIndexChanged);
            // 
            // cmbMeasureUnit
            // 
            this.cmbMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasureUnit.FormattingEnabled = true;
            this.cmbMeasureUnit.Location = new System.Drawing.Point(235, 12);
            this.cmbMeasureUnit.Name = "cmbMeasureUnit";
            this.cmbMeasureUnit.Size = new System.Drawing.Size(189, 24);
            this.cmbMeasureUnit.TabIndex = 2;
            this.cmbMeasureUnit.Visible = false;
            // 
            // txtFinder
            // 
            this.txtFinder.Location = new System.Drawing.Point(235, 12);
            this.txtFinder.Name = "txtFinder";
            this.txtFinder.Size = new System.Drawing.Size(423, 22);
            this.txtFinder.TabIndex = 3;
            this.txtFinder.Visible = false;
            // 
            // rtbProductView
            // 
            this.rtbProductView.Location = new System.Drawing.Point(12, 42);
            this.rtbProductView.Name = "rtbProductView";
            this.rtbProductView.ReadOnly = true;
            this.rtbProductView.Size = new System.Drawing.Size(776, 348);
            this.rtbProductView.TabIndex = 4;
            this.rtbProductView.Text = "";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(664, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(121, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Buscar";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.rtbProductView);
            this.Controls.Add(this.txtFinder);
            this.Controls.Add(this.cmbMeasureUnit);
            this.Controls.Add(this.cmbFinderType);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FrmProductos";
            this.Text = "Catalogo de productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbFinderType;
        private System.Windows.Forms.ComboBox cmbMeasureUnit;
        private System.Windows.Forms.TextBox txtFinder;
        private System.Windows.Forms.RichTextBox rtbProductView;
        private System.Windows.Forms.Button btnFind;
    }
}