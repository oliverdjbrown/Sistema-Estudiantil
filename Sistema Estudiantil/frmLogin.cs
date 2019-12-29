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
    public partial class frmLogin : Form
    {
        string privilegio = "ADMIN";
        public frmLogin()
        {
            InitializeComponent();
        }

        void Credenciales()
        {
            txtUsuario.Text = "OBROWN";
            txtPassword.Text = "1234";
        }

        void ValidarUsuario()
        {
            try
            {
                using (programacion3Entities db = new programacion3Entities())
                {
                    var query = (from u in db.usuarios
                                 where u.usuario == txtUsuario.Text && u.password == txtPassword.Text
                                 select u.usuario).FirstOrDefault();

                    if (query != null)
                    {
                        cargarMdi();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarMdi()
        {
            frmPrincipal frm = new frmPrincipal();
            frm.lblUsuario.Text = txtUsuario.Text;
            frm.lblPrivilegio.Text = privilegio;
            this.Hide();
            frm.ShowDialog();
            txtPassword.Clear();
            this.Show();
            txtPassword.Focus();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Credenciales();
        }
    }
}
