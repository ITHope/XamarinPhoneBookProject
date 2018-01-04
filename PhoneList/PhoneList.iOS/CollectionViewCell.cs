using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace PhoneList.iOS
{
    public partial class CollectionViewCell : UICollectionViewCell, IView
    {
        public static readonly NSString Key = new NSString("MyCollectionViewCell");
        public static readonly UINib Nib;

        private IPresenter _presenter;

        static CollectionViewCell()
        {
            Nib = UINib.FromName("MyCollectionViewCell", NSBundle.MainBundle);
        }

        protected CollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public async void ConfigCell(IInteractor interactor, int id)
        {
            if (_presenter == null)
            {
                _presenter = new Presenter(this, interactor);
            }
            await _presenter.Init(id);
        }

        public void SetFName(string fname)
        {
            InvokeOnMainThread(() => 
            { 
                _myLabel.Text = fname;
            });
        }

        public void SetIcon(string icon)
        {
            //throw new NotImplementedException();
        }

        public void SetLName(string lname)
        {
            //throw new NotImplementedException();
        }

        public void SetPhone(int phone)
        {
            //throw new NotImplementedException();
        }
    }
}
