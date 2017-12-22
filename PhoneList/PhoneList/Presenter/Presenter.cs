using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Presenter: IPresenter
    {
        IView _view;
        IInteractor _interactor;

        public Presenter(IView view, IInteractor interactor)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            if (interactor == null)
            {
                throw new ArgumentNullException();
            }

            _view = view;
            _interactor = interactor;
        }

        public void Init(int id)
        {
            ViewModel model = _interactor.Get(id);

            if (model == null)
            {
                _view.SetFName("");
                _view.SetLName("");
            }
            else
            {
                _view.SetFName(model.fname);
                _view.SetLName(model.lname);
            }
        }
    }
}
