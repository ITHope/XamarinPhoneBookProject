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
using PhoneList;

namespace PhoneList.Droid
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<User> _users = new List<User>();

        public RecyclerViewAdapter(List<User> users)
        {
            _users = users;
        }

        public override int ItemCount => _users.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            var presenter = new Presenter(vh, new Interactor(new ModelCreator(new Repository())));
            presenter.Init(position);
            //vh.txt.Text = _users[position].Name;
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