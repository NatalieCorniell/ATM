using System;

namespace CajeroAutomatico
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "CAJERO AUTOMÁTICO";

            Login login = new Login();
            login._Login();
        }
    }
}
