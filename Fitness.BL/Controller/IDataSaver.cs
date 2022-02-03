
namespace Fitness.BL.Controller
{
    /// <summary>
    /// Интерфейс, описывающий работу с данными в файлах.
    /// </summary>
    public interface IDataSaver
    {
        void Save(string fileName, object type);
        T Load<T>(string fileName) where T : class;
    }
}
