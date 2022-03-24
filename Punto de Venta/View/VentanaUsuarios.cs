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
    public partial class VentanaUsuarios : Form
    {
        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            conexionSQLN AgregarUsuarios = new conexionSQLN();
            dtgUsuarios.DataSource = AgregarUsuarios.devolverListaUsuarios();
        }
    }
}
