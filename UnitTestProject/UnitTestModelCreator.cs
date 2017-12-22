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
    public class UnitTestModelCreator
    {
        IModelCreator _modelCreator;
        Mock<IRepository> _repositoryMock;

        [SetUp]
        public void ModelCreatorSetUp()
        {
            _repositoryMock = new Mock<IRepository>();
            _modelCreator = new ModelCreator(/*_user, */_repositoryMock.Object);
        }

        [Test]
        public void TestModelCreatorCtorCheckRepositorySet()
        {
            var fieldInfo = typeof(ModelCreator).GetField("_repository", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_modelCreator);
            Assert.AreEqual(_repositoryMock.Object, data);
        }

        [Test]
        public void TestModelCreatorCtorExNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _modelCreator = new ModelCreator(null);
            });
        }

        [Test]
        public void TestModelCreatorGetModel()
        {
            var fname = "";
            var lname = "";
            var model = new ViewModel(fname, lname);

            var resultModel =_modelCreator.GetModel();

            Assert.AreEqual(model, resultModel);
        }

        [Test]
        public void TestModelCreatorGetUserFromRepository()
        {
            var user = new User(0, "fname", "lname", 0, "");
            var model = new ViewModel("fname", "lname");

            _repositoryMock.Setup(f => f.Get())
                                        .Returns(user);

            _modelCreator.GetModel();

            _repositoryMock.Verify(f => f.Get(), Times.Once);
        }

        [Test]
        public void TestModelCreatorGetUserFromRepositoryNullUser()
        {
            //var user = new User(0, "fname", "lname", 0, "");
            User user = null;
            //var model = new ViewModel("fname", "lname");
            var expModel = new ViewModel("", "");

            _repositoryMock.Setup(f => f.Get())
                                        .Returns(user);

            var resModel = _modelCreator.GetModel();

            _repositoryMock.Verify(f => f.Get(), Times.Once);

            Assert.AreEqual(expModel, resModel);
        }
    }
}
