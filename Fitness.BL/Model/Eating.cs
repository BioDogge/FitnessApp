using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства приема пищи
        public int Id { get; set; }

        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime MealTime { get; set; }

        /// <summary>
        /// Справочник еды и её веса.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        /// <summary>
        /// ID Пользователя.
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion

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
