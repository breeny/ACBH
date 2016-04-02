using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using ACBH.Model;

namespace ACBH.Droid.Controllers
{
    class BeerRecyclerController : RecyclerView.Adapter
    {
        List<BeerEntry> beers;

        public BeerRecyclerController(List<BeerEntry> beers)
        {
            this.beers = beers;
        }

        public override int ItemCount
        {
            get
            {
                return beers.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var beer = beers[position];
            var stubbyHolder = holder as BeerRecyclerHolder;
            stubbyHolder.BeerName.Text = beer.Beer.Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.beerentryrow, parent, false);
            var viewHolder = new BeerRecyclerHolder(row);
            return viewHolder;
        }
    }

    class BeerRecyclerHolder : RecyclerView.ViewHolder
    {
        public TextView BeerName { get; private set; }
        public BeerRecyclerHolder(View view) : base(view)
        {
            BeerName = view.FindViewById<TextView>(Resource.Id.beer_name);
        }
    }
}