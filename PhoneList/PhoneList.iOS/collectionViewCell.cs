using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace PhoneList.iOS
{
    public class collectionViewCell : UICollectionViewCell
    {
        public UILabel mainLabel;
        public static NSString CellId = new NSString("customCollectionCell");

        [Export ("initWithFrame:")]
        public collectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            ContentView.Layer.BorderColor = UIColor.Blue.CGColor;
            ContentView.Layer.BorderWidth = 4.0f;

            mainLabel = new UILabel();

            ContentView.AddSubviews(new UIView[] {mainLabel});

        }

        public void UpdateCell (string text) {
            mainLabel.Text = text;
            mainLabel.Frame = new CGRect(5, 5, ContentView.Bounds.Width, 26);
        }
    }
}
