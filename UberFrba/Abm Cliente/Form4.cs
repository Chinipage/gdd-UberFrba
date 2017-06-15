﻿using System;
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
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"update a
                                            set CLIE_NOMBRE = '{0}', CLIE_APELLIDO = '{1}',  CLIE_DNI = {2}, CLIE_DIRECCION = '{3}', CLIE_CP = '{4}',
                                            CLIE_FECHA_NACIMIENTO = convert(datetime, '{5}', 103), CLIE_MAIL = '{6}', CLIE_TELEFONO  = {7}
                                            from GESTION_DE_GATOS.CLIENTE as a
                                            where CLIE_ID = {8}", 
                                            txtNomM.Text, txtApeM.Text, txtDniM.Text, txtDirM.Text, txtCpM.Text,
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

        //Funcion que da de alta un Cliente
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (checkObligatorios())
            {
                //el sistema chequea que no exista el teléfono ingresado
                string query = "";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        query = string.Format(@"select CLIE_ID 
                                                from GESTION_DE_GATOS.CLIENTE
                                                where CLIE_TELEFONO = {0}", txtTelA.Text);
                        SqlCommand cmmd = new SqlCommand(query, conn);
                        conn.Open();
                        SqlDataReader reg = null;
                        //El sistema chequea si ya existe algun cliente con el telefono ingresado
                        reg = cmmd.ExecuteReader();
                        if (reg.Read())
                        {
                            MessageBox.Show("[ERROR] Ya existe un Cliente con el mismo teléfono. Alta Abortada");
                            return;
                        }
                        else
                        {
                            //ROLLBACK SI SE PUEDE!!!!!!!!!!!!!!
                            //El sistema crea un usuario, obtiene su id y da de alta el cliente
                            conn.Close();
                            string queryAltaUser = "";
                            queryAltaUser = string.Format(@"insert into GESTION_DE_GATOS.USUARIO 
                                                            (USUA_USERNAME, USUA_CONTRASENIA, USUA_HABILITADO)
                                                            values ('{0}', convert(char(255), HASHBYTES('SHA2_256', convert(char(255), '{1}'))),
                                                             1); SELECT SCOPE_IDENTITY();", (txtNomA.Text + txtApeA.Text).ToLower(), (txtNomA.Text + txtApeA.Text).ToLower());
                            SqlCommand cmmd2 = new SqlCommand(queryAltaUser, conn);
                            //obtengo el id del nuevo usuario creado
                            conn.Open();
                            var newId = cmmd2.ExecuteScalar();
                            conn.Close();

                            string queryAltaCli = ""; string mail = "";
                            //El sistema se fija si el mail es null
                            if (txtMailA.Text == string.Empty)
                                mail = "null";
                            else
                                mail = "'" + txtMailA.Text + "'";
                            //inserto en la bd los datos del nuevo Cliente y el id de su usuario nuevo
                            queryAltaCli = string.Format(@"insert into GESTION_DE_GATOS.CLIENTE
                                                            (CLIE_USUARIO, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI, CLIE_DIRECCION, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_TELEFONO, CLIE_HABILITADO, CLIE_CP)
                                                            values ({0}, '{1}', '{2}', {3}, '{4}', convert(datetime, '{5}', 103), {6}, {7}, {8}, '{9}')", newId, txtNomA.Text, txtApeA.Text, txtDniA.Text, 
                                                            txtDirA.Text, txtFecNacA.Text, mail, txtTelA.Text, 1, txtCpA.Text);
                            SqlCommand cmmd3 = new SqlCommand(queryAltaCli, conn);
                            conn.Open();
                            cmmd3.ExecuteNonQuery();
                            conn.Close();
                            //El sistema libera memoria
                            cmmd.Dispose();
                            cmmd2.Dispose();
                            cmmd3.Dispose();
                            MessageBox.Show("El cliente se dio de alta satisfactoriamente. Se generó el usuario " + (txtNomA.Text + txtApeA.Text).ToLower() + " con ID: " + newId.ToString());
                            return;
                        }
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
