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
        string i = "";//BOORRARAR
        public VentanaUsuarios()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            try
            {
                if (dtgUsuarios.CurrentRow == null)
                { }
                else
                {
                    txtNombre.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["nombre"].Value.ToString();
                    txtApellido.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["apellidos"].Value.ToString();
                    txtTelefono.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["telefono"].Value.ToString();
                    txtDNI.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["dni"].Value.ToString();
                    txtUsuario.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["usuario"].Value.ToString();
                    txtContraseña.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["contraseña"].Value.ToString();
                }
            }
            catch { }
        }

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            conexionSQLN AgregarUsuarios = new conexionSQLN();
            dtgUsuarios.DataSource = AgregarUsuarios.devolverListaUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            conexionSQLN AgregarUsuario = new conexionSQLN();
            if (txtNombre.Text != "")
                if (txtApellido.Text != "")
                    if (txtTelefono.Text != "")
                        if (txtDNI.Text != "")
                            if (txtUsuario.Text != "")
                                if (txtContraseña.Text != "")
                                {
                                    if(txtUsuario.Text == AgregarUsuario.obtenerNombreUsuarios(txtUsuario.Text))
                                    {
                                        MessageBox.Show("Ya existe un Usuario con ese nombre");
                                    }
                                    else
                                    {
                                        AgregarUsuario.InsertarUsuario(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDNI.Text, txtUsuario.Text, txtContraseña.Text);
                                        dtgUsuarios.DataSource = AgregarUsuario.devolverListaUsuarios();
                                    }
                                    
                                }
                                else
                                    MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
            else
                                MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
            else
                            MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
            else
                        MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
            else
                    MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
            else
                MessageBox.Show("Complete todos los campos para agregar un usuario", "Atencion");
         

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //agregar modificar! 
            if(i != "")
            {
                conexionSQLN modificar = new conexionSQLN();
                modificar.ModificarUsuario(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDNI.Text, i, txtContraseña.Text);
                dtgUsuarios.DataSource = modificar.devolverListaUsuarios();
            }
            
        }

        private void dtgUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            
            try
            {
                if(dtgUsuarios.CurrentRow == null)
                {  }
                else 
                {
                    i = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["id_usuario"].Value.ToString();
                    txtNombre.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["nombre"].Value.ToString();
                    txtApellido.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["apellidos"].Value.ToString();
                    txtTelefono.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["telefono"].Value.ToString();
                    txtDNI.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["dni"].Value.ToString();
                    txtUsuario.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["usuario"].Value.ToString();
                    txtContraseña.Text = dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells["contraseña"].Value.ToString();
                }
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexionSQLN elminar = new conexionSQLN();
            elminar.EliminarUsuario(i);
            dtgUsuarios.DataSource = elminar.devolverListaUsuarios();
        }
    }
}
