﻿using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// Создание нового пола.
        /// </summary>
        /// <param name="name"> Имя пола.</param>
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
