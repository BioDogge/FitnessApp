using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Класс, реализующий работу с данными из файлов.
    /// </summary>
    class SerializeDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T : class
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

        public void Save(string fileName, object type)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, type);
            }
        }
    }
}
