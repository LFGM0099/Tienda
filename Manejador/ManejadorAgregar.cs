using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorAgregar
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"call p_GuardarProducto('{Nombre.Text}', '{Descripcion.Text}', '{Precio.Text}'))"),
                "!ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Borrar(int id_producto, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}", "!ATENCION!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_EliminarProducto({id_producto})");
                MessageBox.Show("Registro eliminado", "!ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(int id_producto, TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Modificar($"call p_ModificarProducto({id_producto}, '{Nombre.Text}', '{Descripcion.Text}', '{Precio.Text}'))"),
                "!ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        DataGridViewButtonColumn Boton(string t, Color fondo)
        {
            DataGridViewButtonColumn b = new DataGridViewButtonColumn();
            b.Text = t;
            b.UseColumnTextForButtonValue = true;
            b.FlatStyle = FlatStyle.Popup;
            b.DefaultCellStyle.BackColor = fondo;
            b.DefaultCellStyle.ForeColor = Color.White;
            return b;
        }

        public void MostrarUsuarios(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = f.Mostrar($"select * from v_Productos where nombre like '%{filtro}%'", "usuarios").Tables[0];
            Tabla.Columns.Insert(5, Boton("Borrar", Color.Red));
            Tabla.Columns.Insert(6, Boton("Editar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
    }
}
