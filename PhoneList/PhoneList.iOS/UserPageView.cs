using Foundation;
using System;
using UIKit;
using System.ComponentModel;

namespace PhoneList.iOS
{
    [DesignTimeVisible(true)]
    public partial class UserPageView : UIView, IComponent
    {
        public UserPageView (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if ((Site != null) && Site.DesignMode)
            {
                // Bundle resources aren't available in DesignMode
                return;
            }

            NSBundle.MainBundle.LoadNib("UserPageView", this, null);

            // At this point all of the code-behind properties should be set, specifically rootView which must be added as a subview of this view
            var frame = _rootView.Frame;
            frame.Height = Frame.Height;
            frame.Width = Frame.Width;
            _rootView.Frame = frame;
            this.AddSubview(this._rootView);
        }
        public ISite Site { get; set; }

        public event EventHandler Disposed;
    
        public void SetConfig(string fName, string lName, string phone, string icon)
        {
            InvokeOnMainThread(() =>
            {
                _lblFNameTxt.Text = fName;
                _lblLNameTxt.Text = lName;
                _lblPhoneTxt.Text = phone;

                var image = UIImage.FromBundle(icon);
                _imgIcon.Image = image;
            });
        }
    }
}