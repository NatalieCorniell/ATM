using System;
using System.Linq;
namespace CajeroAutomatico
{
    public class Login
    {
        public Login()
        {


        }

        public static void _Login()
        {
            Console.WriteLine("\n\n\n\n\t\t Bienvenido al Cajero Automático");

            Console.Write("\t Usuario: ");
            string User = Console.ReadLine();
            Console.Write("\t Contraseña: ");
            string Pass = Console.ReadLine();

            string UserAdmin = "1";
            string PassCorrect = "2";
            int MaxAttempts = 3;


            if (User != UserAdmin || Pass != PassCorrect)
            {

                Console.WriteLine("\tMENSAJE DE PUREBA!!-USUARIO NO ADMIN");
                _Login();
            }
            else
            {
                AdminSection.Menu_Admin();
            }
            Console.ReadKey();
        }
    }
}
