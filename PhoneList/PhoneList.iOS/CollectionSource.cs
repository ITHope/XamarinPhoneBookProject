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

            return cell;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }
    }
}
