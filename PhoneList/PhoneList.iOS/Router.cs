using System;
using Foundation;
using UIKit;

namespace PhoneList.iOS
{
    public class Router : IRouter
    {
        public void GoToDetailsPage(string fName, string lName, string phone, string icon)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
            vc.InvokeOnMainThread(() => {
                var dtpController = vc.Storyboard.InstantiateViewController("DetailedUserPage") as DetailedUserPage;
                dtpController.SetConfig(fName, lName, phone, icon);
                ((UINavigationController)vc).PushViewController(dtpController, true);
                //vc.PresentViewController(dtpController, true, null);
            });

            //vc.delegat.transitionAction = (NSIndexPath obj) => vc.PerformSegue("toDetailedPageSegue", this);

            //vc.InvokeOnMainThread(() => {
            //    var dtpController = vc.Storyboard.InstantiateViewController("DetailedUserPageView") as DetailedUserPage;
            //    vc.NavigationController.PushViewController(dtpController, true);
            //});
        }
    }
}
