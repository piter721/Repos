using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrameworSeleniumDemo.bd
{
    class EjecutarQuerySQLServer
    {
        public  SqlConnection Conectar() {
            SqlConnection con = new SqlConnection("SERVER=hc-sql-01.database.windows.net; DATABASE=db_app_Abacook_QA;User ID=app_abacook_Qa;Password=jdnFoRt_454;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            return con;
        }

        public void ConsultarDatos(String query) {
            SqlCommand scmd = new SqlCommand(query, Conectar());
            SqlDataReader dr = null;
            dr = scmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("Existen datos");
            }
            else {
                Console.WriteLine("No existen datos");
            }
        }
    }
}
