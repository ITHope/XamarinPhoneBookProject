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
        public void TestInteractorGetModelFromModelCreator()
        {
            var model = new ViewModel("fname", "lname");
            
            _modelCreatorMock.Setup(f => f.GetModel())
                                        .Returns(model);

            _interactor.Get();
            
            _modelCreatorMock.Verify(f => f.GetModel(), Times.Once);
        }

        [Test]
        public void TestInteractorGetModelFromModelCreatorNull()
        {
            ViewModel model = null;
            ViewModel expModel = new ViewModel("","");

            _modelCreatorMock.Setup(f => f.GetModel())
                                        .Returns(model);

            var resModel = _interactor.Get();

            _modelCreatorMock.Verify(f => f.GetModel(), Times.Once);

            Assert.AreEqual(expModel, resModel);
        }
    }
}
