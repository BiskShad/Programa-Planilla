
using Proyecto_Planilla.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Planilla
{
    public partial class GestionClientes : Form
    {


        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            actualizarLista();

        }

        private void actualizarLista()
        {
            ClientesDao baseDeDatos = new ClientesDao();
            List<cliente> listaDb = baseDeDatos.ObtenerlistadoDeClientes();
            listClientes.Items.Clear();
            for (int i = 0; i < listaDb.Count; i++)
            {
                cliente cliente = listaDb[i];
                listClientes.Items.Add(cliente);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.TarjetaDeCredito = txtTarjetaDeCredito.Text;

            if (lblId.Text != null)
            {
                cliente.Id = lblId.Text;
            }

            ClientesDao baseDeDatos = new ClientesDao();
            baseDeDatos.Guardar(cliente);
            actualizarLista();
            LimpiarListado();


        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            cliente cliente = (cliente)listClientes.SelectedItem;

            ClientesDao baseDeDatos = new ClientesDao();
            baseDeDatos.Eliminar(cliente);
            actualizarLista();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cliente cliente = (cliente)listClientes.SelectedItem;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtTarjetaDeCredito.Text = cliente.TarjetaDeCredito;

            lblId.Text = cliente.Id;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarListado();

        }
        private void LimpiarListado()
        {

            lblId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtTarjetaDeCredito.Text = "";
        }
       
    }
}
