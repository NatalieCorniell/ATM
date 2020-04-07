using System;
namespace CajeroAutomatico
{
    public class ActiveUser
    {
        public static void Active()
        {
            Console.Clear();
            Console.Write("\t Ingrese el número de tarjeta del destinatario  ");
            string targetNumber = Console.ReadLine();

            var User = AdminSection._Users.Find(x => x.TargetNumber == targetNumber);
            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {
                if (userindex.Status == false)
                {
                    Console.Clear();
                    Console.Write("\t\t Está seguro de activar este usuario ? S/N ");
                    string s = Console.ReadLine();

                    if (s == "s")
                    {
                        userindex.Status = true;
                        Console.Write("\t\t Usuario Activado! ");
                        Console.ReadKey();
                        AdminSection.Menu_Admin();
                    }
                }
                
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\t Este usuario está activo, no requiere de activación. ");
                    Console.Write("\t\t Desea introducir un nuevo número de tarjeta? S/N ");
                    string s = Console.ReadLine();

                    if (s == "s")
                    {
                        Active();
                    }
                        Console.ReadKey();
                    AdminSection.Menu_Admin();
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
                    Active();
                }

                Console.ReadKey();
                AdminSection.Menu_Admin();
            }
        }
    }
}
