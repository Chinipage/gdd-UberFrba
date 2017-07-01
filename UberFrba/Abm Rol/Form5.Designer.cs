namespace UberFrba.Abm_Rol
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkLstFuncA = new System.Windows.Forms.CheckedListBox();
            this.txtNomA = new System.Windows.Forms.TextBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelHab = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLstFuncM = new System.Windows.Forms.CheckedListBox();
            this.btnHabDesM = new System.Windows.Forms.Button();
            this.txtNomM = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModif = new System.Windows.Forms.Button();
            this.comboRolM = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rOLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rOLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 359);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkLstFuncA);
            this.tabPage1.Controls.Add(this.txtNomA);
            this.tabPage1.Controls.Add(this.btnAlta);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkLstFuncA
            // 
            this.chkLstFuncA.FormattingEnabled = true;
            this.chkLstFuncA.Location = new System.Drawing.Point(161, 79);
            this.chkLstFuncA.Name = "chkLstFuncA";
            this.chkLstFuncA.Size = new System.Drawing.Size(264, 172);
            this.chkLstFuncA.TabIndex = 12;
            // 
            // txtNomA
            // 
            this.txtNomA.Location = new System.Drawing.Point(161, 21);
            this.txtNomA.Name = "txtNomA";
            this.txtNomA.Size = new System.Drawing.Size(210, 26);
            this.txtNomA.TabIndex = 11;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(269, 279);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(87, 31);
            this.btnAlta.TabIndex = 10;
            this.btnAlta.Text = "CREAR";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelHab);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.chkLstFuncM);
            this.tabPage3.Controls.Add(this.btnHabDesM);
            this.tabPage3.Controls.Add(this.txtNomM);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.btnModif);
            this.tabPage3.Controls.Add(this.comboRolM);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(621, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelHab
            // 
            this.labelHab.AutoSize = true;
            this.labelHab.Location = new System.Drawing.Point(486, 87);
            this.labelHab.Name = "labelHab";
            this.labelHab.Size = new System.Drawing.Size(129, 20);
            this.labelHab.TabIndex = 21;
            this.labelHab.Text = "No Seleccionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Habilitado:";
            // 
            // chkLstFuncM
            // 
            this.chkLstFuncM.FormattingEnabled = true;
            this.chkLstFuncM.Location = new System.Drawing.Point(172, 145);
            this.chkLstFuncM.Name = "chkLstFuncM";
            this.chkLstFuncM.Size = new System.Drawing.Size(248, 172);
            this.chkLstFuncM.TabIndex = 19;
            // 
            // btnHabDesM
            // 
            this.btnHabDesM.Location = new System.Drawing.Point(476, 164);
            this.btnHabDesM.Name = "btnHabDesM";
            this.btnHabDesM.Size = new System.Drawing.Size(114, 29);
            this.btnHabDesM.TabIndex = 18;
            this.btnHabDesM.Text = "Deshabilitar";
            this.btnHabDesM.UseVisualStyleBackColor = true;
            this.btnHabDesM.Click += new System.EventHandler(this.btnHabDesM_Click);
            // 
            // txtNomM
            // 
            this.txtNomM.Location = new System.Drawing.Point(172, 87);
            this.txtNomM.Name = "txtNomM";
            this.txtNomM.Size = new System.Drawing.Size(210, 26);
            this.txtNomM.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(476, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 53);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Guardar Cambios";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Funcionalidades:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nombre del Rol:";
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(452, 30);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(114, 29);
            this.btnModif.TabIndex = 6;
            this.btnModif.Text = "Modificar";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // comboRolM
            // 
            this.comboRolM.ForeColor = System.Drawing.Color.Black;
            this.comboRolM.FormattingEnabled = true;
            this.comboRolM.Location = new System.Drawing.Point(172, 30);
            this.comboRolM.Name = "comboRolM";
            this.comboRolM.Size = new System.Drawing.Size(210, 28);
            this.comboRolM.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Seleccionar:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 381);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UberFrba | ABM Rol ";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rOLBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtNomA;
        private System.Windows.Forms.TextBox txtNomM;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.ComboBox comboRolM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHabDesM;
        private System.Windows.Forms.BindingSource rOLBindingSource;
        private System.Windows.Forms.CheckedListBox chkLstFuncM;
        private System.Windows.Forms.CheckedListBox chkLstFuncA;
        private System.Windows.Forms.Label labelHab;
        private System.Windows.Forms.Label label3;
    }
}