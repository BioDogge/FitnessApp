using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using Fitness.BL.Model;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddFoodTest()
        {
            var userName  = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 250), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));

            eatingController.AddFood(food, 100);

            Assert.AreEqual(foodName, eatingController.Eatings.Foods.First().Key.Name);
        }
    }
}