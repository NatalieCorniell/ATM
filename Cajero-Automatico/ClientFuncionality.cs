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


            Console.Write("\t\tIntroduzca su pin de 4 dígitos");
            int pin = int.Parse(Console.ReadLine());
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\tSeleccione la opción que desee realizar \n");
                    Console.WriteLine("\t\t 1. Consultar CBalance");
                    Console.WriteLine("\t\t 2. Realizar retiro");
                    Console.WriteLine("\t\t 3. Realizar depósito");
                    Console.WriteLine("\t\t 4. Cancelar \n");


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
            CBalance = _Users.Balance;

            Console.WriteLine("\n BANCO: " + _Users.TargetNumber);
            Console.WriteLine("\n Número de tarjeta: " + _Users.TargetNumber);
            Console.WriteLine("\n Su Balance actual es de RD$: {0} ", CBalance + "Pesos.");
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
