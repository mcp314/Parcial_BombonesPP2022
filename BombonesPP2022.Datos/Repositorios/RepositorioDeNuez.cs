using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioDeNuez
    {
        private readonly ConexionBd conexionBd;

        public RepositorioDeNuez()
        {
            conexionBd = new ConexionBd();
        }

        public List<TipoDeNuez> GetLista()
        {
            List<TipoDeNuez> lista = new List<TipoDeNuez>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT TipoNuezId,Nuez,RowVersion FROM dbo.TipoDeNuez";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoDeNuez tipodenuez = ConstruirNuez(reader);
                            lista.Add(tipodenuez);
                        }
                    }
                }

                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private TipoDeNuez ConstruirNuez(SqlDataReader reader)
        {
            return new TipoDeNuez()
            {
                TipoNuezId = reader.GetInt32(0),
                Nuez = reader.GetString(1),
                RowVersion = (byte[])reader[2]

            };
        }


    }
}
