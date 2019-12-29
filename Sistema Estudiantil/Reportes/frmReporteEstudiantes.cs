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

            this.reportViewer1.RefreshReport();
        }
    }
}
