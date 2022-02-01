using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Описание упражнений пользователя.
    /// </summary>
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Дата начала упражнения.
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// Дата конца упражнения.
        /// </summary>
        public DateTime FinishTime { get;  }

        /// <summary>
        /// Информация об активности.
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Пользователь, выполняющий упражнение.
        /// </summary>
        public User User { get; }

        public Exercise(DateTime startTime, DateTime finishTime, Activity activity, User user)
        {
            //TODO: Реализовать проверку входных данных

            StartTime = startTime;
            FinishTime = finishTime;
            Activity = activity;
            User = user;
        }
    }
}
