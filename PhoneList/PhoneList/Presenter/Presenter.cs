using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneList
{
    public class Presenter: IPresenter
    {
        IView _view;
        IInteractor _interactor;

        public Presenter(IView view, IInteractor interactor)
        {
            _view = view ?? throw new ArgumentNullException();
            _interactor = interactor ?? throw new ArgumentNullException();
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
                    _view.SetPhone(0);
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

        public async Task Init(int id)
        {
            ViewModel model = await _interactor.Get(id);

            if (model == null)
            {
                _view.SetFName("");
                _view.SetLName("");
                _view.SetPhone(0);
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
