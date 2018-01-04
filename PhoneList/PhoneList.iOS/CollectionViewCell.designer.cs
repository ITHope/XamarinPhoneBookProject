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
        UIKit.UILabel _myLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_myLabel != null) {
                _myLabel.Dispose ();
                _myLabel = null;
            }
        }
    }
}