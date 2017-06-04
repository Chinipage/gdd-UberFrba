using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            comboRolM.SelectedIndex = 0;
            txtNomM.Enabled = false;
            lstFuncM.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (comboRolM.SelectedIndex > 0)
            {
                txtNomM.Enabled = true;
                lstFuncM.Enabled = true;
                btnSave.Enabled = true;
                txtNomM.Text = comboRolM.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("[WARNING] Por favor seleccione el Rol a modificar");
            }
        }
    }
}
