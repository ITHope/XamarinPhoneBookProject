﻿using System;
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
        public TextView txt { get; set; }
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            txt = itemView.FindViewById<TextView>(Resource.Id.textView);
        }

        public void SetFName(string fname)
        {
            throw new NotImplementedException();
        }

        public void SetLName(string lname)
        {
            throw new NotImplementedException();
        }
    }
}