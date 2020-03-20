using System;
namespace CajeroAutomatico
{
    public class ATM
    {
        public ATM()
        {
        }

        public void Menu_ATM()
        {
            Console.Clear();
            Console.Title = "CONFIGURACIÓN ATM";
            Console.WriteLine("\n\t\t MENU PRINCIPAL ATM \n");
            Console.WriteLine("\t 1. Cambiar nombre de Banco");
            Console.WriteLine("\t 2. Modo de dispensación");
            Console.WriteLine("\t 0. Volver atrás");

            Console.Write("\t Ingrese el número segun la opción deseada: ");
            int Menu = Convert.ToInt32(Console.ReadLine());

            switch (Menu)
            {
                case 1:
                    _NameBank();
                    break;
                case 2:
                    break;
                case 0:
                    Seccion_Administrador seccion_Administrador = new Seccion_Administrador();
                    seccion_Administrador.Menu_Admin();
                    Console.ReadKey();
                    break;
            }
        }

        private void _NameBank()
        {
            Console.Write("\t Ingrese el nuevo nombre del banco: ");
            string nameBank = Console.ReadLine();

        }
    }
}
