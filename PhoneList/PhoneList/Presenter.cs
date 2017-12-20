using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Presenter: IPresenter
    {
        IView _view;
        //IInteractor _interactor;

        public Presenter(IView view, IInteractor interactor)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            //if (interactor == null)
            //{
            //    throw new ArgumentNullException();
            //}

            _view = view;
            //_interactor = interactor;
        }

        public void Init()
        {
            _view.SetFName("fname");
            _view.SetLName("lname");
        }
    }
}
