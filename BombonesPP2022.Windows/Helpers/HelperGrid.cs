using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades;


namespace BombonesPP2022.Windows.Helpers
{
    public static class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

        }
        public static DataGridViewRow ConstruirFila(DataGridView dataGrid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dataGrid);
            return r;
        }

        public static void AgregarFila(DataGridView dataGrid, DataGridViewRow r)
        {
            dataGrid.Rows.Add(r);
        }

        public static void SetearFila(DataGridViewRow r, Object obj)
        {
            switch (obj)
            {
                case Fabricas p:
                    //r.Cells[4].Value = ((Fabricas)obj).FabricaId;
                    r.Cells[0].Value = ((Fabricas)obj).NombreFabrica;
                    r.Cells[1].Value = ((Fabricas)obj).Direccion;
                    r.Cells[3].Value = ((Fabricas)obj).GerenteDeVentas;
                    r.Cells[2].Value = ((Fabricas)obj).PaisId;
                    
                    //r.Cells[5].Value = ((Fabricas)obj).RowVersion;
                    break;
                case TipoDeNuez n:
                    //r.Cells[0].Value = ((TipoDeNuez)obj).TipoNuezId;
                    r.Cells[0].Value = ((TipoDeNuez)obj).Nuez;
                    //r.Cells[2].Value = ((TipoDeNuez)obj).RowVersion;
                    break;
                    //        case Ciudad ciudad:
                    //            r.Cells[0].Value = ((Ciudad)obj).Pais.NombrePais;
                    //            r.Cells[1].Value = ((Ciudad)obj).NombreCiudad;

                    //            break;
                    //        case Cliente cliente:
                    //            r.Cells[0].Value = ((Cliente)obj).NombreCliente;
                    //            r.Cells[1].Value = ((Cliente)obj).Direccion;
                    //            r.Cells[2].Value = ((Cliente)obj).Pais.NombrePais;
                    //            r.Cells[3].Value = ((Cliente)obj).Ciudad.NombreCiudad;
                    //            r.Cells[4].Value = ((Cliente)obj).CodPostal;

                    //            break;

            }

             r.Tag = obj;

        }
    }
}
