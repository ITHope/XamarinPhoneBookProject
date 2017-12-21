using System;
using System.Reflection;
using Moq;
using NUnit;
using NUnit.Framework;
using PhoneList;
using System.Xml.Linq;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTestInteractor
    {
        IInteractor _interactor;
        Mock<IRepository> _repositoryMock;

        [SetUp]
        public void InteractorSetUp()
        {
            _repositoryMock = new Mock<IRepository>(MockBehavior.Strict);
            _interactor = new Interactor(_repositoryMock.Object);
        }

        [Test]
        public void TestInteractorCtorCheckRepositorySet()
        {
            var fieldInfo = typeof(Interactor).GetField("_repository", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_interactor);
            Assert.AreEqual(_repositoryMock.Object, data);
        }

        [Test]
        public void TestInteractorCtorExNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _interactor = new Interactor(null);
            });
        }

        [Test]
        public void TestInteractorGetUserFromRepository()
        {
            var user = new User(0, "fname", "lname", 0, "");
            var _modelCreator = new ModelCreator(user);

            _repositoryMock.Setup(f => f.Get())
                                        .Returns(user);
        
            _interactor.Get();

            _repositoryMock.Verify(f => f.Get(), Times.Once);
        }



    }
}
