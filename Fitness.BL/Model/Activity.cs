using Fitness.BL.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Описание активности пользователя.
    /// </summary>
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Количество сожженных калорий за минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        public Activity()
        {

        }

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
