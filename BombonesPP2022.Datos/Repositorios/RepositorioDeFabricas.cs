using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class  RepositorioDeFabricas
    {
        private readonly ConexionBd conexionBd;

        public RepositorioDeFabricas()
        {
            conexionBd = new ConexionBd();
        }

        public List<Fabricas> GetLista()
        {
            List<Fabricas> lista = new List<Fabricas>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT FabricaId,NombreFabrica,Direccion,GerenteDeVentas,PaisId,RowVersion FROM Fabricas";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fabricas fabrica = ConstruirFabrica(reader);
                            lista.Add(fabrica);
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

        private Fabricas ConstruirFabrica(SqlDataReader reader)
        {
            return new Fabricas()
            {
                FabricaId = reader.GetInt32(0),
                NombreFabrica = reader.GetString(1),
                Direccion = reader.GetString(2),
                GerenteDeVentas = reader.GetString(3),
                PaisId = reader.GetInt32(4),
                RowVersion = (byte[])reader[5]

            };
        }

        public int Agregar(Fabricas fabrica)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO dbo.Fabricas(NombreFabrica,Direccion,GerenteDeVentas,PaisId) VALUES (@nom, @dir,@ger,@Paisid)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", fabrica.NombreFabrica);
                    comando.Parameters.AddWithValue("@dir", fabrica.Direccion);
                    comando.Parameters.AddWithValue("@ger", fabrica.GerenteDeVentas);
                    comando.Parameters.AddWithValue("@Paisid", fabrica.PaisId);

                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        fabrica.FabricaId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Fabricas WHERE FabricaId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                        fabrica.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Fabrica repetida");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(Fabricas fabrica)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Fabricas WHERE FabricaID=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                    comando.Parameters.AddWithValue("@r", fabrica.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado... baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

    }
}
