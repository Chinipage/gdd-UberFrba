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
            tabPage3.Text = "Modificar";
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            //El sistema deshabilita los controles de modificacion
            habDes(false);
        }

        //Funcion que busca Clientes con los Filtros proporcionados
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
                if (txtDniFilM.Text.Length == 0)
                {
                    //agregar select ID para traer todos los datos de modif
                    query = string.Format(@"select CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI 
                                        from GESTION_DE_GATOS.CLIENTE
                                        where CLIE_NOMBRE like '%{0}%' 
                                        and CLIE_APELLIDO like '%{1}%'", 
                                        txtNomFilM.Text, txtApeFilM.Text);
                }
                else
                {
                    query = string.Format(@"select CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI
                                        from GESTION_DE_GATOS.CLIENTE
                                        where CLIE_NOMBRE like '%{0}%' 
                                        and CLIE_APELLIDO like '%{1}%'
                                        and CLIE_DNI = {2}", 
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
        }

        //Funcion que obtiene los datos Cliente seleccionado
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //El sistema obtiene los datos de la fila clickeada
            var row = dataGridView1.Rows[e.RowIndex];
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select CLIE_NOMBRE, CLIE_APELLIDO,  CLIE_DNI, CLIE_DIRECCION, CLIE_CP,
                                                    CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_TELEFONO, CLIE_HABILITADO
                                                    from GESTION_DE_GATOS.CLIENTE
                                                    where CLIE_ID = {0}", row.Cells[0].Value.ToString());
                    //El sistema obtiene el ID del Cliente seleccionado
                    labelID.Text = row.Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    //El sistema muestra los demás datos del Cliente seleccionado
                    txtDniM.Text = dt.Rows[0]["CLIE_DNI"].ToString();
                    txtNomM.Text = dt.Rows[0]["CLIE_NOMBRE"].ToString();
                    txtApeM.Text = dt.Rows[0]["CLIE_APELLIDO"].ToString();
                    txtTelM.Text = dt.Rows[0]["CLIE_TELEFONO"].ToString();
                    txtDirM.Text = dt.Rows[0]["CLIE_DIRECCION"].ToString();
                    txtCpM.Text = dt.Rows[0]["CLIE_CP"].ToString();
                    txtMailM.Text = dt.Rows[0]["CLIE_MAIL"].ToString();
                    txtFecNacM.Text = dt.Rows[0]["CLIE_FECHA_NACIMIENTO"].ToString();
                    labelHab.Text = ((bool)dt.Rows[0]["CLIE_HABILITADO"]).ToString();
                    
                    //El sistema cambia el texto del botón de Habilitar/Deshabilitar
                    if ((bool)dt.Rows[0]["CLIE_HABILITADO"])
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

        //Funcion que guarda las modificaciones del Cliente
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_modificar_cliente", conn);
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

        //Funcion que da de alta un Cliente
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (checkObligatorios())
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //El sistema llama al sp que inserta un chofer nuevo
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_insertar_cliente", conn);
                        buildSqlCommandForInsert(cmmd);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("El cliente se dio de alta satisfactoriamente. Se generó el usuario con su DNI");
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

        private void buildSqlCommandForInsert(SqlCommand cmmd)
        {
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param_nom = new SqlParameter("@NOMBRE", txtNomA.Text);
            SqlParameter param_ape = new SqlParameter("@APELLIDO", txtApeA.Text);
            SqlParameter param_dni = new SqlParameter("@DNI", txtDniA.Text);
            SqlParameter param_cp = new SqlParameter("@CP", txtCpA.Text);
            SqlParameter param_dir = new SqlParameter("@DIRECCION", txtDirA.Text);
            SqlParameter param_fec = new SqlParameter("@FECHA_NACIMIENTO", txtFecNacA.Text);
            SqlParameter param_mail = new SqlParameter("@MAIL", txtMailA.Text);
            SqlParameter param_tel = new SqlParameter("@TELEFONO", txtTelA.Text);
            param_nom.Direction = ParameterDirection.Input;
            param_ape.Direction = ParameterDirection.Input;
            param_dni.Direction = ParameterDirection.Input;
            param_cp.Direction = ParameterDirection.Input;
            param_dir.Direction = ParameterDirection.Input;
            param_fec.Direction = ParameterDirection.Input;
            param_mail.Direction = ParameterDirection.Input;
            param_tel.Direction = ParameterDirection.Input;
            cmmd.Parameters.Add(param_nom);
            cmmd.Parameters.Add(param_ape);
            cmmd.Parameters.Add(param_dni);
            cmmd.Parameters.Add(param_cp);
            cmmd.Parameters.Add(param_dir);
            cmmd.Parameters.Add(param_fec);
            cmmd.Parameters.Add(param_mail);
            cmmd.Parameters.Add(param_tel);
        }

        private void buildSqlCommandForUpdate(SqlCommand cmmd)
        {
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param_id = new SqlParameter("@CLIE_ID", labelID.Text);
            SqlParameter param_nom = new SqlParameter("@NOMBRE", txtNomM.Text);
            SqlParameter param_ape = new SqlParameter("@APELLIDO", txtApeM.Text);
            SqlParameter param_dni = new SqlParameter("@DNI", txtDniM.Text);
            SqlParameter param_cp = new SqlParameter("@CP", txtCpM.Text);
            SqlParameter param_dir = new SqlParameter("@DIRECCION", txtDirM.Text);
            SqlParameter param_fec = new SqlParameter("@FECHA_NACIMIENTO", txtFecNacM.Text);
            SqlParameter param_mail = new SqlParameter("@MAIL", txtMailM.Text);
            SqlParameter param_tel = new SqlParameter("@TELEFONO", txtTelM.Text);
            param_id.Direction = ParameterDirection.Input;
            param_nom.Direction = ParameterDirection.Input;
            param_ape.Direction = ParameterDirection.Input;
            param_dni.Direction = ParameterDirection.Input;
            param_cp.Direction = ParameterDirection.Input;
            param_dir.Direction = ParameterDirection.Input;
            param_fec.Direction = ParameterDirection.Input;
            param_mail.Direction = ParameterDirection.Input;
            param_tel.Direction = ParameterDirection.Input;
            cmmd.Parameters.Add(param_id);
            cmmd.Parameters.Add(param_nom);
            cmmd.Parameters.Add(param_ape);
            cmmd.Parameters.Add(param_dni);
            cmmd.Parameters.Add(param_cp);
            cmmd.Parameters.Add(param_dir);
            cmmd.Parameters.Add(param_fec);
            cmmd.Parameters.Add(param_mail);
            cmmd.Parameters.Add(param_tel);
        }

        //Funcion que deshabilita al cliente elegido
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
                                            set CLIE_HABILITADO = {0}
                                            from GESTION_DE_GATOS.CLIENTE as a
                                            where CLIE_ID = {1}", hab, labelID.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    //El sistema informa el estado del Cliente
                    if(hab == '0')
                        MessageBox.Show("Se Deshabilitó al Cliente seleccionado");
                    else
                        MessageBox.Show("Se Habilitó al Cliente seleccionado");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }
        
        //Funcion que chequea los datos obligatorios
        private bool checkObligatorios()
        {
            foreach (Control c in tabPage1.Controls)
            {
                if (c is TextBox && !(c.Name.Contains("Mail")))
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
            txtTelM.Enabled = stat;
            txtDirM.Enabled = stat;
            txtCpM.Enabled = stat;
            txtMailM.Enabled = stat;
            txtFecNacM.Enabled = stat;
            btnSave.Enabled = stat;
        }
    }
}
