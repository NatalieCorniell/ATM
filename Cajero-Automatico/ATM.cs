using System;
namespace CajeroAutomatico
{
    public class ATM
    {
        private int bp50 = 0;
        private int bp100 = 0;
        private int bp200 = 0;
        private int bp500 = 0;
        private int bp1000 = 0;
        private int bp2000 = 0;
        private int result = 0;
        private string retirement;


        public static string BankName { get; set; }
        public static void Menu_ATM()
        {

            while (true)
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

                        AdminSection.Menu_Admin();
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void _NameBank()
        {
            try
            {
                Console.Write("\t Ingrese el nuevo nombre del banco: ");
                string nameBank = Console.ReadLine();

                BankName = nameBank;
                if (nameBank == "")
                {
                    Console.WriteLine("\n\t Debe llenar todos los campos. \n ");
                    Console.ReadKey();
                    _NameBank();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\t\t########################################\n");
                    Console.WriteLine("\t\t##### Usuario Editado Con Exito!! #####\n");
                    Console.WriteLine("\t\t########################################\n");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n\n \t\t ERROR!! \n");
                Console.WriteLine("\t :( verifique e intente nuevamente. \n");
                Console.ReadKey();
            }
        }
        public static void Dispensing_Mode()
        {

        }
    }
}
