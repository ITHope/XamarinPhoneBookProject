using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneList.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            collectionView.RegisterClassForCell(typeof(collectionViewCell), collectionViewCell.CellId);
            collectionView.Source = new collectionSource();
            collectionView.Delegate = new Delegate();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
