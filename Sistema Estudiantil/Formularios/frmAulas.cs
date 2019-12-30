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
    public partial class frmAulas : Form
    {
        public frmAulas()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (var context = new programacion3Entities())
            {                
                var lista = context.aulas.ToList();
                dgvElementos.DataSource = context.aulas.Local.ToBindingList();
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

        void Guardar()
        {
            using (var context = new programacion3Entities())
            {
                var std = new aulas()
                {
                    aula = txtAgregar.Text
                };
                context.aulas.Add(std);
                context.SaveChanges();
            }
            CargarDatos();
        }

        void Filtrar()
        {
            using (var context = new programacion3Entities())
            {
                var lista = context.aulas.Where(s => s.aula.Contains(txtBuscar.Text)).ToList();
                dgvElementos.DataSource = context.aulas.Local.ToBindingList();
            }
        }

        private void frmAulas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}
