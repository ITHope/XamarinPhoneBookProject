using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneList.iOS
{
    public partial class ViewController : UIViewController, IUsersListAdapter
    {
        collectionSource _collectionSource; 

        public ViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            collectionView.RegisterClassForCell(typeof(collectionViewCell), collectionViewCell.CellId);


            IRepository repository = new Repository(new UsersList());
            _collectionSource = new collectionSource(repository);


            collectionView.Source = _collectionSource;
            collectionView.Delegate = new Delegate();

            var controller = new Controller(this, repository);
            controller.Start();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _collectionSource.UpdateUsersList(usersList);

            InvokeOnMainThread(() => {
                collectionView.ReloadData();
            });

        }
    }
}
