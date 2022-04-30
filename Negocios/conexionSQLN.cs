using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class conexionSQLN
    {
        
        ConecxionSQL cn = new ConecxionSQL();        
        
        #region Usuarios
        public int consultaloginSQL(string Usuario, string Contraseña)
        {
            
            return cn.consultalogin(Usuario, Contraseña);
        }
        public DataTable devolverListaUsuarios()
        {
            return cn.ObtenerUsuarios();
        }
        public int obtenerIdUsuarios(string user)//BORRAR
        {
            return cn.obtenerIdUsuarios(user);
        }
        public string obtenerNombreUsuarios(string user)
        {
            return cn.obtenerNombreUsuarios(user);
        }
        public int InsertarUsuario(string nom, string apell, string tel, string dni, string usuario, string constra)
        {
            return cn.InsertarUsuario(nom, apell, tel, dni, usuario, constra);
        }
        public void EliminarUsuario(string idUser)
        {
            cn.EliminarUsuario(idUser);
        }
        public void ModificarUsuario(string nom, string apell, string tel, string dni, string id,string contra)
        {
            cn.ModificarUsuario(nom, apell, tel, dni, id,contra);
        }
        #endregion
        #region Inventario
        public DataTable ObtenerInventario()
        {
            return cn.ObtenerInventario();
        }
        public DataTable ObtenerUnArticulo(string codigo)
        {
            return cn.ObtenerUnArticulo(codigo);
        }

            #endregion
            #region Clientes
            public DataTable ObtenerClientes()
        {
            return cn.ObtenerClientes();
        }
        public int ObtenerClienteConCodigo(int codigo)
        {
            return cn.ObtenerClienteConCodigo(codigo);
        }
        public DataTable ObtenerCliente(int codigo)
        {
            return cn.ObtenerCliente(codigo);
        }
        #endregion
        #region Facturacion
        public string consultarFactura()
        {
            return cn.consultaFactura();
        }
        public void AgregarFacturaABS(List<Factura1.Factura> listFact)
        {
            cn.AgregarFacturaABS(listFact);
        }

        #endregion
    }
}
