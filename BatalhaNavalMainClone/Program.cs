using teste_batalha_naval;

internal class Program
{
    private static void Main(string[] args)
    {
        Player player1 = new Player();
        Player player2 = new Player();

        Console.WriteLine("Nome do jogador 1: ");
        player1.Name = Console.ReadLine();
        Console.WriteLine("Nome do jogador 2: ");
        player2.Name = Console.ReadLine();

        InsertSubmarine(player1, player2);
        player2._board.PrintBoard(player1);
        InsertDestroyer(player1, player2);
        player2._board.PrintBoard(player1);
        InsertCarrier(player1, player2);
        player2._board.PrintBoard(player1);

        InsertSubmarine(player2, player1);
        player1._board.PrintBoard(player2);
        InsertDestroyer(player2, player1);
        player1._board.PrintBoard(player2);
        InsertCarrier(player2, player1);
        player1._board.PrintBoard(player2);

        int round = 0;
        bool aux=true;

        do
        {
            if (round % 2 == 0)
            {
                Console.WriteLine($"Turno de {player1.Name}");
                VerifyShootPosition(player1);
                if (player1._submarine._life == 0)
                {
                    Console.WriteLine("Seu Submarino foi destruido em combate!");
                }
                if (player1._destroyer._life == 0)
                {
                    Console.WriteLine("Seu Destroyer foi abatido durante uma Batalha!");
                }
                if (player1._aircraftCarrier._life == 0)
                {
                    Console.WriteLine("Seu Porta Aviões foi subjulgado pelo Adversário!!");
                }
                player1._board.PrintBoard();
            }
            else
            {
                Console.WriteLine($"Turno de {player2.Name}");
                VerifyShootPosition(player2);
                if (player2._submarine._life == 0)
                {
                    Console.WriteLine("Seu Submarino foi destruido em combate!");
                }
                if (player2._destroyer._life == 0)
                {
                    Console.WriteLine("Seu Destroyer foi abatido durante uma Batalha!");
                }
                if (player2._aircraftCarrier._life == 0)
                {
                    Console.WriteLine("Seu Porta Aviões foi subjulgado pelo Adversário!!");
                }
                player2._board.PrintBoard();

                if(player1._life==0)
                {
                    Console.WriteLine(player2.Name+" Voce ganhou !!!");
                    aux = false;
                }
                if (player2._life == 0)
                {
                    Console.WriteLine(player1.Name + " Voce ganhou !!!");
                    aux = false;
                }
            }
        } while (aux);


        void InsertSubmarine(Player p1, Player p2)
        {
            int[] VetPositions = new int[2];
            int orientation;
            bool aux = false;
            do
            {
                Console.WriteLine(p1.Name + " voce esta colocando o submarino no tabuleiro: ");
                VetPositions = VerifyInsertPosition();

                do
                {
                    Console.WriteLine("Escolha a orientacao:\n[1]- Horizontal\n[2]- Vertical\n: ");
                    if (int.TryParse(Console.ReadLine(), out orientation))
                    {
                        if (orientation == 1 || orientation == 2)
                        {
                            aux = true;
                        }
                        else
                        {
                            aux = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite uma orientacao valida");
                    }
                } while (aux != true);
            } while (p2.InsertShip(VetPositions, p2._submarine, orientation) == 0);

        }

        void InsertDestroyer(Player p1, Player p2)
        {
            int[] VetPositions = new int[2];
            int orientation;
            bool aux = false;
            do
            {
                Console.WriteLine(p1.Name + " voce esta colocando o Destroyer no tabuleiro: ");
                VetPositions = VerifyInsertPosition();

                do
                {
                    Console.WriteLine("Escolha a orientacao:\n[1]- Horizontal\n[2]- Vertical\n: ");
                    if (int.TryParse(Console.ReadLine(), out orientation))
                    {
                        if (orientation == 1 || orientation == 2)
                        {
                            aux = true;
                        }
                        else
                        {
                            aux = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite uma orientacao valida");
                    }
                } while (aux == false);
            } while (p2.InsertShip(VetPositions, p2._destroyer, orientation) == 0);

        }

        void InsertCarrier(Player p1, Player p2)
        {
            int[] VetPositions = new int[2];
            int orientation;
            bool aux = false;
            do
            {
                Console.WriteLine(p1.Name + " voce esta colocando o Porta Avioes no tabuleiro: ");
                VetPositions = VerifyInsertPosition();

                do
                {
                    Console.WriteLine("Escolha a orientacao:\n[1]- Horizontal\n[2]- Vertical\n: ");
                    if (int.TryParse(Console.ReadLine(), out orientation))
                    {
                        if (orientation == 1 || orientation == 2)
                        {
                            aux = true;
                        }
                        else
                        {
                            aux = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite uma orientacao valida");
                    }
                } while (aux == false);
            } while (p2.InsertShip(VetPositions, p2._aircraftCarrier, orientation) == 0);

        }

        int[] VerifyInsertPosition()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRST";
            char charPosition;
            string[] auxString;
            int[] auxVector = new int[2];

            Console.WriteLine("Indique a posição alvo: (A,1)");
            auxString = Console.ReadLine().Split(',');

            if (auxString.GetUpperBound(0) == 0)
            {
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                return VerifyInsertPosition();
            }

            if ((!int.TryParse(auxString[0], out (auxVector[0]))))
            {
                if ((!int.TryParse(auxString[1], out auxVector[0])))
                {
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    return VerifyInsertPosition();
                }
                else
                {
                    if (!char.TryParse(auxString[0].Trim().ToUpper(), out charPosition))
                    {
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        return VerifyInsertPosition();
                    }

                    auxVector[0] -= 1;
                    if (auxVector[0] > 19)
                    {
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        return VerifyInsertPosition();
                    }
                    auxVector[1] = alphabet.IndexOf(charPosition);
                    return auxVector;
                }
            }
            else
            {
                if (!char.TryParse(auxString[1].Trim().ToUpper(), out charPosition))
                {
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    return VerifyInsertPosition();
                }
                auxVector[0] -= 1;
                if (auxVector[0] > 19)
                {
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    return VerifyInsertPosition();
                }
                auxVector[1] = alphabet.IndexOf(charPosition);
                if (auxVector[1] == -1)
                {
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    return VerifyInsertPosition();
                }
                return auxVector;
            }
        }

        void VerifyShootPosition(Player player)//(int row, int col)
        {
            int[] posVector = VerifyInsertPosition();
            int playerShoot;
            playerShoot = player.shoot(posVector[0], posVector[1]);

            if (playerShoot == 1)
            {
                Console.WriteLine(">>>SPLASH<<<");
                round++;
            }
            else if (playerShoot == 2)
            {
                Console.WriteLine(">>>CRASH<<<");
                player.TakeLife();
            }
            else
            {
                Console.WriteLine("Atirou em posicao repetida!!!");
                round++;
            }
        }

        /*bool ChangePlayer(char character, Player player)
        {
            if (character == '-')
            {
                Console.WriteLine("Perdeu a vez!");
                return true;
            }
            else if (character == 'X')
            {
                VerifyShootPosition(player);
                return false;
            }
            return true;
        }*/
    }
}