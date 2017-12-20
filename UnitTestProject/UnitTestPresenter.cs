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
    public class UnitTestPresenter
    {
        IPresenter _presenter;
        Mock<IView> _viewMock;
        Mock<IInteractor> _interactorMock;

        [SetUp]
        public void PresenterSetUp()
        {
            _viewMock = new Mock<IView>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractor>(MockBehavior.Strict);
            _presenter = new Presenter(_viewMock.Object, _interactorMock.Object);
        }

        [Test]
        public void TestPresenterCtorCheckViewSet()
        {
            var fieldInfo = typeof(Presenter).GetField("_view", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_presenter);
            Assert.AreEqual(_viewMock.Object, data);
        }

        [Test]
        public void TestPresenterCtorCheckInteractorSet()
        {
            var fieldInfo = typeof(Presenter).GetField("_interactor", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = fieldInfo.GetValue(_presenter);
            Assert.AreEqual(_interactorMock.Object, data);
        }

        [Test]
        public void TestPresenterCtorExNullView()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new Presenter(null, _interactorMock.Object);
            });
        }

        [Test]
        public void TestPresenterCtorExNullInteractor()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new Presenter(_viewMock.Object, null);
            });
        }

        [Test]
        public void TestPresenterInit()
        {
            var fname = "fname";
            var lname = "lname";
            var model = new ViewModel(fname, lname);

            _interactorMock.Setup(f => f.Get())
                                        .Returns(model);

            _viewMock.Setup(f => f.SetFName(model.fname));
            _viewMock.Setup(f => f.SetLName(model.lname));

            _presenter.Init();

            _interactorMock.Verify(f => f.Get(), Times.Once);
            _viewMock.Verify( f => f.SetFName(model.fname), Times.Once);
            _viewMock.Verify( f => f.SetLName(model.lname), Times.Once);
        }


        [Test]
        public void TestInteractorGetEmptyModelEx()
        {
            ViewModel model = null;

            _interactorMock.Setup(f => f.Get())
                                        .Returns(model);

            _viewMock.Setup(f => f.SetFName(""));
            _viewMock.Setup(f => f.SetLName(""));

            _presenter.Init();

            _interactorMock.Verify(f => f.Get(), Times.Once);
            _viewMock.Verify(f => f.SetFName(""), Times.Once);
            _viewMock.Verify(f => f.SetLName(""), Times.Once);
        }
    }
}
