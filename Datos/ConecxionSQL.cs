using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ConecxionSQL
    {
        static string conecionstring = "server= localhost; database= PuntodeVenta;" +
            "integrated security= true";
        SqlConnection con = new SqlConnection(conecionstring);

        public int consultalogin(string Usuario,string Contraseña)
        {
            int contador;
            con.Open();
            string Query = "Select Count(*) from Usuario = '"+Usuario+"'" +
                "and contraseña = '"+Contraseña+"'";
            SqlCommand sqlComand = new SqlCommand(Query, con);
            contador = Convert.ToInt32(sqlComand.ExecuteScalar());
            con.Close();
            return contador;
        }
    }
}
