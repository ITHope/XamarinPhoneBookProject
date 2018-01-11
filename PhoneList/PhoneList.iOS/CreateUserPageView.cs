using Foundation;
using System;
using UIKit;
using System.ComponentModel;


namespace PhoneList.iOS
{
    [DesignTimeVisible(true)]
    public partial class CreateUserPageView : UIView, IComponent
    {
        public CreateUserPageView (IntPtr handle) : base (handle)
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

            NSBundle.MainBundle.LoadNib("CreateUserPageView", this, null);

            // At this point all of the code-behind properties should be set, specifically rootView which must be added as a subview of this view
            var frame = _rootView.Frame;
            frame.Height = Frame.Height;
            frame.Width = Frame.Width;
            _rootView.Frame = frame;
            this.AddSubview(this._rootView);
        }

        public ISite Site { get; set; }

        public event EventHandler Disposed;
    }
}