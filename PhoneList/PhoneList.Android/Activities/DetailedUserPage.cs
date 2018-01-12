using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.App;
using PhoneList.Droid.Views;

namespace PhoneList.Droid
{
    [Activity(ParentActivity = typeof(MainActivity))]
    //[MetaData(NavUtils.ParentActivity, Value = ".MainActivity")]
    public class DetailedUserPage : AppCompatActivity
    {
        private DetailedUserPageView _detailedUserPageView;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.DetailedUserPage);

            _detailedUserPageView = FindViewById<DetailedUserPageView>(Resource.Id._detailedUserPageView);                
        }

        protected override void OnResume()
        {
            base.OnResume();

            var fName = Intent.GetStringExtra("fName");
            var lName = Intent.GetStringExtra("lName");
            var phone = Intent.GetStringExtra("phone");
            var icon = Intent.GetStringExtra("icon");

            _detailedUserPageView.SetConfig(fName, lName, phone, icon);

            Title = fName + " " + lName;
        }
    }
}