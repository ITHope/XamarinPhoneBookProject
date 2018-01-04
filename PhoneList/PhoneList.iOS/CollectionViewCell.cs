using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace PhoneList.iOS
{
    public partial class CollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("MyCollectionViewCell");
        public static readonly UINib Nib;

        private UserView _view;
        private IPresenter _presenter;
        static CollectionViewCell()
        {
            Nib = UINib.FromName("MyCollectionViewCell", NSBundle.MainBundle);
        }

        protected CollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            _view = new UserView(_myLabel);
        }

        public void ConfigCell(IInteractor interactor, int id)
        {
            if (_presenter == null)
            {
                _presenter = new Presenter(_view, interactor);
            }
            _presenter.Init(id);
        }

        //public void ConfigCell(User user)
        //{
        //    SetFName(user.Name);
        //    SetLName(user.LastName);
        //}

        //public void ConfigCell(int id)
        //{
        //    SetFName(id.ToString());
        //}

        public void SetFName(string fname)
        {
            InvokeOnMainThread(() => 
            { 
                _myLabel.Text = fname;
            });
        }

        public void SetLName(string lname)
        {
            //throw new NotImplementedException();
        }

        private class UserView : IView
        {
            private UILabel _lblFName;

            public UserView(UILabel lblFName)
            {
                _lblFName = lblFName;
            }

            public void SetFName(string fname)
            {
                _lblFName.InvokeOnMainThread(() =>
                {
                    _lblFName.Text = fname;
                });
            }

            public void SetLName(string lname)
            {
                //throw new NotImplementedException();
            }
        }
    }
}
