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

namespace UberFrba.Abm_Chofer
{
    public partial class Form3 : Form
    {

        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            //El sistema deshabilita los controles de modificacion
            habDes(false);
        }

        //Método que busca un Chofer según el filtro aplicado
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //El sistema limpia el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            if (txtNomFilM.Text.Length == 0 && txtApeFilM.Text.Length == 0 && txtDniFilM.Text.Length == 0)
                MessageBox.Show("[WARNING] Escriba un Nombre, Apellido o DNI para Filtrar");
            else
            {
                string query = "";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (txtDniFilM.Text.Length == 0)
                        {
                            query = string.Format(@"select CHOF_ID, CHOF_NOMBRE, CHOF_APELLIDO, CHOF_DNI 
                                                from GESTION_DE_GATOS.CHOFER
                                                where CHOF_NOMBRE like '%{0}%' 
                                                and CHOF_APELLIDO like '%{1}%'",
                                                txtNomFilM.Text, txtApeFilM.Text);
                        }
                        else
                        {
                            query = string.Format(@"select CHOF_ID, CHOF_NOMBRE, CHOF_APELLIDO, CHOF_DNI
                                                from GESTION_DE_GATOS.CHOFER
                                                where CHOF_NOMBRE like '%{0}%' 
                                                and CHOF_APELLIDO like '%{1}%'
                                                and CHOF_DNI = {2}",
                                                txtNomFilM.Text, txtApeFilM.Text, txtDniFilM.Text);
                        }
                        //El sistema llena el dt con los resultados de la query
                        DataTable dt = FuncsLib.getDtWithQuery(query);
                        //El sistema llena el dgv con el dt
                        dataGridView1.DataSource = dt;
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                        //El sistema agrega el boton modificar como ultima columna
                        btnColumn.Name = "Accion";
                        btnColumn.Text = "Modificar";
                        int col = dataGridView1.Columns.Count;
                        dataGridView1.Columns.Insert(col, btnColumn);
                    }
                    catch (SqlException sqlErro)
                    {
                        MessageBox.Show(sqlErro.Message + "Query: " + query);
                    }
                }
            }
        }

        //Método que trae los datos del Chofer seleccionado de la bd
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //El sistema obtiene los datos de la fila clickeada
            var row = dataGridView1.Rows[e.RowIndex];
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select CHOF_NOMBRE, CHOF_APELLIDO,  CHOF_DNI, CHOF_DIRECCION,
                                            CHOF_FECHA_NACIMIENTO, CHOF_MAIL, CHOF_TELEFONO, CHOF_HABILITADO
                                            from GESTION_DE_GATOS.CHOFER
                                            where CHOF_ID = {0}", row.Cells[0].Value.ToString());
                    //El sistema obtiene el ID del Cliente seleccionado
                    labelID.Text = row.Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    //El sistema muestra los demás datos del Cliente seleccionado
                    txtDniM.Text = dt.Rows[0]["CHOF_DNI"].ToString();
                    txtNomM.Text = dt.Rows[0]["CHOF_NOMBRE"].ToString();
                    txtApeM.Text = dt.Rows[0]["CHOF_APELLIDO"].ToString();
                    txtTelM.Text = dt.Rows[0]["CHOF_TELEFONO"].ToString();
                    txtDirM.Text = dt.Rows[0]["CHOF_DIRECCION"].ToString();
                    txtMailM.Text = dt.Rows[0]["CHOF_MAIL"].ToString();
                    txtFecNacM.Text = dt.Rows[0]["CHOF_FECHA_NACIMIENTO"].ToString();
                    labelHab.Text = ((bool)dt.Rows[0]["CHOF_HABILITADO"]).ToString();

                    //El sistema cambia el texto del botón de Habilitar/Deshabilitar
                    if ((bool)dt.Rows[0]["CHOF_HABILITADO"])
                        btnHabDesM.Text = "Deshabilitar";
                    else
                        btnHabDesM.Text = "Habilitar";
                    habDes(true);
                }
                catch (SqlException sqlErro)
                {
                    MessageBox.Show(sqlErro.Message);
                }
            }
        }

        //Método que da de alta un Chofer
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (checkObligatorios())
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //El sistema llama al sp que inserta un chofer nuevo
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_insertar_chofer", conn);
                        if (buildSqlCommandForInsert(cmmd))
                        {
                            conn.Open();
                            cmmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("El chofer se dio de alta satisfactoriamente. Se generó el usuario con su DNI");
                        }
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
                MessageBox.Show("[WARNING] Por favor complete todos los campos con '*'");
                return;
            }
        }

        private bool buildSqlCommandForInsert(SqlCommand cmmd)
        {
            if (DateTime.Parse(txtFecNacA.Text) > DateTime.Now)
            {
                MessageBox.Show("[ERROR] El chofer es menor de edad.");
                return false;
            }
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param_nom = new SqlParameter("@NOMBRE", txtNomA.Text);
            SqlParameter param_ape = new SqlParameter("@APELLIDO", txtApeA.Text);
            SqlParameter param_dni = new SqlParameter("@DNI", txtDniA.Text);
            SqlParameter param_dir = new SqlParameter("@DIRECCION", txtDirA.Text);
            SqlParameter param_fec = new SqlParameter("@FECHA_NACIMIENTO", txtFecNacA.Text);
            SqlParameter param_mail = new SqlParameter("@MAIL", txtMailA.Text);
            SqlParameter param_tel = new SqlParameter("@TELEFONO", txtTelA.Text);
            param_nom.Direction = ParameterDirection.Input;
            param_ape.Direction = ParameterDirection.Input;
            param_dni.Direction = ParameterDirection.Input;
            param_dir.Direction = ParameterDirection.Input;
            param_fec.Direction = ParameterDirection.Input;
            param_mail.Direction = ParameterDirection.Input;
            param_tel.Direction = ParameterDirection.Input;
            cmmd.Parameters.Add(param_nom);
            cmmd.Parameters.Add(param_ape);
            cmmd.Parameters.Add(param_dni);
            cmmd.Parameters.Add(param_dir);
            cmmd.Parameters.Add(param_fec);
            cmmd.Parameters.Add(param_mail);
            cmmd.Parameters.Add(param_tel);
            return true;
        }

        private void buildSqlCommandForUpdate(SqlCommand cmmd)
        {
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param_id = new SqlParameter("@CHOF_ID", labelID.Text);
            SqlParameter param_nom = new SqlParameter("@NOMBRE", txtNomM.Text);
            SqlParameter param_ape = new SqlParameter("@APELLIDO", txtApeM.Text);
            SqlParameter param_dni = new SqlParameter("@DNI", txtDniM.Text);
            SqlParameter param_dir = new SqlParameter("@DIRECCION", txtDirM.Text);
            SqlParameter param_fec = new SqlParameter("@FECHA_NACIMIENTO", txtFecNacM.Text);
            SqlParameter param_mail = new SqlParameter("@MAIL", txtMailM.Text);
            SqlParameter param_tel = new SqlParameter("@TELEFONO", txtTelM.Text);
            param_id.Direction = ParameterDirection.Input;
            param_nom.Direction = ParameterDirection.Input;
            param_ape.Direction = ParameterDirection.Input;
            param_dni.Direction = ParameterDirection.Input;
            param_dir.Direction = ParameterDirection.Input;
            param_fec.Direction = ParameterDirection.Input;
            param_mail.Direction = ParameterDirection.Input;
            param_tel.Direction = ParameterDirection.Input;
            cmmd.Parameters.Add(param_id);
            cmmd.Parameters.Add(param_nom);
            cmmd.Parameters.Add(param_ape);
            cmmd.Parameters.Add(param_dni);
            cmmd.Parameters.Add(param_dir);
            cmmd.Parameters.Add(param_fec);
            cmmd.Parameters.Add(param_mail);
            cmmd.Parameters.Add(param_tel);
        }

        //Funcion que chequea los datos obligatorios
        private bool checkObligatorios()
        {
            if (txtNomA.Text == string.Empty || txtApeA.Text == string.Empty || txtDniA.Text == string.Empty || txtTelA.Text == string.Empty || txtFecNacA.Text == string.Empty || txtDirA.Text == string.Empty || txtMailA.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        //Funcion que habilita/deshabilita los controles de modificacion
        private void habDes(bool stat)
        {
            txtNomM.Enabled = stat;
            txtApeM.Enabled = stat;
            txtDniM.Enabled = stat;
            txtMailM.Enabled = stat;
            txtTelM.Enabled = stat;
            txtDirM.Enabled = stat;
            txtFecNacM.Enabled = stat;
            btnSave.Enabled = stat;
            btnHabDesM.Enabled = stat;
        }

        //Funcion que guarda las modificaciones del Chofer
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNomM.Text == string.Empty || txtApeM.Text == string.Empty || txtDniM.Text == string.Empty || txtTelM.Text == string.Empty || txtFecNacM.Text == string.Empty || txtDirM.Text == string.Empty || txtMailA.Text == string.Empty)
            {
                MessageBox.Show("[ERROR] Falta completar campos obligatorios.");
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_modificar_chofer", conn);
                    buildSqlCommandForUpdate(cmmd);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("[INFO] Se guardaron los cambios");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Funcion que deshabilita al chofer elegido
        private void btnHabDesM_Click(object sender, EventArgs e)
        {
            string query = ""; char hab;

            //El sistema chequea si el Cliente está habilitado para cambiar su estado
            if (labelHab.Text == "True")
                hab = '0';
            else
                hab = '1';

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"update a
                                            set CHOF_HABILITADO = {0}
                                            from GESTION_DE_GATOS.CHOFER as a
                                            where CHOF_ID = {1}", hab, labelID.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    //El sistema informa el estado del Chofer
                    if (hab == '0')
                        MessageBox.Show("Se Deshabilitó al Chofer seleccionado");
                    else
                        MessageBox.Show("Se Habilitó al Chofer seleccionado");
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
