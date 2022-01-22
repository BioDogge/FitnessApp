using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(string userName, string genderName, DateTime dateOfBirth, double weight, double height)
        {
            // TODO: Необходима проверка входных данных

            var gender = new Gender(genderName);
            User = new User(userName, gender, dateOfBirth, weight, height);
        }
        /// <summary>
        /// Получение данных пользователя.
        /// </summary>
        /// <returns>Данные пользователя.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                // TODO: Нужно реализовать чтение пользователя, а так же случай, если его не прочитали
            }
        }

        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
