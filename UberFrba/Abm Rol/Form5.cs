using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace UberFrba.Abm_Rol
{
    public partial class Form5 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            habDes(false);
            fillCombo();
        }

        private void fillCombo()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT ROL_ID, ROL_DESCRIPCION FROM GESTION_DE_GATOS.ROL WHERE ROL_DESCRIPCION IS NOT NULL AND ROL_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Roles");
                    comboRolM.DataSource = ds.Tables["Roles"];
                    comboRolM.DisplayMember = "ROL_DESCRIPCION";
                    comboRolM.ValueMember = "ID_ROL";
                    comboRolM.SelectedIndex = -1;
                }
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
        }


        private void btnModif_Click(object sender, EventArgs e)
        {
            if (comboRolM.SelectedIndex != -1)
            {
                habDes(true);
                txtNomM.Text = comboRolM.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("[WARNING] Por favor seleccione el Rol a modificar");
            }
        }

        private void habDes(bool flag)
        {
            if (flag)
            {
                txtNomM.Enabled = true;
                lstFuncM.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                txtNomM.Enabled = false;
                lstFuncM.Enabled = false;
                btnSave.Enabled = false;
            }
        }
    }
}
