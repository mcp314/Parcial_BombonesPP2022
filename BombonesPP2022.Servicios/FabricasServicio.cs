using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Datos.Repositorios;

namespace BombonesPP2022.Servicios
{
    public class FabricasServicio
    {
        private readonly RepositorioDeFabricas repositorio;

        public FabricasServicio()
        {
            repositorio = new RepositorioDeFabricas();
        }

        public List<Fabricas> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Fabricas fabrica)
        {
            try
            {
                return repositorio.Agregar(fabrica);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(Fabricas fabrica)
        {
            try
            {
                return repositorio.Borrar(fabrica);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
