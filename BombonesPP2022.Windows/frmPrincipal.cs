using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void BombonesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmBombones();
            frm.Show();
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea salir de la aplicación?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FabricasButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmFabricas();
            //frm.FormClosing += Frm_FormClosing;
            //frm.SetUsuario(usuario);
            frm.Show();
        }

        private void NuecesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmTipoNuez();
            frm.Show();
        }

        private void PaisesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmPaises();
            frm.Show();
        }

        private void ChocolatesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmTipoChocolate();
            frm.Show();
        }

        private void RellenosButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new frmTipoRelleno();
            frm.Show();
        }
    }
}
