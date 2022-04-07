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
    public partial class Ventana_Principal : Form
    {
        
        public Ventana_Principal()
        {
            InitializeComponent();
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {

            Image salir2 = Image.FromFile(@"D:\pc1\escritorio\Programacion\PROGRAMAS\Punto de Venta\Datos\Properties\btnsalir2.jpg");
            btnSalir.BackgroundImage = salir2;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmUsuarios_Click(object sender, EventArgs e)
        {
            View.VentanaUsuarios VU = new View.VentanaUsuarios();
            this.Hide();
            VU.ShowDialog();
            this.Show();
        }

        private void tsmAbrirFactura_Click(object sender, EventArgs e)
        {
            
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario Inv = new Inventario();
            this.Hide();
            Inv.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            this.Hide();
            cliente.ShowDialog();
            this.Show();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            conexionSQLN con = new conexionSQLN();
            int codigoCliente = con.ObtenerClienteConCodigo(int.Parse(txtCodigoCliente.Text));
            if(txtCodigoCliente.Text == codigoCliente.ToString())
            {

            }
        }
    }
}
