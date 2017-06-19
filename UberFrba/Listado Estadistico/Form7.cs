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

namespace UberFrba.Listado_Estadistico
{
    public partial class Form7 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            comboRepo.SelectedIndex = -1;
            comboTrim.SelectedIndex = -1;
            comboRepo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboRepo.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboTrim.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboTrim.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboRepo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTrim.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (comboRepo.SelectedIndex == -1 || comboTrim.SelectedIndex == -1 || txtAnio.Text == string.Empty)
            {
                MessageBox.Show("[WARNING] Debe completar todos los campos");
                return;
            }
            //El sistema limpia el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            string query = "";
            switch (comboRepo.SelectedIndex.ToString())
            {
                case "0":
                    query = string.Format(@"select top(5) * 
                                            from GESTION_DE_GATOS.v_chof_recaudacion 
                                            where Trimestre = {0} and Anio = '{1}'
                                            order by Recaudacion desc", comboTrim.SelectedItem.ToString(), txtAnio.Text);
                    break;
                case "1":
                    query = string.Format(@"select top(5) * 
                                            from GESTION_DE_GATOS.v_chof_viaje 
                                            where Trimestre =  {0} and Year([Fecha de inicio del viaje]) = '{1}'
                                            and Year([Fecha de fin del viaje]) = '{1}' 
                                            order by [Distancia Recorrida] desc", comboTrim.SelectedItem.ToString(), txtAnio.Text);
                    break;
                case "2":
                    query = string.Format(@"select top(5) * 
                                            from GESTION_DE_GATOS.v_clie_consumo 
                                            where Trimestre = {0} and Anio = '{1}'
                                            order by Importe desc", comboTrim.SelectedItem.ToString(), txtAnio.Text);
                    break;
                case "3":
                    query = string.Format(@"select top(5) * 
                                            from GESTION_DE_GATOS.v_clie_vehi 
                                            where Trimestre = {0} and Anio = '{1}'
                                            order by [Cant. viajes] desc", comboTrim.SelectedItem.ToString(), txtAnio.Text);
                    break;
                default:
                    break;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }
    }
}
