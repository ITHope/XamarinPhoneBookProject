using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;

namespace PhoneList.iOS
{
    struct CustomFlowLayoutConstants
    {
        public struct Cell
        {
            /* The height of the non-featured cell */
            public static nfloat standardHeight = 100;
            /* The height of the first visible cell */
            public static nfloat featuredHeight = 280;
        }
    }

    [Register("CustomFlowLayout")]
    public class CustomFlowLayout : UICollectionViewFlowLayout
    {
        // MARK: Properties and Variables

        /* The amount the user needs to scroll before the featured cell changes */
        private const float _dragOffset = 180;


        protected internal CustomFlowLayout(IntPtr handle) : base(handle)
        {
        }

        List<UICollectionViewLayoutAttributes> Cache  = new List<UICollectionViewLayoutAttributes>();

        int FeaturedItemIndex 
        {
            get
            {
                return (int)Math.Max(0, CollectionView.ContentOffset.Y/_dragOffset);
            }
        }

        nfloat NextItemPercentageOffset
        {
            get
            {
                return (CollectionView.ContentOffset.Y/_dragOffset) - FeaturedItemIndex;
            }
        }

        nfloat Width { get { return CollectionView.Bounds.Width; } }

        nfloat Height { get { return CollectionView.Bounds.Height; } }

        int NumberOfItems 
        { 
            get 
            { 
                return (int)CollectionView.NumberOfItemsInSection(0);
            } 
        }

        // MARK: UICollectionViewLayout

        /* Return the size of all the content in the collection view */
        public override CGSize CollectionViewContentSize
        {
            get
            {
                var contentHeight = (NumberOfItems * _dragOffset) + (Height - _dragOffset);
                return new CGSize(Width, contentHeight);
            }
        }

        public override void PrepareLayout()
        {
            Cache.Clear();

            var standardHeight = CustomFlowLayoutConstants.Cell.standardHeight;
            var featuredHeight = CustomFlowLayoutConstants.Cell.featuredHeight;
            var frame = CGRect.Empty;
            nfloat y = 0;

            for (int item = 0; item < NumberOfItems; item++)
            {
                var indexPath = NSIndexPath.FromItemSection(item, 0);
                var attributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);

                attributes.ZIndex = item;
                var height = standardHeight;
                if((indexPath.Item == FeaturedItemIndex))
                {
                    var yOffset = standardHeight * NextItemPercentageOffset;
                    y = CollectionView.ContentOffset.Y - yOffset;
                    height = featuredHeight;
                }
                else if((indexPath.Item == (FeaturedItemIndex+1)) && (indexPath.Item != NumberOfItems))
                {
                    var y0 = y;
                    var maxY = y + standardHeight;
                    height = standardHeight + (nfloat)Math.Max((featuredHeight - standardHeight) * NextItemPercentageOffset, 0);
                    y = maxY - height;
                    var fr = Cache[FeaturedItemIndex].Frame;
                    fr.Height -= y0 - y;
                    Cache[FeaturedItemIndex].Frame = fr;
                }
                else 
                {
                    height = standardHeight;
                }

                frame = new CGRect(0, y, Width, height);
                attributes.Frame = frame;

                Cache.Add(attributes);

                y = frame.GetMaxY();
            }
        }

        /* Return all attributes in the cache whose frame intersects with the rect passed to the method */
        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CoreGraphics.CGRect rect)
        {
            var layoutAttributes = new List<UICollectionViewLayoutAttributes>();

            for (int i = 0; i < Cache.Count; i++)
            {
                if (Cache[i].Frame.IntersectsWith(rect))
                {
                    layoutAttributes.Add(Cache[i]);
                }
            }

            return layoutAttributes.ToArray();
        }

        /* Return true so that the layout is continuously invalidated as the user scrolls */
        public override bool ShouldInvalidateLayoutForBoundsChange(CoreGraphics.CGRect newBounds)
        {
            return true;
        }
    }
}
