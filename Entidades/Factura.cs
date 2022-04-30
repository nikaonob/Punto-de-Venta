using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string PrecioxUnidad { get; set; }
        public string Cantidad { get; set; }
        public string CodigoCliente { get; set; }
        public string DescuentoC { get; set; }
        public string MontoTotal { get; set; }
        public string NumeroFactura { get; set; }
    }
}
