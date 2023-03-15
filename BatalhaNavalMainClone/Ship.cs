using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_batalha_naval
{
    internal abstract class Ship
    {
        public int _life { get; set; }
        public int[,] _positions { get; set; }

        private void TakeLife()
        {
            this._life--;
        }
    }
}
