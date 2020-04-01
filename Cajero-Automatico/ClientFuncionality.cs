using System;
namespace CajeroAutomatico
{
    public class ClientFuncionality
    {

        public static _UsersCRUD _Users = new _UsersCRUD();

        public static double CBalance = 0;
        public static double CDeposit;
        public static double CWithdraw;


        public static void Menu()
        {


            try
            {
                while (true)
                {
                    Console.Clear();

                    Console.Title = "SECCIÓN CLIENTES";
                    Console.WriteLine("\n\n\t\t ############################################\n");
                    Console.WriteLine("\t\t #### MENU PRINCIPAL - SECCIÓN CLIENTES ####\n");
                    Console.WriteLine("\t\t ############################################\n");

                    Console.WriteLine("\t\t 1. Consultar Balance");
                    Console.WriteLine("\t\t 2. Realizar retiro");
                    Console.WriteLine("\t\t 3. Realizar depósito");
                    Console.WriteLine("\t\t 4. Cancelar \n");

                    Console.Write("\n\t\tSeleccione la opción que desee realizar: ");

                    int menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            CheckCBalance();
                            break;
                        case 2:
                            WithDraw();
                            break;
                        case 3:
                            Deposito();
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
                Menu();
            }
        }
        public static void CheckCBalance()
        {

            Console.Clear();

            int count = 1;
            Console.Write("\t Ingrese su contaseña porfavor: ");

            string password = Console.ReadLine();

            var User = AdminSection._Users.Find(x => x.Password == password);

            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {

                Console.WriteLine("\n\t BANCO: " + ATM.BankName);
                Console.WriteLine("\t Número de tarjeta: " + userindex.TargetNumber);
                Console.WriteLine("\t Balance disponible RD$: {0} ", userindex.Balance + "Pesos.");

                Console.ReadKey();
            }
            else
            {
                count++;

                if ( count < 2)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t##### Acceso denegado, intente de nuevo porfavor #####\n");
                    Console.ReadKey();
                    CheckCBalance();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\t##### Acceso denegado, Desea cancelar ? S/N #####\n");

                    string selection = Console.ReadLine();
                    if (selection == "s")
                    {
                        CheckCBalance();
                    }

                    Console.ReadKey();
                    Menu();
                }
            }

        }
        public static void WithDraw()
        {

            /* Console.WriteLine("\n ENTER THE Withdraw CBalance : ");
             Withdraw = int.Parse(Console.ReadLine());
             if (Withdraw % 100 != 0)
             {
                 Console.WriteLine("\n PLEASE ENTER THE CBalance IN ABOVE 100");
             }
             else if (Withdraw > (CBalance - 1000))
             {
                 Console.WriteLine("\n SORRY! INSUFFICENT CBalance");
             }
             else
             {
                 CBalance -= Withdraw;
                 Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                 Console.WriteLine("\n CURRENT CBalance IS Rs : {0}", CBalance);
             }*/
        }
        public static void Deposito()
        {
            Console.Write("\n Introduzca la cantidad a depositar");
            CDeposit = int.Parse(Console.ReadLine());
            CBalance += CDeposit;
            Console.WriteLine("Su CBalance actual ahora es RD$: {0}", CBalance + " Pesos.");
        }
    }
}
