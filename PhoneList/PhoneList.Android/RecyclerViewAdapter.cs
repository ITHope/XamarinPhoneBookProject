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
    public class RecyclerViewAdapter : RecyclerView.Adapter/*, IMyAdapter*/
    {
        private List<int> _idList;
        public RecyclerViewAdapter(IRepository repository)
        {
            _idList = repository.GetAllIdList();
        }

        public override int ItemCount => _idList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            var presenter = new Presenter(vh, new Interactor(new ModelCreator(new Repository(new UsersList()))));
            //_idList = presenter.GetAllIdList();
            //presenter.Init(_idList[position]);
            presenter.GetNextUser();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item, parent, false);
            
            var vh = new RecyclerViewHolder(itemView);
            return vh;
        }

        //public void UpdateData(List<int> newIdList)
        //{
        //    _idList = newIdList;
        //}

        //public void Update(List<User> data)
        //{
        //    _idList = data;
        //    NotifyDataSetChanged();
        //}
    }
}