using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Еда и её полезные вещества.
    /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства еды
        public int Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество белков в 100 гр. продукта.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Количество жиров в 100 гр. продукта.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Количество углеводов в 100 гр. продукта.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Количество калорий в 100 гр. продукта.
        /// </summary>
        public double Calories { get; set; }
        #endregion

        public Food (string name) :
            this (name, 0, 0, 0, 0)
        {

        }

        public Food (string name, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO: Реализовать проверку входных даннных

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
