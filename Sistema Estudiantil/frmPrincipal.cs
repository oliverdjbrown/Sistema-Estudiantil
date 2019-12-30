using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Estudiantil
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void aulasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opciones.frmAulas frm = new Opciones.frmAulas();
            frm.Show();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opciones.frmMaterias frm = new Opciones.frmMaterias();
            frm.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opciones.frmUsuarios frm = new Opciones.frmUsuarios();
            frm.Show();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones.frmRegistroEstudiantes frm = new Opciones.frmRegistroEstudiantes();
            frm.Show();
        }

        private void estudiantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reportes.frmReporteEstudiantes frm = new Reportes.frmReporteEstudiantes();
            frm.Show();
        }

        private void aulasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
