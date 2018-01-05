using UIKit;
using System;
using Foundation;
using System.Collections.Generic;
using CoreGraphics;

namespace PhoneList.iOS
{
    public class CollectionSource : UICollectionViewDataSource, IUsersListAdapter
    {
        private List<User> _usersList;
        private IInteractor _interactor;

        public CollectionSource(IRepository repository)
        {
            _usersList = new List<User>();
            _interactor = new Interactor(new ModelCreator(repository));
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _usersList.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CollectionViewCell)collectionView.DequeueReusableCell(CollectionViewCell.Key, indexPath);

            cell.ConfigCell(_interactor, _usersList[(int)indexPath.Item].Id);

            if (indexPath.Item == 0)
            {
                //cell.Transform = new CoreGraphics.CGAffineTransform(100, 100, 100, 100, 50, 50);
                //cell.Transform.TransformSize(new CoreGraphics.CGSize(collectionView.Bounds.Size.Width, 1000));
                //cell.Transform = CGAffineTransform.MakeScale(2F, 2F);
            }

            return cell;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }
    }
}
