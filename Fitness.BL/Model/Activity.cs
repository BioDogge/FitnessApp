using System;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Описание активности пользователя.
    /// </summary>
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get;  }

        /// <summary>
        /// Количество сожженных калорий за минуту.
        /// </summary>
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            //TODO: Реализовать проверку входных данных

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
