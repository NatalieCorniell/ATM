using System;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    [Serializable]
    public class LogTransacciones
    {
        public static List<LogTransacciones> transactions = new List<LogTransacciones>();
        public string Client { get; set; }
        public string Target { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Info { get; set; }
        public static void test(bool IsWait = false)
        {

            Console.WriteLine("\t\t Listado de transacciones: ");
            int count = 1;
            foreach (LogTransacciones Element in transactions)
            {
                Console.WriteLine(count + " - \t Cliente : " + Element.Client + " \n"
                    + "\t Tipo de transacción: " + Element.Type + " \n"
                    + "\t Fecha: " + Element.Date + " \n"
                    + "\t Información: " + Element.Info);
                count++;
            }
            if (IsWait)
            {
                Console.ReadKey();
            }


        }
        public static void Show(bool IsWait = false)
        {

            if (transactions.Count == 0)
            {
                Console.WriteLine("\t No se ha realizado una transacción");
                Console.ReadKey();

            }
            else
            {
                Console.Clear();
                Console.Write("\t Ingrese el número de tarjeta: ");

                string target = Console.ReadLine();

                var User = transactions.Find(x => x.Target == target);

                var userindex = CRUD.GetElement(transactions, transactions.IndexOf(User));

                if (transactions.Contains(userindex))
                {
                    int count = 1;
                    foreach (LogTransacciones Element in transactions)
                    {
                        Console.WriteLine(count + " - \t Cliente : " + Element.Client + " \n"
                            + "\t Tipo de transacción: " + Element.Type + " \n"
                            + "\t Fecha: " + Element.Date + " \n"
                            + "\t Información: " + Element.Info);
                        count++;
                    }
                    if (IsWait)
                    {
                        Console.ReadKey();
                    }

                }

            }
        }
    }
}
