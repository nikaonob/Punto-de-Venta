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
    public partial class BusquedaClientes : Form
    {
        public DataTable Cosa;
        public BusquedaClientes()
        {
            InitializeComponent();
            conexionSQLN client = new conexionSQLN();
            dtgClientes.DataSource = client.ObtenerClientes();
        }
        public BusquedaClientes(string producto) //Reutilizar el form para obtener inventarios
        {
            InitializeComponent();
            conexionSQLN inventario = new conexionSQLN();
            dtgClientes.DataSource = inventario.ObtenerInventario();
            button1.Text = "Seleccionar Articulo";
        }

        private void button1_Click(object sender, EventArgs e) //Boton Seleccionar Clientes
        {
            string id = dtgClientes.Rows[dtgClientes.CurrentCell.RowIndex].ToString();
            if(button1.Text == "Seleccionar Articulo")
            {
                string codigo = dtgClientes.Rows[dtgClientes.CurrentRow.Index].Cells["codigo"].Value.ToString();
                conexionSQLN con = new conexionSQLN();
                Cosa = con.ObtenerUnArticulo(codigo);
                this.Close();
            }
        }
    }
}
