using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Servicios;
using BombonesPP2022.Entidades;
using BombonesPP2022.Windows.Helpers;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricas : Form
    {
        public frmFabricas()
        {
            InitializeComponent();
        }

        private FabricasServicio servicio;
        private List<Fabricas> lista;
        private void frmFabricas_Load(object sender, EventArgs e)
        {
            servicio = new FabricasServicio();
            try
            {
                lista = servicio.GetLista();
                //MostrarDatosEnGrilla(); //estaba comentado
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

        private void NuevoIconButton_Click(object sender, EventArgs e)
        {
            frmFabricasAE frm = new frmFabricasAE() { Text = "Agregar una fábrica" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Fabricas fabrica = frm.GetFabrica();
                int registrosAfectados = servicio.Agregar(fabrica);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se agregaron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();
                }
                else
                {
                    //var r = ConstruirFila();
                    var r = HelperGrid.ConstruirFila(DatosDataGridView);
                    //SetearFila(r,categoria);
                    HelperGrid.SetearFila(r, fabrica);
                    //AgregarFila(r);
                    HelperGrid.AgregarFila(DatosDataGridView, r);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RecargarGrilla()
        {
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarIconButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                var r = DatosDataGridView.SelectedRows[0];
                Fabricas fabrica = (Fabricas)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado de {fabrica.NombreFabrica}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                int registrosAfectados = servicio.Borrar(fabrica);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se borraron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();

                }
                else
                {
                    DatosDataGridView.Rows.Remove(r);
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        private void BorrarIconButton_Click_1(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                var r = DatosDataGridView.SelectedRows[0];
                Fabricas fabrica = (Fabricas)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado de {fabrica.NombreFabrica}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                int registrosAfectados = servicio.Borrar(fabrica);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se borraron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();

                }
                else
                {
                    DatosDataGridView.Rows.Remove(r);
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        //private void EditarIconButton_Click(object sender, EventArgs e)
        //{
        //    if (DatosDataGridView.SelectedRows.Count == 0)
        //    {
        //        return;
        //    }

        //    var r = DatosDataGridView.SelectedRows[0];
        //    Categoria categoria = (Categoria)r.Tag;
        //    Categoria catAuxiliar = (Categoria)categoria.Clone();
        //    try
        //    {
        //        frmCategoriasAE frm = new frmCategoriasAE() { Text = "Editar un país" };
        //        frm.SetCategoria(categoria);
        //        DialogResult dr = frm.ShowDialog(this);
        //        if (dr == DialogResult.Cancel)
        //        {
        //            return;
        //        }

        //        categoria = frm.GetCategoria();
        //        int registrosAfectados = servicio.Editar(categoria);
        //        if (registrosAfectados == 0)
        //        {
        //            MessageBox.Show("No se borraron registros...",
        //                "Advertencia",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Warning);
        //            //Recargar grilla
        //            RecargarGrilla();

        //        }
        //        else
        //        {
        //            //SetearFila(r,categoria);
        //            HelperGrid.SetearFila(r, categoria);
        //            MessageBox.Show("Registro modificado",
        //                "Mensaje",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        //SetearFila(r, catAuxiliar);
        //        HelperGrid.SetearFila(r, catAuxiliar);
        //        MessageBox.Show(exception.Message,
        //            "Error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}

        //private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
    }
