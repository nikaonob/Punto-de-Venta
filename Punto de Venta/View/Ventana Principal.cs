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
using System.Drawing.Printing;

namespace Punto_de_Venta.View
{
    public partial class Ventana_Principal : Form
    {
        DataTable dt;
        public Ventana_Principal()
        {
            InitializeComponent();
            txtDescuento.Text = "0";
            txtImpuesVent.Text = "0";
            dt = new DataTable();
            dt.Columns.Add("Codigo"); dt.Columns.Add("Producto"); dt.Columns.Add("Precio x Unidad");
            dt.Columns.Add("Cantidad"); dt.Columns.Add("Descuento"); dt.Columns.Add("Precio Total");
            dtgPrincipal.DataSource = dt;
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");

            conexionSQLN con = new conexionSQLN();
            txtNFactura.Text = con.consultarFactura();
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
            conexionSQLN agregarProducto = new conexionSQLN();
            DataTable Producto = agregarProducto.ObtenerUnArticulo(txtProducto.Text);
            #region Validar AgregarProductos
            bool validarCantidad(string cant)
            {
                bool validar = false;
                int cantidad;
                try
                {
                    cantidad = int.Parse(cant);
                    validar = true;
                }
                catch { }

                return validar;
            }
            int obtenerCantidad()
            {
                
                int cant = 1;
                if(txtCantidadProducto.Text == "")
                {
                    cant = 1;
                }
                else
                {
                    if(validarCantidad(txtCantidadProducto.Text))
                    {
                        cant = int.Parse(txtCantidadProducto.Text);
                    }
                    else
                    {
                        cant = 0;
                    }
                    
                }
                return cant;
            }
            double obtenerPrecioTotal(string precio,string imp,string cant)
            {
                if(int.Parse(imp) >0)
                {
                    return (((Convert.ToDouble(precio) * Convert.ToDouble(imp)) / 100) + Convert.ToDouble(precio)) * Convert.ToDouble(cant);
                }
                else
                {
                    return Convert.ToDouble(precio) * Convert.ToDouble(cant);
                }
            }
            string obtenerTotalTodosProductos(DataRow dt,double precios)
            {
                string total = "0.00";
                double suma = precios;
                suma += Convert.ToDouble(dt["Precio Total"]);
                total = suma.ToString("N2");
                return total;
            }
            #endregion
            if (Producto.Rows.Count == 1)
            {
                DataRow row = dt.NewRow();
                row["Codigo"] = Producto.Rows[0]["Codigo"].ToString();
                row["Producto"] = Producto.Rows[0]["Producto"].ToString();
                row["Precio x Unidad"] = Producto.Rows[0]["Precio"].ToString();
                row["Cantidad"] = obtenerCantidad().ToString();
                row["Descuento"] = txtDescuento.Text;
                row["Precio Total"] = obtenerPrecioTotal(Producto.Rows[0]["Precio"].ToString(), txtImpuesVent.Text, obtenerCantidad().ToString());
                if(obtenerCantidad() > 0)
                {
                    dt.Rows.Add(row);
                    lblTotal.Text = obtenerTotalTodosProductos(row, Convert.ToDouble(lblTotal.Text));
                }
                else
                {
                    MessageBox.Show("No puedes introducir valores no numericos en la cantidad");
                }
            }
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
            if (txtCodigoCliente.Text != "")
            {
                try
                {
                    int codigoCliente = con.ObtenerClienteConCodigo(int.Parse(txtCodigoCliente.Text));
                    if (txtCodigoCliente.Text == codigoCliente.ToString())
                    {
                        MessageBox.Show("ClienteEncontrado");
                        DataTable Cliente = con.ObtenerCliente(codigoCliente);
                        if(Cliente.Rows.Count == 1)
                        {
                            txtCliente.Text = Cliente.Rows[0]["Nombre_Cliente"].ToString() + " " + Cliente.Rows[0]["Apellido_Cliente"].ToString();
                            txtDescuento.Text = Cliente.Rows[0]["Descuento"].ToString();
                        }
                        
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("No se encontro el Cliente, Desea buscarlo en la lista?", "Busqueda Cliente", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            BusquedaClientes buscarC = new BusquedaClientes();
                            buscarC.ShowDialog();
                        }
                        ;
                    }
                }
                catch
                {
                    MessageBox.Show("Debe ingresar solo datos numericos", "Atencion");
                }
                
            }
        }

        private void tstxtImpVenta_TextChanged(object sender, EventArgs e)
        {
            txtImpuesVent.Text = tstxtImpVenta.Text;
            
        }

        private void tstxtDescuento_TextChanged(object sender, EventArgs e)
        {
            txtDescuento.Text = tstxtDescuento.Text;
            txtCliente.Text = "";
            txtCodigoCliente.Text = "";
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BusquedaClientes buscarInventario = new BusquedaClientes("Inventario");
            buscarInventario.ShowDialog();
            if(buscarInventario.Cosa.Rows.Count == 1)
            {
                txtProducto.Text = buscarInventario.Cosa.Rows[0]["codigo"].ToString();
                button1.PerformClick();
                
            }
            
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            #region Validaciones
            string validarCodigoCliente(string cc)
            {
                if(cc == "")
                {
                    return "SinIndentificar";
                }
                else
                {
                    return cc;
                }

            }
            string vaildarNconComa(string num)
            {
                try
                {
                    string[] elNum = num.Split(',');
                    num = elNum[0] + "." + elNum[1];
                }
                catch
                {

                }
                
                return num;
            }
            #endregion

            conexionSQLN cn = new conexionSQLN();
            Factura1.Factura fact;
            List<Factura1.Factura> listfac = new List<Factura1.Factura>();
            DateTime fechadeFacturacion = DateTime.Now;
            foreach (DataRow row in dt.Rows)
            {
                fact = new Factura1.Factura();
                fact.Codigo = row["Codigo"].ToString();
                fact.Producto = row["Producto"].ToString();
                fact.PrecioxUnidad = vaildarNconComa(row["Precio x Unidad"].ToString());
                fact.Cantidad = row["Cantidad"].ToString();
                fact.Descuento = row["Descuento"].ToString();
                fact.PrecioTotal = vaildarNconComa(row["Precio Total"].ToString());
                fact.Cliente = validarCodigoCliente(txtCodigoCliente.Text);
                fact.ClienteDesc = vaildarNconComa(txtDescuento.Text);
                fact.Codigo = row["Codigo"].ToString();
                fact.NumeroFactura = txtNFactura.Text;
                fact.Fecha = fechadeFacturacion;
                listfac.Add(fact);

            }
            cn.AgregarFacturaABS(listfac);

            //         ------PROCESO DE IMPRECION-----------------            
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 14);
            int ancho = 550;
            int y = 30;

            e.Graphics.DrawString("------Punto de Venta------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Numero de Factura#"+txtNFactura.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Cliente: "+txtCliente.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Fecha: "+ DateTime.Now.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("--------Productos---------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            foreach (DataRow miRow in dt.Rows)
            {
                e.Graphics.DrawString(
                    miRow["Codigo"].ToString() + " "+
                    miRow["Producto"].ToString() + " $:" +
                    miRow["Precio x Unidad"].ToString() + " Cant." +
                    miRow["Cantidad"].ToString() + " Desc " +
                    miRow["Descuento"].ToString() + "% Total:" +
                    miRow["Precio Total"].ToString() + " "
                    , font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            }
            e.Graphics.DrawString("---------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("--Total: $"+lblTotal.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("--Gracias por su visita----", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20));

        }
    }
}
