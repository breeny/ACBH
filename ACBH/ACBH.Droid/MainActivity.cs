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
using Android.Support.V7.App;

namespace ACBH.Droid
{
	[Activity (Label = "ACBH.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/MyTheme")]
	public class MainActivity : AppCompatActivity
	{
        RecyclerView recyclerView;
        Android.Support.V7.Widget.Toolbar toolbar;

        protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var client = new Client("https://hottest100-craftbeer.firebaseio.com");

            var beers = (List<BeerEntry>) await client.RetrieveBeers(2015);
            var adapter = new BeerRecyclerController(beers);
            recyclerView.SetAdapter(adapter);
        }
	}
}


