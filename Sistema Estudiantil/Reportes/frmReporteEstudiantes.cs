using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Estudiantil.Reportes
{
    public partial class frmReporteEstudiantes : Form
    {
        public frmReporteEstudiantes()
        {
            InitializeComponent();
        }

        private void frmReporteEstudiantes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'programacion3DataSet.estudiantes' Puede moverla o quitarla según sea necesario.
            this.estudiantesTableAdapter.Fill(this.programacion3DataSet.estudiantes); 
            this.reportViewer1.RefreshReport();
        }
    }
}
