using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер упражнений.
    /// </summary>
    public class ExerciseController : BaseController
    {
        #region Свойства упражнений
        /// <summary>
        /// Название файла, содержащего информацию о упражнениях.
        /// </summary>
        private const string EXERCISES_FILE_NAME = "exercises.dat";

        /// <summary>
        /// Название файла, содержащего информацию о активности.
        /// </summary>
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        /// <summary>
        /// Пользователь, который выполняет упражнение.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список упражнений.
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Список активности.
        /// </summary>
        public List<Activity> Activities { get; }
        #endregion

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetExercises();
            Activities = GetActivities();
        }

        public void Add(Activity activity, DateTime startTime, DateTime finishTime)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(startTime, finishTime, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(startTime, finishTime, act, user);
                Exercises.Add(exercise);
            }

            Save();
        }

        /// <summary>
        /// Получение списка активности.
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Получение списка упражнений.
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Сохранение упражнений.
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
