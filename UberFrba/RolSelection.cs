using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UberFrba
{
    public partial class RolSelection : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];
        public string usua = "";

        public RolSelection(string user)
        {
            InitializeComponent();
            usua = user;
        }

        private void RolSelection_Load(object sender, EventArgs e)
        {
            fillCombo();
            comboRol.SelectedIndex = -1;
        }

        //El sistema llena los combos y lst con los datos de la bd
        private void fillCombo()
        {
            try
            {
                comboRol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboRol.AutoCompleteSource = AutoCompleteSource.ListItems;
                using (var conn = new SqlConnection(connectionString))
                {
                    string queryRol = string.Format(@"SELECT ROL_ID, rtrim(ROL_DESCRIPCION) as ROL_DESCRIPCION FROM GESTION_DE_GATOS.ROL as a inner join GESTION_DE_GATOS.ROL_USUARIO as b on a.ROL_ID = b.RU_ROL_ID
                                                    inner join GESTION_DE_GATOS.USUARIO as c on b.RU_USUA_ID = c.USUA_ID
                                                    where USUA_USERNAME = '{0}' and ROL_HABILITADO = 1", usua);
                    SqlDataAdapter da = new SqlDataAdapter(queryRol, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Roles");
                    
                    comboRol.DisplayMember = "ROL_DESCRIPCION";
                    comboRol.ValueMember = "ROL_ID";
                    comboRol.DataSource = ds.Tables["Roles"];
                    comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboRol.SelectedIndex == -1)
            {
                MessageBox.Show("[WARNING] Por favor seleccione un Rol.");
                return;
            }
            else
            {
                Form1 frm = new Form1(usua, comboRol.SelectedValue.ToString());
                frm.Show();
                this.Close();
            }
        }
    }
}