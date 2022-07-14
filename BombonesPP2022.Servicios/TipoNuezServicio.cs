using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Datos.Repositorios;

namespace BombonesPP2022.Servicios
{
    public class TipoNuezServicio
    {
        private readonly RepositorioDeNuez repositorio;

        public TipoNuezServicio()
        {
            repositorio = new RepositorioDeNuez();
        }

        public List<TipoDeNuez> GetLista()
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
    }
}
