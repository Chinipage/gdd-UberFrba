namespace UberFrba.Listado_Estadistico
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboRepo = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboTrim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado:";
            // 
            // comboRepo
            // 
            this.comboRepo.FormattingEnabled = true;
            this.comboRepo.Items.AddRange(new object[] {
            "Choferes con mayor recaudación",
            "Choferes con el viaje más largo realizado",
            "Clientes con mayor consumo",
            "Cliente que utilizo más veces el mismo automóvil"});
            this.comboRepo.Location = new System.Drawing.Point(92, 32);
            this.comboRepo.Name = "comboRepo";
            this.comboRepo.Size = new System.Drawing.Size(347, 28);
            this.comboRepo.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(356, 88);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(159, 38);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "Ejecutar";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(836, 297);
            this.dataGridView1.TabIndex = 3;
            // 
            // comboTrim
            // 
            this.comboTrim.FormattingEnabled = true;
            this.comboTrim.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboTrim.Location = new System.Drawing.Point(542, 32);
            this.comboTrim.Name = "comboTrim";
            this.comboTrim.Size = new System.Drawing.Size(113, 28);
            this.comboTrim.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trimestre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Año:";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(714, 32);
            this.txtAnio.Mask = "99999";
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 26);
            this.txtAnio.TabIndex = 7;
            this.txtAnio.ValidatingType = typeof(int);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 452);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTrim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.comboRepo);
            this.Controls.Add(this.label1);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UberFrba | Listado Estadistico";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRepo;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboTrim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtAnio;
    }
}