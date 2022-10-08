using System;
using System.Threading;

namespace BankingHelp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Konto = new int[5, 2] { { 1234, 123 }, { 1111, 111 }, { 2222, 222 }, { 3333, 333 }, { 4444, 444 } };
            Console.WriteLine("Välkommen till bankprogrammet");
            Loggin(Konto);
        }
        static void Loggin(int[,] Konto)
        {
            for(int i = 0; i < 3; i++)
            { 
                Console.WriteLine("Användarnummer: ");
                int AnvändarNummer = (int.Parse(Console.ReadLine()));
                Console.WriteLine("Pinnummer: ");
                int AnvändarPin=(int.Parse(Console.ReadLine()));
                for(int j=0; j< 5; j++)
                {
                    if (AnvändarNummer == Konto[j,0] && AnvändarPin == Konto[j, 1])
                    {
                        MainMenu(AnvändarPin,Konto);
                    }
                }
            }
        }
        static void MainMenu(int Attempt, int[,] Konto)
        {
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4 Logga ut");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Loggin(Konto);
                    break;
            }
        }
    }
}
