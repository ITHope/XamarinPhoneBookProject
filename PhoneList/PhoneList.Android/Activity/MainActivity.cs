using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using System;

namespace PhoneList.Droid
{
    [Activity(Label = "PhoneList", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private RecyclerViewAdapter adapter;
        private RecyclerView recycler;
        private RecyclerView.LayoutManager layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);
            
            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:

            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);

            // Plug in my adapter:

            Repository repo = new Repository(new UsersList());
            adapter = new RecyclerViewAdapter(repo, this);
            recycler.SetAdapter(adapter);


            var controller = new Controller(adapter, repo);
            controller.Start();
        }
    }
}

