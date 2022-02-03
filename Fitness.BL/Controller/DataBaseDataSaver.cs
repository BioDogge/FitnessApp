using Fitness.BL.Model;
using System.Linq;
using System;

namespace Fitness.BL.Controller
{
    public class DataBaseDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().FirstOrDefault();
                return result;
            }
        }

        public void Save(string fileName, object type)
        {
            using (var db = new FitnessContext())
            {
                switch (type)
                {
                    case User user:
                        db.Users.Add(type as User);

                        break;
                    case Gender gender:
                        db.Genders.Add(type as Gender);
                        
                        break;
                    case Food food:
                        db.Foods.Add(type as Food);

                        break;
                    case Exercise exercise:
                        db.Exercises.Add(type as Exercise);

                        break;
                    case Eating eating:
                        db.Eatings.Add(type as Eating);

                        break;
                    case Activity activity:
                        db.Activities.Add(type as Activity);

                        break;
                }

                db.SaveChanges();
            }
        }
    }
}
