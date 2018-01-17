using Android.OS;
using Android.App;
using Android.Content;
using PhoneList.Droid.Views;
using Android.Support.V7.App;

namespace PhoneList.Droid
{
    [Activity(ParentActivity = typeof(MainActivity))]
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