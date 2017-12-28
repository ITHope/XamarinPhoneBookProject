using System;
using UIKit;

namespace PhoneList.iOS
{
    public class Delegate : UICollectionViewDelegateFlowLayout
    {
        public Delegate()
        {
        }

        public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            //return base.GetSizeForItem(collectionView, layout, indexPath);
            return new CoreGraphics.CGSize(collectionView.Bounds.Size.Width , 100);
        }
    }
}
