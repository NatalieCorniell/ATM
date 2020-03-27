using System;
namespace CajeroAutomatico
{
    public class Menu
    {
        public Menu()
        {
        }
      /*  public static void PrincipalMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Title = "SISTEMA DE AUTOBUSES ITLA";
                Console.WriteLine("\n\t\t MENU PRINCIPAL \n");
                Console.WriteLine("\t 1. Mantenimiento de autobuses");
                Console.WriteLine("\t 2. Mantenimiento de choferes");
                Console.WriteLine("\t 3. Mantenimiento de Rutas");
                Console.WriteLine("\t 4. Menu de asignaciones");
                Console.WriteLine("\t 5. Venta de tickets");
                try
                {
                    Console.Write("\t Ingrese el número segun la opción deseada: ");
                    int Menu = Convert.ToInt32(Console.ReadLine());

                    switch (Menu)
                    {
                        case (int)Principal_Menu.CRUD_BUSES:
                            BusesPrincipalMenu();
                            break;
                        case (int)Principal_Menu.CRUD_DRIVERS:
                            DriversPrincipalMenu();
                            break;
                        case (int)Principal_Menu.ROUTS:
                            RoutsPrincipalMenu();
                            break;
                        case (int)Principal_Menu.ASSIGNMENT:
                            AssignmentPrincipalMenu();
                            break;
                        case (int)Principal_Menu.TICKETS:
                            Tickets_Sell();
                            break;
                        default:
                            Console.WriteLine("\n\n \t Este número de Sección no exite .");
                            Console.ReadKey();
                            PrincipalMenu();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\t\t Algo anda mal en la seleccion, verifique porfavor. ");
                    Console.ReadKey();
                    PrincipalMenu();
                }
            }
        }*/
    }
}
