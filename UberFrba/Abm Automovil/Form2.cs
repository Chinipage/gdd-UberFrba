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
            //El sistema deshabilita la funcion para que el usuario ingrese una fila
            dataGridView1.AllowUserToAddRows = false;
            //El sistema deshabilita los controles de modificacion
            habDes(false);
            fillCombos();
            //El sistema inicializa los combos sin valor seleccionado
            comboChofA.SelectedIndex = -1;
            comboChofM.SelectedIndex = -1;
            comboChofFilM.SelectedIndex = -1;
            comboMarcaA.SelectedIndex = -1;
            comboMarcaM.SelectedIndex = -1;
            comboTurnoA.SelectedIndex = -1;
            comboTurnoM.SelectedIndex = -1;
            comboMarcaFilM.SelectedIndex = -1;
        }

        //Método que llena los combos de datos desde la bd
        private void fillCombos()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    comboChofA.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboChofA.AutoCompleteSource = AutoCompleteSource.ListItems;
                    //El sistema obtiene todas las Marcas y sus IDs
                    string queryMarcas = "select distinct(MARC_DESCRIPCION), MARC_ID from GESTION_DE_GATOS.MODELO inner join GESTION_DE_GATOS.MARCA on MODE_MARCA = MARC_ID";
                    string queryTurnos = "select distinct(TURN_DESCRIPCION), TURN_ID from GESTION_DE_GATOS.TURNO where TURN_HABILITADO = 1";
                    string queryChof = "select (convert(nvarchar(255), CHOF_DNI) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER where CHOF_HABILITADO = 1"; 
                    SqlDataAdapter da = new SqlDataAdapter(queryMarcas, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryTurnos, conn);
                    SqlDataAdapter da3 = new SqlDataAdapter(queryChof, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Marcas");
                    da2.Fill(ds, "Turnos");
                    da3.Fill(ds, "Choferes");
                    conn.Close();

                    //El sistema llena el combo de Marcas de la seccion Alta
                    comboMarcaA.DisplayMember = "MARC_DESCRIPCION";
                    comboMarcaA.ValueMember = "MARC_ID";
                    comboMarcaA.DataSource = ds.Tables["Marcas"];
                    comboMarcaA.DropDownStyle = ComboBoxStyle.DropDownList;
                    
                    //El sistema llena el combo de Marcas de la seccion Modificacion
                    comboMarcaM.DisplayMember = "MARC_DESCRIPCION";
                    comboMarcaM.ValueMember = "MARC_ID";
                    comboMarcaM.DataSource = ds.Tables["Marcas"];
                    comboMarcaM.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Marcas de la seccion Filtro Modificacion
                    comboMarcaFilM.DisplayMember = "MARC_DESCRIPCION";
                    comboMarcaFilM.ValueMember = "MARC_ID";
                    comboMarcaFilM.DataSource = ds.Tables["Marcas"];
                    comboMarcaFilM.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Turnos de la seccion Alta
                    comboTurnoA.DisplayMember = "TURN_DESCRIPCION";
                    comboTurnoA.ValueMember = "TURN_ID";
                    comboTurnoA.DataSource = ds.Tables["Turnos"];
                    comboTurnoA.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Turnos de la seccion Modificacion
                    comboTurnoM.DisplayMember = "TURN_DESCRIPCION";
                    comboTurnoM.ValueMember = "TURN_ID";
                    comboTurnoM.DataSource = ds.Tables["Turnos"];
                    comboTurnoM.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Choferes de la seccion Alta
                    comboChofA.DisplayMember = "CHOFER";
                    comboChofA.ValueMember = "CHOF_ID";
                    comboChofA.DataSource = ds.Tables["Choferes"];
                    comboChofA.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Choferes de la seccion Modificacion
                    comboChofM.DisplayMember = "CHOFER";
                    comboChofM.ValueMember = "CHOF_ID";
                    comboChofM.DataSource = ds.Tables["Choferes"];
                    comboChofM.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Choferes de la seccion Modificacion Filtro
                    comboChofFilM.DisplayMember = "CHOFER";
                    comboChofFilM.ValueMember = "CHOF_ID";
                    comboChofFilM.DataSource = ds.Tables["Choferes"];
                    comboChofFilM.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que da de alta un Vehiculo
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (checkObligatorios() == false)
            {
                MessageBox.Show("[ERROR] Todos los campos son obligatorios");
                return;
            }
            int modelo = getModelo((int)comboMarcaA.SelectedValue);
            
            if ((modelo > 0))
            {
                string query = "";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //crear trigger que agregue VEHICULO_CHOFER al ser insertado un nuevo auto
                        query = string.Format(@"inert into GESTION_DE_GATOS.VEHICULO (VEHI_MODELO, VEHI_PATENTE, VEHI_HABILITADO)
                                                values ({0}, '{1}', 1); SELECT SCOPE_IDENTITY();", modelo, txtPatA.Text);
                        SqlCommand cmmd = new SqlCommand(query, conn);
                        conn.Open();
                        var idVehi = (int)cmmd.ExecuteScalar();
                        conn.Close();
                        bool status = asignarVehiAchofYturno(idVehi);
                        if (status)
                            MessageBox.Show("[INFO] El vehículo se ha dado de Alta satisfactoriamente");
                        else
                            return;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.ToString());
                    }
                }
            }
        }

        //Funcion que verifica si existe el modelo, sino lo agrega y devuelve el ID
        private int getModelo(int marca_id)
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                query = string.Format(@"select MODE_ID 
                                        from GESTION_DE_GATOS.MODELO
                                        where MODE_DESCRIPCION = '{0}'", txtModA.Text);
                try
                {
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reg = null;
                    reg = cmmd.ExecuteReader();
                    //Si existe el modelo devuelve el ID
                    if (reg.Read())
                    {
                        return (int)reg["MODE_ID"];
                    }
                    //Si no existe lo crea y devuelve el nuevo ID
                    else
                    {
                        string queryAltaMod = string.Format(@"insert into GESTION_DE_GATOS.MODELO (MODE_DESCRIPCION, MODE_MARCA)
                                                              values ('{0}', {1}); SELECT SCOPE_IDENTITY()", txtModA.Text, marca_id);
                        SqlCommand cmmd2 = new SqlCommand(queryAltaMod, conn);
                        conn.Open();
                        var newId = cmmd2.ExecuteScalar();
                        conn.Close();
                        return (int)newId;
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return 0;
                }
            }
        }

        //Funcion que asigna vehiculo y turno al chofer
        private bool asignarVehiAchofYturno(int idVehi)
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"inser into GESTION_DE_GATOS.VEHICULO_CHOFER (VC_VEHI_ID, VC_CHOF_ID, VC_TURN_ID)
                                            values ({0}, {1}, {2})", idVehi, (int)comboChofA.SelectedValue, (int)comboTurnoA.SelectedValue);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return false;
                }
            }
        }

        //Método que busca el vehiculo deseado
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //El sistema limpia el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            string query = string.Format(@"select distinct(VEHI_ID), MARC_DESCRIPCION, MODE_DESCRIPCION, VEHI_PATENTE, CHOF_NOMBRE, CHOF_APELLIDO, TURN_DESCRIPCION
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_VEHI_ID
                                            inner join GESTION_DE_GATOS.CHOFER as e on d.VC_CHOF_ID = e.CHOF_ID
                                            inner join GESTION_DE_GATOS.TURNO as f on d.VC_TURN_ID = f.TURN_ID
                                            where ");
            if (comboMarcaFilM.SelectedIndex == -1 && txtModFilM.Text.Length == 0 && txtModFilM.Text.Length == 0 && txtPatFilM.Text.Length == 0 && comboChofFilM.SelectedIndex == -1)
            {
                MessageBox.Show("[WARNING] Por favor ingrese alguno de los campos de búsqueda");
                return;
            }
            if (comboMarcaFilM.SelectedIndex > 0)
                query += "MARC_ID = '" + comboMarcaFilM.SelectedValue.ToString() +"' and ";
            if (txtModFilM.Text.Length > 0)
                query += "MODE_DESCRIPCION = '" + txtModFilM.Text + "' and ";
            if (txtPatFilM.Text.Length > 0)
                query += "VEHI_PATENTE = '" + txtPatFilM.Text +"' and ";
            if (comboChofFilM.SelectedIndex != -1)
                query += "CHOF_ID = '" + comboChofFilM.SelectedValue.ToString() + "'";
            else
            {
                string queryFinal = "";
                queryFinal = query.Remove(query.Length - 4, 4);
                query = queryFinal;
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
            /*using (var conn = new SqlConnection(connectionString))
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
            }*/
        }

        //Método que trae los datos del vehiculo a modificar
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            habDes(true);
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select MARC_ID, MODE_DESCRIPCION, VEHI_PATENTE, CHOF_ID, TURN_DESCRIPCION, VEHI_HABILITADO, TURN_ID
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_VEHI_ID
                                            inner join GESTION_DE_GATOS.CHOFER as e on d.VC_CHOF_ID = e.CHOF_ID
                                            inner join GESTION_DE_GATOS.TURNO as f on d.VC_TURN_ID = f.TURN_ID
                                            inner join GESTION_DE_GATOS.USUARIO as g on e.CHOF_USUARIO = g.USUA_ID
                                            where VEHI_ID = {0} and TURN_DESCRIPCION = '{1}'",row.Cells[0].Value.ToString(), row.Cells["TURN_DESCRIPCION"].Value.ToString());
                    //El sistema obtiene el ID del Cliente seleccionado
                    labelID.Text = row.Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    //El sistema muestra los demás datos del Cliente seleccionado
                    comboMarcaM.SelectedValue = dt.Rows[0]["MARC_ID"].ToString();
                    txtModM.Text = dt.Rows[0]["MODE_DESCRIPCION"].ToString();
                    txtPatM.Text = dt.Rows[0]["VEHI_PATENTE"].ToString();
                    comboChofM.SelectedValue = dt.Rows[0]["CHOF_ID"].ToString();
                    comboTurnoM.SelectedValue = dt.Rows[0]["TURN_ID"].ToString();
                    labelT.Text = dt.Rows[0]["TURN_ID"].ToString();
                    labelT.Visible = false;
                    labelHab.Text = dt.Rows[0]["VEHI_HABILITADO"].ToString();

                    //El sistema cambia el texto del botón de Habilitar/Deshabilitar
                    if (labelHab.Text == "1")
                        btnHabDesM.Text = "Deshabilitar";
                    else
                        btnHabDesM.Text = "Habilitar";
                    habDes(true);
                }
                catch(SqlException sqlEx)
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
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
                if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    if (combo.SelectedIndex == -1)
                        return false;
                }
            }
            return true;
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

        //Funcion que devuelve el id del modelo
        private int getModelo2(string modelo)
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                query = string.Format(@"select MODE_ID 
                                        from GESTION_DE_GATOS.MODELO
                                        where MODE_DESCRIPCION = '{0}'", modelo);
                try
                {
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reg = null;
                    reg = cmmd.ExecuteReader();
                    if (reg.Read())
                        return (int)reg["MODE_ID"];
                    else
                    {
                        return 0;
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return 0;
                }
            }
        }

        //PULIR!!!!!!!!!!
        //Método que guarda las modificaciones de un vehículo
        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    //Obtengo el ID del modelo
                    int modelo = getModelo2(txtModM.Text);
                    if(!(modelo > 0))
                    {
                        MessageBox.Show("El modelo ingresado no existe!");
                        return;
                    }
                    query = string.Format(@"BEGIN TRANSACTION
                                            update a
                                            set a.VEHI_PATENTE = '{0}', a.VEHI_MODELO = {1}
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_CHOF_ID
                                            where VEHI_ID = {5} and VC_TURN_ID = {6}
                                            
                                            update c
                                            set c.MARC_ID = {2}
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_CHOF_ID
                                            where VEHI_ID = {5} and VC_TURN_ID = {6}
                                            
                                            update d
                                            set d.VC_CHOF_ID = {3}, d.VC_TURN_ID = {4}
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            inner join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_CHOF_ID
                                            where VEHI_ID = {5} and VC_TURN_ID = {6}
                                            COMMIT", 
                                            txtPatM.Text, modelo, comboMarcaM.SelectedValue.ToString(), comboChofM.SelectedValue.ToString(), 
                                            comboTurnoM.SelectedValue.ToString(), labelID.Text, labelT.Text);
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

        //Método que habilita/deshabilita un vehículo
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
                                            set VEHI_HABILITADO = {0}
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            where VEHI_ID = {1}", hab, labelID.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    //El sistema informa el estado del Cliente
                    if (hab == '0')
                        MessageBox.Show("Se Deshabilitó el Vehículo seleccionado");
                    else
                        MessageBox.Show("Se Habilitó el Vehículo seleccionado");
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
