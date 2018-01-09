using Android.OS;
using Android.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace PhoneList.Droid
{
    [Activity(Label = "PhoneList", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IUsersListAdapter
    {
        private RecyclerViewAdapter adapter;
        private RecyclerView recycler;
        private RecyclerView.LayoutManager layoutManager; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            

            //this.ActionBar.NavigationMode = ActionBarNavigationMode.List;

            //var actionBar = ((Activity)this).ActionBar;
            //actionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha));

            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            //Plug in the linear layout manager:

            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);

            // Plug in my adapter:

            Repository repo = new Repository(new UsersList());

            adapter = new RecyclerViewAdapter(repo);
            adapter.ItemClick += OnItemClick;
            recycler.SetAdapter(adapter);

            var controller = new Controller(this, repo);
            controller.Start();
        }

        void OnItemClick(object sender, int position)
        {
            RunOnUiThread(() =>
            {
                adapter.ShowDetailedPage(position);
            });
        }

        public void UpdateUsersList(List<User> usersList)
        {
           adapter.UpdateUsersList(usersList);
           RunOnUiThread(() =>
            {
                adapter.NotifyDataSetChanged();
            });
        }
    }
}

