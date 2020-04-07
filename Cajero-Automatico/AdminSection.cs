using System;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    [Serializable]
    public static class AdminSection
    {
        public static List<_UsersCRUD> _Users = new List<_UsersCRUD>();


        public enum AdminMenu
        {

            ADD_USER = 1,
            EDIT_USER,
            DELETE_USER,
            SHOW_USER,
            RESTART_PASSWORDS,
            TRANSACTIONS,
            ATM,
            USER_ADMINISTRATION,
            USER_ACTIVE,
            ADD_BALANCE,
            CLOSE_SECTION
        }
        public static void Menu_Admin()
        {
            while (true)
            {

                Console.Clear();
                Console.Title = "SECCIÓN ADMINISTRADOR";
                Console.WriteLine("\n\n\t\t ################################################\n");
                Console.WriteLine("\t\t #### MENU PRINCIPAL - SECCIÓN ADMINISTRADOR ####\n");
                Console.WriteLine("\t\t ################################################\n");
                Console.WriteLine("\t\t 1. Agregar Usuario.");
                Console.WriteLine("\t\t 2. Editar Usuario. ");
                Console.WriteLine("\t\t 3. Eliminar Usuario. ");
                Console.WriteLine("\t\t 4. Listar Usuarios. ");
                Console.WriteLine("\t\t 5. Restablecer Contraseña. ");
                Console.WriteLine("\t\t 6. Ver Log de Transacciones. ");
                Console.WriteLine("\t\t 7. Configuracion de ATM. ");
                Console.WriteLine("\t\t 8. Administrar usuarios. ");
                Console.WriteLine("\t\t 9. Reactivación de usuario. ");
                Console.WriteLine("\t\t 10. Agregar saldo. ");
                Console.WriteLine("\t\t 0. Cerrar sección. \n");
                try
                {
                    Console.Write("\t Ingrese el número segun la opcion deseada: ");
                    int Menu = Convert.ToInt32(Console.ReadLine());


                    switch (Menu)
                    {
                        case (int)AdminMenu.ADD_USER:
                            _UsersCRUD.FormAddUser();
                            break;
                        case (int)AdminMenu.EDIT_USER:
                            _UsersCRUD.FormEditUsers();
                            break;
                        case (int)AdminMenu.DELETE_USER:
                            _UsersCRUD.FormDeleteUser();
                            break;
                        case (int)AdminMenu.SHOW_USER:
                            Console.Clear();
                            _UsersCRUD.FormShowUsers(true);
                            break;
                        case (int)AdminMenu.RESTART_PASSWORDS:
                            RestartPassword.Restart();
                            break;
                        case (int)AdminMenu.TRANSACTIONS:
                            LogTransacciones.Show(true);
                            break;
                        case (int)AdminMenu.ATM:
                            ATM.Menu_ATM();
                            break;
                        case (int)AdminMenu.USER_ADMINISTRATION:
                            UserAdminAdministrator.MenuAdmin();
                            break;
                        case (int)AdminMenu.USER_ACTIVE:
                            ActiveUser.Active();
                            break;
                        case (int)AdminMenu.ADD_BALANCE:
                            AddBalance.AddB();
                            break;
                        case 0:
                            Console.Write("\t Sección de Administrador cerrada ");
                            Console.ReadKey();
                            Login._Login();
                            break;
                        default:
                            Menu_Admin();
                            break;
                    }
                }
                catch (Exception)
                {
                    Menu_Admin();
                }
            }
        }
    }
}
