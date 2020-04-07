using System;
namespace CajeroAutomatico
{
    [Serializable]

    public class AddBalance
    {
        public static void AddB()
        {

            Console.Clear();
            Console.Write("\t El número de tarjeta del destinatario: ");
            string targetNumber = Console.ReadLine();
            var User = AdminSection._Users.Find(x => x.TargetNumber == targetNumber);
            var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

            if (AdminSection._Users.Contains(userindex))
            {
                Console.Write("\n\t  Introduzca el monto: ");
                double amount = Convert.ToInt32(Console.ReadLine());

                double newB = userindex.Balance += amount;

                Console.WriteLine("\t\t##### Se han agregado RD$ " + amount + " pesos. #####\n");
                Console.WriteLine("\t\t##### Nuevo balance: " + newB + " #####\n");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t##### Usuario no encontrado #####\n");
                Console.Write("\n\t\t Desea realizar otra busqueda? S/N : ");
                string s = Console.ReadLine();
                if (s == "s")
                {
                    AddB();
                }
                AdminSection.Menu_Admin();
            }
        }
    }
}
