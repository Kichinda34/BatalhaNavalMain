using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace teste_batalha_naval
{
    internal class Board
    {
        //0 == vazio/agua
        //1 == acertou na agua
        //2 == acertou no navio
        //3 == navio
        public int[,] _board { get; set; } = new int[20, 20];

        public Board()
        {

        }
        
        public void PrintBoard()
        {
            for (int l = 0; l < _board.GetLength(0); l++)
            {
                for (int c = 0; c < _board.GetLength(1); c++)
                {
                    //Console.Write(" " + _board [l, c]);
                    if (this._board[l, c] == 0 || this._board[l, c] == 3) 
                    {
                        Console.Write(" ~");
                    }
                    else if (this._board[l, c] == 1)
                    {
                        Console.Write(" O");
                    }
                    else
                    {
                        Console.Write(" X");
                    } 
                }
                Console.WriteLine();
            }
        }


    }

}
