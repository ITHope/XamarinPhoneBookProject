using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace PhoneList.iOS
{
    public class collectionViewCell : UICollectionViewCell, IView
    {
        public UILabel fNameText;
        public UILabel lNameText;
        public UILabel phoneText;
        public UIImageView icon;

        public static NSString CellId = new NSString("customCollectionCell");

        [Export ("initWithFrame:")]
        public collectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };

            ContentView.Layer.BorderColor = UIColor.Blue.CGColor;
            ContentView.Layer.BorderWidth = 4.0f;

            fNameText = new UILabel();
            lNameText = new UILabel();
            phoneText = new UILabel();
            //icon = new UIImageView(UIImage.FromBundle("Icon/santa-claus.png"));
            //icon.Center = ContentView.Center;
            //icon.Transform = CGAffineTransform.MakeScale(0.7f, 0.7f);


            phoneText.Text = "4242546564";
            phoneText.Frame = new CGRect(250, 5, ContentView.Bounds.Width, 26);


            ContentView.AddSubviews(new UIView[] {fNameText});
            ContentView.AddSubviews(new UIView[] { lNameText });
            ContentView.AddSubviews(new UIView[] { phoneText });
            //ContentView.AddSubviews(new UIView[] { icon });

        }

        /*public void UpdateCell (string text) {
            mainLabel.Text = text;
            mainLabel.Frame = new CGRect(5, 5, ContentView.Bounds.Width, 26);
        }*/

        public void SetFName(string fname)
        {
            fNameText.Text = fname;
            fNameText.Frame = new CGRect(20, 5, ContentView.Bounds.Width, 26);
        }

        public void SetLName(string lname)
        {
            lNameText.Text = lname;
            lNameText.Frame = new CGRect(20, 25, ContentView.Bounds.Width, 26);
        }
    }
}
