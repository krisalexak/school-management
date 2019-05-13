using System;

namespace School
{
    public static class MainView
    {
        internal static int login()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Press 0 to exit application");
                Console.WriteLine("Press 1 to login as a Student");
                Console.WriteLine("Press 2 to login as a Trainer");
                Console.WriteLine("Press 3 to login as a Head Master");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Student Accounts: Usernames: su1-su8, Passwords: sp1-sp8");
                Console.WriteLine();
                Console.WriteLine("Trainer Accounts: Usernames: tu1-tu8, Passwords: tp1-tp8");
                Console.WriteLine();
                Console.WriteLine("Head Master Account: Username: hu , Password: hp");
            } while (!int.TryParse(Console.ReadLine(), out userInput));

            return userInput;
        }
    }
}