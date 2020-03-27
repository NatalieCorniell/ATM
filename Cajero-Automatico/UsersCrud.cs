using System;
using System.Collections.Generic;
using System.Linq;
using PanoramicData.ConsoleExtensions;
namespace CajeroAutomatico
{
    public class _UsersCRUD
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TargetNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public const string role = "Cliente";

        public static void FormAddUser()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t Llene los campos ");
                Console.Write("\t Nombre: ");
                string nameUser = Console.ReadLine();
                Console.Write("\t Apellido: ");
                string lastnameUser = Console.ReadLine();
                Console.Write("\t Número de tarjeta: ");
                string targetNumberUser = Console.ReadLine();



                Console.Write("\t Contraseña: ");
                string PasswordUser = ConsolePlus.ReadPassword(); ;

               /* do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        PasswordUser += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && PasswordUser.Length > 0)
                        {
                            PasswordUser = PasswordUser.Substring(0, (PasswordUser.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);*/

                Console.Write("\n\t Saldo inicial: "  + PasswordUser);
                double BalanceUser = Convert.ToInt32(Console.ReadLine());


                if (nameUser == "" || lastnameUser == "" ||
                    targetNumberUser == "" || PasswordUser == "" ||
                    BalanceUser <= 0)
                {
                    Console.WriteLine("\n\t Debe llenar todos los campos. \n ");
                    Console.ReadKey();
                    FormAddUser();
                }
                else
                {
                    _UsersCRUD Users = new _UsersCRUD
                    {
                        Name = nameUser,
                        LastName = lastnameUser,
                        TargetNumber = targetNumberUser,
                        Password = PasswordUser,
                        Balance = BalanceUser
                    };
                    CRUD.Add(AdminSection._Users, Users);
                }

                if (AdminSection._Users.Count != 0)
                {
                    Console.WriteLine("\n\n\n\n\n\n\t\t########################################\n");
                    Console.WriteLine("\t\t##### Usuario Guardado Con Exito!! #####\n");
                    Console.WriteLine("\t\t########################################\n");
                    Console.ReadKey();
                    AdminSection.Menu_Admin();

                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n\n \t\t ERROR!! \n");

                Console.WriteLine("\t :( usuario no guardado, verifique e intente nuevamente. \n");
                Console.ReadKey();
                FormAddUser();
            }

        }
        public static void FormEditUsers()
 
        {
            if (AdminSection._Users.Count == 0)
            {
                Console.WriteLine("\t Lista de Usuarios vacia-sección editar ");
            }
            else
            {
                Console.Clear();
                try
                {
                    Console.Write("\t Introduzca el número de la Tarjeta: ");
                    string targetUser = Console.ReadLine();
                    var User = AdminSection._Users.Find(x => x.TargetNumber == targetUser);


                  var userindex =  CRUD.GetElement(AdminSection._Users, (AdminSection._Users.IndexOf(User) - 1));

                        if (AdminSection._Users.Contains(userindex))
                        {

                            Console.Clear();
                            Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                            Console.Write("\t Nombre: ");
                            string nameUser = Console.ReadLine();
                            Console.Write("\t Apellido: ");
                            string lastnameUser = Console.ReadLine();

                        if (nameUser == "" || targetUser == "")
                        {
                            Console.WriteLine("\n\t Debe llenar todos los campos. \n ");
                            Console.ReadKey();
                            FormAddUser();
                        }
                        else
                        {

                            _UsersCRUD Users = new _UsersCRUD
                            {
                                Name = nameUser,
                                LastName = lastnameUser
                            };


                            //CRUD.Edit(AdminSection._Users, (User.ToString().IndexOf(User.ToString()) - 1), Users);

                            int indexTarget = AdminSection._Users.IndexOf(User);


                            CRUD.Edit(AdminSection._Users, indexTarget - 1 , Users);

                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\t\t########################################\n");
                            Console.WriteLine("\t\t##### Usuario Editado Con Exito!! #####\n");
                            Console.WriteLine("\t\t########################################\n");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t No existe usuario con este número de tarjeta \n");
                        Console.ReadKey();
                        AdminSection.Menu_Admin();
                    }

                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n \t\t ERROR DE SISTEMA! \n");
                    Console.ReadKey();
                    FormEditUsers();
                }
            }
        }
        public static void FormShowUsers(bool IsWait = false)

        {
            if (AdminSection._Users.Count == 0)
            {
                Console.WriteLine("\t Listado de usuarios vacia");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\t\t Listado de usuarios: ");
                int count = 1;
                foreach (_UsersCRUD Element in AdminSection._Users)
                {
                    Console.WriteLine(count + " - " + Element.Name + " " + Element.LastName);
                    count++;
                }
                if (IsWait)
                {
                    Console.ReadKey();
                }
            }
        }
        public static void FormDeleteUser()

        {
            try
            {
                if (AdminSection._Users.Count == 0)
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

                    var User = AdminSection._Users.Find(x => x.TargetNumber == targetUser).TargetNumber.IndexOf(targetUser);


                    CRUD.GetElement(AdminSection._Users, User - 1);


                    CRUD.Delete(AdminSection._Users, (User - 1));


                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\t\t################################################\n");
                    Console.WriteLine("\t\t############# Usuario Eliminado Con Exito!! #####\n");
                    Console.WriteLine("\t\t################################################\n");
                    FormDeleteUser();
                    Console.ReadKey();
                }
            }
            catch (Exception) {
                Console.WriteLine("\n\t\t ERROR DE SISTEMA!\n");
                Console.ReadKey();
                AdminSection.Menu_Admin();
            }
        }

    }
}
