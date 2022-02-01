using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("MainGreeting", culture) + Environment.NewLine);

            Console.Write(resourceManager.GetString("EnterName", culture));
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                var dateOfBirth = ParseToDateTime("дату рождения");
                var weight = ParseToDouble("вес");
                var height = ParseToDouble("рост");

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.Write(Environment.NewLine);

            while (true)
            {
                Console.WriteLine("Что необходимо сделать?");
                Console.WriteLine("Нажмите \"E\" чтобы ввести прием пищи.");
                Console.WriteLine("Нажмите \"A\" чтобы ввести упражнение.");
                Console.WriteLine("Нажмите \"Q\" для выхода из приложения.");


                var key = Console.ReadKey();

                Console.Write(Environment.NewLine);

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.AddFood(food.Food, food.Weight);

                        foreach (var item in eatingController.Eatings.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }

                        break;
                    case ConsoleKey.A:
                        var getDataForExercise = EnterExercise();

                        exerciseController.Add(getDataForExercise.Activity, getDataForExercise.StartTime, getDataForExercise.FinishTime);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.StartTime.ToShortTimeString()} до {item.FinishTime.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);

                        break;

                }

                Console.ReadKey();
            }
        }

        private static (DateTime StartTime, DateTime FinishTime, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseToDouble("расход энергии в минуту");

            var startTime = ParseToDateTime("начало упражнения");
            var finishTime = ParseToDateTime("окончание упражнения");

            var activity = new Activity(name, energy);

            return (StartTime: startTime, FinishTime: finishTime, Activity: activity);
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
        /// Преобразование введенных пользователем данных в тип "DateTime".
        /// </summary>
        /// <returns></returns>
        private static DateTime ParseToDateTime(string valueString)
        {
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write($"Введите {valueString} (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Данные неверно указано.");
                }
            }

            return dateOfBirth;
        }

        /// <summary>
        /// Преобразование введенных польователем данных в тип "double".
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
