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
                                                where CHOFER_NOMBRE like '%{0}%' 
                                                and CHOFER_APELLIDO like '%{1}%'
                                                and CHOFER_DNI = {2}",
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
                        //El sistema crea un usuario, obtiene su id y da de alta el chofer
                        conn.Close();
                        string queryAltaUser = "";
                        queryAltaUser = string.Format(@"insert into GESTION_DE_GATOS.USUARIO
                                                        (USUA_USERNAME, USUA_CONTRASENIA, USUA_HABILITADO)
                                                        values ('{0}', (GESTION_DE_GATOS.f_encriptar_contrasenia('{0}')),
                                                            1); SELECT SCOPE_IDENTITY();", txtDniA.Text);
                        SqlCommand cmmd = new SqlCommand(queryAltaUser, conn);
                        //obtengo el id del nuevo usuario creado
                        conn.Open();
                        var newId = cmmd.ExecuteScalar();
                        conn.Close();

                        string queryAltaCho = ""; 
                        //inserto en la bd los datos del nuevo Cliente y el id de su usuario nuevo
                        queryAltaCho = string.Format(@"insert into GESTION_DE_GATOS.CHOFER
                                                        (CHOF_USUARIO, CHOF_NOMBRE, CHOF_APELLIDO, CHOF_DNI, CHOF_DIRECCION, CHOF_FECHA_NACIMIENTO, CHOF_TELEFONO, CHOF_HABILITADO)
                                                        values ({0}, '{1}', '{2}', {3}, '{4}', convert(datetime, '{5}', 103), {6}, {7})", newId, txtNomA.Text, txtApeA.Text, txtDniA.Text, 
                                                        txtDirA.Text, txtFecNacA.Text, txtTelA.Text, 1);
                        SqlCommand cmmd2 = new SqlCommand(queryAltaCho, conn);
                        conn.Open();
                        cmmd2.ExecuteNonQuery();
                        conn.Close();
                        //El sistema libera memoria
                        cmmd.Dispose();
                        cmmd2.Dispose();
                        MessageBox.Show("El chofer se dio de alta satisfactoriamente. Se generó el usuario " + txtDniA.Text + " con ID: " + newId.ToString());
                        return;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
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

        //Funcion que chequea los datos obligatorios
        private bool checkObligatorios()
        {
            foreach (Control c in tabPage1.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
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
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"update a
                                            set CHOF_NOMBRE = '{0}', CHOF_APELLIDO = '{1}',  CHOF_DNI = {2}, CHOF_DIRECCION = '{3}', 
                                            CHOF_FECHA_NACIMIENTO = convert(datetime, '{4}', 103), CHOF_MAIL = '{5}', CHOF_TELEFONO  = {6}
                                            from GESTION_DE_GATOS.CHOFER as a
                                            where CHOF_ID = {7}",
                                            txtNomM.Text, txtApeM.Text, txtDniM.Text, txtDirM.Text, 
                                            txtFecNacM.Text, txtMailM.Text, txtTelM.Text, labelID.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Se guardaron los cambios");
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
