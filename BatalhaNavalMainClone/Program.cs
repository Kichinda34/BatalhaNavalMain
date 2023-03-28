using teste_batalha_naval;

internal class Program
{
    private static void Main(string[] args)
    {
        Player player1 = new Player();
        Player player2 = new Player();

        Console.WriteLine("Este é um sistema feito para o jogo de batalha naval, BEM VINDOS!!!");
        Console.WriteLine("Esse jogo é jogado em 2 pessoas, então por favor informem seus nomes.\n");

        Console.WriteLine("Nome do jogador 1: ");
        player1.Name = Console.ReadLine();
        Console.WriteLine("Nome do jogador 2: ");
        player2.Name = Console.ReadLine();

        Console.Clear();

        player2._board.PrintBoard(player1);
        InsertSubmarine(player1, player2);
        Console.Clear();
        player2._board.PrintBoard(player1);
        InsertDestroyer(player1, player2);
        Console.Clear();
        player2._board.PrintBoard(player1);
        InsertCarrier(player1, player2);
        Console.Clear();
        player2._board.PrintBoard(player1);
        Console.WriteLine("Para o proximo jogador inserir seus navios, Aperte Enter!");
        Console.ReadKey();
        Console.Clear();

        player1._board.PrintBoard(player2);
        InsertSubmarine(player2, player1);
        Console.Clear();
        player1._board.PrintBoard(player2);
        InsertDestroyer(player2, player1);
        Console.Clear();
        player1._board.PrintBoard(player2);
        InsertCarrier(player2, player1);
        Console.Clear();
        player1._board.PrintBoard(player2);
        Console.WriteLine("Para irem para o jogo Aperte Enter!!!");
        Console.ReadKey();
        Console.Clear();

        int round = 0;
        bool aux=true;

        do
        {
            Console.Clear() ;
            if (round % 2 == 0)
            {
                player1._board.PrintBoard();
                Console.WriteLine($"Turno de {player1.Name}");
                VerifyShootPosition(player1, player2);
                
                player1._board.PrintBoard();
                Console.WriteLine("Aperte Enter para continuar!!");
                Console.ReadKey();
            }
            else
            {
                player2._board.PrintBoard();
                Console.WriteLine($"Turno de {player2.Name}");
                VerifyShootPosition(player2, player1);
                
                player2._board.PrintBoard();
                Console.WriteLine("Aperte Enter para continuar!!");
                Console.ReadKey();
            }
            if (player1._life == 0)
            {
                Console.WriteLine(player2.Name + " Voce ganhou !!!");
                aux = false;
            }
            if (player2._life == 0)
            {
                Console.WriteLine(player1.Name + " Voce ganhou !!!");
                aux = false;
            }
        } while (aux);

        int[] VerifyInsertPosition()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRST";
            char charPosition;
            string[] auxString;
            int[] auxVector = new int[2];

            Console.WriteLine("Indique a posição alvo separada por virgulas: A,1");
            auxString = Console.ReadLine().Split(',');//separa em um vetor a partir das virgulas

            if (auxString.GetUpperBound(0) == 1)
            {
                if ((!int.TryParse(auxString[0], out (auxVector[0]))))
                {
                    //falhou ao converter o primeiro valor em inteiro, ou seja é uma string
                    if ((!int.TryParse(auxString[1], out auxVector[0])))
                    {
                        //verifica se digtou 2 strings
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        return VerifyInsertPosition();
                    }
                    else
                    {
                        //caso nao tenha digitado 2 strings
                        if (!char.TryParse(auxString[0].Trim().ToUpper(), out charPosition))
                        {
                            //tenta converter para char, ja que char permite so uma letra
                            Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            return VerifyInsertPosition();
                        }
                       
                        auxVector[0] -= 1;

                        if (auxVector[0] > 19 || auxVector[0] < 0)
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
                    if (auxVector[0] > 19 || auxVector[0] < 0)
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
            else
            {
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                return VerifyInsertPosition();
            }
        }

        void VerifyShootPosition(Player player, Player p2)//(int row, int col)
        {
            int[] posVector = VerifyInsertPosition();
            int playerShoot;
            playerShoot = player.shoot(posVector[0], posVector[1], p2);

            if (playerShoot == 1)
            {
                Console.WriteLine(">>>SPLASH<<<");
                round++;
            }
            else if (playerShoot == 2)
            {
                Console.WriteLine(">>>CRASH<<<");
            }
            else
            {
                Console.WriteLine("Atirou em posicao repetida!!!");
                round++;
            }
        }

    }
}