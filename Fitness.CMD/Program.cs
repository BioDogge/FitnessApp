using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness Trackers!" + Environment.NewLine);

            Console.Write("Введите имя пользователя: ");
            var userName = Console.ReadLine();

            var userController = new UserController(userName);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                var dateOfBirth = ParseToDateTime();
                var weight = ParseToDouble("вес");
                var height = ParseToDouble("рост");

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
        }

        private static DateTime ParseToDateTime()
        {
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write("Введите дату рождения (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно указана дата рождения.");
                }
            }

            return dateOfBirth;
        }

        private static double ParseToDouble(string valueString)
        {
            while (true)
            {
                Console.Write($"Введите {valueString}: ");
                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверно указан {valueString}.");
                }
            }
        }
    }
}
