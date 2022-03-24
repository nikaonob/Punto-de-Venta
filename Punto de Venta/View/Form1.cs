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

namespace Punto_de_Venta
{
    public partial class Form1 : Form
    {
        conexionSQLN cn = new conexionSQLN();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            /*
            if(cn.consultaloginSQL(txtUsuario.Text,txtContraseña.Text) == 1)
            {
                View.Ventana_Principal VP = new View.Ventana_Principal();
                this.Hide();
                VP.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario no ah sido encontrado");
            }
            */
            View.Ventana_Principal VP = new View.Ventana_Principal();
            this.Hide();
            VP.ShowDialog();
            this.Close();
        }
    }
}
