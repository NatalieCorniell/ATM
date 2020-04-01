using System;
using System.IO;
using System.Linq;
namespace CajeroAutomatico
{
    public class ATM
    {
        private static int bp50 = 0;
        private static int bp100 = 0;
        private static int bp200 = 0;
        private static int bp500 = 0;
        private static int bp1000 = 0;
        private static int bp2000 = 0;
        private static int result;
        private string retirement;
        private static int monto_a_retirar = 0;

        public static string DispensingMode = "";

        public static string BankName { get; set; }
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
                Console.Write("\t ERROR DE SISTEMA: ");
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
                    Console.WriteLine("\n\t Debe llenar todos los campos. \n ");
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
                        Console.WriteLine("\t\t##### DATO ALMACENADO!! #####\n");
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
                Console.WriteLine("\t\t 2. Dispensación: papeletas de 200 y 1,000 pesos.");
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
            Console.WriteLine("dispensacion de - $200 y mil pesos");
            if (monto_a_retirar == 200)
            {
                int re = result = 200;
                Console.WriteLine("SE DISPENSARÁN: " + re);
            }
            else if (monto_a_retirar == 1000)
            {
                int re = result = 1000;
                Console.WriteLine("SE DISPENSARÁN: " + re);
            }
            else { Console.WriteLine("ESTE CAJERO SOLO PERMITE RETIROS DE 200 Y MIL PESOS "); }

        }
        public static void Config2()
        {
            Console.WriteLine("dispensacion de -100 y 500-");
            if (monto_a_retirar == 100)
            {
                int re = result = 100;
                Console.WriteLine("SE DISPENSARÁN: " + re);
            }
            else if (monto_a_retirar == 500)
            {
                int re = result = 500;
                Console.WriteLine("SE DISPENSARÁN: " + re);
            }
            else if (monto_a_retirar == 200)
            {
                int re = result = 100;
                Console.WriteLine("SE DISPENSARÁN DOS PAPELETAS DE : " + re);
            }
            else if (monto_a_retirar == 300)
            {
                int re = result = 100;
                Console.WriteLine("SE DISPENSARÁN TRES PAPELETAS DE : " + re);
            }
            else if (monto_a_retirar == 400)
            {
                int re = result = 100;
                Console.WriteLine("SE DISPENSARÁN CUATRO PAPELETAS DE : " + re);
            }
            else if (monto_a_retirar == 500)
            {
                int re = result = 500;
                Console.WriteLine("SE DISPENSARÁN UNA PAPELETAS DE : " + re);
            }
            else if (monto_a_retirar == 600)
            {
                Console.WriteLine("SE DISPENSARÁN UNA PAPELETAS DE 500 y una de 100");
            }
            else if (monto_a_retirar == 700)
            {
                Console.WriteLine("SE DISPENSARÁN UNA PAPELETAS DE 500 y dos de 100");
            }
            else if (monto_a_retirar == 800)
            {
                Console.WriteLine("SE DISPENSARÁN UNA PAPELETAS DE 500 y tres de 100");
            }
            else if (monto_a_retirar == 900)
            {
                Console.WriteLine("SE DISPENSARÁN UNA PAPELETAS DE 500 y cuatro de 100");
            }
            else if (monto_a_retirar == 1000)
            {
                Console.WriteLine("SE DISPENSARÁN DOS PAPELETAS DE 500");
            }
            else { Console.WriteLine("ESTE CAJERO SOLO PERMITE RETIROS DE 200 Y MIL PESOS "); }

        }
        public static void Config3() { }

        public static int Balance = 0;
        public static int Deposit;
        public static int Withdraw;

        public static void ClientFuncionality()
        {
            Console.Write("\t\tIntroduzca su pin de 4 dígitos");
            int pin = int.Parse(Console.ReadLine());
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\tSeleccione la opción que desee realizar \n");
                    Console.WriteLine("\t\t 1. Consultar balance");
                    Console.WriteLine("\t\t 2. Realizar retiro");
                    Console.WriteLine("\t\t 3. Realizar depósito");
                    Console.WriteLine("\t\t 4. Cancelar \n");


                    int menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            CheckBalance();
                            break;
                        case 2:
                            WithDraw();
                            break;
                        case 3:
                            // Deposito();
                            break;
                        case 4:
                            Console.WriteLine("\n\n\t\t GRACIAS POR UTILIZAR NUESTROS SERVICIOS! \n");
                            Console.ReadKey();
                            AdminSection.Menu_Admin();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                ClientFuncionality();
            }
        }
        public static void CheckBalance()
        {
            Console.WriteLine("\n Su balance actual es de RD$: {0} ", Balance + "Pesos.");
        }
        public static void WithDraw()
        {

            /* Console.WriteLine("\n ENTER THE Withdraw Balance : ");
             Withdraw = int.Parse(Console.ReadLine());
             if (Withdraw % 100 != 0)
             {
                 Console.WriteLine("\n PLEASE ENTER THE Balance IN ABOVE 100");
             }
             else if (Withdraw > (Balance - 1000))
             {
                 Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
             }
             else
             {
                 Balance -= Withdraw;
                 Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                 Console.WriteLine("\n CURRENT BALANCE IS Rs : {0}", Balance);
             }
        }
        public static void Deposito()
        {
            Console.Write("\n Introduzca la cantidad a depositar");
            Deposit = int.Parse(Console.ReadLine());
            Balance += Deposit;
            Console.WriteLine("Su balance actual ahora es RD$: {0}", Balance + " Pesos.");
        }*/
        }
    }
}
