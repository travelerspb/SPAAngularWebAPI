using System;
using System.Linq;
using Jog.Data;
using Jog.Data.Abstract;
using Jog.Web.Api.Controllers;
using Jog.Web.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace Job.Api.Tests
{
    [TestClass]
    public class WorkoutCtrlTests
    {
        private IKernel _kernel;
        private Mock<IJogRepo> _mockRepo;

        [TestInitialize]
        public void Setup()
        {
            _kernel = new StandardKernel();

            _mockRepo = new Mock<IJogRepo>();

            _kernel.Bind<IJogRepo>().ToConstant(_mockRepo.Object);
        }

        [TestMethod]
        public void AddNewWorkout_CorrectModel_WorkoutSavedReturned()
        {
            var controller = _kernel.Get<WorkoutsController>();
            _mockRepo.Setup(x => x.AddWorkout(It.IsAny<Workout>())).Returns((Workout w)=>w);
            var newWorkout = new Workout
            {
                Date = DateTime.Today,
                Distance = 100,
                Duration = 200,
            };

            var answer = controller.AddWorkout(newWorkout);

            Assert.IsNotNull(answer);
            Assert.AreEqual(100, ((Workout)answer).Distance);
            Assert.AreEqual(200, ((Workout)answer).Duration);
            Assert.AreEqual(DateTime.Today, ((Workout)answer).Date);
        }
    }
}
