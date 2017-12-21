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
        User _user;
        IModelCreator _modelCreator;

        [SetUp]
        public void ModelCreatorSetUp()
        {
            _user = new User(0, "fname", "lname", 0, "");
            _modelCreator = new ModelCreator(_user);
        }

        [Test]
        public void TestModelCreatorCtorCheckUserSet()
        {
            var fieldInfo = typeof(ModelCreator).GetField("_user", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_modelCreator);
            Assert.AreEqual(_user, data);
        }

        [Test]
        public void TestModelCreatorCtorExNullUser()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _modelCreator = new ModelCreator(null);
            });
        }

        [Test]
        public void TestModelCreatorGetModel()
        {
            var fname = "fname";
            var lname = "lname";
            var model = new ViewModel(fname, lname);

            var resultModel =_modelCreator.GetModel();

            Assert.AreEqual(model, resultModel);
        }
    }
}
