﻿using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        #region Свойства гендера
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        #endregion

        public Gender()
        {

        }

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
