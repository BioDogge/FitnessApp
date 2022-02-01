using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Абстрактный класс, реализующий сохранение и загрузку данных о пользователе.
    /// </summary>
    public abstract class BaseController
    {
        protected void Save(string fileName, object type)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, type);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T types)
                {
                    return types;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
