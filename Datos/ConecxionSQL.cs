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
        
        static string conecionstring = "server= DESKTOP-BC6IL40; database= PuntodeVenta;" +
            " integrated security= true";
        SqlConnection con = new SqlConnection(conecionstring);
        #region Usuarios
        public int obtenerIdUsuarios(string user)
        {
            con.Open();
            string Query = "Select id from usuario where usuario ='" + user + "'";
            SqlCommand sqlcomand = new SqlCommand(Query, con);
            SqlDataAdapter dato = new SqlDataAdapter(sqlcomand);
            DataTable id = new DataTable();
            dato.Fill(id);
            con.Close();
            return int.Parse(id.Rows[0]["id"].ToString());

        }
        public int consultalogin(string Usuario, string Contraseña)
        {
            int contador;
            con.Open();
            string Query = "Select Count(*) from usuario where Usuario = '" + Usuario + "'" +
                " and contraseña = '" + Contraseña + "'";
            SqlCommand sqlComand = new SqlCommand(Query, con);
            contador = Convert.ToInt32(sqlComand.ExecuteScalar());
            con.Close();
            return contador;
        }
        public DataTable ObtenerUsuarios()
        {
            con.Open();
            string Query = "select usuario.usuario,usuario.contraseña,persona.nombre,persona.apellidos," +
                "Persona.dni,Persona.telefono,Persona.id_usuario " +
                "from Usuario inner join persona on usuario.id = persona.id_usuario";
            SqlCommand sqlComand = new SqlCommand(Query, con);
            SqlDataAdapter datos = new SqlDataAdapter(sqlComand);

            DataTable Usuarios = new DataTable();
            datos.Fill(Usuarios);
            con.Close();
            return Usuarios;
        }
        public string obtenerNombreUsuarios(string user)
        {
            con.Open();
            string Query = "Select usuario from usuario where usuario = '" + user + "'";
            SqlCommand sqlcomand = new SqlCommand(Query, con);
            SqlDataAdapter dato = new SqlDataAdapter(sqlcomand);
            DataTable id = new DataTable();
            dato.Fill(id);
            con.Close();
            if (id.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return id.Rows[0]["usuario"].ToString();
            }


        }
        public int InsertarUsuario(string nom, string apell, string tel, string dni, string usuario, string constra)
        {
            int frag = 0;
            con.Open();
            string Query = "insert into usuario values ('" + usuario + "','" + constra + "')";
            SqlCommand sqc = new SqlCommand(Query, con);
            sqc.ExecuteNonQuery();
            con.Close();
            int id = obtenerIdUsuarios(usuario);
            con.Open();
            string Query2 = "insert into persona values ('" + nom + "','" + apell + "','" + tel + "','" + dni + "','" + id + "')";
            SqlCommand sqc2 = new SqlCommand(Query2, con);
            sqc2.ExecuteNonQuery();
            con.Close();


            return frag;
        }
        public void ModificarUsuario(string nom, string apell, string tel, string dni, string id, string contraseña)
        {
            con.Open();
            string Query = "Update Usuario set contraseña = '" + contraseña + "' where id = " + id + "";
            SqlCommand miComand = new SqlCommand(Query, con);
            miComand.ExecuteNonQuery();
            Query = "Update Persona set nombre = '" + nom + "', apellidos = '" + apell +
                "', telefono = '" + tel + "', dni = '" + dni + "' where id_usuario = '" + id + "'";
            miComand = new SqlCommand(Query, con);
            miComand.ExecuteNonQuery();
            con.Close();

        }
        public void EliminarUsuario(string idUser)
        {
            con.Open();
            string Query = "Delete from usuario where id = '" + idUser + "'";
            SqlCommand miComand = new SqlCommand(Query, con);
            miComand.ExecuteNonQuery();
            Query = "Delete from persona where id_usuario =  '" + idUser + "'";
            miComand = new SqlCommand(Query, con);
            miComand.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Inventario
        public DataTable ObtenerInventario()
        {
            con.Open();
            string query = "select * from inventario";
            SqlCommand miComand = new SqlCommand(query, con);
            DataTable miDatatable = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(miComand);
            datos.Fill(miDatatable);
            con.Close();
            return miDatatable;
        }
            public DataTable ObtenerUnArticulo(string codigo)
            {
            con.Open();
            string query = "select * from Inventario where codigo = '" + codigo + "'";
            SqlCommand miComand = new SqlCommand(query, con);
            DataTable miDatatable = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(miComand);
            datos.Fill(miDatatable);
            con.Close();
            return miDatatable;
        }
        #endregion
        #region Clientes
        public DataTable ObtenerClientes()
        {
            con.Open();
            string query = "select * from Clientes";
            SqlCommand miComand = new SqlCommand(query, con);
            DataTable miDatatable = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(miComand);
            datos.Fill(miDatatable);
            con.Close();
            return miDatatable;
        }
        public int ObtenerClienteConCodigo(int codigo)
        {
            
            con.Open();
            string query = "select * from Clientes where id = '"+codigo+"'";
            SqlCommand miComand = new SqlCommand(query, con);
            DataTable miDatatable = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(miComand);
            datos.Fill(miDatatable);
            con.Close();
            if (miDatatable.Rows.Count == 0)
            {

               codigo = 0;
            }
            else
            {
               codigo = int.Parse(miDatatable.Rows[0]["id"].ToString());
            }
            con.Close();
            return codigo;
        }
        public DataTable ObtenerCliente(int codigo)
        {
            con.Open();
            string query = "select * from Clientes where id = '" + codigo + "'";
            SqlCommand miComand = new SqlCommand(query, con);
            DataTable miDatatable = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(miComand);
            datos.Fill(miDatatable);
            con.Close();
            return miDatatable;
        }

        #endregion
        #region Facturacion
        public string consultaFactura()
        {
            
            con.Open();
            string query = "Select (Select distinct top 1 NumeroFactura from Facturacion order by NumeroFactura desc) + 1 as NumeroFactura";
            SqlCommand micomands = new SqlCommand(query, con);
            SqlDataReader read = micomands.ExecuteReader();            
            if(read.Read()) // SI esta leyendo algo
            {
                return read["NumeroFactura"].ToString();
                con.Close();
            }
            else
            {
                return "1";
                con.Close();
            }
           
        }
        public void AgregarFacturaABS(List<Factura1.Factura> listFact)
        {
            
            foreach (Factura1.Factura fact in listFact)
            {
                con.Open();
                string query = "insert into Facturacion (Codigo,producto,precioxunidad,cantidad,codigocliente," +
                    "descuentocliente,montototal,numerofactura) " +
                    "values ('"+fact.Codigo+"','"+fact.Producto+"',"+Convert.ToDouble(fact.PrecioxUnidad)+","+Convert.ToInt32(fact.Cantidad)+"" +
                    ",'"+fact.Cliente+"',"+ Convert.ToDouble(fact.ClienteDesc)+","+ Convert.ToDouble(fact.PrecioTotal)+",'"+fact.NumeroFactura+"')";
                SqlCommand micomando = new SqlCommand(query, con);
                micomando.ExecuteNonQuery();
                con.Close();
            }
            
        }
        #endregion
    }
}
