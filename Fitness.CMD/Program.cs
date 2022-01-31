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
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.Write(Environment.NewLine);

            Console.WriteLine("Что необходимо сделать?");
            Console.WriteLine("Нажмите \"E\" чтобы ввести прием пищи");
            var key = Console.ReadKey();

            Console.Write(Environment.NewLine);

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.AddFood(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eatings.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Добавление продукта и приема пищи пользователем.
        /// </summary>
        /// <returns></returns>
        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var nameFood = Console.ReadLine();

            var calories = ParseToDouble("калорийность");
            var proteins = ParseToDouble("количество белков");
            var fats = ParseToDouble("количество жиров");
            var carbohydrates = ParseToDouble("количество углеводов");

            var weight = ParseToDouble("вес порции");
            var product = new Food(nameFood, proteins, fats, carbohydrates, calories);

            return (Food: product, Weight: weight);
        }

        /// <summary>
        /// Преобразование даты рождения пользователя в необходимый формат.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Преобразование вводимых польователем данных в тип "double".
        /// </summary>
        /// <param name="valueString"></param>
        /// <returns></returns>
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
                    Console.WriteLine($"Поле \"{valueString}\" неверно указано.");
                }
            }
        }
    }
}
