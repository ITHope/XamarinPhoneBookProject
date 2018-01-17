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

            _imgIconBottomConstraint.Constant = delta * 70;
            _lblFNameTopConstrraint.Constant = delta * 50;       

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
