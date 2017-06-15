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

namespace UberFrba.Abm_Rol
{
    public partial class Form5 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Alta";
            tabPage3.Text = "Modificar";
            habDes(false);
            fillCombos();
            comboRolM.SelectedIndex = -1;
        }

        //El sistema llena los combos y lst con los datos de la bd
        private void fillCombos()
        {
            try
            {
                comboRolM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboRolM.AutoCompleteSource = AutoCompleteSource.ListItems;
                using (var conn = new SqlConnection(connectionString))
                {
                    string queryRol = "SELECT ROL_ID, rtrim(ROL_DESCRIPCION) as ROL_DESCRIPCION FROM GESTION_DE_GATOS.ROL WHERE ROL_DESCRIPCION IS NOT NULL";
                    string queryFunc = "SELECT FUNC_ID, rtrim(FUNC_DESCRIPCION) as FUNC_DESCRIPCION FROM GESTION_DE_GATOS.FUNCIONALIDAD";
                    SqlDataAdapter da = new SqlDataAdapter(queryRol, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryFunc, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Roles");
                    da2.Fill(ds, "Func");
                    
                    comboRolM.DisplayMember = "ROL_DESCRIPCION";
                    comboRolM.ValueMember = "ROL_ID";
                    comboRolM.DataSource = ds.Tables["Roles"];
                    comboRolM.DropDownStyle = ComboBoxStyle.DropDownList;

                    chkLstFuncA.DataSource = ds.Tables["Func"];
                    chkLstFuncA.DisplayMember = "FUNC_DESCRIPCION";
                    chkLstFuncA.ValueMember = "FUNC_ID";

                    chkLstFuncM.DataSource = ds.Tables["Func"];
                    chkLstFuncM.DisplayMember = "FUNC_DESCRIPCION";
                    chkLstFuncM.ValueMember = "FUNC_ID";
                }
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
        }

        //Funcion que trae los datos del Rol a modificar
        private void btnModif_Click(object sender, EventArgs e)
        {
            //El sistema quita el check a todas las funcionalidades
            for (int i = 0; i < chkLstFuncM.Items.Count; i++)
            {
                chkLstFuncM.SetItemChecked(i, false);
            }
            if (comboRolM.SelectedIndex != -1)
            {
                habDes(true);
                DataRowView dv = (DataRowView)comboRolM.SelectedItem;
                string rol = (string)dv.Row["ROL_DESCRIPCION"];

                txtNomM.Text = rol;
                //El sistema trae las funcionalidades seleccionadas para ese Rol
                string query = string.Format(@"select rtrim(FUNC_DESCRIPCION) as FUNC_DESCRIPCION, ROL_HABILITADO
                                                from GESTION_DE_GATOS.FUNCIONALIDAD as a
                                                inner join GESTION_DE_GATOS.FUNCIONALIDAD_ROL as b on a.FUNC_ID = b.FR_FUNC_ID
                                                inner join GESTION_DE_GATOS.ROL as c on b.FR_ROL_ID = c.ROL_ID
                                                where ROL_ID = {0}", comboRolM.SelectedValue.ToString());
                DataTable dt = FuncsLib.getDtWithQuery(query);
                if (dt.Rows.Count > 0)
                {
                    labelHab.Text = ((bool)dt.Rows[0]["ROL_HABILITADO"]).ToString();
                    //El sistema marca en la chkBoxList las funcionalidades de ese Rol
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < chkLstFuncM.Items.Count; i++)
                        {
                            DataRowView dv2 = (DataRowView)chkLstFuncM.Items[i];
                            string func = (string)dv2.Row["FUNC_DESCRIPCION"];
                            if (func == row["FUNC_DESCRIPCION"].ToString())
                                chkLstFuncM.SetItemChecked(i, true);
                        }
                    }
                }
                else
                {
                    //arreglar este caso!
                    fillCombos();
                    labelHab.Text = "True";
                }
                if (labelHab.Text == "True")
                    btnHabDesM.Text = "Deshabilitar";
                else
                    btnHabDesM.Text = "Habilitar";
            }
            else
            {
                MessageBox.Show("[WARNING] Por favor seleccione el Rol a modificar");
            }
        }

        //Funcion que habilita/deshabilita los controles de modificacion
        private void habDes(bool stat)
        {
            txtNomM.Enabled = stat;
            chkLstFuncM.Enabled = stat;
            btnSave.Enabled = stat;
            btnHabDesM.Enabled = stat;
        }

        //Método que habilita/deshabilita un Rol
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
                                            set ROL_HABILITADO = {0}
                                            from GESTION_DE_GATOS.ROL as a
                                            where ROL_ID = {1}", hab, comboRolM.SelectedValue.ToString());
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                    conn.Close();
                    //El sistema informa el estado del Cliente
                    if (hab == '0')
                        MessageBox.Show("Se Deshabilitó el Rol seleccionado");
                    else
                        MessageBox.Show("Se Habilitó el Rol seleccionado");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que guarda las modificaciones de un Rol
        private void btnSave_Click(object sender, EventArgs e)
        {
            string rol_id = comboRolM.SelectedValue.ToString();
            string queryDel = string.Format(@"delete
                                            from GESTION_DE_GATOS.FUNCIONALIDAD_ROL
                                            where FR_ROL_ID = {0}", rol_id);
            using (var conn = new SqlConnection(connectionString))
            {
                SqlCommand cmmd = new SqlCommand(queryDel, conn);
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
            }
            asignarFuncArol(int.Parse(rol_id), 'M');
            MessageBox.Show("[INFO] Se guardaron los cambios.");
        }

        //Método que da de alta un Rol
        private void btnAlta_Click(object sender, EventArgs e)
        {
            string queryAlta = string.Format(@"insert into GESTION_DE_GATOS.ROL (ROL_DESCRIPCION, ROL_HABILITADO) 
                                                values ('{0}', 1); SELECT SCOPE_IDENTITY();", txtNomA.Text);
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand(queryAlta, conn);
                    conn.Open();
                    var rol_id = cmmd.ExecuteScalar();
                    conn.Close();
                    int rolId = int.Parse(rol_id.ToString());
                    asignarFuncArol(rolId, 'A');
                    MessageBox.Show("[INFO] Se dio de alta el Rol satisfactoriamente");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return;
                }
            }
        }

        //Método que asigna las funcionalidades a un rol
        private void asignarFuncArol(int rol_id, char tipo)
        {
            CheckedListBox chkLstFunc = new CheckedListBox();
            if (tipo == 'A')
                chkLstFunc = chkLstFuncA;
            else
                chkLstFunc = chkLstFuncM;
            string queryFuncs = "";
            for (int i = 0; i < chkLstFunc.CheckedItems.Count; i++)
            {
                DataRowView dv = (DataRowView)chkLstFunc.CheckedItems[i];
                string func_id = dv.Row["FUNC_ID"].ToString();
                queryFuncs = string.Format(@"insert into GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_FUNC_ID, FR_ROL_ID)
                                            values ({0},{1})", func_id, rol_id.ToString());
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmmd = new SqlCommand(queryFuncs, conn);
                        conn.Open();
                        cmmd.ExecuteNonQuery();
                        conn.Close();
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
}
