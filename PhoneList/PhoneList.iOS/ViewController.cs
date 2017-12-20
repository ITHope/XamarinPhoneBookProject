using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneList.iOS
{
    public partial class ViewController : UIViewController
    {
        List<User> userData;

        public ViewController(IntPtr handle) : base(handle)
        {
            userData = new List<User>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            InitData();
            collectionView.RegisterClassForCell(typeof(collectionViewCell), collectionViewCell.CellId);
            collectionView.Source = new collectionSource(userData);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        private void InitData()
        {
            for (int i = 0; i < 120; i++)
            {
                userData.Add(new User(i, "name" + i, "LastName" + i, +i * 10, i.ToString()));
            }
        }
    }
}
