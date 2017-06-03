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

namespace UberFrba.Abm_Cliente
{
    public partial class Form4 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage2.Text = "Baja";
            tabPage3.Text = "Modificar";
            txtNomM.Enabled = false;
            txtApeM.Enabled = false;
            txtDniM.Enabled = false;
            txtMailM.Enabled = false;
            txtTelM.Enabled = false;
            txtDirM.Enabled = false;
            txtCpM.Enabled = false;
            txtFecNacM.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtNomFilM.Text.Length < 1 && txtApeFilM.Text.Length < 1 && txtDniFilM.Text.Length < 1)
                MessageBox.Show("[WARNING] Escriba un Nombre, Apellido o DNI para Filtrar");
            else
            {
                string query = "";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (txtDniFilM.Text.Length < 1)
                        {
                            //agregar select ID para traer todos los datos de modif
                            query = string.Format(@"select cliente_Nombre, cliente_Apellido, cliente_DNI from gd_esquema.Maestra 
                                                where cliente_Nombre like '%{0}%' 
                                                and cliente_Apellido like '%{1}%'
                                                ", txtNomFilM.Text, txtApeFilM.Text);
                        }
                        else
                        {
                            query = string.Format(@"select cliente_Nombre, cliente_Apellido, cliente_DNI from gd_esquema.Maestra 
                                                where cliente_Nombre like '%{0}%' 
                                                and cliente_Apellido like '%{1}%'
                                                and cliente_dni = {2}", txtNomFilM.Text, txtApeFilM.Text, txtDniFilM.Text);
                        }
                        SqlCommand cmmd = new SqlCommand(query, conn);
                        SqlDataAdapter da = new SqlDataAdapter(cmmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                        btnColumn.Name = "Accion";
                        btnColumn.Text = "Modificar";
                        int col = 3;
                        dataGridView1.Columns.Insert(col, btnColumn);
                    }
                    catch (SqlException sqlErro)
                    {
                        MessageBox.Show(sqlErro.Message + "Query: " + query);
                    }
                }
            }
        }

        //obtiene el ID del cliente seleccionado para traer la data de la bd
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select distinct(cliente_dni), cliente_Nombre, Cliente_Apellido, 
                                                    Cliente_Telefono, Cliente_Direccion, Cliente_Mail, 
                                                    Cliente_Fecha_Nac
                                                    from gd_esquema.Maestra
                                                    where cliente_Nombre = '{0}' and cliente_Apellido = '{1}'", row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    txtDniM.Text = dt.Rows[0][0].ToString();
                    txtNomM.Text = dt.Rows[0][1].ToString();
                    txtApeM.Text = dt.Rows[0][2].ToString();
                    txtTelM.Text = dt.Rows[0][3].ToString();
                    txtDirM.Text = dt.Rows[0][4].ToString();
                    txtMailM.Text = dt.Rows[0][5].ToString();
                    txtFecNacM.Text = dt.Rows[0][6].ToString();
                    txtNomM.Enabled = true;
                    txtApeM.Enabled = true;
                    txtDniM.Enabled = true;
                    txtTelM.Enabled = true;
                    txtDirM.Enabled = true;
                    txtMailM.Enabled = true;
                    txtFecNacM.Enabled = true;
                    btnSave.Enabled = true;
                }
                catch (SqlException sqlErro)
                {
                    MessageBox.Show(sqlErro.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //update cambios
        }
    }
}
