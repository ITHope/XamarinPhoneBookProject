using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Presenter: IPresenter
    {
        IView _view;
        public Presenter(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            _view = view;
        }

        public void Init()
        {
            _view.SetFName("fname");
            _view.SetLName("lname");
        }
    }
}
