using System;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Linq;

namespace PhoneList.iOS
{
    public class CollectionSource : UICollectionViewSource, IUsersListAdapter
    {
        private IRepository _repository;
        private List<User> _usersList;
        private IInteractor _interactor;
        private IPresenter _presenter;

        public CollectionSource(IRepository repository)
        {
            _repository = repository;
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

            //_presenter = new Presenter(cell, new Interactor(new ModelCreator(_repository)));
            //_presenter.Init(_usersList[(int)indexPath.Item].Id);

            cell.ConfigCell(_interactor, _usersList[(int)indexPath.Item].Id);

            return cell;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }
    }
}
