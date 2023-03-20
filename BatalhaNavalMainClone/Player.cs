using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace teste_batalha_naval
{
    internal class Player
    {
        public int _life { get; set; }
        public Submarine _submarine { get; set; }
        public Destroyer _destroyer { get; set; }
        public AircraftCarrier _aircraftCarrier { get; set; }
        public Board _board { get; set; }
        public string Name { get; set; }

        public Player()
        {
            this._life = 9;
            this._submarine = new Submarine();
            this._destroyer = new Destroyer();
            this._aircraftCarrier = new AircraftCarrier();
            this._board = new Board();
        }

        public void TakeLife()
        {
            this._life--;
        }

        public int shoot(int row, int col)
        {
            int aux =  this._board.Verifyshoot(row, col);

            if (aux != 0)
            {
                this._board.InsertBoard(row, col, aux);
                DestroyShip(row, col);
                TakeLife();
            }
            return aux;
        }

        public int InsertShip(int[] positions, Ship ship, int orientation)
        {
            int row = positions[0];
            int col = positions[1];
            string aux;

            if (orientation == 1)
            {
                aux = "horizontal";
            }
            else
            {
                aux = "vertical";
            }

            int operation = _board.VerifyPosition(row, col, ship, aux);

            if (operation != 0)
            {
                this._board.InsertBoard(row, col, ship, aux, operation);
                InsertPositionOnShipBoard(row, col, ship, aux, operation);
            }
            else
            {
                Console.WriteLine("Nao pode ocupar esta posicao");
            }
            return operation;
        }

        public void InsertPositionOnShipBoard(int row, int column, Ship ship, string orientation, int direction)
        {
            if (orientation == "horizontal")
            {
                if (direction == 1)
                {
                    for (int i = 0; i < ship._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        ship._positions[i, j] = row;
                        j++;
                        ship._positions[i, j] = column;
                        column++;
                    }
                }
                else
                {
                    for (int i = 0; i < ship._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        ship._positions[i, j] = row;
                        j++;
                        ship._positions[i, j] = column;
                        column--;
                    }
                }
            }
            else
            {
                if (direction == 1)
                {
                    for (int i = 0; i < ship._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        ship._positions[i, j] = row;
                        j++;
                        ship._positions[i, j] = column;
                        row++;
                    }
                }
                else
                {
                    for (int i = 0; i < ship._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        ship._positions[i, j] = row;
                        j++;
                        ship._positions[i, j] = column;
                        row--;
                    }
                }
            }
        }

        public void DestroyShip(int row, int col)
        {
            for(int i = 0; i < this._submarine._positions.GetLength(0); i++)
            {
                if (this._submarine._positions[i, 0] == row)
                {
                    if (this._submarine._positions[i, 1] == col)
                    {
                        this._submarine.TakeLife();
                        return;
                    }
                }
            }

            for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
            {
                if (this._destroyer._positions[i, 0] == row)
                {
                    if (this._destroyer._positions[i, 1] == col)
                    {
                        this._destroyer.TakeLife();
                        return;
                    }
                }
            }
            for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
            {
                if (this._aircraftCarrier._positions[i, 0] == row)
                {
                    if (this._aircraftCarrier._positions[i, 1] == col)
                    {
                        this._aircraftCarrier.TakeLife();
                        return;
                    }
                }
            }
        }
    }
}

