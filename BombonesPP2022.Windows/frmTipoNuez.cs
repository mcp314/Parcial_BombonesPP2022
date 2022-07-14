using System;
using System.Windows.Forms;
using BombonesPP2022.Servicios;
using BombonesPP2022.Entidades;
using BombonesPP2022.Windows.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Windows
{
    public partial class frmTipoNuez : Form
    {
        public frmTipoNuez()
        {
            InitializeComponent();
        }
        
        private TipoNuezServicio servicio;
        private List<TipoDeNuez> lista;
        private void frmTipoNuez_Load(object sender, EventArgs e)
        {
            servicio = new TipoNuezServicio();
            try
            {
                lista = servicio.GetLista();
                
                HelperForm.MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception exception)
            {
                HelperMessage.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }

        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var fabrica in lista)
            {
                var r = HelperGrid.ConstruirFila(DatosDataGridView);
                HelperGrid.SetearFila(r, fabrica);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
        }


        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
