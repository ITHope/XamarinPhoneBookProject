using UIKit;

namespace PhoneList.iOS
{
    public class Delegate : UICollectionViewDelegateFlowLayout
    {
        public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            return new CoreGraphics.CGSize(collectionView.Bounds.Size.Width , 100);
        }
    }
}
