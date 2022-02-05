using Fitness.BL.Model;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Класс, реализующий работу с данными в базе данных.
    /// </summary>
    public class DataBaseDataSaver : IDataSaver
    {
        /// <summary>
        /// Загрузка данных из базы данных.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        /// <summary>
        /// Сохранение данных в базу данных.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }

        //public void Save(string fileName, object type)
        //{
        //    using (var db = new FitnessContext())
        //    {
        //        switch (type)
        //        {
        //            case User user:
        //                db.Users.Add(type as User);

        //                break;
        //            case Gender gender:
        //                db.Genders.Add(type as Gender);

        //                break;
        //            case Food food:
        //                db.Foods.Add(type as Food);

        //                break;
        //            case Exercise exercise:
        //                db.Exercises.Add(type as Exercise);

        //                break;
        //            case Eating eating:
        //                db.Eatings.Add(type as Eating);

        //                break;
        //            case Activity activity:
        //                db.Activities.Add(type as Activity);

        //                break;
        //        }

        //        db.SaveChanges();
        //    }
        //}
    }
}
