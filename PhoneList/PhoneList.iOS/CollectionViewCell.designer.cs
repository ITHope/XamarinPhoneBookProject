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
    [Register ("CollectionViewCell")]
    partial class CollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _cellView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _imgConstHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _imgIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _imgIconBottomConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _imgIconLeftConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _imgIconTopConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblFName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _lblFNameBottomConstrraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _lblFNameTopConstrraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblLName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _lblPhoneTopConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_cellView != null) {
                _cellView.Dispose ();
                _cellView = null;
            }

            if (_imgConstHeight != null) {
                _imgConstHeight.Dispose ();
                _imgConstHeight = null;
            }

            if (_imgIcon != null) {
                _imgIcon.Dispose ();
                _imgIcon = null;
            }

            if (_imgIconBottomConstraint != null) {
                _imgIconBottomConstraint.Dispose ();
                _imgIconBottomConstraint = null;
            }

            if (_imgIconLeftConstraint != null) {
                _imgIconLeftConstraint.Dispose ();
                _imgIconLeftConstraint = null;
            }

            if (_imgIconTopConstraint != null) {
                _imgIconTopConstraint.Dispose ();
                _imgIconTopConstraint = null;
            }

            if (_lblFName != null) {
                _lblFName.Dispose ();
                _lblFName = null;
            }

            if (_lblFNameBottomConstrraint != null) {
                _lblFNameBottomConstrraint.Dispose ();
                _lblFNameBottomConstrraint = null;
            }

            if (_lblFNameTopConstrraint != null) {
                _lblFNameTopConstrraint.Dispose ();
                _lblFNameTopConstrraint = null;
            }

            if (_lblLName != null) {
                _lblLName.Dispose ();
                _lblLName = null;
            }

            if (_lblPhone != null) {
                _lblPhone.Dispose ();
                _lblPhone = null;
            }

            if (_lblPhoneTopConstraint != null) {
                _lblPhoneTopConstraint.Dispose ();
                _lblPhoneTopConstraint = null;
            }
        }
    }
}