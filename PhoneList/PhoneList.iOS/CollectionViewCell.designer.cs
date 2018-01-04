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
    [Register ("MyCollectionViewCell")]
    partial class CollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _imgIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblFName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblLName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblPhone { get; set; }

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

            if (_lblLName != null) {
                _lblLName.Dispose ();
                _lblLName = null;
            }

            if (_lblPhone != null) {
                _lblPhone.Dispose ();
                _lblPhone = null;
            }
        }
    }
}