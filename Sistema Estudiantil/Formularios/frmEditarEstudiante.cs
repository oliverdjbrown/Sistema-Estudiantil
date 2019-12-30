using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Estudiantil.Opciones
{
    public partial class frmEditarEstudiante : Form
    {
        public int Matricula;
        public frmEditarEstudiante()
        {
            InitializeComponent();
        }

        void CargarDatos(int MatriculaEstudiante)
        {
            using (var context = new programacion3Entities())
            {
                var std = context.estudiantes.Find(MatriculaEstudiante);
                txtNombres.Text = std.nombre;
                txtApellidos.Text = std.apellido;
                cbSexo.Text = std.sexo;
                txtIdentificacion.Text = std.identificacion;
                dtpFechaNacimiento.Value = std.fechaNacimiento.Value;
                mtTelefono.Text = std.telefono;
                txtDireccion.Text = std.direccion;
            }
        }

        void ValidarCampos()
        {
            if (txtNombres.Text == "" || txtApellidos.Text == "" || txtIdentificacion.Text == "" || cbSexo.Text == "" || txtDireccion.Text == "" || mtTelefono.Text == "")
            { MessageBox.Show("Validar los Campos Obligatorios(*).", "!Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else { Actualizar(); this.Close(); }
        }

        void Actualizar()
        {
            using (var context = new programacion3Entities())
            {
                var std = context.estudiantes.Find(Matricula);
                std.nombre = txtNombres.Text;
                std.apellido = txtApellidos.Text;
                std.sexo = cbSexo.Text;
                std.identificacion = txtIdentificacion.Text;
                std.fechaNacimiento = DateTime.Parse(dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                std.telefono = mtTelefono.Text;
                std.direccion = txtDireccion.Text;
                context.SaveChanges();
            }
        }

        private void frmEditarEstudiante_Load(object sender, EventArgs e)
        {
            CargarDatos(Matricula);
        }

        private void txtActualizar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}
