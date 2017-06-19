namespace UberFrba.Rendicion_Viajes
{
    partial class Form9
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
            this.dtpFecRend = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboChof = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRendir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImpTot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecRend
            // 
            this.dtpFecRend.Location = new System.Drawing.Point(77, 48);
            this.dtpFecRend.Name = "dtpFecRend";
            this.dtpFecRend.Size = new System.Drawing.Size(253, 26);
            this.dtpFecRend.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // comboChof
            // 
            this.comboChof.FormattingEnabled = true;
            this.comboChof.Location = new System.Drawing.Point(419, 48);
            this.comboChof.Name = "comboChof";
            this.comboChof.Size = new System.Drawing.Size(303, 28);
            this.comboChof.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chofer:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(710, 271);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(295, 107);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(125, 45);
            this.btnRendir.TabIndex = 7;
            this.btnRendir.Text = "Rendir Viajes";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Importe Total: $";
            // 
            // lblImpTot
            // 
            this.lblImpTot.AutoSize = true;
            this.lblImpTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpTot.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblImpTot.Location = new System.Drawing.Point(132, 454);
            this.lblImpTot.Name = "lblImpTot";
            this.lblImpTot.Size = new System.Drawing.Size(19, 20);
            this.lblImpTot.TabIndex = 9;
            this.lblImpTot.Text = "0";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 483);
            this.Controls.Add(this.lblImpTot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboChof);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecRend);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UberFrba | Rendicion de Viajes";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecRend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboChof;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImpTot;
    }
}