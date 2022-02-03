using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Абстрактный класс, реализующий сохранение и загрузку данных из файлов.
    /// </summary>
    public abstract class BaseController
    {
        protected IDataSaver dataSaver = new DataBaseDataSaver();

        protected void Save(string fileName, object type)
        {
            dataSaver.Save(fileName, type);
        }

        protected T Load<T>(string fileName) where T : class
        {
            return dataSaver.Load<T>(fileName);
        }
    }
}
