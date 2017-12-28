using System;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace PhoneList.iOS
{
    public class collectionSource : UICollectionViewSource
    {

        public collectionSource()
        {
            
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 20;
        }

        /*public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.CellForItem(indexPath);
            cell.fNameText.Alpha = 0.5f;

        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.CellForItem(indexPath);
            cell.fNameText.Alpha = 1f;
        }*/

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.DequeueReusableCell(collectionViewCell.CellId, indexPath);

            var presenter = new Presenter(cell, new Interactor(new ModelCreator(new Repository(new UsersList()))));
            presenter.Init(indexPath.Row);

            //collectionView.Delegate = new Delegate();

            //cell.UpdateCell(userData[indexPath.Row].Name);

            return cell;
        }


    }
}
