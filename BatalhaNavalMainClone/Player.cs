using System;
using System.Collections.Generic;
using System.Linq;
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
            return this._board.Verifyshoot(row, col);

            /*for(int i = 0; i < this._submarine._positions.GetLength(0); i++)
            {
                if (this._submarine._positions[i, 0] == row)
                {
                    if (this._submarine._positions[i, 1] == col)
                    {
                        TakeLife();
                        return true;
                    }
                }
            }
            for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
            {
                if (this._destroyer._positions[i, 0] == row)
                {
                    if (this._destroyer._positions[i, 1] == col)
                    {
                        TakeLife();
                        return true;
                    }
                }
            }
            for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
            {
                if (this._aircraftCarrier._positions[i, 0] == row)
                {
                    if (this._aircraftCarrier._positions[i, 1] == col)
                    {
                        TakeLife();
                        return true;
                    }
                }
            }*/
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
            if (ship._name == "AircraftCarrier")
            {
                if (ship._name == "horizontal" && direction == 1)
                {
                    for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._aircraftCarrier._positions[i, j] = row;
                        j++;
                        this._aircraftCarrier._positions[i, j] = column;
                        column++;
                    }

                }
                else if (orientation == "horizontal" && direction == 2)
                {
                    for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._aircraftCarrier._positions[i, j] = row;
                        j++;
                        this._aircraftCarrier._positions[i, j] = column;
                        column--;
                    }
                }
                else if (orientation == "vertical" && direction == 1)
                {
                    for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._aircraftCarrier._positions[i, j] = row;
                        j++;
                        this._aircraftCarrier._positions[i, j] = column;
                        row++;
                    }
                }
                else if (orientation == "vertical" && direction == 2)
                {
                    for (int i = 0; i < this._aircraftCarrier._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._aircraftCarrier._positions[i, j] = row;
                        j++;
                        this._aircraftCarrier._positions[i, j] = column;
                        row--;
                    }
                }
            }
            else if (ship._name == "Destroyer")
            {
                if (orientation == "horizontal" && direction == 1)
                {
                    for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._destroyer._positions[i, j] = row;
                        j++;
                        this._destroyer._positions[i, j] = column;
                        column++;
                    }

                }
                else if (orientation == "horizontal" && direction == 2)
                {
                    for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._destroyer._positions[i, j] = row;
                        j++;
                        this._destroyer._positions[i, j] = column;
                        column--;
                    }
                }
                else if (orientation == "vertical" && direction == 1)
                {
                    for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._destroyer._positions[i, j] = row;
                        j++;
                        this._destroyer._positions[i, j] = column;
                        row++;
                    }
                }
                else if (orientation == "vertical" && direction == 2)
                {
                    for (int i = 0; i < this._destroyer._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._destroyer._positions[i, j] = row;
                        j++;
                        this._destroyer._positions[i, j] = column;
                        row--;
                    }
                }
            }
            else if (ship._name == "Submarine")
            {
                if (orientation == "horizontal" && direction == 1)
                {
                    for (int i = 0; i < this._submarine._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._submarine._positions[i, j] = row;
                        j++;
                        this._submarine._positions[i, j] = column;
                        column++;
                    }

                }
                else if (orientation == "horizontal" && direction == 2)
                {
                    for (int i = 0; i < this._submarine._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._submarine._positions[i, j] = row;
                        j++;
                        this._submarine._positions[i, j] = column;
                        column--;
                    }
                }
                else if (orientation == "vertical" && direction == 1)
                {
                    for (int i = 0; i < this._submarine._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._submarine._positions[i, j] = row;
                        j++;
                        this._submarine._positions[i, j] = column;
                        row++;
                    }
                }
                else if (orientation == "vertical" && direction == 2)
                {
                    for (int i = 0; i < this._submarine._positions.GetLength(0); i++)
                    {
                        int j = 0;
                        this._submarine._positions[i, j] = row;
                        j++;
                        this._submarine._positions[i, j] = column;
                        row--;
                    }
                }
            }
        }

    }
}

