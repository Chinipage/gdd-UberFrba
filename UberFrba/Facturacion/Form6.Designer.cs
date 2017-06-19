namespace UberFrba.Facturacion
{
    partial class Form6
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
            this.comboCli = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFact = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImpTot = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCli
            // 
            this.comboCli.FormattingEnabled = true;
            this.comboCli.Location = new System.Drawing.Point(80, 76);
            this.comboCli.Name = "comboCli";
            this.comboCli.Size = new System.Drawing.Size(279, 28);
            this.comboCli.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // btnFact
            // 
            this.btnFact.Location = new System.Drawing.Point(513, 68);
            this.btnFact.Name = "btnFact";
            this.btnFact.Size = new System.Drawing.Size(120, 43);
            this.btnFact.TabIndex = 2;
            this.btnFact.Text = "Facturar";
            this.btnFact.UseVisualStyleBackColor = true;
            this.btnFact.Click += new System.EventHandler(this.btnFact_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(723, 289);
            this.dataGridView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Inicio:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(117, 21);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(242, 26);
            this.dtpFecIni.TabIndex = 5;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(468, 22);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(245, 26);
            this.dtpFecFin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Fin:";
            // 
            // lblImpTot
            // 
            this.lblImpTot.AutoSize = true;
            this.lblImpTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpTot.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblImpTot.Location = new System.Drawing.Point(131, 425);
            this.lblImpTot.Name = "lblImpTot";
            this.lblImpTot.Size = new System.Drawing.Size(19, 20);
            this.lblImpTot.TabIndex = 11;
            this.lblImpTot.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Importe Total: $";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 448);
            this.Controls.Add(this.lblImpTot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCli);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UberFrba | Facturacion de Clientes";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFact;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImpTot;
        private System.Windows.Forms.Label label4;
    }
}