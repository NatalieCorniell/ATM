using System;
using System.Collections.Generic;
using PanoramicData.ConsoleExtensions;

namespace CajeroAutomatico
{
    [Serializable]
    public class UserAdminAdministrator
    {
        public static List<UserAdminAdministrator> _UsersAdmin = new List<UserAdminAdministrator>();
        public static List<string> _TargetNumberValidation = new List<string>();

        public string Name { get; set; }
        public string LastName { get; set; }
        public string TargetNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        private enum MenuA
        {
            ADD_ADMIN = 1,
            EDIT_ADMIN,
            SHOW_ADMIN,
            DELETE_ADMIN
        }
        public static void MenuAdmin()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.Title = "SECCIÓN USUARIOS ADMINISTRADOR";
                    Console.WriteLine("\t\t #### MENU - SECCIÓN USUSARIOS 'ADMINISTRADORÚ ####\n");

                    Console.WriteLine("\t 1. Agregar Usuario.");
                    Console.WriteLine("\t 2. Editar Usuario. ");
                    Console.WriteLine("\t 3. Listar Usuarios. ");
                    Console.WriteLine("\t 4. Eliminar Usuario.");
                    Console.WriteLine("\t 0. Volver");

                    Console.Write("\n\t\tSeleccione la opción que desee realizar: ");
                    int menu = Convert.ToInt32(Console.ReadLine());
                    switch (menu)
                    {
                        case (int)MenuA.ADD_ADMIN:
                            Add_UserAdmin();
                            break;
                        case (int)MenuA.EDIT_ADMIN:
                            Edit_UserAdmin();
                            break;
                        case (int)MenuA.SHOW_ADMIN:
                            Console.Clear();
                            List_UserAdmin(true);
                            break;
                        case (int)MenuA.DELETE_ADMIN:
                            Delete_UserAdmin();
                            break;
                        case 0:
                            Exit();
                            break;
                        default:
                           MenuAdmin();
                            break;
                    }
                }
            }
            catch (Exception) { MenuAdmin(); }
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
        private static void Add_UserAdmin()
        {
            try
            {

                Console.Clear();
                Console.Write("\t Nombre: ");
                string nameUserAdmin = Console.ReadLine();
                Console.Write("\t Apellido: ");
                string lastnameUserAdmin = Console.ReadLine();
                Console.Write("\t Número de tarjeta: ");
                string targetNumberUserAdmin = Console.ReadLine();
                Console.Write("\t Contraseña: ");
                string PasswordUser = ConsolePlus.ReadPassword();

                if (nameUserAdmin == "" || nameUserAdmin == "" ||
                   targetNumberUserAdmin == "" || PasswordUser == "")
                {
                    Console.WriteLine("\n\t Debe llenar todos los campos. \n ");
                    Console.ReadKey();
                    Add_UserAdmin();
                }
                else
                {
                    if (Validation(targetNumberUserAdmin))
                    {
                        UserAdminAdministrator Users = new UserAdminAdministrator
                        {
                            Name = nameUserAdmin,
                            LastName = lastnameUserAdmin,
                            TargetNumber = targetNumberUserAdmin,
                            Password = PasswordUser,
                            Role = "Administrador"
                        };

                        CRUD.Add(_UsersAdmin, Users);
                    }
                    else
                    {
                        Console.WriteLine("\t\t ERROR. Número de tarjeta ya existente.\n");
                        Console.ReadKey();
                        Add_UserAdmin();
                    }
                }

                if (_UsersAdmin.Count != 0)
                {
                    Console.WriteLine("\n\n\t\t Usuario Guardado Con Exito!!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\n\t :( usuario no guardado, verifique e intente nuevamente.");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n\n \t\t ERROR!! \n");

                Console.WriteLine("\n\t :( usuario no guardado, verifique e intente nuevamente. \n");
                Console.ReadKey();
                Add_UserAdmin();
            }
        }
        public static void Edit_UserAdmin()
        {

            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t Lista de Usuarios vacia ");
            }
            else
            {
                Console.Clear();
                try
                {
                    Console.Write("\t Introduzca el número de la Tarjeta: ");
                    string targetUser = Console.ReadLine();
                    var User = _UsersAdmin.Find(x => x.TargetNumber == targetUser);

                    var userindex = CRUD.GetElement(_UsersAdmin, _UsersAdmin.IndexOf(User));

                    if (_UsersAdmin.Contains(User))
                    {

                        Console.Clear();
                        Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                        Console.Write("\t Nombre: ");
                        string nameUser = Console.ReadLine();
                        Console.Write("\t Apellido: ");
                        string lastnameUser = Console.ReadLine();
                        UserAdminAdministrator UsersA = new UserAdminAdministrator
                        {
                            Name = nameUser,
                            LastName = lastnameUser
                        };
                        int indexTarget = _UsersAdmin.IndexOf(User);


                        CRUD.Edit(_UsersAdmin, indexTarget, UsersA);

                        Console.WriteLine("\t Usuario Editado Con Exito!!");
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
                            Edit_UserAdmin();
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
                        Edit_UserAdmin();
                    }

                    Console.ReadKey();
                    AdminSection.Menu_Admin();
                }
            }
        }
        public static void List_UserAdmin(bool IsWait = false)
        {
            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t Listado de usuarios vacia");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\t\t Listado de usuarios: ");
                int count = 1;
                foreach (UserAdminAdministrator Element in _UsersAdmin)
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
        public static void Delete_UserAdmin()
        {

            try
            {
                if (_UsersAdmin.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t Lista de usuarios vacia");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.Write("\t Introduzca el número de la Tarjeta: ");
                    string targetUser = Console.ReadLine();

                    var User = _UsersAdmin.Find(x => x.TargetNumber == targetUser);

                    var userindex = CRUD.GetElement(_UsersAdmin, _UsersAdmin.IndexOf(User));

                    if (_UsersAdmin.Contains(userindex))
                    {
                        Console.Write("\n\t Está seguro que desa eliminar este usuario ? S/N : ");
                        string selection = Console.ReadLine();
                        if (selection == "s")
                        {
                            int indexTarget = _UsersAdmin.IndexOf(userindex);

                            CRUD.Delete(_UsersAdmin, indexTarget);

                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\t\t#######################################\n");
                            Console.WriteLine("\t\t#### Usuario Eliminado Con Exito!! ####\n");
                            Console.WriteLine("\t\t#######################################\n");
                            Console.ReadKey();
                            AdminSection.Menu_Admin();
                        }
                        else
                        {
                            Console.WriteLine("\t Eliminación cancelada \n");
                            Console.ReadKey();
                            AdminSection.Menu_Admin();
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
                            Delete_UserAdmin();
                        }

                        Console.ReadKey();
                        AdminSection.Menu_Admin();
                    }
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
                    Delete_UserAdmin();
                }

                Console.ReadKey();
                AdminSection.Menu_Admin();
            }
        }
        public static void Exit()
        {
            Console.Clear();
            Console.Write("\n\n\t\t ¿Desea cerrar sección?\n1-Si\n2-No");
            int resp = Convert.ToInt32(Console.ReadLine());
            switch (resp)
            {
                case 1:
                    Login._Login();
                    break;
                case 2:
                    AdminSection.Menu_Admin();
                    break;
            }
        }
    }
}
