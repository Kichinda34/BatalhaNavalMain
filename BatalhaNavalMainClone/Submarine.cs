using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace teste_batalha_naval
{
    internal class Submarine : Ship
    {
        public Submarine()
        {
            this._life = 2;
            this._positions = new int[2, 2];
        }

    }
}
