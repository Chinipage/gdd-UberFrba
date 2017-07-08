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

namespace UberFrba.Rendicion_Viajes
{
    public partial class Form9 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            dtpFecRend.Format = DateTimePickerFormat.Custom;
            dtpFecRend.CustomFormat = "dd/MM/yyyy";
            dtpFecRend.MaxDate = DateTime.Today;
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            fillCombos();
            //Se inicializan el combo sin seleccion
            comboChof.SelectedIndex = -1;
        }

        //Método del sistema que llena los combos de datos desde la bd
        private void fillCombos()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    comboChof.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboChof.AutoCompleteSource = AutoCompleteSource.ListItems;
                    
                    //El sistema obtiene todas las Marcas y sus IDs
                    string queryChof = "select ((convert(nvarchar(18), CHOF_DNI)) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER where CHOF_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(queryChof, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Choferes");
                    conn.Close();

                    //El sistema llena el combo de Choferes
                    comboChof.DataSource = ds.Tables["Choferes"];
                    comboChof.DisplayMember = "CHOFER";
                    comboChof.ValueMember = "CHOF_ID";
                    comboChof.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("[SQL] " + sqlEx.Message);
                    return;
                }
            }
        }

        //Método que calcula la rendicion de un Chofer en una Fecha
        private void btnRendir_Click(object sender, EventArgs e)
        {
            if (checkObligatorios())
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_rend_viajes", conn);
                        cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter param_chof = new SqlParameter("@CHOFER", int.Parse(comboChof.SelectedValue.ToString()));
                        SqlParameter param_fec = new SqlParameter("@FECHA_FACTURACION", dtpFecRend.Value.Date.ToShortDateString());
                        SqlParameter output = new SqlParameter("@IMPORTE_TOTAL", SqlDbType.Float);
                        output.Direction = ParameterDirection.Output;
                        param_chof.Direction = ParameterDirection.Input;
                        param_fec.Direction = ParameterDirection.Input;
                        cmmd.Parameters.Add(param_chof);
                        cmmd.Parameters.Add(param_fec);
                        cmmd.Parameters.Add(output);
                        conn.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmmd.ExecuteReader());
                        conn.Close();
                        dataGridView1.DataSource = dt;
                        lblImpTot.Text = output.Value.ToString();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("[SQL] " + sqlEx.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("[WARNING] Falta seleccionar el Chofer");
                return;
            }
        }

        //Función del sistema que chequea los datos obligatorios
        private bool checkObligatorios()
        {
            foreach (Control c in this.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    if (combo.SelectedIndex == -1)
                        return false;
                }
            }
            return true;
        }
    }
}
