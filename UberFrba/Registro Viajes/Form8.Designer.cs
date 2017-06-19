namespace UberFrba.Registro_Viajes
{
    partial class Form8
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
            this.comboChof = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKMs = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerIni = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.comboCli = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.btnRegViaje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chofer:";
            // 
            // comboChof
            // 
            this.comboChof.FormattingEnabled = true;
            this.comboChof.Location = new System.Drawing.Point(79, 94);
            this.comboChof.Name = "comboChof";
            this.comboChof.Size = new System.Drawing.Size(263, 28);
            this.comboChof.TabIndex = 1;
            this.comboChof.SelectedIndexChanged += new System.EventHandler(this.comboChof_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Automóvil:";
            // 
            // comboTurno
            // 
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(81, 29);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(186, 28);
            this.comboTurno.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Turno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad KMs:";
            // 
            // txtKMs
            // 
            this.txtKMs.Location = new System.Drawing.Point(492, 94);
            this.txtKMs.Mask = "9999";
            this.txtKMs.Name = "txtKMs";
            this.txtKMs.Size = new System.Drawing.Size(63, 26);
            this.txtKMs.TabIndex = 7;
            // 
            // dateTimePickerIni
            // 
            this.dateTimePickerIni.Location = new System.Drawing.Point(172, 178);
            this.dateTimePickerIni.Name = "dateTimePickerIni";
            this.dateTimePickerIni.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerIni.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha y Hora Inicio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha y Hora Fin:";
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(553, 178);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerFin.TabIndex = 10;
            // 
            // comboCli
            // 
            this.comboCli.FormattingEnabled = true;
            this.comboCli.Location = new System.Drawing.Point(81, 248);
            this.comboCli.Name = "comboCli";
            this.comboCli.Size = new System.Drawing.Size(263, 28);
            this.comboCli.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cliente:";
            // 
            // txtAuto
            // 
            this.txtAuto.Location = new System.Drawing.Point(461, 26);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.Size = new System.Drawing.Size(192, 26);
            this.txtAuto.TabIndex = 14;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(659, 29);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(117, 20);
            this.labelID.TabIndex = 15;
            this.labelID.Text = "ID: Seleccionar";
            // 
            // btnRegViaje
            // 
            this.btnRegViaje.Location = new System.Drawing.Point(315, 314);
            this.btnRegViaje.Name = "btnRegViaje";
            this.btnRegViaje.Size = new System.Drawing.Size(160, 46);
            this.btnRegViaje.TabIndex = 16;
            this.btnRegViaje.Text = "Registrar Viaje";
            this.btnRegViaje.UseVisualStyleBackColor = true;
            this.btnRegViaje.Click += new System.EventHandler(this.btnRegViaje_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 384);
            this.Controls.Add(this.btnRegViaje);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txtAuto);
            this.Controls.Add(this.comboCli);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerIni);
            this.Controls.Add(this.txtKMs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboChof);
            this.Controls.Add(this.label1);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UberFrba | Registro de Viajes";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboChof;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtKMs;
        private System.Windows.Forms.DateTimePicker dateTimePickerIni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.ComboBox comboCli;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Button btnRegViaje;
    }
}