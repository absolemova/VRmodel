using System;
using System.IO;

namespace VideoRental
{
    class Menu
    {
        public static UserInput UserChoice()
        {
            // берем все "названия", объявленные в перечислении UserInput
            Type type = typeof(UserInput);
            Array values = type.GetEnumValues();

            Console.WriteLine("\tСписок дозволенного:");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{Enum.Format(type, values.GetValue(i), "D")}.    {values.GetValue(i)}");
            }
            Console.Write(">>>");
            string key = Console.ReadLine();
            // если нажали что-то нормальное, то очищаем экран
            if (!string.IsNullOrWhiteSpace(key))
                Console.Clear();

            return (UserInput)Enum.Parse(type, key);
        }
    }
}
