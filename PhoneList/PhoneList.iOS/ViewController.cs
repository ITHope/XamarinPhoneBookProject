using UIKit;
using System;
using Foundation;
using System.Collections.Generic;

namespace PhoneList.iOS
{
    public partial class ViewController : UIViewController, IUsersListAdapter
    {
        CollectionSource _collectionSource;
        public Delegate delegat;

        public ViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            collectionView.RegisterNibForCell(CollectionViewCell.Nib, CollectionViewCell.Key);

            IRepository repository = new Repository(new UsersList());
            _collectionSource = new CollectionSource(repository);

            collectionView.DataSource = _collectionSource;

            delegat = new Delegate();
            //delegat.transitionAction = (NSIndexPath obj) => PerformSegue("toDetailedPageSegue", this);

            collectionView.Delegate = delegat;

            //this.NavigationController.NavigationItem.RightBarButtonItem.Clicked += GoToCreateUserPage;

            var controller = new Controller(this, repository);
            controller.Start();
        }

        private void GoToCreateUserPage(object sender, EventArgs e)
        {
            InvokeOnMainThread(() => {
                
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    //var controller = (DetailedUserPage)segue.DestinationViewController;
        //    //var controller = (CreateUserPage)segue.DestinationViewController;
        //    //controller.SetConfig();
        //}

        public void UpdateUsersList(List<User> usersList)
        {
            _collectionSource.UpdateUsersList(usersList);
    
            InvokeOnMainThread(() => {
                if (usersList.Count > 0)
                {
                    var insertedPath = NSIndexPath.FromItemSection(usersList.Count - 1, 0);
                    collectionView.InsertItems(new NSIndexPath[] { insertedPath });

                    //scroll to the last one if you need
                    //collectionView.ScrollToItem(insertedPath, UICollectionViewScrollPosition.Bottom, true);
                }
            });
        }
    }
}