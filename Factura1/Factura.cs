using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura1
{
    public class Factura
    {

        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string PrecioxUnidad { get; set; }
        public string Cantidad { get; set; }
        public string Descuento { get; set; }
        public string PrecioTotal { get; set; }
        public string Cliente { get; set; }
        public string ClienteDesc { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }

    }
}
