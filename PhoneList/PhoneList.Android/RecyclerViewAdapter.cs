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
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public override int ItemCount => throw new NotImplementedException();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            vh.txt.Text = "";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item, parent, false);
            
            var vh = new RecyclerViewHolder(itemView);
            return vh;
        }
    }
}