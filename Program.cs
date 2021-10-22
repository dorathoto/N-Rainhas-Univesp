using System;
/*
 *    # A¹ B² C³
 *    A
 *    B
 *    C

# => quina
A¹,A²,A³


Numero de rainhas sera sempre o numero de N do tabuleiro
*/

namespace NRainhas
{
    class Program
    {
        static int[] Tabuleiro;
        static readonly int n = 8;     //N rainhas - nxn linhas x colunas
        static int Count = 0;
        static readonly char[] LetrasTabuleiro = "#ABCDEFGHIJKLM".ToCharArray();

        static void Main(string[] args)
        {
           if (n > 3 && n < 16)
            {//limite pra não transformar em teste de bechamark
                Tabuleiro = new int[n + 1]; //+1 pq tem a quina do tabuleiro
                Rainha(1, n);
            }
        }

        static void Rainha(int row, int n)
        {
            for (int column = 1; column <= n; ++column)
            {
                if (SetLugar(row, column))
                {
                    Tabuleiro[row] = column;    //seta a coluna que a rainha ficará com base na linha do tabuleiro

                    if (row == n)
                    {
                        //se a linha é igual ao número de colunas, chegou ao final
                        Exibe(n);
                    }
                    else
                    {
                        Rainha(row + 1, n);
                    }
                }
            }
        }
        static bool SetLugar(int row, int column)
        {
            for (int i = 1; i <= row - 1; ++i)
            {
                var teste = Tabuleiro[i] == column;
                if (Tabuleiro[i] == column)
                {
                    return false;
                }

                var v1 = Tabuleiro[i] - column;
                var v2 = i - row;
                if (Math.Abs(v1) == Math.Abs(v2))
                {
                    return false;
                }
            }

            return true;
        }

        static void Exibe(int n)
        {
            Console.WriteLine($"\nSolução nr: {++Count}");

            for (int i = 0; i <= n; i++)
            {
                //exibe colunas do tabuleiro
                Console.Write($"{LetrasTabuleiro[i]} ");
            }

            for (int i = 1; i <= n; i++)
            {//exibe linhas
                Console.Write($"\n{LetrasTabuleiro[i]} ");

                for (int j = 1; j <= n; j++)
                {
                    if (Tabuleiro[i] == j)
                        Console.Write("Q ");
                    else
                        Console.Write(". ");
                }
            }

            Console.WriteLine();
        }
    }
}
