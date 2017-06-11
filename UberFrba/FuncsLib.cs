using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba
{
    class FuncsLib
    {
        public string connectionString = ConfigurationManager.AppSettings["connString"];


        //Funcion que recibe una query y devuelve un DataTable con el resultado de la consulta.
        public static DataTable getDtWithQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection("connString"))
            {
                DataTable dt = new DataTable();
                SqlCommand cmmd = new SqlCommand(query, conn);
                conn.Open();
                dt.Load(cmmd.ExecuteReader());
                conn.Close();
                return dt;
            }
        }
    }
}
