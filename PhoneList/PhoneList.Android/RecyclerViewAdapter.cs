using System;
using Android.Views;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace PhoneList.Droid
{
    public class RecyclerViewAdapter : RecyclerView.Adapter, IUsersListAdapter
    {
        private List<User> _usersList;
        IRepository _repository;
        private Presenter presenter;

        public event EventHandler<int> ItemClick;

        public RecyclerViewAdapter(IRepository repository)
        {
            _repository = repository;
            _usersList = new List<User>();
        }

        public override int ItemCount => _usersList.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            presenter = new Presenter(vh, new Interactor(new ModelCreator(_repository)), new Router(vh.ItemView.Context));
            presenter.Init(_usersList[position].Id);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.Item, parent, false);

            var card = parent.FindViewById<CardView>(Resource.Id.cardView);
            
            var vh = new RecyclerViewHolder(itemView, OnClick);

            return vh;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }

        public void ShowDetailedPage (int userId)
        {
            presenter.GoToDetailsPage(_usersList[userId].Id);
        }
    }
}