using System;
namespace CajeroAutomatico
{
    public class Seccion_Administrador
    {
        public Seccion_Administrador()
        {
        }
        enum MenuData
        {

        }
        public void Menu_Admin()
        {
            Console.Clear();
            Console.Title = "SECCION ADMINISTRADOR";
            Console.WriteLine("\n\t\t MENU PRINCIPAL \n");
            Console.WriteLine("\t 1. Agregar Usuario.");
            Console.WriteLine("\t 2. Editar Usuario. ");
            Console.WriteLine("\t 3. Eliminar Usuario. ");
            Console.WriteLine("\t 4. Restablecer Contraseña. ");
            Console.WriteLine("\t 5. Ver Log de Transacciones. ");
            Console.WriteLine("\t 6. Configuracion de ATM. ");
            Console.WriteLine("\t 7. Administrar usuarios. ");
            Console.WriteLine("\t 8. Reactivación de usuario. ");
            Console.WriteLine("\t 0. Cerrar seccion. \n");

            Console.Write("\t Ingrese el numero segun la opcion deseada: ");
            int Menu = Convert.ToInt32(Console.ReadLine());
            Mantenimiento_Usuarios mantenimiento_Usuarios = new Mantenimiento_Usuarios();

            switch (Menu)
            {
                case 1:
                    mantenimiento_Usuarios.FormAddUser();
                    break;
                case 2:
                    mantenimiento_Usuarios.FormEditUsers();
                    break;
                case 3:
                    mantenimiento_Usuarios.FormDeleteUser();
                    break;
                case 0:
                    Login login = new Login();
                    login._Login();
                    Console.Write("\t Seccion de Administrador cerrada ");
                    Console.ReadKey();
                    break;

            }


        }
    }
}
