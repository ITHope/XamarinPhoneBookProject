using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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

            phoneText.Text = "5874554564";
        }

        public void SetFName(string fname)
        {
            fNameText.Text = fname;
        }

        public void SetLName(string lname)
        {
            lNameText.Text = lname;
        }
    }
}