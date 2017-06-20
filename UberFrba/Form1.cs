using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Facturacion;
using UberFrba.Listado_Estadistico;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;
using UberFrba.Abm_Turno;
using System.Configuration;
using System.Data.SqlClient;

namespace UberFrba
{
    public partial class Form1 : Form
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];
        public string prof = "";

        public Form1(string user, string profile)
        {
            InitializeComponent();
            lblUser.Text = user;
            prof = profile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkPermissions(lblUser.Text);
        }

        //Función del sistema que chequea el Rol y permisos del usuario
        private void checkPermissions(string user)
        {
            string query = "";
            query = string.Format(@"select USUA_USERNAME, ROL_DESCRIPCION, FUNC_DESCRIPCION, FUNC_ID, ROL_HABILITADO
                                    from GESTION_DE_GATOS.ROL as a
                                    inner join GESTION_DE_GATOS.FUNCIONALIDAD_ROL as b on a.ROL_ID = b.FR_ROL_ID
                                    inner join GESTION_DE_GATOS.FUNCIONALIDAD as c on b.FR_FUNC_ID = c.FUNC_ID
                                    inner join GESTION_DE_GATOS.ROL_USUARIO as d on b.FR_ROL_ID = d.RU_ROL_ID
                                    inner join GESTION_DE_GATOS.USUARIO as e on d.RU_USUA_ID = e.USUA_ID
                                    where USUA_USERNAME = '{0}' and ROL_ID = {1}", user, prof);
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();

                    //El sistema recorre el resultado para habilitar los permisos correspondientes
                    foreach (DataRow row in dt.Rows)
                    {
                        switch (row["FUNC_ID"].ToString())
                        {
                            case "1":
                                button4.Visible = true;
                                break;
                            case "2":
                                button3.Visible = true;
                                break;
                            case "3":
                                button1.Visible = true;
                                break;
                            case "4":
                                button2.Visible = true;
                                break;
                            case "7":
                                button7.Visible = true;
                                break;
                            case "8":
                                button5.Visible = true;
                                break;
                            case "9":
                                button8.Visible = true;
                                break;
                            case "10":
                                button6.Visible = true;
                                break;
                            case "11":
                                button10.Visible = true;
                                break;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (this.RefToLogin != null)
                this.RefToLogin.Show();
            else
                this.RefToRolSel.Show();
            this.Close();
        }

        public Form RefToLogin { get; set; }

        public Form RefToRolSel { get; set; }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
        }
    }
}
