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
    public partial class frmUsuarios : Form
    {
        int result;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (var context = new programacion3Entities())
            {
                var lista = context.usuarios.ToList();
                dgvElementos.DataSource = context.usuarios.Local.ToBindingList();
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
                dgvElementos.Columns[2].Visible = false;
                dgvElementos.Columns[4].Visible = false;
                dgvElementos.Columns[5].Visible = false;
                dgvElementos.Columns[6].Visible = false;
            }
        }

        void ValidarCampos()
        {
            if (txtUsuario.Text == "" || cbPrivilegios.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "") 
            { MessageBox.Show("Validar los Campos Obligatorios(*).", "!Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }            
            else { ValidarPassword(txtPassword.Text, txtConfirmPassword.Text); }
        }

        int ValidarPassword(string valor1, string valor2)
        {           
            if(valor1 == valor2) { result = 1; } 
            else 
            { 
                result = 0;
                MessageBox.Show("Las Contraseñas no coinciden.", "!Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }

        void Guardar()
        {
            ValidarCampos();
            if (result == 1)
            {
                using (var context = new programacion3Entities())
                {
                    var std = new usuarios()
                    {
                        usuario = txtUsuario.Text,
                        password = txtPassword.Text,
                        privilegio = cbPrivilegios.Text,
                        fechaCreacion = DateTime.Now,
                        estatus = 1                        
                    };
                    context.usuarios.Add(std);
                    context.SaveChanges();
                }
                LimpiarCampos();
                CargarDatos();
            }            
        }

        void Filtrar()
        {
            using (var context = new programacion3Entities())
            {
                var lista = context.usuarios.Where(s => s.usuario.Contains(txtBuscar.Text)).ToList();
                dgvElementos.DataSource = context.usuarios.Local.ToBindingList();
            }
        }

        void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cbPrivilegios.Text = "";
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
