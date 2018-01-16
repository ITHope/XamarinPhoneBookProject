using System;
using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace PhoneList.iOS
{
    public partial class CollectionViewCell : UICollectionViewCell, IView
    {
        public static readonly NSString Key = new NSString("CollectionViewCell");
        public static readonly UINib Nib;
        private int _currentUserId;

        private IPresenter _presenter;

        static CollectionViewCell()
        {
            Nib = UINib.FromName("CollectionViewCell", NSBundle.MainBundle);
        }

        protected CollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ApplyLayoutAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            base.ApplyLayoutAttributes(layoutAttributes);

            var standardHeight = CustomFlowLayoutConstants.Cell.standardHeight;
            var featuredHeight = CustomFlowLayoutConstants.Cell.featuredHeight;

            var delta = (nfloat)(1 - ((featuredHeight - Frame.Height) / (featuredHeight - standardHeight)));


            //var minAlpha = (nfloat)0.7;
            //var maxAlpha = (nfloat)1.0;
            //_imgIcon.Alpha = maxAlpha - (delta * (maxAlpha - minAlpha));
            nfloat scale = 1;// = (nfloat)Math.Max(delta, 0.5);
            if (delta > 0.5)
            {
                scale = 2;
            }

            //_imgIcon.Transform = CGAffineTransform.MakeScale(scale, scale);

            //_imgIconTopConstraint.Constant = delta * 50;
            //_imgIconLeftConstraint.Constant = delta * 50;
            _imgIconBottomConstraint.Constant = delta * 70;
            _lblFNameTopConstrraint.Constant = delta * 50;
            //_lblPhoneTopConstraint.Constant = delta * 100;

            //_cellView.Layer.BorderWidth = 1;
            //_cellView.Layer.BorderColor = UIColor.Gray.CGColor;

            //if (_cellView != null)
            //{
            //    CALayer borderLayer = new CALayer();
            //    borderLayer.BackgroundColor = UIColor.FromRGB(23, 162, 227).CGColor;
            //    borderLayer.Frame = new CGRect(0, Frame.Height, 335, 5);
            //    Layer.AddSublayer(borderLayer);
            //}

            //_lblFName.Transform = CGAffineTransform.MakeScale(scale, scale);
            //_lblLName.Transform = CGAffineTransform.MakeScale(scale, scale);
            //UIView.BeginAnimations("OpenInfo");
            //UIView.SetAnimationDuration(1.0);
            //_imgTopConstr.Constant = 100;
        }

        private void DrawBorder()
        {
            
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            _cellView.AddGestureRecognizer(new UITapGestureRecognizer((obj) => _presenter.GoToDetailsPage(_currentUserId)));
        }

        public async void ConfigCell(IInteractor interactor, int id)
        {
            if (_presenter == null)
            {
                _presenter = new Presenter(this, interactor, new Router());
            }
            await _presenter.Init(id);
            _currentUserId = id;
        }

        public void SetFName(string fname)
        {
            InvokeOnMainThread(() =>
            {
                _lblFName.Text = fname;
            });
        }

        public void SetIcon(string icon)
        {
            InvokeOnMainThread(() =>
            {
                var image = UIImage.FromBundle(icon);
                _imgIcon.Image = image;
            });
        }

        public void SetLName(string lname)
        {
            InvokeOnMainThread(() =>
            {
                _lblLName.Text = lname;
            });
        }

        public void SetPhone(string phone)
        {
            InvokeOnMainThread(() =>
            {
                _lblPhone.Text = phone;
            });
        }
    }
}
