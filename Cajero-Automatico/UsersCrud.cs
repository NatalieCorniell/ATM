using System;
using System.Collections.Generic;
using System.Linq;
using PanoramicData.ConsoleExtensions;
namespace CajeroAutomatico
{
    public class _UsersCRUD
    {
        public static List<string> _TargetNumberValidation = new List<string>();
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TargetNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public string Role { get; set; }

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
                Console.Write("\t Pin de Contraseña: ");
                string PasswordUser = ConsolePlus.ReadPassword();
                Console.Write("\n\t Saldo inicial: ");
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
                    if (Validation(targetNumberUser))
                    {
                        CRUD.Add(_TargetNumberValidation, targetNumberUser);
                        _UsersCRUD Users = new _UsersCRUD
                        {
                            Name = nameUser,
                            LastName = lastnameUser,
                            TargetNumber = targetNumberUser,
                            Password = PasswordUser,
                            Balance = BalanceUser,
                            Role = "Cliente"
                        };
                        CRUD.Add(AdminSection._Users, Users);
                    }
                    else
                    {
                        Console.WriteLine("\t\t ERROR. Número de tarjeta ya existente.\n");
                        Console.ReadKey();
                        FormAddUser();
                    }

                }

                if (AdminSection._Users.Count != 0)
                {
                    Console.WriteLine("\n\n\n\n\n\n\t\t########################################\n");
                    Console.WriteLine("\t\t##### Usuario Guardado Con Exito!! #####\n");
                    Console.WriteLine("\t\t########################################\n");

                    Console.Write("\n\t\t Desea agregar otro usuario? S/N : ");
                    string selection = Console.ReadLine();
                    if (selection == "s")

                    {
                        FormAddUser();
                    }

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


                    var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

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


                            CRUD.Edit(AdminSection._Users, indexTarget, Users);

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
                        Console.WriteLine("\n\t\t No existe un usuario con este número de tarjeta \n");
                        Console.Write("\n\t\t Desea realizar otra busqueda? S/N : ");
                        string selection = Console.ReadLine();
                        if (selection == "s")

                        {
                            FormEditUsers();
                        }

                        Console.ReadKey();
                        AdminSection.Menu_Admin();
                    }

                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t No existe un usuario con este número de tarjeta \n");
                    Console.Write("\n\t\t Desea realizar otra busqueda? S/N : ");
                    string selection = Console.ReadLine();
                    if (selection == "s")

                    {
                        FormEditUsers();
                    }

                    Console.ReadKey();
                    AdminSection.Menu_Admin();
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

                    FormShowUsers(false);
                    Console.Write("\t Introduzca el número de la Tarjeta: ");
                    string targetUser = Console.ReadLine();

                    /* var User = AdminSection._Users.Find(x => x.TargetNumber == targetUser);


                     var UserIndex = CRUD.GetElement(AdminSection._Users, User);

                     if (AdminSection._Users.Contains(UserIndex))
                     {

                         var ind = CRUD.GetElement(AdminSection._Users, UserIndex);
 */
                    var User = AdminSection._Users.Find(x => x.TargetNumber == targetUser);


                    var userindex = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(User));

                    if (AdminSection._Users.Contains(userindex))
                    {

                        Console.WriteLine("\t Está seguro que desa eliminar este usuario ? \n");
                        string s = Console.ReadLine();
                        if (s == "s")
                        {

                            int indexTarget = AdminSection._Users.IndexOf(User);

                            CRUD.Delete(AdminSection._Users, indexTarget);

                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\t\t################################################\n");
                            Console.WriteLine("\t\t############# Usuario Eliminado Con Exito!! #####\n");
                            Console.WriteLine("\t\t################################################\n");
                            AdminSection.Menu_Admin();
                            Console.ReadKey();
                        }
                        Console.WriteLine("\t Eliminación cancelada \n");

                        AdminSection.Menu_Admin();
                        Console.ReadKey();
                    }
                    else
                    {


                        Console.Clear();
                        Console.WriteLine("\n\t\t No existe un usuario con este número de tarjeta \n");
                        Console.Write("\n\t\t Desea realizar otra busqueda? S/N : ");
                        string selection = Console.ReadLine();
                        if (selection == "s")

                        {
                            FormDeleteUser();
                        }

                        Console.ReadKey();
                        AdminSection.Menu_Admin();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n\t\t ERROR DE SISTEMA!\n");
                Console.ReadKey();
                AdminSection.Menu_Admin();
            }

            /*
                                var User = CRUD.GetElement(AdminSection._Users, AdminSection._Users.IndexOf(UserIndex));

                                var UserIndex = AdminSection._Users.Find(x => x.TargetNumber == targetUser).TargetNumber.IndexOf(targetUser);



                                if (AdminSection._Users.Contains(User))
                                {


                                }*/
        }
        public static bool Validation(string Elements)
        {
            bool valid = true;
            foreach (string element in _TargetNumberValidation)
            {
                if (element == Elements)
                {
                    valid = false;
                }
            }

            return valid;
        }
    }
}
