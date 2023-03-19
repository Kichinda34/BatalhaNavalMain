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

        public void PrintBoard()
        {
            for (int l = 0; l < _board.GetLength(0); l++)
            {
                for (int c = 0; c < _board.GetLength(1); c++)
                {
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
        public int VerifyPosition(int row, int column, Ship ship, string orientation)
        {
            if (orientation == "horizontal")
            {
                int aux = VerifyRowToRight(row, column, ship, orientation);
                if (aux != 0)
                {
                    return aux;
                }
                else
                {
                    return VerifyRowToLeft(row, column, ship, orientation);
                }
            }
            else
            {
                int aux = VerifyColumnToUp(row, column, ship, orientation);
                if (aux != 0)
                {
                    return aux;
                }
                else
                {
                    return VerifyColumnToDown(row, column, ship, orientation);
                }
            }
        }

        public int VerifyRowToRight(int row, int column, Ship ship, string orientation)
        {
            // Verificação da horizontal da esquerda para a direita;
            if (orientation == "horizontal")
            {
                // Verifica se cabe na horizontal para a direita;
                if (column + ship._life - 1 <= this._board.GetLength(1) - 1)
                {
                    // Verifica posição inicial;
                    if (this._board[row, column] != 0)
                    {
                        return 0;
                    }
                    // Percorre as colunas;
                    for (int coluna = column; coluna < column + ship._life - 1; coluna++)
                    {
                        // Verifica em cima, em baixo e uma posição a frente;

                        if (row == 0)
                        {
                            if (this._board[row + 1, coluna] != 0 || this._board[row, coluna + 1] != 0)
                            {
                                return 0;
                            }
                        }
                        else if (row == 19)
                        {
                            if (this._board[row - 1, coluna] != 0 || this._board[row, coluna + 1] != 0)
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (this._board[row - 1, coluna] != 0 || this._board[row + 1, coluna] != 0 || this._board[row, coluna + 1] != 0)
                            {
                                return 0;
                            }
                        }
                    }

                    // Verifica diagonal frente e tras
                    if (row == 0 && column == 0)
                    {
                        if (this._board[row, column + ship._life] != 0 || this._board[row + 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 0)
                    {
                        if (this._board[row, column + ship._life] != 0 || this._board[row + 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row + 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 19)
                    {
                        if (this._board[row, column + ship._life] != 0 || this._board[row - 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row - 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (this._board[row, column + ship._life] != 0 || this._board[row + 1, column + ship._life] != 0 || this._board[row - 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row + 1, column - 1] != 0 || this._board[row - 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                    }

                    return 1;
                }

                return 0;
            }

            return 0;
        }

        public int VerifyRowToLeft(int row, int column, Ship ship, string orientation)
        {
            if (orientation == "horizontal")
            {
                if (column - (ship._life - 1) >= 0)
                {
                    // Verifica a posição inicial;
                    if (this._board[row, column] != 0)
                    {
                        return 0;
                    }
                    // Percorre coluna
                    for (int coluna = column; coluna > column - (ship._life - 1); coluna--)
                    {
                        // Verifica em cima e em baixo
                        if (row == 0)
                        {
                            if (this._board[row + 1, coluna] != 0 || this._board[row, coluna - 1] != 0)
                            {
                                return 0;
                            }
                        }
                        else if (row == 19)
                        {
                            if (this._board[row - 1, coluna] != 0 || this._board[row, coluna - 1] != 0)
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (this._board[row - 1, coluna] != 0 || this._board[row + 1, coluna] != 0 || this._board[row, coluna - 1] != 0)
                            {
                                return 0;
                            }
                        }
                    }

                    // Verifica diagonal frente e tras
                    if (row == 0 && column == 0)
                    {
                        if (this._board[row, column + ship._life] != 0 || this._board[row + 1, column + ship._life] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 0)
                    {
                        if (this._board[row, column - ship._life] != 0 || this._board[row + 1, column - ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row + 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 19)
                    {
                        if (this._board[row, column - ship._life] != 0 || this._board[row - 1, column - ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row - 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (this._board[row, column - ship._life] != 0 || this._board[row + 1, column - ship._life] != 0 || this._board[row - 1, column - ship._life] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column - 1] != 0 || this._board[row + 1, column - 1] != 0 || this._board[row - 1, column - ship._life] != 0)
                        {
                            return 0;
                        }
                    }

                    return 2;
                }
            }

            return 0;
        }

        public int VerifyColumnToDown(int row, int column, Ship ship, string orientation)
        {
            // Verifica se cabe na vertical
            if (orientation == "vertical")
            {
                // Verifica se cabe na vertical para baixo
                if (row + ship._life - 1 <= this._board.GetLength(0) - 1)
                {

                    // Verifica a posição inicial;
                    if (this._board[row, column] != 0)
                    {
                        return 0;
                    }
                    // Percorre as linhas
                    for (int linha = row; linha < row + ship._life - 1; linha++)
                    {
                        // Verifica em cima e em baixo e uma posição a frente
                        if (column == 0)
                        {
                            if (this._board[linha, column + 1] != 0 || this._board[linha + 1, column] != 0)
                            {
                                return 0;
                            }
                        }
                        else if (column == 19)
                        {
                            if (this._board[linha, column - 1] != 0 || this._board[linha + 1, column] != 0)
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (this._board[linha, column - 1] != 0 || this._board[linha, column + 1] != 0 || this._board[linha + 1, column] != 0)
                            {
                                return 0;
                            }
                        }
                    }

                    // Verifica diagonal frente e tras
                    if (row == 0 && column == 0)
                    {
                        if (this._board[row + ship._life, column] != 0 || this._board[row + ship._life, column + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (column == 0)
                    {
                        if (this._board[row + ship._life, column] != 0 || this._board[row + ship._life, column + 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row, column + 1] != 0 || this._board[row + 1, column + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (column == 19)
                    {
                        if (this._board[row + ship._life, column] != 0 || this._board[row + ship._life, column - 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row - 1, column] != 0 || this._board[row - 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (this._board[row + ship._life, column] != 0 || this._board[row + ship._life, column + 1] != 0 || this._board[row + ship._life, column - 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row - 1, column] != 0 || this._board[row - 1, column - 1] != 0 || this._board[row - 1, column + 1] != 0)
                        {
                            return 0;
                        }
                    }

                    return 1;
                }

                return 0;
            }

            return 0;
        }

        public int VerifyColumnToUp(int row, int column, Ship ship, string orientation)
        {
            if (orientation == "vertical")
            {
                // Verifica se cabe na vertical de baixo para cima
                if (row - (ship._life - 1) >= 0)
                {
                    //Verifica posição inicial;
                    if (this._board[row, column] != 0)
                    {
                        return 0;
                    }
                    // Percorre a linha
                    for (int linha = row; linha > row - (ship._life - 1); linha--)
                    {
                        // verifica de uma lado e de outro
                        if (column == 0)
                        {
                            if (this._board[linha, column + 1] != 0 || this._board[linha - 1, column] != 0)
                            {
                                return 0;
                            }
                        }
                        else if (column == 19)
                        {
                            if (this._board[linha, column - 1] != 0 || this._board[linha - 1, column] != 0)
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (this._board[linha, column + 1] != 0 || this._board[linha - 1, column] != 0 || this._board[linha, column - 1] != 0)
                            {
                                return 0;
                            }
                        }
                    }

                    // Verifica diagonal frente e tras
                    if (row == 0 && column == 0)
                    {
                        if (this._board[row + ship._life, column] != 0 || this._board[row + ship._life, column + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    if (column == 0)
                    {
                        if (this._board[row - ship._life, column] != 0 || this._board[row - ship._life, column + 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row - 1, column] != 0 || this._board[row - 1, column + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (column == 19)
                    {
                        if (this._board[row - ship._life, column] != 0 || this._board[row - ship._life, column - 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row - 1, column] != 0 || this._board[row - 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (this._board[row - ship._life, column] != 0 || this._board[row - ship._life, column + 1] != 0 || this._board[row - ship._life, column - 1] != 0)
                        {
                            return 0;
                        }
                        else if (this._board[row - 1, column] != 0 || this._board[row - 1, column + 1] != 0 || this._board[row - 1, column - 1] != 0)
                        {
                            return 0;
                        }
                    }

                    return 2;
                }
            }

            return 0;
        }

        public int Verifyshoot(int row, int col)
        {
            if (this._board[row, col] == 0)
            {
                return 1;
            }
            else if (this._board[row, col] == 3)
            {
                return 2;
            }
            return 0;
        }

        public void InsertBoard(int row, int column, Ship ship, string orientation, int direction)
        {

            if (orientation == "horizontal")
            {
                if (direction == 1)
                {
                    for (int i = 0; i < ship._life; i++)
                    {
                        this._board[row, column] = 3;
                        column++;
                    }
                }
                else
                {
                    for (int i = 0; i < ship._life; i++)
                    {
                        this._board[row, column] = 3;
                        column--;
                    }
                }
            }
            else
            {
                if (direction == 1)
                {
                    for (int i = 0; i < ship._life; i++)
                    {
                        this._board[row, column] = 3;
                        row++;
                    }
                }
                else
                {
                    for (int i = 0; i < ship._life; i++)
                    {
                        this._board[row, column] = 3;
                        row--;
                    }
                }
            }
        }
    }
}
