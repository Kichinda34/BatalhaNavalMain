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
        InsertDestroyer(player1, player2);
        InsertCarrier(player1, player2);

        InsertSubmarine(player2, player1);
        InsertDestroyer(player2, player1);
        InsertCarrier(player2, player1);

        int round = 0;

        do
        {
            if (round % 2 == 0)
            {
                Console.WriteLine($"Turno de {player1.Name}");
                VerifyShootPosition(player1);
                if (player1._submarine._life == 0)
                {
                    Console.WriteLine("seu submarino esta destruido");
                }
            }
            else
            {
                Console.WriteLine($"Turno de {player2.Name}");
                VerifyShootPosition(player2);
            }


        } while (true);


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

        char VerifyShootPosition(Player player)//(int row, int col)
        {
            int[] posVector = VerifyInsertPosition();
            int playerShoot;
            playerShoot = player.shoot(posVector[0], posVector[1]);

            if (playerShoot == 1)
            {
                Console.WriteLine(">>>SPLASH<<<");
                round++;
                return 'O';
            }
            else if (playerShoot == 2)
            {
                Console.WriteLine(">>>CRASH<<<");
                player.TakeLife();
                return 'X';
            }
            else
            {
                round++;
                return '-';//VerifyShootPosition(player);
            }
        }

        bool ChangePlayer(char character, Player player)
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
        }
    }
}