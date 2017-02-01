using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

using SQLite;

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
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			SQLiteConnection database = new SQLiteConnection(path + @"\database.db");

			database.CreateTable<Entry>();

			database.CreateTable<Account>();
			Account a = new Account();
			a.configureAccountTypes(database);

			database.CreateTable<TaxRate>();
			TaxRate t = new TaxRate();
			t.configureTaxRates(database);


			Button newEntryButton = FindViewById<Button>(Resource.Id.NewEntryButton);
			Intent newEntry = new Intent(this, typeof(NewEntryActivity));
			newEntryButton.Click += delegate { StartActivity(newEntry); };

			Button showAllEntriesButton = FindViewById<Button>(Resource.Id.ShowAllEntriesButton);
			Intent showAll = new Intent(this, typeof(ShowAllActivity));
			showAllEntriesButton.Click += delegate { StartActivity(showAll); };

			Button generateReportButton = FindViewById<Button>(Resource.Id.GenerateReportButton);
			Intent generate = new Intent(this, typeof(NewEntryActivity));
			generateReportButton.Click += delegate { StartActivity(generate); };
		}
	}
}

