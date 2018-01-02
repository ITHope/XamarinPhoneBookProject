using System;
using System.Reflection;
using Moq;
using NUnit;
using NUnit.Framework;
using PhoneList;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTestController
    {
        Controller _controller;
        Mock<IUsersListAdapter> _usersListAdapterMock;
        Mock<IRepository> _repositoryMock;

        [SetUp]
        public void ControllerSetUp()
        {
            _usersListAdapterMock = new Mock<IUsersListAdapter>(MockBehavior.Strict);
            _repositoryMock = new Mock<IRepository>(MockBehavior.Strict);
            _controller = new Controller(_usersListAdapterMock.Object, _repositoryMock.Object);
        }

        [Test]
        public void TestControllerCtorCheckRepositorySet()
        {
            var fieldInfo = typeof(Controller).GetField("_repository", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_controller);
            Assert.AreEqual(_repositoryMock.Object, data);
        }

        [Test]
        public void TestControllerCtorCheckUsersListAdapterSet()
        {
            var fieldInfo = typeof(Controller).GetField("_usersListAdapter", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_controller);
            Assert.AreEqual(_usersListAdapterMock.Object, data);
        }

        [Test]
        public void TestControllerCtorExNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _controller = new Controller(_usersListAdapterMock.Object, null);
            });
        }

        [Test]
        public void TestControllerCtorExNullUsersListAdapter()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _controller = new Controller(null, _repositoryMock.Object);
            });
        }

        [Test]
        public async Task TestControllerStartUpdating()
        {
            List<User> users = new List<User>();

            //_usersListAdapterMock.Setup(f => f.UpdateUsersList(users));
            _repositoryMock.Setup(f => f.GetAllUsers())
                                        .Returns(users);

            await _controller.Start();

            //_usersListAdapterMock.Verify(f => f.UpdateUsersList(users), Times.Once);
            _repositoryMock.Verify(f => f.GetAllUsers(), Times.Once);
        }
    }
}
