using System;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace PhoneList.iOS
{
    public class collectionSource : UICollectionViewSource
    {
        public List<User> userData { get; set; }

        public collectionSource(List<User> _userData)
        {
            userData = _userData;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return userData.Count;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.CellForItem(indexPath);
            cell.mainLabel.Alpha = 0.5f;
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.CellForItem(indexPath);
            cell.mainLabel.Alpha = 1f;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.DequeueReusableCell(collectionViewCell.CellId, indexPath);

            var presenter = new Presenter(cell, new Interactor(new ModelCreator(new Repository())));
            presenter.Init();

            //cell.UpdateCell(userData[indexPath.Row].Name);

            return cell;
        }
    }
}
