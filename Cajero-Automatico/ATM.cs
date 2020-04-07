using System;
using System.IO;
using System.Linq;
namespace CajeroAutomatico
{
    [Serializable]
    public class ATM
    {

        public static int DispensingMode { set; get; }

        public static string BankName = "Banco ITLA";
        public static void Menu_ATM()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.Title = "CONFIGURACIÓN ATM";
                    Console.WriteLine("\n\t\t MENU PRINCIPAL ATM -Configuración ATM \n");
                    Console.WriteLine("\t 1. Cambiar nombre de Banco");
                    Console.WriteLine("\t 2. Modo de dispensación");
                    Console.WriteLine("\t 0. Volver atrás");

                    Console.Write("\t Ingrese el número segun la opción deseada: ");
                    int Menu = Convert.ToInt32(Console.ReadLine());

                    switch (Menu)
                    {
                        case 1:
                            NameBank();
                            break;
                        case 2:
                            Dispensing_Mode();
                            break;
                        case 3:
                            Dispensing_Mode();
                            break;
                        case 0:

                            AdminSection.Menu_Admin();
                            Console.ReadKey();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Console.Write("\t Número de selección no existente, intente de nuevo porfavor ");
                Console.ReadKey();
                Menu_ATM();
            }
        }
        public static void NameBank()
        {
            try
            {
                Console.Write("\t Ingrese el nuevo nombre del banco: ");
                string nameBank = Console.ReadLine();


                if (nameBank == "")
                {
                    Console.WriteLine("\n\t Debe llenar los campos. \n ");
                    Console.ReadKey();
                    NameBank();

                }
                else
                {

                    Console.Write("\n\t\t Está seguro de realizar el cambio? S/N : ");
                    string seleccion = Console.ReadLine();
                    if (seleccion == "s")
                    {
                        BankName = nameBank;
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\t##### DATO ALMACENADO!! #####\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Menu_ATM();
                    }

                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n\n \t\t ERROR DE SISTEMA! \n");
                Console.ReadKey();
            }
        }
        public static void Dispensing_Mode()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("\t\t SELECCIONE EL MODO DE DISPENSACIÓN \n");
                Console.WriteLine("\t\t 1. Dispensación: papeletas de 200 y 1,000 pesos.");
                Console.WriteLine("\t\t 2. Dispensación: papeletas de 100 y 500 pesos.");
                Console.WriteLine("\t\t 3. Dispensación: papeletas mínimas.");
                try
                {
                    Console.Write("\t Número de selección: ");
                    int Menu = Convert.ToInt32(Console.ReadLine());


                    switch (Menu)
                    {
                        case 1:
                            Config1();
                            break;
                        case 2:
                            Config2();
                            break;
                        case 3:
                            Config3();
                            break;
                        case 0:
                            Console.Write("\t Sección de Administrador cerrada ");
                            Console.ReadKey();
                            Login._Login();
                            break;
                        default:
                            Menu_ATM();
                            break;
                    }
                }
                catch (Exception)
                {
                    Menu_ATM();
                }
            }

        }
        public static void Config1()
        {

            DispensingMode = 1;
            Console.WriteLine("\n\n\n\n\n\n\t\t__________________________________\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t__ Modo de dispensación guardado __\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t___________________________________\n");
            Console.ReadKey();
            Menu_ATM();

        }
        public static void Config2()
        {
            DispensingMode = 2;
            Console.WriteLine("\n\n\n\n\n\n\t\t__________________________________\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t__ Modo de dispensación guardado __\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t___________________________________\n");
            Console.ReadKey();
            Menu_ATM();

        }
        public static void Config3()
        {
            DispensingMode = 3;
            Console.WriteLine("\n\n\n\n\n\n\t\t__________________________________\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t__ Modo de dispensación guardado __\n");
            Console.WriteLine("\t\t                                   \n");
            Console.WriteLine("\t\t___________________________________\n");
            Console.ReadKey();
            Menu_ATM();

        }
    }
}
