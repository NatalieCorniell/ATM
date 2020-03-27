using System;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    public class CRUD
    {
        public CRUD()
        {
        }
        public static void Add<T>(List<T> list, T item)
        {
            list.Add(item);
        }
        public static T GetElement<T>(List<T> list, int index)
        {
            return list[index];
        }
        public static void Edit<T>(List<T> list, int index, T value)
        {
            list[index] = value;
        }
        public static void Delete<T>(List<T> list, int? index)
        {
            int indice = index ?? 0;

            list.RemoveAt(indice);
        }
        public static void Show<T>(List<T> list, bool IsWait = false)
        {
            int count = 1;
            foreach (T item in list)
            {
                Console.WriteLine(count + "- " + item);
                count++;
            }

            if (IsWait)
            {
                Console.ReadKey();
            }
        }
    }
}
