using Android.OS;
using Android.App;
using Android.Support.V7.App;

namespace PhoneList.Droid.Resources.layout
{
    [Activity(Label = "CreateNewUserPage")]
    public class CreateNewUserPage : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateNewUserPage);
        }
    }
}