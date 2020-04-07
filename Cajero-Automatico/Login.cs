using System;
using System.Linq;
using PanoramicData.ConsoleExtensions;
namespace CajeroAutomatico
{
    public class Login
    {
        public static _UsersCRUD _Users = new _UsersCRUD();

        public static void _Login()
        {

            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t <><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("\t <><                                                    ><>");
            Console.WriteLine("\t <><            Bienvenido  al Cajero Automático        ><>");
            Console.WriteLine("\t <><                                                    ><>");
            Console.WriteLine("\t <><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");


            Console.Write("\n\t Numero de tarjeta: ");

            string TargetNumber = "";
            ConsoleKeyInfo TN = Console.ReadKey(true);
            while (TN.Key != ConsoleKey.Enter)
            {
                if (TN.Key != ConsoleKey.Backspace)
                {
                    if (TN.Key != ConsoleKey.RightArrow)
                    {
                        if (TN.Key != ConsoleKey.LeftArrow)
                        {
                            if (TN.Key != ConsoleKey.UpArrow)
                            {
                                if (TN.Key != ConsoleKey.DownArrow)
                                {
                                    Console.Write("#");
                                    TargetNumber += TN.KeyChar;
                                }
                            }
                        }
                    }
                }
                else if (TN.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(TargetNumber))
                    {
                        TargetNumber = TargetNumber.Substring(0, TargetNumber.Length - 1);
                        int position = Console.CursorLeft;
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(position - 1, Console.CursorTop);


                    }
                }
                TN = Console.ReadKey(true);
            }

            Console.Write("\n\t Contraseña: ");
            string pass = ConsolePlus.ReadPassword();

            string UserAdmin = "1";
            string AdminPass = "2";

            int MaxAttempts = 0;
            if (TargetNumber != UserAdmin || pass != AdminPass)
            {
                var User = AdminSection._Users.Find(x => x.TargetNumber == TargetNumber);
                var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

                if (userindex.TargetNumber != TargetNumber || userindex.Password != pass)
                {

                    Console.WriteLine("no no no no ");
                }
                else
                {
                    ClientFuncionality.Menu();
                }
               

            }
            else
            {
                
                AdminSection.Menu_Admin();
               
            }
            Console.ReadKey();

        }

    }
}
