using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    /// 
    [Serializable]
    public class User
    {
        //HACK: Свойства Gender и DateOfBirth незащищенные, необходимо для них добавить поля и в свойствах реализовать проверку на входные данные
        #region Свойства пользователя
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        #endregion

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="gender">Пол пользователя.</param>
        /// <param name="dateOfBirth">Дата рождения пользователя.</param>
        /// <param name="weight">Вес пользователя.</param>
        /// <param name="height">Рост пользователя.</param>
        public User(string name, Gender gender, DateTime dateOfBirth, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            }

            if (dateOfBirth < DateTime.Parse("01.01.1900") || dateOfBirth >= DateTime.Now)
            {
                throw new ArgumentException("Неправильно введена дата рождения.", nameof(dateOfBirth));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}