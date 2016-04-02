package md51ea2e9173a0fdd6a03038dbb6b9c0446;


public class BeerRecyclerHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ACBH.Droid.Controllers.BeerRecyclerHolder, ACBH.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BeerRecyclerHolder.class, __md_methods);
	}


	public BeerRecyclerHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == BeerRecyclerHolder.class)
			mono.android.TypeManager.Activate ("ACBH.Droid.Controllers.BeerRecyclerHolder, ACBH.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
