using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Estudiantil.Opciones
{
    public partial class frmRegistroEstudiantes : Form
    {
        int Matricula = 0;
        public frmRegistroEstudiantes()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (var context = new programacion3Entities())
            {
                var lista = context.estudiantes.ToList();
                dgvElementos.DataSource = context.estudiantes.Local.ToBindingList();
                dgvElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvElementos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvElementos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvElementos.RowHeadersVisible = false;
                dgvElementos.BackgroundColor = Color.White;
                dgvElementos.DefaultCellStyle.SelectionBackColor = Color.Gray;
                dgvElementos.ReadOnly = true;
                dgvElementos.AllowUserToDeleteRows = false;
                dgvElementos.AllowUserToOrderColumns = false;
                dgvElementos.AllowUserToResizeColumns = false;
                dgvElementos.AllowUserToResizeRows = false;
                dgvElementos.AllowUserToAddRows = false;
                dgvElementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvElementos.Sort(dgvElementos.Columns[0], ListSortDirection.Descending);
                dgvElementos.BorderStyle = BorderStyle.None;
                dgvElementos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgvElementos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvElementos.DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen;
                dgvElementos.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dgvElementos.BackgroundColor = Color.White;
                dgvElementos.EnableHeadersVisualStyles = false;
                dgvElementos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvElementos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 93, 142);
                dgvElementos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvElementos.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.0F, FontStyle.Bold);                
            }
        }

        void ValidarCampos()
        {           
            if (txtNombres.Text == "" || txtApellidos.Text == "" || txtIdentificacion.Text == "" || cbSexo.Text == "" || txtDireccion.Text == "" || mtTelefono.Text == "")
            { MessageBox.Show("Validar los Campos Obligatorios(*).", "!Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }           
            else { Guardar(); }
        }        

        void Guardar()
        {           
                using (var context = new programacion3Entities())
                {
                    var std = new estudiantes()
                    {
                        nombre = txtNombres.Text,
                        apellido = txtApellidos.Text,
                        sexo = cbSexo.Text,
                        identificacion = txtIdentificacion.Text,
                        fechaNacimiento = DateTime.Parse(dtpFechaNacimiento.Value.ToString("yyyy-MM-dd")),
                        telefono = mtTelefono.Text,
                        direccion = txtDireccion.Text
                    };
                    context.estudiantes.Add(std);
                    context.SaveChanges();
                }
                LimpiarCampos();
                CargarDatos();            
        }

        void Eliminar(int id)
        {
            using (var context = new programacion3Entities())
            {
                var std = context.estudiantes.Find(id);
                context.estudiantes.Remove(std);
                context.SaveChanges();
            }
            CargarDatos();
        }

        void Filtrar()
        {
            using (var context = new programacion3Entities())
            {
                var lista = context.estudiantes.Where(s => s.nombre.Contains(txtBuscar.Text) && s.apellido.Contains(txtBuscar.Text)).ToList();
                dgvElementos.DataSource = context.estudiantes.Local.ToBindingList();
            }
        }

        void LimpiarCampos()
        {            
            txtNombres.Clear();
            txtApellidos.Clear();
            txtIdentificacion.Clear();
            cbSexo.Text = "";
            txtDireccion.Clear();
            mtTelefono.Clear();
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtAgregarEstudiante_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void cbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar(Matricula);
        }

        private void dgvElementos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvElementos.Rows[e.RowIndex];
                Matricula = int.Parse(row.Cells["Matricula"].Value.ToString());                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Opciones.frmEditarEstudiante frm = new frmEditarEstudiante();
            frm.Matricula = Matricula;
            frm.ShowDialog();
            CargarDatos();
        }

        private void dgvElementos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Opciones.frmEditarEstudiante frm = new frmEditarEstudiante();
            frm.Matricula = Matricula;
            frm.ShowDialog();
            CargarDatos();
        }
    }
}
