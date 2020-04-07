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


            if (TargetNumber != UserAdmin || pass != AdminPass)
            {
                int MaxAttempts = 0;
                var User = AdminSection._Users.Find(x => x.TargetNumber == TargetNumber);
                var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));


                if (userindex.TargetNumber == TargetNumber && userindex.Password == pass)
                {
                    if (userindex.Status == false)

                    {
                        Console.Clear();
                        Console.WriteLine("\t\t# Recuerde su cuenta está bloqueada. #");
                        Console.ReadKey();
                        _Login();
                    }
                    else
                    {
                        ClientFuncionality.Menu();
                    }
                }
                else
                {
                    if (userindex.Status == false)

                    {
                        Console.Clear();
                        Console.WriteLine("\t\t# Recuerde su cuenta está bloqueada. #");
                        Console.ReadKey();
                        _Login();
                    }
                    else
                    {
                        if (MaxAttempts == 3)
                        {
                            Console.Clear();

                            Console.WriteLine("\n\t\t Su contraseña ha sido bloqueada." +
                            "\n\t\t Para poder desbloquearla consulte con un administrador.\n");

                            userindex.Status = false;

                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\t\t#########################################################");
                            Console.WriteLine("\t\t# La contraseña no es correcta, intentelo una nueva vez #");
                            Console.WriteLine("\t\t#########################################################");
                            MaxAttempts++;
                        }
                    }
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
