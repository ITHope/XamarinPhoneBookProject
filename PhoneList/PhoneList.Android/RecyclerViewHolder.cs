using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PhoneList.Droid
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder, IView
    {
        public TextView fNameText { get; set; }
        public TextView lNameText { get; set; }
        public TextView phoneText { get; set; }


        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            fNameText = itemView.FindViewById<TextView>(Resource.Id.fNameTextView);
            lNameText = itemView.FindViewById<TextView>(Resource.Id.lNameTextView);
            phoneText = itemView.FindViewById<TextView>(Resource.Id.phoneTextView);
        }

        public void SetFName(string fname)
        {
            fNameText.Text = fname;
        }

        public void SetLName(string lname)
        {
            lNameText.Text = lname;
        }

        public void SetPhone(int phone)
        {
            phoneText.Text = phone.ToString();
        }

        public void SetIcon(string icon)
        {
            //throw new System.NotImplementedException();
        }
    }
}