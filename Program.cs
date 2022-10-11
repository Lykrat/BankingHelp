using System;
using System.Threading;

namespace BankingHelp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] User = new int[5, 2] { { 1234, 123 }, { 1111, 111 }, { 2222, 222 }, { 3333, 333 }, { 4444, 444 } };
            object[,] ViktigaKonto = new object[10, 4] { { 123,"Lönekonto",30.35,1 }, { 123,"Sparkonto",10000.00,2 },{ 111,"Lönekonto",100000.90,1 },{ 111,"Sparkonto",3000.00,2 },
                { 222,"Lönekonto",63.77,1 },{ 222,"Sparkonto",1000000.00,2 },{ 333,"Lönekonto",59000.23,1 },{ 333,"Sparkonto",7000.00,2 },{ 444,"Lönekonto",10000.64,1 },{ 444,"Sparkonto",500.00,2 } };
            Console.WriteLine("Välkommen till bankprogrammet");
            Loggin(User,ViktigaKonto);
        }
        static void Loggin(int[,] User, object[,] ViktigaKonton)
        {
            for(int i = 0; i < 3; i++)
            { 
                Console.WriteLine("Användarnummer: ");
                int AnvändarNummer = (int.Parse(Console.ReadLine()));
                Console.WriteLine("Pinnummer: ");
                int AnvändarPin=(int.Parse(Console.ReadLine()));
                for(int j=0; j< 5; j++)
                {
                    if (AnvändarNummer == User[j,0] && AnvändarPin == User[j, 1])
                    {
                        MainMenu(AnvändarPin,User,ViktigaKonton);
                        i = 3;
                        break;
                    }
                }
            }
        }
        static void MainMenu(int Attempt, int[,] User, object[,] ViktigaKonton)
        {
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4 Logga ut");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    CheckKonto(Attempt, ViktigaKonton);
                    break;
                case 2:
                    TransactionKonto(Attempt, ViktigaKonton);
                    break;
                case 3:
                    TakeOutKonto(Attempt, ViktigaKonton);
                    break;
                case 4:
                    Loggin(User,ViktigaKonton);
                    break;
            }
        }
        static void CheckKonto(int Attempt, object[,] ViktigaKonton)
        {
            for (int i=0; i< 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]))
                {
                    Console.WriteLine("Ditt {0} har {1} sek", ViktigaKonton[i, 1], ViktigaKonton[i,2]);
                }
            }
            Console.WriteLine("\nKlicka på enter för att fortsätta till meny");
        }
        static void TransactionKonto(int Attempt, object[,] ViktigaKonton)
        {
            int NumberKonto=0;
            for (int i = 0; i < 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]))
                {
                    NumberKonto++;
                    Console.WriteLine("\n{0}. {1} - {2} sek",NumberKonto, ViktigaKonton[i, 1], ViktigaKonton[i,2]);
                }
            }
            Console.WriteLine("\nVilket Konto ska pengar flyttas ifrån?");
            int Konto1=int.Parse(Console.ReadLine());
            Console.WriteLine("\nVilket Konto ska pengar flyttas till?");
            int Konto2=int.Parse(Console.ReadLine());
            Console.WriteLine("\nHur stor summa ska flyttas");
            double Summa=double.Parse(Console.ReadLine());

            for(int i = 0; i < 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]) && Konto1 == Convert.ToInt32(ViktigaKonton[i, 3]))
                {
                    ViktigaKonton[i, 2] = (Convert.ToDouble(ViktigaKonton[i, 2]) - Summa);
                    Console.WriteLine("Nya värdet är nu {0} sek i {1}", ViktigaKonton[i, 2], ViktigaKonton[i,1]);
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]) && Konto2 == Convert.ToInt32(ViktigaKonton[i, 3]))
                {
                    ViktigaKonton[i, 2] = (Convert.ToDouble(ViktigaKonton[i, 2]) + Summa);
                    Console.WriteLine("Nya värdet är nu {0} sek i {1}", ViktigaKonton[i, 2], ViktigaKonton[i, 1]);
                    break;
                }
            }
        }
        static void TakeOutKonto(int Attempt,object[,] ViktigaKonton)
        {
            int NumberKonto = 0;
            for (int i = 0; i < 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]))
                {
                    NumberKonto++;
                    Console.WriteLine("\n{0}. {1} - {2} sek", NumberKonto, ViktigaKonton[i, 1], ViktigaKonton[i, 2]);
                }
            }
            Console.WriteLine("Vilket Konto vill du ta ut pengar ifrån");
        }
    }
}
