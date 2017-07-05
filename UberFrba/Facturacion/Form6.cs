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

namespace UberFrba.Facturacion
{
    public partial class Form6 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dtpFecIni.Format = DateTimePickerFormat.Custom;
            dtpFecIni.CustomFormat = "dd/MM/yyyy";
            dtpFecFin.Format = DateTimePickerFormat.Custom;
            dtpFecFin.CustomFormat = "dd/MM/yyyy";
            dtpFecIni.MaxDate = DateTime.Now;
            dtpFecFin.MaxDate = DateTime.Now;
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            fillCombo();
            comboCli.SelectedIndex = -1;
        }

        //Método del sistema que llena los combos de datos desde la bd
        private void fillCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    //El sistema habilita el autocompletado en los combos
                    comboCli.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboCli.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //El sistema obtiene los choferes, turnos y clientes habilitados
                    string queryClie = "select CLIE_ID, (convert(nvarchar(18), CLIE_DNI) + ' | ' + CLIE_NOMBRE + ' ' + CLIE_APELLIDO) as CLIENTE from GESTION_DE_GATOS.CLIENTE where CLIE_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(queryClie, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Clientes");
                    conn.Close();

                    //El sistema llena el combo de Clientes
                    comboCli.DataSource = ds.Tables["Clientes"];
                    comboCli.DisplayMember = "CLIENTE";
                    comboCli.ValueMember = "CLIE_ID";
                    comboCli.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("[SQL] " + sqlEx.Message);
                    return;
                }
            }
        }

        //Método que genera una factura para el cliente seleccionado
        private void btnFact_Click(object sender, EventArgs e)
        {
            if (comboCli.SelectedIndex == -1)
            {
                MessageBox.Show("[WARNING] Debe seleccionar un Cliente");
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_fact_viajes", conn);
                    cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //creo los parametros del stored procedure
                    SqlParameter param_cli = new SqlParameter("@CLIENTE", int.Parse(comboCli.SelectedValue.ToString()));
                    SqlParameter param_fec_ini = new SqlParameter("@FECHA_INICIO", dtpFecIni.Value.Date.ToShortDateString());
                    SqlParameter param_fec_fin = new SqlParameter("@FECHA_FIN", dtpFecFin.Value.Date.ToShortDateString());
                    SqlParameter output = new SqlParameter("@IMPORTE_TOTAL", SqlDbType.Float);
                    //Seteo la direccion de los parametros
                    param_cli.Direction = ParameterDirection.Input;
                    param_fec_ini.Direction = ParameterDirection.Input;
                    param_fec_fin.Direction = ParameterDirection.Input;
                    output.Direction = ParameterDirection.Output;
                    //agrego los parametros al command
                    cmmd.Parameters.Add(param_cli);
                    cmmd.Parameters.Add(param_fec_ini);
                    cmmd.Parameters.Add(param_fec_fin);
                    cmmd.Parameters.Add(output);
                    conn.Open();
                    //Guardo el resultado en un DT
                    DataTable dt = new DataTable();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    //Imprimo importe total
                    lblImpTot.Text = output.Value.ToString();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("[SQL] " + sqlEx.Message);
                }
            }
        }

    }
}
