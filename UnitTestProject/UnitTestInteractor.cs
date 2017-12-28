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
    public class UnitTestInteractor
    {
        IInteractor _interactor;
        Mock<IModelCreator> _modelCreatorMock;

        [SetUp]
        public void InteractorSetUp()
        {
            _modelCreatorMock = new Mock<IModelCreator>(MockBehavior.Strict);
            _interactor = new Interactor(_modelCreatorMock.Object);
        }

        [Test]
        public void TestInteractorCtorCheckModelCreatorSet()
        {
            var fieldInfo = typeof(Interactor).GetField("_modelCreator", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_interactor);
            Assert.AreEqual(_modelCreatorMock.Object, data);
        }

        [Test]
        public void TestInteractorCtorExNullModelCreator()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _interactor = new Interactor(null);
            });
        }

        [Test]
        public async Task TestInteractorGetModelFromModelCreator()
        {
            int userId = 0;
            var model = new ViewModel("fname", "lname");

            _modelCreatorMock.Setup(f => f.GetModel(userId))
                                        .Returns(Task.FromResult(model));

            await _interactor.Get(userId);

            _modelCreatorMock.Verify(f => f.GetModel(userId), Times.Once);
        }

        [Test]
        public async Task TestInteractorGetModelFromModelCreatorNull()
        {
            int userId = 0;
            ViewModel model = null;
            ViewModel expModel = new ViewModel("", "");

            _modelCreatorMock.Setup(f => f.GetModel(userId))
                                        .Returns(Task.FromResult(model));

            var resModel = await _interactor.Get(userId);

            _modelCreatorMock.Verify(f => f.GetModel(userId), Times.Once);

            Assert.AreEqual(expModel, resModel);
        }

        [Test]
        public void TestInteractorGetAllIdList()
        {
            List<int> idList = new List<int>();
            _modelCreatorMock.Setup(f => f.GetAllIdList())
                                        .Returns(idList);
            _interactor.GetAllIdList();

            _modelCreatorMock.Verify(f => f.GetAllIdList(), Times.Once);
        }
    }
}
