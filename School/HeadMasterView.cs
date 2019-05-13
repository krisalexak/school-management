using System;

namespace School
{
    public class HeadMasterView
    {
        public static int menu()
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
                Console.WriteLine("Press 1 to perform CRUD on courses");
                Console.WriteLine("Press 2 to perform CRUD on students");
                Console.WriteLine("Press 3 to perform CRUD on assignments");
                Console.WriteLine("Press 4 to perform CRUD on trainers");
                Console.WriteLine("Press 5 to perform CRUD on students per courses");
                Console.WriteLine("Press 6 to perform CRUD on trainers per courses");
                Console.WriteLine("Press 7 to perform CRUD on assignments per courses");
                Console.WriteLine("Press 8 to perform CRUD on schedule per courses");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int entityMenu(string entity)
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Press 0 to CREATE {entity}");
                Console.WriteLine($"Press 1 to READ {entity}");
                Console.WriteLine($"Press 2 to UPDATE {entity}");
                Console.WriteLine($"Press 3 to DELETE {entity}");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int entityPerMenu(string entity)
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Press 0 to CREATE {entity}");
                Console.WriteLine($"Press 1 to UPDATE {entity}");
                Console.WriteLine($"Press 2 to DELETE {entity}");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int ScheduleMenu(string entity)
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Press 1 to UPDATE {entity}");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}