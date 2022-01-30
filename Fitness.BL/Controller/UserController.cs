using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Название файла, содержащего информацию о пользователях.
        /// </summary>
        private const string USER_FILE_NAME = "users.dat";
        /// <summary>
        /// Пользователь.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Флаг на проверку нового пользователя.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Добавление данных для нового пользователя.
        /// </summary>
        /// <param name="gender">Пол пользователя.</param>
        /// <param name="dateOfBirth">Дата рождения пользователя.</param>
        /// <param name="weight">Вес пользователя.</param>
        /// <param name="height">Рост пользователя.</param>
        public void SetNewUserData(string gender, DateTime dateOfBirth, double weight = 1, double height = 1)
        {
            //TODO: Реализовать проверку входных данных

            CurrentUser.Gender = new Gender(gender);
            CurrentUser.DateOfBirth = dateOfBirth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }
    }
}