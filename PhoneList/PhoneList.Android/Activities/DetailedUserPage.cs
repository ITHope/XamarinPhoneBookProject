using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Support.V4.App;

namespace PhoneList.Droid
{
    [Activity(ParentActivity = typeof(MainActivity))]
    [MetaData(NavUtils.ParentActivity, Value = ".MainActivity")]
    public class DetailedUserPage : Activity
    {
        public TextView fNameText { get; set; }
        public TextView lNameText { get; set; }
        public TextView phoneText { get; set; }
        public ImageView imageIcon { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.DetailedUserPage);
            var fName = Intent.GetStringExtra("fName");
            var lName = Intent.GetStringExtra("lName");
            var phone = Intent.GetIntExtra("phone", 0);
            var icon = Intent.GetStringExtra("icon");

            fNameText = FindViewById<TextView>(Resource.Id.lblFNameTxt);
            lNameText = FindViewById<TextView>(Resource.Id.lblLNameTxt);
            phoneText = FindViewById<TextView>(Resource.Id.lblPhoneTxt);
            imageIcon = FindViewById<ImageView>(Resource.Id.imgIcon);

            fNameText.Text = fName;
            lNameText.Text = lName;
            phoneText.Text = phone.ToString();
            imageIcon.SetImageResource(Resource.Mipmap.man);
            
            Title = fName + " " + lName;
        }
    }
}