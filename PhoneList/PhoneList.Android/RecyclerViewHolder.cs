using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace PhoneList.Droid
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder, IView
    {
        public TextView fNameText { get; set; }
        public TextView lNameText { get; set; }
        public TextView phoneText { get; set; }
        public ImageView imageIcon { get; set; }

        public RecyclerViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            fNameText = itemView.FindViewById<TextView>(Resource.Id.fNameTextView);
            lNameText = itemView.FindViewById<TextView>(Resource.Id.lNameTextView);
            phoneText = itemView.FindViewById<TextView>(Resource.Id.phoneTextView);
            imageIcon = itemView.FindViewById<ImageView>(Resource.Id.imageViewIcon);

            itemView.Click += (sender, e) => listener(Position);
        }

        public void SetFName(string fname)
        {
            fNameText.Text = fname;
        }

        public void SetLName(string lname)
        {
            lNameText.Text = lname;
        }

        public void SetPhone(string phone)
        {
            phoneText.Text = phone;
        }

        public void SetIcon(string icon)
        {
            imageIcon.SetImageResource(Resource.Mipmap.man);
        }
    }
}