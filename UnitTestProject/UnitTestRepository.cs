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
    public class UnitTestRepository
    {
        IRepository _repository;

        [SetUp]
        public void RepositorySetUp()
        {
            _repository = new Repository();
        }
        
        [Test]
        public void TestRepositoryGetUser()
        {
            int id = 0;
            var expUser = new User(id, "name" + id, "LastName" + id, +id * 10, id.ToString());
            var resultUser = _repository.Get(id);

            Assert.AreEqual(expUser, resultUser);
        }
    }
}
