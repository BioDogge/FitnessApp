using System;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Абстрактный класс, реализующий динамическое изменение способа работы с данными.
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Менеджер, реализующий способ работы с данными.
        /// </summary>
        private readonly IDataSaver manager = new SerializeDataSaver(); //реализация EF не работает c:

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        /// <summary>
        /// Загрузка данных.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
