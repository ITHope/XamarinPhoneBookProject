using Foundation;
using System;
using UIKit;

namespace PhoneList.iOS
{
    public partial class CustomCollectionView : UICollectionView
    {
        public CustomCollectionView (IntPtr handle) : base (handle)
        {
        }

        public void Initialize()
        {
            RegisterNibForCell(CollectionViewCell.Nib, CollectionViewCell.Key);
        }
    }
}