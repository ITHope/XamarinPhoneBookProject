using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneList.Droid
{
    public class Router : IRouter
    {
        private readonly WeakReference<Context> _context;

        public Router(Context context)
        {
            _context = new WeakReference<Context>(context);
        }

        public void GoToDetailsPage(string fName, string lName, int phone, string icon)
        {
            if (!_context.TryGetTarget(out Context context)) return;
            var i = new Intent(context, typeof(DetailedUserPage));
            i.PutExtra("fName", fName);
            i.PutExtra("lName", lName);
            i.PutExtra("phone", phone);
            i.PutExtra("icon", icon);
            (context as Activity)?.StartActivity(i);
        }
    }
}