using System;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace PhoneList.iOS
{
    public class collectionSource : UICollectionViewSource, IUsersListAdapter
    {
        private IRepository _repository;
        private List<User> _usersList;

        public collectionSource(IRepository repository)
        {
            _repository = repository;
            _usersList = new List<User>();
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _usersList.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (collectionViewCell)collectionView.DequeueReusableCell(collectionViewCell.CellId, indexPath);

            var presenter = new Presenter(cell, new Interactor(new ModelCreator(_repository)));
            presenter.Init(_usersList[indexPath.Row].Id);

            //collectionView.Delegate = new Delegate();

            //cell.UpdateCell(userData[indexPath.Row].Name);

            return cell;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }
    }
}
