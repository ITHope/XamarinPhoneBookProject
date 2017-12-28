using System;
using System.Reflection;
using Moq;
using NUnit;
using NUnit.Framework;
using PhoneList;
using System.Xml.Linq;
using System.Threading.Tasks;

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
            var expUser = new User(0, "name0", "LastName0", 10, "");

            _dataSourceMock.Setup(f => f.GetUserById(userId))
                                        .Returns(Task.FromResult(expUser));

            await _repository.Get(userId);

            _dataSourceMock.Verify(f => f.GetUserById(userId), Times.Once);
        }
    }
}
