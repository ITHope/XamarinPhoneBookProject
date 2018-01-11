using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public class Presenter : IPresenter
    {
        IView _view;
        IInteractor _interactor;
        IRouter _router;

        public Presenter(IView view, IInteractor interactor, IRouter router)
        {
            _view = view ?? throw new ArgumentNullException();
            _interactor = interactor ?? throw new ArgumentNullException();
            _router = router ?? throw new ArgumentNullException();
        }

        public List<int> GetAllIdList()
        {
            var idList = _interactor.GetAllIdList();
            return idList;
        }

        public async Task GetNextUser()
        {
            await Task.Run(async () =>
            {
                ViewModel model = await _interactor.GetNextUser();

                if (model == null)
                {
                    _view.SetFName("");
                    _view.SetLName("");
                    _view.SetPhone("");
                    _view.SetIcon("");
                }
                else
                {
                    _view.SetFName(model.fname);
                    _view.SetLName(model.lname);
                    _view.SetPhone(model.phone);
                    _view.SetIcon(model.iconPicture);
                }
            }
            );
        }

        public async void GoToDetailsPage(int userId)
        {
            var model = await _interactor.Get(userId);
            _router.GoToDetailsPage(model.fname, model.lname, model.phone, model.iconPicture);
        }

        public async Task Init(int id)
        {
            var model = await _interactor.Get(id);

            if (model == null)
            {
                _view.SetFName("");
                _view.SetLName("");
                _view.SetPhone("");
                _view.SetIcon("");
            }
            else
            {
                _view.SetFName(model.fname);
                _view.SetLName(model.lname);
                _view.SetPhone(model.phone);
                _view.SetIcon(model.iconPicture);
            }
        }
    }
}
