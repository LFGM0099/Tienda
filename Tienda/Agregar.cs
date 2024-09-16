using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace Tienda
{
    public partial class Agregar : Form
    {
        ManejadorAgregar ma;
        int fila = 0, columna = 0;
        public static int id_producto = 0;
        public static string Nombre = "", Descripcion = "", Precio = "";

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dtgvTabla.Visible = true;
            ma.MostrarProducto(dtgvTabla, txtBusqueda.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Agregar()
        {
            InitializeComponent();
            ma = new ManejadorAgregar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (id_producto > 0)
            {
                ma.Modificar(id_producto, txtNombre, txtDescripcion, txtPrecio);
            }
            else
            {
                ma.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }

        private void dtgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;

            switch (columna)
            {
                case 5:
                    {
                        id_producto = int.Parse(dtgvTabla.Rows[fila].Cells[0].Value.ToString());
                        ma.Borrar(id_producto, dtgvTabla.Rows[fila].Cells[2].Value.ToString());
                        dtgvTabla.Visible = false;

                    }
                    break;
                case 6:
                    {
                        id_producto = int.Parse(dtgvTabla.Rows[fila].Cells[0].Value.ToString());
                        Nombre = dtgvTabla.Rows[fila].Cells[1].Value.ToString();
                        Descripcion = dtgvTabla.Rows[fila].Cells[2].Value.ToString();
                        Precio = dtgvTabla.Rows[fila].Cells[3].Value.ToString();

                        txtNombre.Text = Nombre;
                        txtDescripcion.Text = Descripcion;
                        txtPrecio.Text = Precio;
                    }
                    break;
            }
        }
    }
}
