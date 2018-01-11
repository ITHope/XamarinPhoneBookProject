using Android.OS;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.Design.Widget;
using PhoneList.Droid.Resources.layout;
using Android.Support.V7.App;

namespace PhoneList.Droid
{
    [Activity(Label = "PhoneList", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IUsersListAdapter
    {
        private RecyclerViewAdapter adapter;
        private RecyclerView recycler;
        private RecyclerView.LayoutManager layoutManager;
        private FloatingActionButton btnFloatCreateUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            btnFloatCreateUser = FindViewById<FloatingActionButton>(Resource.Id.fab);

            //Plug in the linear layout manager:

            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);

            // Plug in my adapter:

            Repository repo = new Repository(new UsersList());

            adapter = new RecyclerViewAdapter(repo);
            adapter.ItemClick += OnItemClick;
            recycler.SetAdapter(adapter);

            btnFloatCreateUser.Click += delegate
            {
                ShowCreateNewUserPage();
            };

            var controller = new Controller(this, repo);
            controller.Start();
        }

        void ShowCreateNewUserPage()
        {
            RunOnUiThread(() =>
            {
                var i = new Intent(this, typeof(CreateNewUserPage));
                StartActivity(i);
            });
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

