using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;

namespace Punto_de_Venta.View
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            conexionSQLN con = new conexionSQLN();
            dtgInventario.DataSource = con.ObtenerInventario();
        }
    }
}
