using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime MealTime { get; }

        /// <summary>
        /// Справочник еды и её веса.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.",nameof(user));
            MealTime = DateTime.UtcNow;
            Foods = new Dictionary<Food,double>();
        }

        /// <summary>
        /// Добавление новой еды в справочник.
        /// </summary>
        /// <param name="food">Еда.</param>
        /// <param name="weight">Вес.</param>
        public void Add (Food food, double weight)
        {
            var currentFood = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (currentFood == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[currentFood] += weight;
            }
        }
    }
}
