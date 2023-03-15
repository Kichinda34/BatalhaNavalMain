using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_batalha_naval
{
    internal class Destroyer : Ship
    {
        public Destroyer()
        {
            this._life = 3;
            this._positions = new int[3, 2];
        }
    }
}
