using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class RecyclerViewAdapter : RecyclerView.Adapter, IUsersListAdapter
    {
        private List<User> _usersList;
        private Context _context;
        IRepository _repository;

        public RecyclerViewAdapter(IRepository repository, Context context)
        {
            _repository = repository;
            _context = context;
            _usersList = new List<User>();
            //_idList = _repository.GetAllIdList();
        }

        public override int ItemCount => _usersList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            var presenter = new Presenter(vh, new Interactor(new ModelCreator(_repository)));
            //_idList = presenter.GetAllIdList();
            presenter.Init(_usersList[position].Id);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item, parent, false);
            
            var vh = new RecyclerViewHolder(itemView);
            return vh;
        }

        public void UpdateUsersList(List<User> usersList)
        {
            _usersList = usersList;
            (_context as Activity).RunOnUiThread(() =>
            {
                NotifyDataSetChanged();
            });
        }
    }
}