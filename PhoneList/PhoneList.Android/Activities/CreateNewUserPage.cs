using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace PhoneList.Droid.Resources.layout
{
    [Activity(Label = "CreateNewUserPage")]
    public class CreateNewUserPage : AppCompatActivity
    {
        private CreateNewUserPage _createNewUserPage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateNewUserPage);

           
        }
    }
}