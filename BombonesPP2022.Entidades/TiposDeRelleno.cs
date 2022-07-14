using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class TiposDeRelleno:ICloneable
    {
        public int TipoRellenoId { get; set; }

        public string Relleno { get; set; }

        public byte[] RowVersion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
