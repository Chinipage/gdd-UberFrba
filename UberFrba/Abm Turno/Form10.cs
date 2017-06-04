using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            btnHabDesM.Enabled = false;
            btnSave.Enabled = false;
            txtDescM.Enabled = false;
            txtHrFinM.Enabled = false;
            txtHrInM.Enabled = false;
            txtPbM.Enabled = false;
            txtValKmM.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
        }
    }
}
