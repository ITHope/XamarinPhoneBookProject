using Android.Util;
using Android.Widget;
using Android.Runtime;
using Android.Content;
using Android.Support.Constraints;

namespace PhoneList.Droid.Views
{
    [Register("PhoneList.Droid.Views.DetailedUserPageView")]
    public class DetailedUserPageView : ConstraintLayout
    {
        public TextView fNameText { get; set; }
        public TextView lNameText { get; set; }
        public TextView phoneText { get; set; }
        public ImageView imageIcon { get; set; }
        
        public DetailedUserPageView(Context context) : base(context)
        {
            Initialize();
        }

        public DetailedUserPageView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public DetailedUserPageView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            Inflate(Context, Resource.Layout.DetailedUserPageView, this);   

            fNameText = FindViewById<TextView>(Resource.Id.lblFNameTxt);
            lNameText = FindViewById<TextView>(Resource.Id.lblLNameTxt);
            phoneText = FindViewById<TextView>(Resource.Id.lblPhoneTxt);
            imageIcon = FindViewById<ImageView>(Resource.Id.imgIcon);
        }

        internal void SetConfig(string fName, string lName, string phone, string icon)
        {
            fNameText.Text = fName;
            lNameText.Text = lName;
            phoneText.Text = phone;
            imageIcon.SetImageResource(Resource.Mipmap.man);
        }
    }
}