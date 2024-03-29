﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : BaseController
    {
        #region Свойства контроллера
        /// <summary>
        /// Название файла, содержащего информацию о еде
        /// </summary>
        private const string FOOD_FILE_NAME = "foods.dat";

        /// <summary>
        /// Название файла, содержащего информацию о приемах пищи.
        /// </summary>
        private const string EATINGS_FILE_NAME = "eatings.dat";

        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Справочник еды.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Справочник употребления пищи.
        /// </summary>
        public Eating Eatings { get; }
        #endregion

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Foods = GetFoods();
            Eatings = GetEatings();
        }

        /// <summary>
        /// Добавление приема пищи.
        /// </summary>
        /// <param name="food">Название продукта.</param>
        /// <param name="weight">Вес.</param>
        public void AddFood(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eatings.Add(food, weight);
                Save();
            }
            else
            {
                Eatings.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Получение справочника употребления пищи.
        /// </summary>
        /// <returns></returns>
        private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получение справочника еды.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Сохранение списка еды.
        /// </summary>
        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eatings);
        }
    }
}