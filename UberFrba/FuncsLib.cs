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
        //Funcion que recibe una query y devuelve un DataTable con el resultado de la consulta.
        public static DataTable getDtWithQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                    return null;
                }
            }
        }
    }
}
