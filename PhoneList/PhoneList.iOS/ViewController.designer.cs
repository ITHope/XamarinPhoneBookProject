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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem _addNavBarBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        PhoneList.iOS.CustomCollectionView collectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_addNavBarBtn != null) {
                _addNavBarBtn.Dispose ();
                _addNavBarBtn = null;
            }

            if (collectionView != null) {
                collectionView.Dispose ();
                collectionView = null;
            }

            if (mainView != null) {
                mainView.Dispose ();
                mainView = null;
            }
        }
    }
}