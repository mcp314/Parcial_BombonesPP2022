using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricasAE : Form
    {
        public frmFabricasAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (fabrica != null)
            {
                FabricaTextBox.Text = fabrica.NombreFabrica;
                DireccionTextBox.Text = fabrica.Direccion;
                GerenteTextBox.Text = fabrica.GerenteDeVentas;
                PaisesComboBox.SelectedValue=fabrica.PaisId;
            }
        }

        private Fabricas fabrica;
        public void SetFabrica(Fabricas fabrica)
        {
            this.fabrica = fabrica;
        }

        public Fabricas GetFabrica()
        {
            return fabrica;
        }
        private void CancelarIconButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OKIconButton_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica == null)
                {
                    fabrica = new Fabricas();
                }

                fabrica.NombreFabrica = FabricaTextBox.Text;
                fabrica.Direccion = DireccionTextBox.Text;
                fabrica.GerenteDeVentas = GerenteTextBox.Text;
                fabrica.PaisId = int.Parse(PaisesComboBox.SelectedText);

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            //errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(FabricaTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(FabricaTextBox, "El nombre de la fabrica es requerido");
            }

            return valido;
        }

        private void OKIconButton_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica == null)
                {
                    fabrica = new Fabricas();
                }

                fabrica.NombreFabrica = FabricaTextBox.Text;
                fabrica.Direccion = DireccionTextBox.Text;
                fabrica.GerenteDeVentas = GerenteTextBox.Text;
                fabrica.PaisId = int.Parse(PaisesComboBox.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
