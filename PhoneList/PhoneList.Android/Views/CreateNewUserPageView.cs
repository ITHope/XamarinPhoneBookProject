using Android.Util;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.Constraints;

namespace PhoneList.Droid.Views
{
    [Register("PhoneList.Droid.Views.CreateNewUserPageView")]
    public class CreateNewUserPageView : ConstraintLayout
    {
        private Button _btnCancel;

        public CreateNewUserPageView(Context context) : base(context)
        {
            Initialize();
        }

        public CreateNewUserPageView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public CreateNewUserPageView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            Inflate(Context, Resource.Layout.CreateNewUserPageView, this);

            _btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            _btnCancel.Click += delegate
            {
                OnClickBtnCancel();
            };
        }

        private void OnClickBtnCancel()
        {
            ((AppCompatActivity)Context).Finish();
        }
    }
}