

using System;
namespace CajeroAutomatico
{
    public class Login
    {
        public Login()
        {
            

        }

        public void _Login()
        {
            Console.WriteLine("\t\t Bienvenido al Cajero Automático");

            Console.Write("\t Usuario: ");
            string User = Console.ReadLine();
            Console.Write("\t Contraseña: ");
            string Pass = Console.ReadLine();

            string UserAdmin = "1234-1234-1234-1234";
            string PassCorrect = "Admin123";
            int MaxAttempts = 3;


            Console.ReadKey();

                if (User != UserAdmin || Pass != PassCorrect)
                {

                Console.WriteLine("\tMENSAJE DE PUREBA!!-USUARIO NO ADMIN");
            }
            else
            {
                Seccion_Administrador seccion_Administrador = new Seccion_Administrador();
                seccion_Administrador.Menu_Admin();


            }

            Console.ReadKey();
        }
    }
}
