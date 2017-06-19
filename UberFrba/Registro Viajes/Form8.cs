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
            comboTurno.SelectedIndex = -1;
            comboChof.SelectedIndex = -1;
            comboCli.SelectedIndex = -1;
            comboChof.SelectedIndexChanged += new EventHandler(comboChof_SelectedIndexChanged);
            //El sistema deshabilita el textBox del auto pues otro método lo completa
            txtAuto.Enabled = false;
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
                    string queryChof = "select ((convert(nvarchar(8), CHOF_DNI)) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER where CHOF_HABILITADO = 1";
                    string queryTurnos = "select distinct(TURN_DESCRIPCION), TURN_ID from GESTION_DE_GATOS.TURNO where TURN_HABILITADO = 1";
                    string queryClie = "select CLIE_ID, (convert(nvarchar(8), CLIE_DNI) + ' | ' + CLIE_NOMBRE + ' ' + CLIE_APELLIDO) as CLIENTE from GESTION_DE_GATOS.CLIENTE where CLIE_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(queryChof, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryTurnos, conn);
                    SqlDataAdapter da3 = new SqlDataAdapter(queryClie, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Choferes");
                    da2.Fill(ds, "Turnos");
                    da3.Fill(ds, "Clientes");
                    conn.Close();

                    //El sistema llena el combo de Turnos
                    comboTurno.DataSource = ds.Tables["Turnos"];
                    comboTurno.DisplayMember = "TURN_DESCRIPCION";
                    comboTurno.ValueMember = "TURN_ID";
                    comboTurno.DropDownStyle = ComboBoxStyle.DropDownList;

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

        //Método del sistema que busca el vehículo asignado al chofer seleccionado
        private void comboChof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTurno.SelectedIndex == -1)
            {
                MessageBox.Show("[WARNING] Debe seleccionar el Turno");
                comboChof.SelectedIndex = -1;
                return;
            }
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select VEHI_ID, MODE_DESCRIPCION, MARC_DESCRIPCION
                                            from GESTION_DE_GATOS.CHOFER as a
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as b on a.CHOF_ID = b.VC_CHOF_ID
                                            inner join GESTION_DE_GATOS.VEHICULO as c on b.VC_VEHI_ID = c.VEHI_ID
                                            inner join GESTION_DE_GATOS.MODELO as d on c.VEHI_MODELO = d.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as e on d.MODE_MARCA = e.MARC_ID
                                            where CHOF_ID = {0} and b.VC_TURN_ID = {1}", comboChof.SelectedValue.ToString(), comboTurno.SelectedValue.ToString());
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        labelID.Text = "ID: " + dt.Rows[0]["VEHI_ID"].ToString();
                        txtAuto.Text = dt.Rows[0]["MARC_DESCRIPCION"].ToString() + " " + dt.Rows[0]["MODE_DESCRIPCION"].ToString();
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("[SQL] " + sqlEx.Message);
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
                        string query = string.Format(@"insert into GESTION_DE_GATOS.VIAJE (VIAJ_CHOFER, VIAJ_CLIENTE, VIAJ_VEHICULO, 
                                               VIAJ_TURNO, VIAJ_DISTANCIA, VIAJ_FECHA_INICIO, VIAJ_FECHA_FIN)
                                               values ({0},{1},{2},{3},{4},'{5}','{6}')", comboChof.SelectedValue.ToString(),
                                                comboCli.SelectedValue.ToString(), labelID.Text.Replace("ID: ",""), comboTurno.SelectedValue.ToString(),
                                                txtKMs.Text, dateTimePickerIni.Value.Date.ToShortDateString() + " " + dateTimePickerIni.Value.Hour.ToString() + ":00:00",
                                                dateTimePickerFin.Value.Date.ToShortDateString() + " " + dateTimePickerFin.Value.Hour.ToString() + ":00:00");
                        Clipboard.SetText(query);
                        SqlCommand cmmd = new SqlCommand(query, conn);
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
