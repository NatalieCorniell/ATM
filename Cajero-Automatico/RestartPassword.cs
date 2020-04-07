using System;
using PanoramicData.ConsoleExtensions;
namespace CajeroAutomatico
{
    [Serializable]
    public class RestartPassword
    {
        public static void Restart()
        {
            Console.Clear();
            Console.Write("\t Ingrese el número de tarjeta del destinatario  ");
            string targetNumber = Console.ReadLine();

            var User = AdminSection._Users.Find(x => x.TargetNumber == targetNumber);
            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {

                Console.Clear();
                Console.Write("\t\t Introduzca la nueva contraseña");
                string pass = ConsolePlus.ReadPassword();

                if (pass == "")
                {
                    Console.WriteLine("\n\t Debe introducir el nuevo valor. \n ");
                    Console.ReadKey();
                    Restart();
                }
                else
                {
                    userindex.Password = pass;

                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\t\t########################################\n");
                    Console.WriteLine("\t\t##### Usuario Editado Con Exito!! #####\n");
                    Console.WriteLine("\t\t########################################\n");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\t\t No existe un usuario con este número de tarjeta \n");
                Console.Write("\n\t\t Desea realizar otra busqueda? S/N : ");
                string selection = Console.ReadLine();
                if (selection == "s")

                {
                    Restart();
                }

                Console.ReadKey();
                AdminSection.Menu_Admin();
            }
        }
    }
}
