using School.Models;
using System;
using System.Linq;

namespace School
{
    internal class HeadMasterManager
    {
        internal static string getUserName()
        {
            HeadMasterAccount hmAccount;
            string userName;
            do
            {
                Console.WriteLine("Please insert username");
                userName = Program.GetStringSha256Hash(Console.ReadLine());
                using (var context = new SchoolContext())
                {
                    hmAccount = context.HeadMasterAccounts.SingleOrDefault(s => s.Username.Equals(userName));
                }
            } while (hmAccount == null);
            return userName;
        }

        internal static void getPassword(string userName)
        {
            string password;
            HeadMasterAccount hm;
            do
            {
                Console.WriteLine("Please insert password");
                password = Program.GetStringSha256Hash(Console.ReadLine());
                using (var context = new SchoolContext())
                {
                    hm = context.HeadMasterAccounts.SingleOrDefault(h => h.Password.Equals(password) && h.Username.Equals(userName));
                }
            } while (hm == null);
        }
    }
}