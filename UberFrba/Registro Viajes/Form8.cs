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

namespace UberFrba.Registro_Viajes
{
    public partial class Form8 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            //El sistema setea los formatos de los datepickers
            dateTimePickerIni.Format = DateTimePickerFormat.Custom;
            dateTimePickerIni.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerFin.Format = DateTimePickerFormat.Custom;
            dateTimePickerFin.CustomFormat = "dd/MM/yyyy HH:mm";
            //El sistema llena los combos y los inicializa sin seleccion
            comboChof.SelectedIndexChanged -= new EventHandler(comboChof_SelectedIndexChanged);
            fillCombos();
            comboChof.SelectedIndex = -1;
            comboCli.SelectedIndex = -1;

            dateTimePickerIni.ValueChanged += new EventHandler(dateTimePickerIni_ValueChanged);
            dateTimePickerFin.ValueChanged += new EventHandler(dateTimePickerFin_ValueChanged);
            comboChof.SelectedIndexChanged += new EventHandler(comboChof_SelectedIndexChanged);

            //El sistema deshabilita el textBox del auto pues otro método lo completa
            txtAuto.Enabled = false;
            txtTurno.Enabled = false;

        }

        //Método del sistema que llena los combos de datos desde la bd
        private void fillCombos()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    //El sistema habilita el autocompletado en los combos
                    comboChof.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboChof.AutoCompleteSource = AutoCompleteSource.ListItems;
                    comboCli.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboCli.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //El sistema obtiene los choferes, turnos y clientes habilitados
                    string queryChof = "select ((convert(nvarchar(8), CHOF_DNI)) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER where CHOF_ID in(select VC_CHOF_ID from GESTION_DE_GATOS.VEHICULO_CHOFER) and CHOF_HABILITADO = 1";
                    string queryClie = "select CLIE_ID, (convert(nvarchar(8), CLIE_DNI) + ' | ' + CLIE_NOMBRE + ' ' + CLIE_APELLIDO) as CLIENTE from GESTION_DE_GATOS.CLIENTE where CLIE_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(queryChof, conn);
                    SqlDataAdapter da3 = new SqlDataAdapter(queryClie, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Choferes");
                    da3.Fill(ds, "Clientes");
                    conn.Close();

                    //El sistema llena el combo de Choferes
                    comboChof.DataSource = ds.Tables["Choferes"];
                    comboChof.DisplayMember = "CHOFER";
                    comboChof.ValueMember = "CHOF_ID";
                    comboChof.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void dateTimePickerIni_ValueChanged(object sender, EventArgs e) {
            if (comboChof.SelectedIndex != -1 && dateTimePickerFin.Value != null) {
                loadTurnoAndVehiculo();
            }
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e) {
            if (comboChof.SelectedIndex != -1 && dateTimePickerIni.Value != null) {
                loadTurnoAndVehiculo();
            }
        }

        //Método del sistema que busca el vehículo asignado al chofer seleccionado
        private void comboChof_SelectedIndexChanged(object sender, EventArgs e) {
            if (dateTimePickerIni.Value != null && dateTimePickerFin.Value != null) {
                loadTurnoAndVehiculo();
            }
        }

        private void loadTurnoAndVehiculo() {
            using (var conn = new SqlConnection(connectionString)) {
                try {
                    //El sistema llama al sp que calcula el turno y devuelve los datos del vehiculo asignado al chofer en ese turno
                    DataTable dtOutput = new DataTable();
                    SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_get_turno_vehiculo_de_viaje", conn);
                    cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param_chof = new SqlParameter("@CHOFER", int.Parse(comboChof.SelectedValue.ToString()));
                    SqlParameter param_fec_ini = new SqlParameter("@VIAJE_HORA_INICIO", dateTimePickerIni.Value.Date.ToShortDateString() + " " + dateTimePickerIni.Value.Hour.ToString() + ":00:00");
                    SqlParameter param_fec_fin = new SqlParameter("@VIAJE_HORA_FIN", dateTimePickerFin.Value.Date.ToShortDateString() + " " + dateTimePickerFin.Value.Hour.ToString() + ":00:00");
                    param_chof.Direction = ParameterDirection.Input;
                    param_fec_ini.Direction = ParameterDirection.Input;
                    param_fec_fin.Direction = ParameterDirection.Input;
                    cmmd.Parameters.Add(param_chof);
                    cmmd.Parameters.Add(param_fec_ini);
                    cmmd.Parameters.Add(param_fec_fin);
                    conn.Open();
                    dtOutput.Load(cmmd.ExecuteReader());
                    conn.Close();
                    if (dtOutput.Rows.Count > 0) {
                        txtAuto.Text = dtOutput.Rows[0]["MARC_DESCRIPCION"].ToString() + " " + dtOutput.Rows[0]["MODE_DESCRIPCION"].ToString();
                        labelIDvehi.Text = "ID: " + dtOutput.Rows[0]["VEHI_ID"].ToString();
                        txtTurno.Text = dtOutput.Rows[0]["TURN_DESCRIPCION"].ToString();
                        labelIDtur.Text = "ID: " + dtOutput.Rows[0]["TURN_ID"].ToString();
                    } else {
                        MessageBox.Show("[ERROR] El SP no devolvió ningún registro");
                        return;
                    }
                } catch (SqlException sqlEx) {
                    MessageBox.Show("[SQL] " + sqlEx.Message);
                    txtAuto.Text = "";
                    labelIDvehi.Text = "";
                    txtTurno.Text = "";
                    labelIDtur.Text = "";
                    return;
                }
            }
        }

        //Método del sistema que da de alta un viaje
        private void btnRegViaje_Click(object sender, EventArgs e)
        {
            if (checkObligatorios())
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //El sistema llama al sp encargado de registrar los viajes
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_insert_viajes", conn);
                        cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter param_chof = new SqlParameter("@CHOFER", int.Parse(comboChof.SelectedValue.ToString()));
                        SqlParameter param_cli = new SqlParameter("@CLIENTE", int.Parse(comboCli.SelectedValue.ToString()));
                        SqlParameter param_vehi = new SqlParameter("@VEHICULO", int.Parse(labelIDvehi.Text.Replace("ID: ","")));
                        SqlParameter param_tur = new SqlParameter("@TURNO", int.Parse(labelIDtur.Text.Replace("ID: ","")));
                        SqlParameter param_dist = new SqlParameter("@DISTANCIA", int.Parse(txtKMs.Text));
                        SqlParameter param_fec_ini = new SqlParameter("@FECHA_INICIO", dateTimePickerIni.Value.Date.ToShortDateString() + " " + dateTimePickerIni.Value.Hour.ToString() + ":00:00");
                        SqlParameter param_fec_fin = new SqlParameter("@FECHA_FIN", dateTimePickerFin.Value.Date.ToShortDateString() + " " + dateTimePickerFin.Value.Hour.ToString() + ":00:00");
                        param_chof.Direction = ParameterDirection.Input;
                        param_cli.Direction = ParameterDirection.Input;
                        param_vehi.Direction = ParameterDirection.Input;
                        param_tur.Direction = ParameterDirection.Input;
                        param_dist.Direction = ParameterDirection.Input;
                        param_fec_ini.Direction = ParameterDirection.Input;
                        param_fec_fin.Direction = ParameterDirection.Input;
                        cmmd.Parameters.Add(param_chof);
                        cmmd.Parameters.Add(param_cli);
                        cmmd.Parameters.Add(param_vehi);
                        cmmd.Parameters.Add(param_tur);
                        cmmd.Parameters.Add(param_dist);
                        cmmd.Parameters.Add(param_fec_ini);
                        cmmd.Parameters.Add(param_fec_fin);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("[INFO] Se registró el Viaje correctamente");
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("[SQL] " + sqlEx.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("[WARNING] Debe completar todos los campos");
                return;
            }
        }

        //Función del sistema que chequea los datos obligatorios
        private bool checkObligatorios()
        {
            if (txtAuto.Text == string.Empty)
                return false;
            if (txtKMs.Text == string.Empty)
                return false;
            if (txtTurno.Text == string.Empty)
                return false;
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
