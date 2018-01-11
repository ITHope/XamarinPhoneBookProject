// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneList.iOS
{
    [Register ("CreateUserViewController")]
    partial class CreateUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        PhoneList.iOS.CreateUserPageView _createUserPageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CreateUserView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_createUserPageView != null) {
                _createUserPageView.Dispose ();
                _createUserPageView = null;
            }

            if (CreateUserView != null) {
                CreateUserView.Dispose ();
                CreateUserView = null;
            }
        }
    }
}