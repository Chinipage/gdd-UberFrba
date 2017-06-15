namespace UberFrba.Abm_Automovil
{
    partial class Form2
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
            this.btnAlta = new System.Windows.Forms.Button();
            this.comboChofA = new System.Windows.Forms.ComboBox();
            this.comboTurnoA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMarcaA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPatFilM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModFilM = new System.Windows.Forms.TextBox();
            this.comboMarcaFilM = new System.Windows.Forms.ComboBox();
            this.maestraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboChofM = new System.Windows.Forms.ComboBox();
            this.comboTurnoM = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPatM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboMarcaM = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnHabDesM = new System.Windows.Forms.Button();
            this.maestraTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.MaestraTableAdapter();
            this.txtModA = new System.Windows.Forms.TextBox();
            this.txtModM = new System.Windows.Forms.TextBox();
            this.comboChofFilM = new System.Windows.Forms.ComboBox();
            this.labelHab = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maestraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 700);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtModA);
            this.tabPage1.Controls.Add(this.btnAlta);
            this.tabPage1.Controls.Add(this.comboChofA);
            this.tabPage1.Controls.Add(this.comboTurnoA);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtPatA);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboMarcaA);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(382, 185);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(118, 62);
            this.btnAlta.TabIndex = 10;
            this.btnAlta.Text = "CARGAR";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // comboChofA
            // 
            this.comboChofA.FormattingEnabled = true;
            this.comboChofA.Location = new System.Drawing.Point(584, 87);
            this.comboChofA.Name = "comboChofA";
            this.comboChofA.Size = new System.Drawing.Size(284, 28);
            this.comboChofA.TabIndex = 9;
            // 
            // comboTurnoA
            // 
            this.comboTurnoA.FormattingEnabled = true;
            this.comboTurnoA.Location = new System.Drawing.Point(326, 87);
            this.comboTurnoA.Name = "comboTurnoA";
            this.comboTurnoA.Size = new System.Drawing.Size(158, 28);
            this.comboTurnoA.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chofer:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Turno:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Patente:*";
            // 
            // txtPatA
            // 
            this.txtPatA.Location = new System.Drawing.Point(94, 89);
            this.txtPatA.Name = "txtPatA";
            this.txtPatA.Size = new System.Drawing.Size(114, 26);
            this.txtPatA.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modelo:*";
            // 
            // comboMarcaA
            // 
            this.comboMarcaA.FormattingEnabled = true;
            this.comboMarcaA.Location = new System.Drawing.Point(89, 18);
            this.comboMarcaA.Name = "comboMarcaA";
            this.comboMarcaA.Size = new System.Drawing.Size(175, 28);
            this.comboMarcaA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:*";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(909, 667);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboChofFilM);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPatFilM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtModFilM);
            this.groupBox1.Controls.Add(this.comboMarcaFilM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 356);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Automovil";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 86;
            this.label9.Text = "Chofer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 84;
            this.label8.Text = "Patente:";
            // 
            // txtPatFilM
            // 
            this.txtPatFilM.Location = new System.Drawing.Point(488, 29);
            this.txtPatFilM.Name = "txtPatFilM";
            this.txtPatFilM.Size = new System.Drawing.Size(70, 26);
            this.txtPatFilM.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "Modelo:";
            // 
            // txtModFilM
            // 
            this.txtModFilM.Location = new System.Drawing.Point(296, 30);
            this.txtModFilM.Name = "txtModFilM";
            this.txtModFilM.Size = new System.Drawing.Size(114, 26);
            this.txtModFilM.TabIndex = 81;
            // 
            // comboMarcaFilM
            // 
            this.comboMarcaFilM.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.maestraBindingSource, "Auto_Marca", true));
            this.comboMarcaFilM.FormattingEnabled = true;
            this.comboMarcaFilM.Items.AddRange(new object[] {
            "Seleccionar..."});
            this.comboMarcaFilM.Location = new System.Drawing.Point(69, 30);
            this.comboMarcaFilM.Name = "comboMarcaFilM";
            this.comboMarcaFilM.Size = new System.Drawing.Size(155, 28);
            this.comboMarcaFilM.TabIndex = 80;
            // 
            // maestraBindingSource
            // 
            this.maestraBindingSource.DataMember = "Maestra";
            this.maestraBindingSource.DataSource = this.gD1C2017DataSet;
            // 
            // gD1C2017DataSet
            // 
            this.gD1C2017DataSet.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "Marca:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(876, 248);
            this.dataGridView1.TabIndex = 78;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(407, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 29);
            this.btnSearch.TabIndex = 77;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelT);
            this.groupBox2.Controls.Add(this.labelHab);
            this.groupBox2.Controls.Add(this.txtModM);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.comboChofM);
            this.groupBox2.Controls.Add(this.labelID);
            this.groupBox2.Controls.Add(this.comboTurnoM);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtPatM);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.comboMarcaM);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btnHabDesM);
            this.groupBox2.Location = new System.Drawing.Point(14, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 295);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modificar Automovil";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 63);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Guardar Cambios";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboChofM
            // 
            this.comboChofM.FormattingEnabled = true;
            this.comboChofM.Location = new System.Drawing.Point(404, 161);
            this.comboChofM.Name = "comboChofM";
            this.comboChofM.Size = new System.Drawing.Size(303, 28);
            this.comboChofM.TabIndex = 19;
            // 
            // comboTurnoM
            // 
            this.comboTurnoM.FormattingEnabled = true;
            this.comboTurnoM.Location = new System.Drawing.Point(95, 161);
            this.comboTurnoM.Name = "comboTurnoM";
            this.comboTurnoM.Size = new System.Drawing.Size(175, 28);
            this.comboTurnoM.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Chofer:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Turno:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(662, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Patente:";
            // 
            // txtPatM
            // 
            this.txtPatM.Location = new System.Drawing.Point(737, 83);
            this.txtPatM.Name = "txtPatM";
            this.txtPatM.Size = new System.Drawing.Size(114, 26);
            this.txtPatM.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(322, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 13;
            this.label13.Text = "Modelo:";
            // 
            // comboMarcaM
            // 
            this.comboMarcaM.FormattingEnabled = true;
            this.comboMarcaM.Location = new System.Drawing.Point(95, 85);
            this.comboMarcaM.Name = "comboMarcaM";
            this.comboMarcaM.Size = new System.Drawing.Size(175, 28);
            this.comboMarcaM.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "Marca:";
            // 
            // btnHabDesM
            // 
            this.btnHabDesM.Location = new System.Drawing.Point(484, 226);
            this.btnHabDesM.Name = "btnHabDesM";
            this.btnHabDesM.Size = new System.Drawing.Size(117, 44);
            this.btnHabDesM.TabIndex = 0;
            this.btnHabDesM.Text = "Deshabilitar";
            this.btnHabDesM.UseVisualStyleBackColor = true;
            this.btnHabDesM.Click += new System.EventHandler(this.btnHabDesM_Click);
            // 
            // maestraTableAdapter
            // 
            this.maestraTableAdapter.ClearBeforeFill = true;
            // 
            // txtModA
            // 
            this.txtModA.Location = new System.Drawing.Point(382, 18);
            this.txtModA.Name = "txtModA";
            this.txtModA.Size = new System.Drawing.Size(196, 26);
            this.txtModA.TabIndex = 11;
            // 
            // txtModM
            // 
            this.txtModM.Location = new System.Drawing.Point(399, 84);
            this.txtModM.Name = "txtModM";
            this.txtModM.Size = new System.Drawing.Size(216, 26);
            this.txtModM.TabIndex = 91;
            // 
            // comboChofFilM
            // 
            this.comboChofFilM.FormattingEnabled = true;
            this.comboChofFilM.Location = new System.Drawing.Point(623, 27);
            this.comboChofFilM.Name = "comboChofFilM";
            this.comboChofFilM.Size = new System.Drawing.Size(259, 28);
            this.comboChofFilM.TabIndex = 87;
            // 
            // labelHab
            // 
            this.labelHab.AutoSize = true;
            this.labelHab.Location = new System.Drawing.Point(326, 35);
            this.labelHab.Name = "labelHab";
            this.labelHab.Size = new System.Drawing.Size(129, 20);
            this.labelHab.TabIndex = 82;
            this.labelHab.Text = "No Seleccionado";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(205, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 81;
            this.label15.Text = "HABILITADO:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 20);
            this.label16.TabIndex = 80;
            this.label16.Text = "ID:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(57, 36);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(129, 20);
            this.labelID.TabIndex = 79;
            this.labelID.Text = "No Seleccionado";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(490, 35);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(0, 20);
            this.labelT.TabIndex = 92;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 722);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Automovil | UberFrba";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maestraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboMarcaA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboChofA;
        private System.Windows.Forms.ComboBox comboTurnoA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHabDesM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModFilM;
        private System.Windows.Forms.ComboBox comboMarcaFilM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPatFilM;
        private System.Windows.Forms.ComboBox comboChofM;
        private System.Windows.Forms.ComboBox comboTurnoM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPatM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboMarcaM;
        private System.Windows.Forms.Label label14;
        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource maestraBindingSource;
        private GD1C2017DataSetTableAdapters.MaestraTableAdapter maestraTableAdapter;
        private System.Windows.Forms.TextBox txtModA;
        private System.Windows.Forms.TextBox txtModM;
        private System.Windows.Forms.ComboBox comboChofFilM;
        private System.Windows.Forms.Label labelHab;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelT;
    }
}