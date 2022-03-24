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

        public int consultaloginSQL(string Usuario,string Contraseña)
        {
            return cn.consultalogin(Usuario, Contraseña);
        }
        public DataTable devolverListaUsuarios()
        {
            return cn.ObtenerUsuarios();
        }
    }
}
