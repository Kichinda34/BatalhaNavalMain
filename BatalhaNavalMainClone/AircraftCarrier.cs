using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_batalha_naval
{
    internal class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            this._name = "AircraftCarrier";
            this._life = 4;
            this._positions = new int[4, 2];
        }
    }
}
