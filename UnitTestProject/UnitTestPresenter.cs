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
        public async Task TestPresenterInit()
        {
            int userId = 0;
            var fname = "fname";
            var lname = "lname";
            var model = new ViewModel(fname, lname);

            _interactorMock.Setup(f => f.Get(userId))
                                        .Returns(Task.FromResult(model));

            _viewMock.Setup(f => f.SetFName(model.fname));
            _viewMock.Setup(f => f.SetLName(model.lname));

            await _presenter.Init(userId);

            _interactorMock.Verify(f => f.Get(userId), Times.Once);
            _viewMock.Verify(f => f.SetFName(model.fname), Times.Once);
            _viewMock.Verify(f => f.SetLName(model.lname), Times.Once);
        }


        [Test]
        public async Task TestInteractorGetEmptyModel()
        {
            int userId = 0;
            ViewModel model = null;

            _interactorMock.Setup(f => f.Get(userId))
                                        .Returns(Task.FromResult(model));

            _viewMock.Setup(f => f.SetFName(""));
            _viewMock.Setup(f => f.SetLName(""));

            await _presenter.Init(userId);

            _interactorMock.Verify(f => f.Get(userId), Times.Once);
            _viewMock.Verify(f => f.SetFName(""), Times.Once);
            _viewMock.Verify(f => f.SetLName(""), Times.Once);
        }

        [Test]
        public void TestPresenterGetAllIdList()
        {
            List<int> idList = new List<int>();
            _interactorMock.Setup(f => f.GetAllIdList())
                                        .Returns(idList);
            _presenter.GetAllIdList();

            _interactorMock.Verify(f => f.GetAllIdList(), Times.Once);
        }

        [Test]
        public async Task TestPresenterGetNextUser()
        {
            var model = new ViewModel("fname", "lname");

            _interactorMock.Setup(f => f.GetNextUser())
                                        .Returns(Task.FromResult(model));

            _viewMock.Setup(f => f.SetFName(model.fname));
            _viewMock.Setup(f => f.SetLName(model.lname));

            await _presenter.GetNextUser(); 

            _interactorMock.Verify(f => f.GetNextUser(), Times.Once);
            _viewMock.Verify(f => f.SetFName(model.fname), Times.Once);
            _viewMock.Verify(f => f.SetLName(model.lname), Times.Once);
        }

        [Test]
        public async Task TestPresenterGetNextUserEmptyModel()
        {
            ViewModel model = null;

            _interactorMock.Setup(f => f.GetNextUser())
                                        .Returns(Task.FromResult(model));

            _viewMock.Setup(f => f.SetFName(""));
            _viewMock.Setup(f => f.SetLName(""));

            await _presenter.GetNextUser();

            _interactorMock.Verify(f => f.GetNextUser(), Times.Once);
            _viewMock.Verify(f => f.SetFName(""), Times.Once);
            _viewMock.Verify(f => f.SetLName(""), Times.Once);
        }
    }
}
