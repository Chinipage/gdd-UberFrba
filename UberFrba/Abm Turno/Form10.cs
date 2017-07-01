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

namespace UberFrba.Abm_Turno
{
    public partial class Form10 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            dataGridView1.AllowUserToAddRows = false;
            habDes(false);
        }

        //Método que trae los datos del Turno a modificar
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            habDes(true);
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select TURN_HABILITADO
                                            from GESTION_DE_GATOS.TURNO as a
                                            where TURN_ID = {0}", 
                                            row.Cells["TURN_ID"].Value.ToString());
                    //El sistema obtiene el ID del Cliente seleccionado
                    labelID.Text = row.Cells["TURN_ID"].Value.ToString();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reg = null;
                    reg = cmmd.ExecuteReader();
                    if (reg.Read())
                    {
                        labelHab.Text = ((bool)reg["TURN_HABILITADO"]).ToString();
                    }
                    conn.Close();

                    //El sistema muestra los demás datos del Turno seleccionado
                    txtDescM.Text = row.Cells["TURN_DESCRIPCION"].Value.ToString();
                    txtHrInM.Text = row.Cells["TURN_INICIO"].Value.ToString();
                    txtHrFinM.Text = row.Cells["TURN_FIN"].Value.ToString();
                    txtValKmM.Text = row.Cells["TURN_VALOR_KILOMETRO"].Value.ToString();
                    txtPbM.Text = row.Cells["TURN_PRECIO_BASE"].Value.ToString();

                    //El sistema cambia el texto del botón de Habilitar/Deshabilitar dependiendo del estado del turno
                    if (labelHab.Text == "True")
                        btnHabDesM.Text = "Deshabilitar";
                    else
                        btnHabDesM.Text = "Habilitar";
                    habDes(true);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que da de alta un Turno
        private void btnAlta_Click(object sender, EventArgs e)
        {
            bool verif = verifSuperposYdur(txtHrInA.Text, txtHrFinA.Text);
            if (verif)
            {
                if (checkObligatorios() == false)
                {
                    MessageBox.Show("[ERROR] Todos los campos son obligatorios");
                    return;
                }
                string query = ""; char hab;
                if (chkHabDesA.Checked == true)
                    hab = '1';
                else
                    hab = '0';
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        query = string.Format(@"insert into GESTION_DE_GATOS.TURNO (TURN_INICIO, TURN_FIN, TURN_DESCRIPCION, TURN_VALOR_KILOMETRO, TURN_PRECIO_BASE, TURN_HABILITADO)
                                                values ({0}, {1}, '{2}', {3}, {4}, {5})",
                                                txtHrInA.Text, txtHrFinA.Text, txtDescA.Text, txtValKmA.Text.Replace(',', '.'), txtPbA.Text.Replace(',', '.'), hab);
                        SqlCommand cmmd = new SqlCommand(query, conn);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("[INFO] El Turno se ha dado de Alta satisfactoriamente");
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.ToString());
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }

        //Funcion que verifica que el turno se encuentre dentro del mismo dia
        private bool verifSuperposYdur(string hrIn, string hrFin)
        {
            if ((int.Parse(hrFin) - int.Parse(hrIn)) <= 0)
            {
                MessageBox.Show("[ERROR] El horario debe estar contenido dentro de las 24hs.");
                return false;
            }
            return true;
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
            btnHabDesM.Enabled = stat;
            btnSave.Enabled = stat;
            txtDescM.Enabled = stat;
            txtHrFinM.Enabled = stat;
            txtHrInM.Enabled = stat;
            txtPbM.Enabled = stat;
            txtValKmM.Enabled = stat;
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
                                            set TURN_HABILITADO = {0}
                                            from GESTION_DE_GATOS.TURNO as a
                                            where TURN_ID = {1}", hab, labelID.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    //El sistema informa el estado del Cliente
                    if (hab == '0')
                        MessageBox.Show("Se Deshabilitó el Turno seleccionado");
                    else
                        MessageBox.Show("Se Habilitó el Turno seleccionado");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que busca Turnos por descripción
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //El sistema limpia el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            if (txtDescFilM.Text == string.Empty)
            {
                MessageBox.Show("[WARNING] Por favor ingrese el campo de búsqueda");
                return;
            }
            string query = string.Format(@"select TURN_ID, TURN_INICIO, TURN_FIN, TURN_DESCRIPCION, TURN_VALOR_KILOMETRO, TURN_PRECIO_BASE
                                            from GESTION_DE_GATOS.TURNO
                                            where TURN_DESCRIPCION like '%{0}%'", txtDescFilM.Text);
            using (var conn = new SqlConnection(connectionString))
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
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que guarda los cambios del Turno
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool verif = verifSuperposYdur(txtHrInM.Text, txtHrFinM.Text);
            if (!verif)
            {
                return;
            }
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"update a
                                            set TURN_INICIO = {0}, TURN_FIN = {1}, TURN_DESCRIPCION = '{2}', TURN_VALOR_KILOMETRO = {3}, TURN_PRECIO_BASE = {4}
                                            from GESTION_DE_GATOS.TURNO as a
                                            where TURN_ID = {5}",
                                            txtHrInM.Text, txtHrFinM.Text, txtDescM.Text, txtValKmM.Text.Replace(',', '.'), txtPbM.Text.Replace(',', '.'), labelID.Text);
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
    }
}
