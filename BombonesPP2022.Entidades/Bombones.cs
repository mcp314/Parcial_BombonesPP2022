using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Bombones:ICloneable
    {
        public int BombonId { get; set; }

        public string NombreBombon { get; set; }

        public int TipoChocolateId { get; set; }

        public int TipoNuezId { get; set; }


       public int TiporellenoId { get; set; }

        public double PrecioVenta { get; set; }

        public int Stock { get; set; }

        public int FabricaId { get; set; }

        public byte[] RowVersion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
