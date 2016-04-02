using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using ACBH.Network;
using ACBH.Model;
using System.Collections.Generic;
using ACBH.Droid.Controllers;

namespace ACBH.Droid
{
	[Activity (Label = "ACBH.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        RecyclerView recyclerView;

        protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var client = new Client("https://hottest100-craftbeer.firebaseio.com");

            var beers = (List<BeerEntry>) await client.RetrieveBeers(2015);
            var adapter = new BeerRecyclerController(beers);
            recyclerView.SetAdapter(adapter);
        }
	}
}


