using System;
using System.Linq;
using Jog.Common;
using Jog.Common.Security;
using Jog.Data.Abstract;
using Jog.Data.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace Jog.Data.Tests
{
    [TestClass]
    public class RepoTests
    {
        private IKernel _kernel;
        private Mock<IJogContext> _mockContext;
        private Mock<IUserSession> _mockUserSession;
        private Mock<IDateTimeProvider> _mockDateTime;

        [TestInitialize]
        public void Setup()
        {
            _kernel = new StandardKernel();

            _mockDateTime = new Mock<IDateTimeProvider>();
            _kernel.Bind<IDateTimeProvider>().ToConstant(_mockDateTime.Object);

            _mockContext = new Mock<IJogContext>();

            _kernel.Bind<IJogContext>().ToConstant(_mockContext.Object);

            _mockUserSession = new Mock<IUserSession>();
            _kernel.Bind<IUserSession>().ToConstant(_mockUserSession.Object);

            _kernel.Bind<IJogRepo>().To(typeof (JogRepo));
        }

        [TestMethod]
        public void AddNewWorkout_FieldsCorrect_EntityProperlyReturn()
        {
            var testRepo = _kernel.Get<IJogRepo>();

            var userName = "test";
            _mockUserSession.Setup(x => x.Username).Returns(userName);
            var newWorkout = new Workout() {Id = 1};
            _mockContext.Setup(x => x.Workouts.Add(It.IsAny<Workout>())).Returns((Workout x) => x);

            var workInRepo = testRepo.AddWorkout(newWorkout);

            Assert.AreEqual(userName, workInRepo.UserName);
        }
    }
}
