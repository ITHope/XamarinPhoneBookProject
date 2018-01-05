using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;

namespace PhoneList.Droid
{
    public class RecyclerViewAdapter : RecyclerView.Adapter, IUsersListAdapter
    {
        private List<User> _usersList;
        IRepository _repository;
        private Presenter presenter;

        public RecyclerViewAdapter(IRepository repository)
        {
            _repository = repository;
            _usersList = new List<User>();
        }

        public override int ItemCount => _usersList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;

            presenter = new Presenter(vh, new Interactor(new ModelCreator(_repository)), new Router(vh.ItemView.Context));

            if (vh != null && !vh.ItemView.HasOnClickListeners)
            {
                vh.ItemView.Click += (s, e) =>
                {
                    if (s is ViewGroup baseLayout && baseLayout.Id == Resource.Id.cardView)
                    {
                        if (baseLayout.Context is MainActivity mainActContext)
                        {
                            //mainActContext.GoToDetailsPage(_usersList[position].Name
                            //                                , _usersList[position].LastName
                            //                                , _usersList[position].Phone
                            //                                , _usersList[position].Icon
                            //                                );
                            mainActContext.RunOnUiThread(() =>
                            {
                                presenter.GoToDetailsPage(_usersList[position].Id);
                            });
                        }
                    }
                };
            }

                presenter.Init(_usersList[position].Id);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item, parent, false);

            var card = parent.FindViewById<CardView>(Resource.Id.cardView);


            var vh = new RecyclerViewHolder(itemView);

            return vh;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
        }
    }
}