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
    [Register ("DetailedUserPage")]
    partial class DetailedUserPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView DetailedUserPageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (DetailedUserPageView != null) {
                DetailedUserPageView.Dispose ();
                DetailedUserPageView = null;
            }
        }
    }
}