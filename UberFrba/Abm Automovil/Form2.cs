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
                    comboChofM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboChofM.AutoCompleteSource = AutoCompleteSource.ListItems;
                    comboChofFilM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboChofFilM.AutoCompleteSource = AutoCompleteSource.ListItems;
                    //El sistema obtiene todas las Marcas y sus IDs
                    string queryMarcas = "select distinct(MARC_DESCRIPCION), MARC_ID from GESTION_DE_GATOS.MODELO inner join GESTION_DE_GATOS.MARCA on MODE_MARCA = MARC_ID";
                    string queryTurnos = "select distinct(TURN_DESCRIPCION), TURN_ID from GESTION_DE_GATOS.TURNO where TURN_HABILITADO = 1";
                    string queryChofM = "select (convert(nvarchar(255), CHOF_DNI) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER";
                    string queryChofA = "select (convert(nvarchar(255), CHOF_DNI) + ' | ' + CHOF_NOMBRE + ' ' + CHOF_APELLIDO) as CHOFER, CHOF_ID from GESTION_DE_GATOS.CHOFER where CHOF_ID not in(select VC_CHOF_ID from GESTION_DE_GATOS.VEHICULO_CHOFER) and CHOF_HABILITADO = 1";
                    SqlDataAdapter da = new SqlDataAdapter(queryMarcas, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryTurnos, conn);
                    SqlDataAdapter da3 = new SqlDataAdapter(queryChofM, conn);
                    SqlDataAdapter da4 = new SqlDataAdapter(queryChofA, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Marcas");
                    da2.Fill(ds, "Turnos");
                    da3.Fill(ds, "ChoferesM");
                    da4.Fill(ds, "ChoferesA");
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
                    comboChofA.DataSource = ds.Tables["ChoferesA"];
                    comboChofA.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Choferes de la seccion Modificacion
                    comboChofM.DisplayMember = "CHOFER";
                    comboChofM.ValueMember = "CHOF_ID";
                    comboChofM.DataSource = ds.Tables["ChoferesM"];
                    comboChofM.DropDownStyle = ComboBoxStyle.DropDownList;

                    //El sistema llena el combo de Choferes de la seccion Modificacion Filtro
                    comboChofFilM.DisplayMember = "CHOFER";
                    comboChofFilM.ValueMember = "CHOF_ID";
                    comboChofFilM.DataSource = ds.Tables["ChoferesM"];
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
            if (checkObligatorios('A') == false)
            {
                MessageBox.Show("[WARNING] Todos los campos son obligatorios");
                return;
            }
            //El sistema obtiene el ID del modelo
            int modelo = getModelo((int)comboMarcaA.SelectedValue, 'A');
            //Si existe el modelo lo inserta sino lo crea y luego inserta con su ID correspondiente
            if ((modelo > 0))
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //El sistema llama al sp que inserta un vehiculo nuevo
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_insertar_vehiculo", conn);
                        cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter param_chof = new SqlParameter("@CHOFER", int.Parse(comboChofA.SelectedValue.ToString()));
                        SqlParameter param_tur = new SqlParameter("@TURNO", int.Parse(comboTurnoA.SelectedValue.ToString()));
                        SqlParameter param_mod = new SqlParameter("@MODELO", modelo);
                        SqlParameter param_pat = new SqlParameter("@PATENTE", txtPatA.Text);
                        SqlParameter param_marc = new SqlParameter("@MARCA", int.Parse(comboMarcaA.SelectedValue.ToString()));
                        param_chof.Direction = ParameterDirection.Input;
                        param_mod.Direction = ParameterDirection.Input;
                        param_pat.Direction = ParameterDirection.Input;
                        param_tur.Direction = ParameterDirection.Input;
                        param_marc.Direction = ParameterDirection.Input;
                        cmmd.Parameters.Add(param_chof);
                        cmmd.Parameters.Add(param_tur);
                        cmmd.Parameters.Add(param_mod);
                        cmmd.Parameters.Add(param_pat);
                        cmmd.Parameters.Add(param_marc);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("[INFO] Se dio de Alta el Vehículo satisfactoriamente.");
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("[SQL] " + sqlEx.Message);
                    }
                }
            }
        }

        //Funcion que verifica si existe el modelo, sino lo agrega y devuelve el ID
        private int getModelo(int marca_id, char mod)
        {
            string query = "";
            TextBox txtMod = new TextBox();
            if (mod == 'A')
                txtMod = txtModA;
            else
                txtMod = txtModM;

            using (var conn = new SqlConnection(connectionString))
            {
                query = string.Format(@"select MODE_ID 
                                        from GESTION_DE_GATOS.MODELO
                                        where MODE_DESCRIPCION = '{0}'", txtMod.Text);
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
                        conn.Close();
                        using (var conn2 = new SqlConnection(connectionString))
                        {
                            string queryAltaMod = string.Format(@"insert into GESTION_DE_GATOS.MODELO (MODE_DESCRIPCION, MODE_MARCA)
                                                                    values ('{0}', {1}); SELECT SCOPE_IDENTITY()", txtMod.Text, marca_id);
                            SqlCommand cmmd2 = new SqlCommand(queryAltaMod, conn2);
                            conn2.Open();
                            var newId = cmmd2.ExecuteScalar();
                            conn2.Close();
                            return int.Parse(newId.ToString());
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return 0;
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
                                            left join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_VEHI_ID
                                            left join GESTION_DE_GATOS.CHOFER as e on d.VC_CHOF_ID = e.CHOF_ID
                                            left join GESTION_DE_GATOS.TURNO as f on d.VC_TURN_ID = f.TURN_ID
                                            where ");
            if (comboMarcaFilM.SelectedIndex == -1 && txtModFilM.Text.Length == 0 && txtModFilM.Text.Length == 0 && txtPatFilM.Text.Length == 0 && comboChofFilM.SelectedIndex == -1)
            {
                MessageBox.Show("[WARNING] Por favor ingrese alguno de los campos de búsqueda");
                return;
            }
            if (comboMarcaFilM.SelectedIndex != -1)
                query += "MARC_ID = '" + comboMarcaFilM.SelectedValue.ToString() + "' and ";
            if (txtModFilM.Text.Length > 0)
                query += "MODE_DESCRIPCION = '" + txtModFilM.Text + "' and ";
            if (txtPatFilM.Text.Length > 0)
                query += "VEHI_PATENTE = '" + txtPatFilM.Text + "' and ";
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
        }

        //Metodo que trae limpia los campos de busqueda
        private void btnClean_Click(object sender, EventArgs e)
        {
            comboMarcaFilM.SelectedIndex = -1;
            txtModFilM.Text = "";
            txtModFilM.Text = "";
            txtPatFilM.Text = "";
            comboChofFilM.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        //Método que trae los datos del vehiculo a modificar
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //el sistema obtiene los datos de la fila clickeada
            var row = dataGridView1.Rows[e.RowIndex];

            habDes(true);
            string query = "";

            //si el auto no tiene chofer asignado reseteo los combos de Chofer y Turno
            if (row.Cells["CHOF_NOMBRE"].Value.ToString().Length < 1)
            {
                comboChofM.SelectedIndex = -1;
                comboTurnoM.SelectedIndex = -1;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select MARC_ID, MODE_DESCRIPCION, VEHI_PATENTE, CHOF_ID, TURN_DESCRIPCION, VEHI_HABILITADO, TURN_ID
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            left join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_VEHI_ID
                                            left join GESTION_DE_GATOS.CHOFER as e on d.VC_CHOF_ID = e.CHOF_ID
                                            left join GESTION_DE_GATOS.TURNO as f on d.VC_TURN_ID = f.TURN_ID
                                            where VEHI_ID = {0}", row.Cells[0].Value.ToString());

                    if (row.Cells["TURN_DESCRIPCION"].Value.ToString().Length > 0)
                        query += " and TURN_DESCRIPCION = '" + row.Cells["TURN_DESCRIPCION"].Value.ToString() + "'";

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

                    if (dt.Rows[0]["CHOF_ID"] == DBNull.Value)
                        comboChofM.Enabled = false;
                    else
                        comboChofM.SelectedValue = dt.Rows[0]["CHOF_ID"].ToString();

                    if (dt.Rows[0]["TURN_ID"] == DBNull.Value)
                        comboTurnoM.Enabled = false;
                    else
                    {
                        comboTurnoM.SelectedValue = dt.Rows[0]["TURN_ID"].ToString();
                        labelT.Text = dt.Rows[0]["TURN_ID"].ToString();
                        labelT.Visible = false;
                    }

                    labelHab.Text = ((bool)dt.Rows[0]["VEHI_HABILITADO"]).ToString();
                    //El sistema cambia el texto del botón de Habilitar/Deshabilitar
                    if (labelHab.Text == "True")
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
        private bool checkObligatorios(char action)
        {
            if (action == 'A')
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
            else
            {
                if (labelHab.Text == "False")
                {
                    if (comboMarcaM.SelectedIndex == -1 || txtModM.Text == string.Empty || txtPatM.Text == string.Empty)
                    {
                        MessageBox.Show("[WARNING] Los campos Marca, Modelo y Patente son obligatorios.");
                        return false;
                    }
                }
                else
                {
                    if (comboMarcaM.SelectedIndex == -1 || txtModM.Text == string.Empty || txtPatM.Text == string.Empty || comboTurnoM.SelectedIndex == -1 || comboChofM.SelectedIndex == -1)
                    {
                        MessageBox.Show("[WARNING] Todos los campos son obligatorios.");
                        return false;
                    }
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

        //Método que guarda las modificaciones de un vehículo
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkObligatorios('M'))
            {
                if (labelHab.Text == "False")
                {
                    MessageBox.Show("[ERROR] No se puede asignar Turno y Chofer a un vehículo deshabilitado.");
                    return;
                }
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //Obtengo el ID del modelo
                        int modelo = getModelo(int.Parse(comboMarcaM.SelectedValue.ToString()), 'M');

                        SqlParameter param_chof = new SqlParameter();
                        SqlParameter param_tur = new SqlParameter();
                        //El sistema llama al sp que modifica un vehiculo 
                        SqlCommand cmmd = new SqlCommand("GESTION_DE_GATOS.p_modificar_vehiculo", conn);
                        cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter param_vehiId = new SqlParameter("@ID_VEHICULO", int.Parse(labelID.Text));
                        if (labelHab.Text == "False")
                        {
                            param_chof = new SqlParameter("@CHOFER", DBNull.Value);
                            param_tur = new SqlParameter("@TURNO", DBNull.Value);
                        }
                        else
                        {
                            param_chof = new SqlParameter("@CHOFER", int.Parse(comboChofM.SelectedValue.ToString()));
                            param_tur = new SqlParameter("@TURNO", int.Parse(comboTurnoM.SelectedValue.ToString()));
                        }
                        SqlParameter param_mod = new SqlParameter("@MODELO", modelo);
                        SqlParameter param_pat = new SqlParameter("@PATENTE", txtPatM.Text);
                        SqlParameter param_marc = new SqlParameter("@MARCA", int.Parse(comboMarcaM.SelectedValue.ToString()));
                        param_vehiId.Direction = ParameterDirection.Input;
                        param_chof.Direction = ParameterDirection.Input;
                        param_tur.Direction = ParameterDirection.Input;
                        param_mod.Direction = ParameterDirection.Input;
                        param_pat.Direction = ParameterDirection.Input;
                        param_marc.Direction = ParameterDirection.Input;
                        cmmd.Parameters.Add(param_vehiId);
                        cmmd.Parameters.Add(param_chof);
                        cmmd.Parameters.Add(param_tur);
                        cmmd.Parameters.Add(param_mod);
                        cmmd.Parameters.Add(param_pat);
                        cmmd.Parameters.Add(param_marc);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Se guardaron los cambios.");
                        btnSearch_Click(null, EventArgs.Empty);
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("[SQL] " + sqlEx.Message);
                        return;
                    }
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
                    {
                        MessageBox.Show("Se Deshabilitó el Vehículo seleccionado");
                        labelHab.Text = "False";
                        btnHabDesM.Text = "Habilitar";
                        comboChofM.SelectedIndex = -1;
                        comboTurnoM.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Se Habilitó el Vehículo seleccionado");
                        labelHab.Text = "True";
                        btnHabDesM.Text = "Deshabilitar";
                    }

                    //Refresco la vista
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    query = string.Format(@"select distinct(VEHI_ID), MARC_DESCRIPCION, MODE_DESCRIPCION, VEHI_PATENTE, CHOF_NOMBRE, CHOF_APELLIDO, TURN_DESCRIPCION
                                            from GESTION_DE_GATOS.VEHICULO as a
                                            inner join GESTION_DE_GATOS.MODELO as b on a.VEHI_MODELO = b.MODE_ID
                                            inner join GESTION_DE_GATOS.MARCA as c on b.MODE_MARCA = c.MARC_ID
                                            left join GESTION_DE_GATOS.VEHICULO_CHOFER as d on a.VEHI_ID = d.VC_VEHI_ID
                                            left join GESTION_DE_GATOS.CHOFER as e on d.VC_CHOF_ID = e.CHOF_ID
                                            left join GESTION_DE_GATOS.TURNO as f on d.VC_TURN_ID = f.TURN_ID
                                            where ");
                    if (comboMarcaFilM.SelectedIndex == -1 && txtModFilM.Text.Length == 0 && txtModFilM.Text.Length == 0 && txtPatFilM.Text.Length == 0 && comboChofFilM.SelectedIndex == -1)
                    {
                        MessageBox.Show("[WARNING] Por favor ingrese alguno de los campos de búsqueda");
                        return;
                    }
                    if (comboMarcaFilM.SelectedIndex != -1)
                        query += "MARC_ID = '" + comboMarcaFilM.SelectedValue.ToString() + "' and ";
                    if (txtModFilM.Text.Length > 0)
                        query += "MODE_DESCRIPCION = '" + txtModFilM.Text + "' and ";
                    if (txtPatFilM.Text.Length > 0)
                        query += "VEHI_PATENTE = '" + txtPatFilM.Text + "' and ";
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
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
