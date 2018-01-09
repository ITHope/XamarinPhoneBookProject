using System;
using System.Reflection;
using Moq;
using NUnit.Framework;
using PhoneList;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTestRepository
    {
        Mock<IDataSource> _dataSourceMock;
        IRepository _repository;

        [SetUp]
        public void RepositorySetUp()
        {
            _dataSourceMock = new Mock<IDataSource>(MockBehavior.Strict);
            _repository = new Repository(_dataSourceMock.Object);
        }

        [Test]
        public void TestRepositoryCtorDataSourceSet()
        {
            var fieldInfo = typeof(Repository).GetField("_dataSource", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_repository);
            Assert.AreEqual(_dataSourceMock.Object, data);
        }

        [Test]
        public void TestRepositoryCtorExNullDataSource()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _repository = new Repository(null);
            });
        }

        [Test]
        public async Task TestRepositoryGetUserFromDataSource()
        {
            int userId = 0;
            var expUser = new User(0, "name0", "LastName0", "", "");

            _dataSourceMock.Setup(f => f.GetUserById(userId))
                                        .Returns(Task.FromResult(expUser));

            await _repository.Get(userId);

            _dataSourceMock.Verify(f => f.GetUserById(userId), Times.Once);
        }

        [Test]
        public void TestRepositoryGetAllIdList()
        {
            List<int> idList = new List<int>();
            _dataSourceMock.Setup(f => f.GetAllIdList())
                                        .Returns(idList);
            _repository.GetAllIdList();

            _dataSourceMock.Verify(f => f.GetAllIdList(), Times.Once);
        }

        [Test]
        public async Task TestRepositoryGetNextUserFromDataSource()
        {
            var expUser = new User(0, "name0", "LastName0", "", "");

            _dataSourceMock.Setup(f => f.GetNextUser())
                                        .Returns(Task.FromResult(expUser));

            await _repository.GetNextUser();

            _dataSourceMock.Verify(f => f.GetNextUser(), Times.Once);
        }

        [Test]
        public void TestRepositoryGetAllUsersFromDataSource()
        {
            List<User> list = new List<User>();
            _dataSourceMock.Setup(f => f.GetAllUsers())
                                        .Returns(list);

            _repository.GetAllUsers();

            _dataSourceMock.Verify(f => f.GetAllUsers(), Times.Once);
        }
    }
}
