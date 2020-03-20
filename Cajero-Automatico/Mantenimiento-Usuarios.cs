using System;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    public class _UsersCRUD
    {

        public List<Users> _Users = new List<Users>();
        public struct Users
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string TargetNumber{ get; set; }
            public string Password { get; set; }
            public double Balance { get; set; }
        }

        public _UsersCRUD()
        {
        }
        public void Add<T>(List<T> _List, T Element)
        {
            _List.Add(Element);
        }
        public void Edit<T>(List<T> _List, int index, T Element)
        {
            _List[index] = Element;
        }
        public void Delete<T>(List<T> _List, int index)
        {
            _List.RemoveAt(index);
        }


        public void FormAddUser()
        {
            Console.Write("\t Nombre: ");
            string nameUser = Console.ReadLine();
            Console.Write("\t Apellido: ");
            string lastnameUser = Console.ReadLine();
            Console.Write("\t Número de tarjeta: ");
            string targetNumberUser = Console.ReadLine();
            Console.Write("\t Contraseña: ");
            string PasswordUser = Console.ReadLine();
            Console.Write("\t Saldo: ");
            double BalanceUser = Convert.ToInt32(Console.ReadLine());

            Users Users = new Users();

            Users.Name = nameUser;
            Users.LastName = lastnameUser;
            Users.TargetNumber = targetNumberUser;
            Users.Password = PasswordUser;
            Users.Balance = BalanceUser;
            Add(_Users, Users);

            if (_Users.Count != 0)
            {
                Console.WriteLine("usuario Guardado Con Exito!!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(" :( usuario no guardado, verifique e intente nuevamente.");
                Console.ReadKey();
            }

        }
        public void FormEditUsers()
        {
            if (_Users.Count == 0)
            {
                Console.WriteLine("\t Lista de Usuarios vacia ");
            }
            else
            {
                Console.Write("\t Introduzca el numero de la Tarjeta segun el usuario que desee editar: ");
                string targetUser = Console.ReadLine();
                var User = _Users.Find(x => x.Name == targetUser);

                if (_Users.Contains(User))
                {

                    Console.Clear();
                    Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                    Console.Write("\t Nombre: ");
                    string nameUser = Console.ReadLine();
                    Console.Write("\t Apellido: ");
                    string lastnameUser = Console.ReadLine();
                    Users Users = new Users();

                    Users.Name = nameUser;
                    Users.LastName = lastnameUser;


                    //Edit(_Users, (index - 1), Users);
                    Console.WriteLine("\t Usuario Editado Con Exito!!");
                    Console.ReadKey();

                }
            }
        }
        public void FormShowUsers()
        {
            if (_Users.Count == 0)
            {
                Console.WriteLine("\t Listado de usuarios vacia");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\t\t Listado de usuarios: ");
                int count = 1;
                foreach (Users Element in _Users)
                {
                    Console.WriteLine(count + " - " + Element.Name + " " + Element.LastName);
                    count++;
                }
            }
        }
        public void FormDeleteUser()
        {
            if (_Users.Count == 0)
            {
                Console.WriteLine("\t\t Lista de usuarios vacia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.Write("\t Introduzca el numero de la Tarjeta segun el usuario que desee editar: ");
                FormShowUsers();
                string targetUser = Console.ReadLine();

                var User = _Users.Find(x => x.TargetNumber == targetUser);

               // Delete(_Users, (User.TargetNumber - 1));
                Console.WriteLine("\t usuario eliminado! \n");
                FormShowUsers();
                Console.ReadKey();
            }
        }


    }
}
