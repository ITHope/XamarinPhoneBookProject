using System;
using UIKit;

namespace PhoneList.iOS
{
    public partial class DetailedUserPage : UIViewController
    {
        private string _fName;
        private string _lName;
        private string _phone; 
        private string _icon;
        
        public DetailedUserPage (IntPtr handle) : base (handle)
        {
        }

        public void SetConfig(string fName, string lName, string phone, string icon)
        {
            _fName = fName;
            _lName = lName;
            _phone = phone;
            _icon = icon;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _userPageView?.SetConfig(_fName, _lName, _phone, _icon);
        }
    }
}