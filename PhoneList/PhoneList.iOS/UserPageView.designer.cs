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
    [Register ("UserPageView")]
    partial class UserPageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _imgIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblFName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblFNameTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblLName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblLNameTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblPhoneTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_imgIcon != null) {
                _imgIcon.Dispose ();
                _imgIcon = null;
            }

            if (_lblFName != null) {
                _lblFName.Dispose ();
                _lblFName = null;
            }

            if (_lblFNameTxt != null) {
                _lblFNameTxt.Dispose ();
                _lblFNameTxt = null;
            }

            if (_lblLName != null) {
                _lblLName.Dispose ();
                _lblLName = null;
            }

            if (_lblLNameTxt != null) {
                _lblLNameTxt.Dispose ();
                _lblLNameTxt = null;
            }

            if (_lblPhone != null) {
                _lblPhone.Dispose ();
                _lblPhone = null;
            }

            if (_lblPhoneTxt != null) {
                _lblPhoneTxt.Dispose ();
                _lblPhoneTxt = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}