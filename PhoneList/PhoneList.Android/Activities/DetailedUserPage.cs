using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content;

namespace PhoneList.Droid
{
    [Activity(Label = "DetailedUserPage")]

    public class DetailedUserPage : Activity
    {
        public TextView fNameText { get; set; }
        public TextView lNameText { get; set; }
        public TextView phoneText { get; set; }
        public ImageView imageIcon { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
        }
    }
}