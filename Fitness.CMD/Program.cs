using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness Trackers");

            Console.Write("Введите имя пользователя: ");
            var userName = Console.ReadLine();

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine()); //HACK: Необходимо переписать под TryParse

            Console.Write("Введите вес: ");
            var weight = Double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(userName, gender, dateOfBirth, weight, height);
            userController.Save();
        }
    }
}
