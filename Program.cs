using System;

namespace BankingHelp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating all the diffrent user accounts and bank accounts
            int[,] User = new int[5, 2] { { 1234, 123 }, { 1111, 111 }, { 2222, 222 }, { 3333, 333 }, { 4444, 444 } };
            object[,] ViktigaKonto = new object[10, 4] { { 123,"Lönekonto",30.35,1 }, { 123,"Sparkonto",10000.00,2 },{ 111,"Lönekonto",100000.90,1 },{ 111,"Sparkonto",3000.00,2 },
                { 222,"Lönekonto",63.77,1 },{ 222,"Sparkonto",1000000.00,2 },{ 333,"Lönekonto",59000.23,1 },{ 333,"Sparkonto",7000.00,2 },{ 444,"Lönekonto",10000.64,1 },{ 444,"Sparkonto",500.00,2 } };
            Console.WriteLine("Välkommen till bankprogrammet\n");
            //Starts the Loggin function
            Loggin(User,ViktigaKonto);
        }
        static void Loggin(int[,] User, object[,] ViktigaKonton)
        {
            //If not done in 3 attempts the program stops
            for(int i = 0; i < 3; i++)
            { 
                Console.WriteLine("Användarnummer: ");
                int AnvändarNummer = (int.Parse(Console.ReadLine()));
                Console.WriteLine("Pinnummer: ");
                int AnvändarPin=(int.Parse(Console.ReadLine()));
                Console.Write("\n");
                //Searches in the User account array after matching account
                for(int j=0; j< 5; j++)
                {
                    if (AnvändarNummer == User[j,0] && AnvändarPin == User[j, 1])
                    {
                        //If it finds an account the main menu starts
                        MainMenu(AnvändarPin,User,ViktigaKonton);
                        i = 3;
                        break;
                    }
                }
            }
        }
        static void MainMenu(int Attempt, int[,] User, object[,] ViktigaKonton)
        {
            //Here we have a lot of values send over to send them to diffrent functions later
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");
            int x = 0;
            //A loop so that there is not errors when choosing in the menu
            while (x == 0)
            {
                string Val = Console.ReadLine();
                Console.Write("\n");
                int Choice;
                //Checks if it can be an int or not
                if (!Int32.TryParse(Val, out Choice))
                {
                    Console.WriteLine("ogiltigt val");
                }
                else
                {
                    Choice=int.Parse(Val);
                    switch (Choice)
                    {
                        //If the int is between 1-4 it starts a function or gives an error message
                        case 1:
                            CheckKonto(Attempt, ViktigaKonton, User);
                            x = 1;
                            break;
                        case 2:
                            TransactionKonto(Attempt, ViktigaKonton, User);
                            x = 1;
                            break;
                        case 3:
                            TakeOutKonto(Attempt, ViktigaKonton, User);
                            x = 1;
                            break;
                        case 4:
                            Loggin(User, ViktigaKonton);
                            x = 1;
                            break;
                        default:
                            Console.WriteLine("ogiltigt val");
                            break;
                    }
                }
            }
        }
        static void CheckKonto(int Attempt, object[,] ViktigaKonton, int[,] User)
        {
            for (int i=0; i< 10; i++)
                //searches all the bank accounts after that specific user
            {
                //Converts the object to int
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]))
                {
                    Console.WriteLine("Ditt {0} har {1} sek", ViktigaKonton[i, 1], ViktigaKonton[i,2]);
                }
            }
            //If the user presses enter they go back to meny oyherwise nothing will happen
            Console.WriteLine("\ntryck på ENTER för meny");
            ConsoleKeyInfo x;
            do
            {
                x = Console.ReadKey();
            }
            while (x.Key != ConsoleKey.Enter);
            Console.Write("\n");
            MainMenu(Attempt, User, ViktigaKonton);
        }
        static void TransactionKonto(int Attempt, object[,] ViktigaKonton, int[,] User)
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
                //if it finds the user and the account number it subtracts the value specified by the user
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]) && Konto1 == Convert.ToInt32(ViktigaKonton[i, 3]))
                {
                    ViktigaKonton[i, 2] = Convert.ToDouble(ViktigaKonton[i, 2]) - Summa;
                    Console.WriteLine("Nya värdet är nu {0} sek i {1}", ViktigaKonton[i, 2], ViktigaKonton[i,1]);
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                //If it finds the user and account number it adds the value specified by the user
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]) && Konto2 == Convert.ToInt32(ViktigaKonton[i, 3]))
                {
                    ViktigaKonton[i, 2] = Convert.ToDouble(ViktigaKonton[i, 2]) + Summa;
                    Console.WriteLine("Nya värdet är nu {0} sek i {1}", ViktigaKonton[i, 2], ViktigaKonton[i, 1]);
                    break;
                }
            }
            //Enter or nothing happens
            Console.WriteLine("\ntryck på ENTER för meny");
            ConsoleKeyInfo x;
            do
            {
                x = Console.ReadKey();
            }
            while (x.Key != ConsoleKey.Enter);
            Console.Write("\n");
            //Sends back to main menu
            MainMenu(Attempt, User, ViktigaKonton);
        }
        static void TakeOutKonto(int Attempt,object[,] ViktigaKonton, int[,] User)
        {
            int NumberKonto = 0;
            for (int i = 0; i < 10; i++)
            {
                if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]))
                {
                    NumberKonto++;
                    //writes all the accounts that the user haves
                    Console.WriteLine("{0}. {1} - {2} sek", NumberKonto, ViktigaKonton[i, 1], ViktigaKonton[i, 2]);
                }
            }
            Console.WriteLine("\nVilket Konto vill du ta ut pengar ifrån?");
            int Konto1 = int.Parse(Console.ReadLine());
            Console.WriteLine("\nHur mycket pengar vill du ta ut?");
            double Summa=double.Parse(Console.ReadLine());
            Console.WriteLine("\nPinnummer: ");
            int Pinnummer=int.Parse(Console.ReadLine());

            if (Pinnummer == Attempt)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Attempt == Convert.ToInt32(ViktigaKonton[i, 0]) && Konto1 == Convert.ToInt32(ViktigaKonton[i, 3]))
                    {
                        //Subracts the value from the bank account the user has specified
                        ViktigaKonton[i, 2] = Convert.ToDouble(ViktigaKonton[i, 2]) - Summa;
                        Console.WriteLine("Nya värdet är nu {0} sek i {1}", ViktigaKonton[i, 2], ViktigaKonton[i, 1]);
                        break;
                    }
                }
            }

            Console.WriteLine("\ntryck på ENTER för meny");
            ConsoleKeyInfo x;
            do
            {
                x = Console.ReadKey();
            }
            while (x.Key != ConsoleKey.Enter);
            Console.Write("\n");
            MainMenu(Attempt, User, ViktigaKonton);
        }
    }
}
