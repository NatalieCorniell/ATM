using System;
using System.Collections.Generic;
using PanoramicData.ConsoleExtensions;
namespace CajeroAutomatico
{
    [Serializable]
    public class ClientFuncionality
    {
        public static LogTransacciones transacciones = new LogTransacciones();

        public static _UsersCRUD _Users = new _UsersCRUD();
        public static List<string> Company = new List<string>();
        public static List<double> Amount = new List<double>();

        public static void Menu()
        {
            // Console.Write("\t Ingrese su contaseña porfavor: ");

            //  string password = Console.ReadLine();
            //Gpassword = password;

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
                    Console.WriteLine("\t\t 4. Comprar tarjeta de llamada");
                    Console.WriteLine("\t\t 0. Salir \n");

                    Console.Write("\n\t\tSeleccione la opción que desee realizar: ");

                    int menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            CheckCBalance();
                            break;
                        case 2:
                            Withdraw();
                            break;
                        case 3:
                            Deposit();
                            break;
                        case 4:
                            Buy();
                            break;
                        case 0:
                            Console.WriteLine("\n\n\t\t GRACIAS POR UTILIZAR NUESTROS SERVICIOS! \n");
                            Console.ReadKey();
                            Login._Login();
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
            Console.Write("\t Ingrese su contaseña porfavor: ");

            string password = ConsolePlus.ReadPassword();

            var User = AdminSection._Users.Find(x => x.Password == password);

            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {
                Console.WriteLine("\n\t BANCO: " + ATM.BankName);
                Console.WriteLine("\t Número de tarjeta: " + userindex.TargetNumber);
                Console.WriteLine("\t Balance disponible RD$: {0} ", userindex.Balance + " Pesos.");


                //transaction

                DateTime date = DateTime.Today;
                LogTransacciones log = new LogTransacciones
                {
                    Client = (userindex.Name + " " + userindex.LastName),
                    Target = userindex.TargetNumber,
                    Date = date.ToString(),
                    Type = "Chequeo de balance",
                    Info = ("Balance disponlible:  " + userindex.Balance)
                };

                CRUD.Add(LogTransacciones.transactions, log);

                Console.ReadKey();
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
        public static void Withdraw()
        {
            Console.Clear();
            Console.Write("\t Ingrese su contaseña porfavor: ");

            string password = ConsolePlus.ReadPassword();

            var User = AdminSection._Users.Find(x => x.Password == password);

            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {
                if (ATM.DispensingMode == 1)
                {
                    Console.Write("\n\t Introduzca la cantidad a retirar: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    var balanceA = userindex.Balance - amount;

                    if (amount % 1000 == 0 || amount % 200 == 0)
                    {
                        if (amount >= 1000)
                        {
                            int b1000 = (int)amount / 1000;
                            amount = (amount % 1000);
                            Console.WriteLine("\n\t Se dispensará: " + b1000 + " Billetes de RD$ 1,000 pesos.");

                        }
                        if (amount >= 200)
                        {
                            int b200 = (int)amount / 200;
                            amount = (amount % 200);
                            Console.WriteLine("\n\t Se dispensará: " + b200 + " Billetes de RD$ 200 pesos.");

                        }
                        Console.WriteLine("\n\n\t\t  Retiro realizado! \n\n" +
                            " \t Favor retirar su dinero y tarjeta.");
                        Console.WriteLine("\n\t Su balance actual es : " + balanceA);
                        User.Balance = balanceA;



                        //transaction

                        DateTime date = DateTime.Today;
                        LogTransacciones log = new LogTransacciones
                        {
                            Client = (userindex.Name + " " + userindex.LastName),
                            Target = userindex.TargetNumber,
                            Date = date.ToString(),
                            Type = "Retiro",
                            Info = ("Retiro de  " + amount + " pesos.")
                        };

                        CRUD.Add(LogTransacciones.transactions, log);

                        Console.ReadKey();
                        Menu();
                    }
                    else if (userindex.Balance <= balanceA)
                    {
                        Console.WriteLine("\n\t Su cuenta no posee fondos suficientes \n\t " +
                            "Nota: Para realizar un retiro debe tener mas de RD$100 pesos. \n");
                        Console.ReadKey();
                    }
                    else if (amount % 100 != 0)
                    {
                        Console.WriteLine("\n" +
                            "\t Lo sentimos, debe introducir un valor mayor de RD$100 pesos \n\t" +
                            " y solo cantidades en enteras. \n\n " +
                            "\t Desea realizar otra transacción? S/N");

                        string selection = Console.ReadLine();
                        if (selection == "s")
                        {
                            Withdraw();
                        }
                        Console.ReadKey();
                        Menu();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\n\t Lo sentimos, este cajero solo dispensa \n\t papeletas de RD$200 y RD$1,000 pesos." +
                            " \n\n " +
                            "\t Desea realizar otra transacción? S/N");

                        string selection = Console.ReadLine();
                        if (selection == "s")
                        {
                            Withdraw();
                        }
                        Console.ReadKey();
                        Menu();
                    }
                }
                if (ATM.DispensingMode == 2)
                {

                    Console.Write("\n\t Introduzca la cantidad a retirar: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    var balanceA = userindex.Balance - amount;


                    if (amount % 500 == 0 || amount % 100 == 0)
                    {
                        if (amount >= 500)
                        {
                            int b500 = (int)amount / 500;
                            amount = (amount % 500);
                            Console.WriteLine("\n\t Se dispensará: " + b500 + " Billetes de RD$ 500 pesos.");

                        }
                        if (amount >= 100)
                        {
                            int b100 = (int)amount / 100;
                            amount = (amount % 100);
                            Console.WriteLine("\n\t Se dispensará: " + b100 + " Billetes de RD$ 100 pesos.");

                        }
                        Console.WriteLine("\n\n\t\t  Retiro realizado! \n\n" +
                            " \t Favor retirar su dinero y tarjeta.");
                        Console.WriteLine("\n\t Su balance actual es : " + balanceA);
                        User.Balance = balanceA;


                        //transaction

                        DateTime date = DateTime.Today;
                        LogTransacciones log = new LogTransacciones
                        {
                            Client = (userindex.Name + " " + userindex.LastName),
                            Target = userindex.TargetNumber,
                            Date = date.ToString(),
                            Type = "Retiro",
                            Info = ("Retiro de  " + amount + " pesos.")
                        };

                        CRUD.Add(LogTransacciones.transactions, log);


                        Console.ReadKey();
                        Menu();
                    }
                    else if (userindex.Balance <= balanceA)
                    {
                        Console.WriteLine("\n\t Su cuenta no posee fondos suficientes \n\t " +
                            "Nota: Para realizar un retiro debe tener mas de RD$100 pesos. \n");
                        Console.ReadKey();
                    }
                    else if (amount % 100 != 0)
                    {
                        Console.WriteLine("\n" +
                            "\t Lo sentimos, debe introducir un valor mayor de RD$100 pesos \n\t" +
                            " y solo cantidades en enteras. \n\n " +
                            "\t Desea realizar otra transacción? S/N");

                        string selection = Console.ReadLine();
                        if (selection == "s")
                        {
                            Withdraw();
                        }
                        Console.ReadKey();
                        Menu();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\n\t Lo sentimos, este cajero solo dispensa \n\t papeletas de RD$500 y RD$100 pesos." +
                            " \n\n " +
                            "\t Desea realizar otra transacción? S/N");

                        string selection = Console.ReadLine();
                        if (selection == "s")
                        {
                            Withdraw();
                        }
                        Console.ReadKey();
                        Menu();
                    }

                }
                if (ATM.DispensingMode == 3)
                {

                    Console.Write("\n\t Introduzca la cantidad a retirar: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    var balanceA = userindex.Balance - amount;


                    if (amount >= 1000)
                    {
                        int b = (int)amount / 1000;
                        Console.WriteLine("\n\t Se dispensará: " + b + " Billetes de RD$ 1000 pesos.");

                        amount -= (1000 * b);
                    }
                    if (amount >= 500)
                    {
                        int b = (int)amount / 500;
                        amount -= (500 * b);
                        Console.WriteLine("\n\t Se dispensará: " + b + " Billetes de RD$ 500 pesos.");


                    }
                    if (amount >= 200)
                    {
                        int b = (int)amount / 200;
                        amount -= (200 * b);
                        Console.WriteLine("\n\t Se dispensará: " + b + " Billetes de RD$ 200 pesos.");


                    }
                    if (amount >= 100)
                    {
                        int b = (int)amount / 100;
                        amount -= (100 * b);
                        Console.WriteLine("\n\t Se dispensará: " + b + " Billetes de RD$ 100 pesos.");


                    }
                    Console.WriteLine("\n\n\t\t  Retiro realizado! \n\n" +
                                               " \t Favor retirar su dinero y tarjeta.");
                    Console.WriteLine("\n\t Su balance actual es : " + balanceA);
                    User.Balance = balanceA;


                    //transaction

                    DateTime date = DateTime.Today;
                    LogTransacciones log = new LogTransacciones
                    {
                        Client = (userindex.Name + " " + userindex.LastName),
                        Target = userindex.TargetNumber,
                        Date = date.ToString(),
                        Type = "Retiro",
                        Info = ("Retiro de RD$" + amount + " pesos.")
                    };

                    CRUD.Add(LogTransacciones.transactions, log);

                    Console.ReadKey();
                    Menu();

                }
                if (ATM.DispensingMode == 0)
                {
                    Console.Write("\n\t Lo sentimos, Cajero no configurado.\n\t Estamos trabajando en ello. ");
                    Console.ReadKey();
                    Menu();
                }
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
        public static void Deposit()
        {
            Console.Clear();
            Console.Write("\t Ingrese su contaseña porfavor: ");
            string password = ConsolePlus.ReadPassword();
            var User = AdminSection._Users.Find(x => x.Password == password);
            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {
                Console.Write("\n\t  Introduzca la cantidad a depositar: ");
                double deposit = Convert.ToInt32(Console.ReadLine());

                double BalanceP = userindex.Balance;

                if (deposit % 100 != 0)
                {
                    Console.WriteLine("\n" +
                       "\t Lo sentimos, debe introducir un valor mayor de RD$100 pesos \n\t" +
                       " y solo cantidades en enteras. ");
                    Console.ReadKey();
                }
                else
                {
                    double BalanceA = userindex.Balance += deposit;

                    Console.WriteLine("\n\t\t Banco: " + ATM.BankName + " \n" +
                    " \t Nombre....................... " + userindex.Name + " " + userindex.LastName + " \n" +
                    " \t Balance anterior............. -RD$: " + BalanceP + " Pesos." + " \n" +
                    " \t Su Balance actual ahora es... -RD$: {0}", BalanceA + " Pesos.");


                    //transaction

                    DateTime date = DateTime.Today;
                    LogTransacciones log = new LogTransacciones
                    {
                        Client = (userindex.Name + " " + userindex.LastName),
                        Target = userindex.TargetNumber,
                        Date = date.ToString(),
                        Type = "Depósito",
                        Info = ("Depósiyo de  " + deposit + " pesos.")
                    };

                    CRUD.Add(LogTransacciones.transactions, log);


                    Console.ReadKey();

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t##### Acceso denegado, intente de nuevo porfavor #####\n");
                Console.ReadKey();
                CheckCBalance();
            }
        }
        public static void Buy()
        {
            Console.Clear();
            Console.Write("\t Ingrese su contaseña porfavor: ");
            string password = ConsolePlus.ReadPassword();
            var User = AdminSection._Users.Find(x => x.Password == password);
            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {

                Company.Add("Claro");
                Company.Add("Altice");
                Company.Add("Viva");

                Amount.Add(25);
                Amount.Add(60);
                Amount.Add(100);
                Amount.Add(150);
                Amount.Add(200);

                Console.Clear();
                Console.WriteLine("\t\t Venta de tarjetas");
                Console.WriteLine("\t 1. Claro ");
                Console.WriteLine("\t 2. Altice ");
                Console.WriteLine("\t 3. Viva ");

                Console.Write("\n\t Seleccione la compañia telefónica: ");
                int c = Convert.ToInt32(Console.ReadLine());

                var element = CRUD.GetElement(Company, c - 1);
                Console.Clear();
                Console.WriteLine("\n\t$$$$$$$$$$$$$$$$$");
                Console.WriteLine("\t$$               $$");
                Console.WriteLine("\t$$     1. 25     $$");
                Console.WriteLine("\t$$     2. 60     $$");
                Console.WriteLine("\t$$     3. 100    $$");
                Console.WriteLine("\t$$     4. 150    $$");
                Console.WriteLine("\t$$     5. 200    $$");
                Console.WriteLine("\t$$               $$");
                Console.WriteLine("\t$$$$$$$$$$$$$$$$$$$\n\n");

                Console.Write("\t Selecione el monto: ");

                int amount = Convert.ToInt32(Console.ReadLine());

                double Item = CRUD.GetElement(Amount, amount - 1);

                double balance = userindex.Balance - Item;

                if (userindex.Balance <= balance)
                {
                    Console.WriteLine("\t Balance insuficiente ");
                    Console.ReadKey();
                }
                else
                {
                    if (amount != 1 || amount != 2 || amount != 3 || amount != 4 || amount != 5)
                    {

                        Console.WriteLine("\t Este número de selección no es válido. ");
                        Console.ReadKey();
                        Menu();
                    }

                    double New = userindex.Balance - balance;
                    Console.WriteLine("\n\t Banco: " + ATM.BankName);
                    Console.WriteLine("\t Cliente: " + userindex.Name + " " + userindex.LastName);
                    Console.WriteLine("\t Compañia de telefono: " + element);
                    Console.WriteLine("\t Monto: RD$" + Item + " pesos.");
                    Console.WriteLine("\t Balance Anterior: RD$ " + userindex.Balance + " pesos.");
                    Console.WriteLine("\t Balance Actual: RD$ " + New + " pesos.");


                    DateTime date = DateTime.Today;
                    LogTransacciones log = new LogTransacciones
                    {
                        Client = (userindex.Name + " " + userindex.LastName),
                        Date = date.ToString(),
                        Type = "Compra",
                        Info = ("Compra de tarjeta de RD$" + balance + " pesos.")
                    };

                    CRUD.Add(LogTransacciones.transactions, log);



                    Console.ReadKey();

                }
            }
        }
    }
}
