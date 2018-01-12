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
        const float dragOffset = 180;

        protected internal CustomFlowLayout(IntPtr handle) : base(handle)
        {
        }

        List<UICollectionViewLayoutAttributes> Cache  = new List<UICollectionViewLayoutAttributes>();

        int FeaturedItemIndex 
        {
            get
            {
                return (int)Math.Max(0, CollectionView.ContentOffset.Y/dragOffset);
            }
        }

        nfloat NextItemPercentageOffset
        {
            get
            {
                return (CollectionView.ContentOffset.Y/dragOffset) - FeaturedItemIndex;
            }
        }

        nfloat Width { get; set; }

        nfloat Height { get; set; }

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
                var contentHeight = (CollectionView.NumberOfSections() * dragOffset) + (Height - dragOffset);
                return new CGSize(Width, contentHeight);
            }
        }

        public override void PrepareLayout()
        {
			Height = CollectionView.Bounds.Height;
            Width = CollectionView.Bounds.Width;

            Cache.Clear();
            //Array.Clear(Cache, 0, Cache.Count);

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

                if(indexPath.Item == FeaturedItemIndex)
                {
                    var yOffset = standardHeight * NextItemPercentageOffset;
                    y = CollectionView.ContentOffset.Y - yOffset;
                    Height = featuredHeight;
                }
                else if(indexPath.Item == (FeaturedItemIndex+1) && indexPath.Item != NumberOfItems)
                {
                    var maxY = y + standardHeight;
                    Height = standardHeight + (nfloat)Math.Max((featuredHeight - standardHeight) * NextItemPercentageOffset, 0);
                    y = maxY - Height;
                }

                frame = new CGRect(0, y, Width, Height);
                attributes.Frame = frame;

                //var layoutattributes = new uicollectionviewlayoutattributes[cache.length+1];

                //for (int i = 0; i < cache.length; i++)
                //{
                //    layoutattributes[i] = cache[i];
                //}
                //layoutattributes[layoutattributes.length - 1] = attributes;
                //cache = layoutattributes;

                Cache.Add(attributes);

                y = CollectionView.Frame.Bottom;
            }
        }

        /* Return all attributes in the cache whose frame intersects with the rect passed to the method */
        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CoreGraphics.CGRect rect)
        {
            var layoutAttributes = new UICollectionViewLayoutAttributes[Cache.Count];

            for (int i = 0; i < Cache.Count; i++)
            {
                //if CGRectIntersectsRect(attributes.frame, rect) 

                if (Cache[i].Frame.IntersectsWith(rect))
                {
                    layoutAttributes[i] = Cache[i];
                }
            }

            return layoutAttributes;
        }

        /* Return true so that the layout is continuously invalidated as the user scrolls */
        public override bool ShouldInvalidateLayoutForBoundsChange(CoreGraphics.CGRect newBounds)
        {
            return true;
        }
    }
}
