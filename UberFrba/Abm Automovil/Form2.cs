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

namespace UberFrba.Abm_Automovil
{
    public partial class Form2 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "select distinct(Auto_Marca) from gd_esquema.Maestra";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Marcas");
                comboMarcaFilM.DisplayMember = "Auto_Marca";
                comboMarcaFilM.ValueMember = "Auto_Marca";
                comboMarcaFilM.DataSource = ds.Tables["Marcas"];
            }
            comboChofA.SelectedIndex = 0;
            comboChofM.SelectedIndex = 0;
            comboChofM.Enabled = false;
            comboMarcaA.SelectedIndex = 0;
            comboMarcaFilM.SelectedIndex = 0;
            comboMarcaM.SelectedIndex = 0;
            comboMarcaM.Enabled = false;
            comboModA.SelectedIndex = 0;
            comboModM.SelectedIndex = 0;
            comboModM.Enabled = false;
            comboTurnoA.SelectedIndex = 0;
            comboTurnoM.SelectedIndex = 0;
            comboTurnoM.Enabled = false;
            txtPatM.Enabled = false;
            btnSave.Enabled = false;
            btnHabDesM.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    //agregar validaciones
                    string query = "insert into Automovil...";
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "select Auto_Marca, Auto_Modelo, Auto_Patente, Chofer_Nombre, Chofer_Apellido from gd_esquema.Maestra where ";
            if (comboMarcaFilM.SelectedIndex == 0 && txtModFilM.Text.Length == 0 && txtModFilM.Text.Length == 0 && txtPatFilM.Text.Length == 0 && txtChofFilM.Text.Length == 0)
            {
                MessageBox.Show("[WARNING] Por favor ingrese alguno de los campos de búsqueda");
                return;
            }
            if (comboMarcaFilM.SelectedIndex > 0)
                query += "Auto_Marca = '" + comboMarcaFilM.SelectedValue +"' and ";
            if (txtModFilM.Text.Length > 0)
                query += "Auto_Modelo = '" + txtModFilM.Text + "' and ";
            if (txtPatFilM.Text.Length > 0)
                query += "Auto_Patente = '" + txtPatFilM.Text +"' and ";
            if (txtChofFilM.Text.Length > 0)
                query += "Chofer_Nombre = '" + txtChofFilM.Text + "'";
            else
            {
                string queryFinal = "";
                queryFinal = query.Remove(query.Length - 4, 4);
                MessageBox.Show("Entree: " + queryFinal);
                query = queryFinal;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.Name = "Accion";
                    btnColumn.Text = "Modificar";
                    int col = 5;
                    dataGridView1.Columns.Insert(col, btnColumn);
                }
                catch (SqlException sqlErro)
                {
                    MessageBox.Show(sqlErro.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            comboChofM.Enabled = true;
            comboMarcaM.Enabled = true;
            comboModM.Enabled = true;
            comboTurnoM.Enabled = true;
            txtPatM.Enabled = true;
            btnSave.Enabled = true;
            btnHabDesM.Enabled = true;
        }
    }
}
