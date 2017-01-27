using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace BookKeeper
{
	[Activity(Label = "Bookkeeper", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.main_layout);

			// Get our button from the layout resource,
			// and attach an event to it
			Button newEntryButton = FindViewById<Button>(Resource.Id.NewEntryButton);
			Intent newEntry = new Intent(this, typeof(NewEntryActivity));
			newEntryButton.Click += delegate { StartActivity(newEntry); };

			Button showAllEntriesButton = FindViewById<Button>(Resource.Id.ShowAllEntriesButton);
			Intent showAll = new Intent(this, typeof(NewEntryActivity));
			newEntryButton.Click += delegate { StartActivity(showAll); };

			Button generateReportButton = FindViewById<Button>(Resource.Id.GenerateReportButton);
			Intent generate = new Intent(this, typeof(NewEntryActivity));
			newEntryButton.Click += delegate { StartActivity(generate); };
		}
	}
}

