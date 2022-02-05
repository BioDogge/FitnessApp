
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Интерфейс, описывающий работу с данными.
    /// </summary>
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
    }
}