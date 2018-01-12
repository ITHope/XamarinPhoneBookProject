// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PhoneList.iOS
{
    [Register ("CreateUserPageView")]
    partial class CreateUserPageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem _cancelNavBarLeftBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem _doneNavBarRightBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblFName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblLName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _txtInputFName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _txtInputLName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _txtInputPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgIcon { get; set; }

        [Action ("CancelBtnOnClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelBtnOnClick (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (_cancelNavBarLeftBtn != null) {
                _cancelNavBarLeftBtn.Dispose ();
                _cancelNavBarLeftBtn = null;
            }

            if (_doneNavBarRightBtn != null) {
                _doneNavBarRightBtn.Dispose ();
                _doneNavBarRightBtn = null;
            }

            if (_lblFName != null) {
                _lblFName.Dispose ();
                _lblFName = null;
            }

            if (_lblLName != null) {
                _lblLName.Dispose ();
                _lblLName = null;
            }

            if (_lblPhone != null) {
                _lblPhone.Dispose ();
                _lblPhone = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_txtInputFName != null) {
                _txtInputFName.Dispose ();
                _txtInputFName = null;
            }

            if (_txtInputLName != null) {
                _txtInputLName.Dispose ();
                _txtInputLName = null;
            }

            if (_txtInputPhone != null) {
                _txtInputPhone.Dispose ();
                _txtInputPhone = null;
            }

            if (imgIcon != null) {
                imgIcon.Dispose ();
                imgIcon = null;
            }
        }
    }
}