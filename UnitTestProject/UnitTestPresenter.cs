using System;
using System.Reflection;
using Moq;
using NUnit;
using NUnit.Framework;
using PhoneList;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTestPresenter
    {
        IPresenter _presenter;
        Mock<IView> _viewMock;
        Mock<IInteractor> _interactorMock;

        [OneTimeSetUp]
        public void PresenterSetUp()
        {
            _viewMock = new Mock<IView>(MockBehavior.Strict);
            _presenter = new Presenter(_viewMock.Object);
        }

        [Test]
        public void TestPresenterCtor()
        {
            var fieldInfo = typeof(Presenter).GetField("_view", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_presenter);
            Assert.AreEqual(_viewMock.Object, data);
        }

        [Test]
        public void TestPresenterCtorExNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new Presenter(null);
            });
        }

        [Test]
        public void TestPresenterInit()
        {
            var fname = "fname";
            var lname = "lname";
            var model = new ViewModel(fname, lname);

            _viewMock.Setup(f => f.SetFName(model.fname));
            _viewMock.Setup(f => f.SetLName(model.lname));
            _presenter.Init();
            _viewMock.Verify( f => f.SetFName(model.fname), Times.Once);
            _viewMock.Verify( f => f.SetLName(model.lname), Times.Once);
        }


    }
}
