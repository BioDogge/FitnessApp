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
        #region Свойства упражнений.
        public int Id { get; set; }

        /// <summary>
        /// Дата начала упражнения.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Дата конца упражнения.
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// ID Активности пользователя.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Информация об активности.
        /// </summary>
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// ID Пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь, выполняющий упражнение.
        /// </summary>
        public virtual User User { get; set; }
        #endregion

        public Exercise()
        {

        }

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
