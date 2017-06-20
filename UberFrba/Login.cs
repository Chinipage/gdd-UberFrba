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
using System.Security.Cryptography;

namespace UberFrba
{
    public partial class Login : Form
    {
        public int loginFailAttempts = 0;
        public string connectionString = ConfigurationManager.AppSettings["connString"];

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            txtPass.PasswordChar = '*';
        }

        //Método que loguea al usuario
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //El sistema chequea si están ambos campos completos
            if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                MessageBox.Show("[WARNING] Por favor escriba Usuario y Contraseña");
                return;
            }

            //El sistema chequea si la pass es correcta
            if (checkPassOK())
            {
                checkProfile();
            }
            else
            {
                //Si no es correcta el sistema incrementa los intentos fallidos
                loginFailAttempts++;
                //Si superó los intentos fallidos el sistema bloquea el usuario
                if (loginFailAttempts == 3)
                {
                    bool flag = blockUser(txtUser.Text);
                    if (flag)
                    {
                        MessageBox.Show("[ERROR] Usuario o clave incorrectos! Su Usuario ha sido deshabilitado");
                        btnLogin.Enabled = false;  
                    }
                    else
                    {
                        MessageBox.Show("[ERROR] Error al bloquear el Usuario");
                        return;
                    }
                }
                else
                    MessageBox.Show("[ERROR] Usuario o clave incorrectos! Vuelva a intentarlo. Intentos Restantes " + (3 - loginFailAttempts).ToString());
                return;
            }
        }

        //Funcion que verifica si la contraseña es correcta
        private bool checkPassOK()
        {
            string query = "";

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select USUA_HABILITADO
                                            from GESTION_DE_GATOS.USUARIO
                                            where USUA_CONTRASENIA = (GESTION_DE_GATOS.f_encriptar_contrasenia('{0}'))
                                            and USUA_USERNAME = '{1}'",
                                            txtPass.Text, txtUser.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reg = null;
                    reg = cmmd.ExecuteReader();
                    if (reg.Read())
                    {
                        if ((bool)reg["USUA_HABILITADO"])
                        {
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El usuario " + txtUser.Text + " se encuentra deshabilitado para utilizar el Sistema");
                            conn.Close();
                            Application.Exit();
                        }
                    }
                    else
                        return false;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
            }
            return true;
        }

        //Funcion que bloquea el usuario luego de 3 intentos fallidos
        private bool blockUser(string user)
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"update a
                                            set USUA_HABILITADO = 0
                                            from GESTION_DE_GATOS.USUARIO as a
                                            where USUA_USERNAME = '{0}'", user);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    conn.Open();
                    int rows = cmmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                        return true;
                    else
                    {
                        MessageBox.Show("El usuario no existe. No se puede bloquear");
                        return false;
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return false;
                }
            }
        }

        private void checkProfile()
        {
            string query = "";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    query = string.Format(@"select ROL_ID, ROL_DESCRIPCION, ROL_HABILITADO, USUA_USERNAME
                                            from GESTION_DE_GATOS.ROL_USUARIO as a
                                            inner join GESTION_DE_GATOS.ROL as c on c.ROL_ID = a.RU_ROL_ID
                                            inner join GESTION_DE_GATOS.USUARIO as b on a.RU_USUA_ID = b.USUA_ID
                                            where USUA_USERNAME = '{0}' and ROL_HABILITADO = 1", txtUser.Text);
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    dt.Load(cmmd.ExecuteReader());
                    conn.Close();
                    //El sistema chequea que el usuario tegna algun Rol asignado
                    if (dt.Rows.Count > 0)
                    {
                        //Si tiene más de 1 Rol se le pide al usuario seleccionar con cual quiere loguearse
                        if (dt.Rows.Count > 1)
                        {
                            RolSelection frmRol = new RolSelection(txtUser.Text);
                            frmRol.RefToLogin = this;
                            this.Visible = false;
                            frmRol.Show();
                            this.Hide();
                        }
                        else
                        {
                            //Form1 frm = new Form1(txtUser.Text, dt.Rows[0]["ROL_ID"].ToString());
                            //frm.Show();
                            Form1 frm1 = new Form1(txtUser.Text, dt.Rows[0]["ROL_ID"].ToString());
                            frm1.RefToLogin = this;
                            this.Visible = false;
                            frm1.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("[WARNING] El usuario no tiene ningún Rol asignado o su/s Rol/es está/n deshabilitado/s.");
                    }
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
