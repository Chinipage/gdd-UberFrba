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
            habDes(false);
            fillCombos();
        }

        private void fillCombos()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    //El sistema obtiene todas las Marcas y sus IDs
                    string queryMarcas = "select distinct(MARC_DESCRIPCION), MARC_ID from GESTION_DE_GATOS.MODELO inner join GESTION_DE_GATOS.MARCA on MODE_MARCA = MARC_ID";
                    string queryTurnos = "select distinct(TURN_DESCRIPCION), TURN_ID from GESTION_DE_GATOS.TURNO";
                    SqlDataAdapter da = new SqlDataAdapter(queryMarcas, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryTurnos, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Marcas");
                    da2.Fill(ds, "Turnos");
                    conn.Close();
                    //El sistema llena el combo de Marcas de la seccion Alta
                    comboMarcaA.DataSource = ds.Tables["Marcas"];
                    comboMarcaA.DisplayMember = "MARC_DESCRIPCION";
                    comboMarcaA.ValueMember = "MARC_ID";
                    comboMarcaA.SelectedIndex = -1;
                    //El sistema llena el combo de Marcas de la seccion Modificacion
                    comboMarcaFilM.DataSource = ds.Tables["Marcas"];
                    comboMarcaFilM.DisplayMember = "MARC_DESCRIPCION";
                    comboMarcaFilM.ValueMember = "MARC_ID";
                    comboMarcaFilM.SelectedIndex = -1;
                    ds.Tables.Remove("Marcas");
                    //El sistema llena el combo de Turnos de la seccion Alta
                    comboTurnoA.DataSource = ds.Tables["Turnos"];
                    comboTurnoA.DisplayMember = "TURN_DESCRIPCION";
                    comboTurnoA.ValueMember = "TURN_ID";
                    comboTurnoA.SelectedIndex = -1;
                    //El sistema llena el combo de Turnos de la seccion Modificacion
                    comboTurnoM.DataSource = ds.Tables["Turnos"];
                    comboTurnoM.DisplayMember = "TURN_DESCRIPCION";
                    comboTurnoM.ValueMember = "TURN_ID";
                    comboTurnoM.SelectedIndex = -1;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                    int col = dataGridView1.Columns.Count;
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
            habDes(true);
        }

        private void comboMarcaFilM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMarcaFilM.SelectedValue.ToString() == "System.Data.DataRowView")
            {

            }
            else
            {
                MessageBox.Show(comboMarcaFilM.SelectedValue.ToString());
            }
        }

        //Funcion que habilita/deshabilita los controles de modificacion
        private void habDes(bool stat)
        {
            comboChofM.Enabled = stat;
            comboMarcaM.Enabled = stat;
            comboTurnoM.Enabled = stat;
            txtModM.Enabled = stat;
            txtPatM.Enabled = stat;
            btnHabDesM.Enabled = stat;
            btnSave.Enabled = stat;
        }
    }
}
