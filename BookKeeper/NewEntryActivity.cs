
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

namespace BookKeeper
{
	[Activity(Label = "New Entry")]
	public class NewEntryActivity : Activity
	{
		BookkeeperManager bookkeeper;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.new_entry_layout);
			bookkeeper = new BookkeeperManager();

			Spinner equitySpinner = FindViewById<Spinner>(Resource.Id.type_equity_spinner);
			equitySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(equitySpinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(
				this, Resource.Array.account_type_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			equitySpinner.Adapter = adapter;

			selectAccount();
			saveInput();
		}

		private void selectAccount()
		{
			RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.incomeOrExpenseRadioGroup);
			RadioButton incomeButton = FindViewById<RadioButton>(Resource.Id.incomeRadioButton );
			RadioButton expenseButton = FindViewById<RadioButton>(Resource.Id.expensesRadioButton);

			radioGroup.CheckedChange += delegate {
				if (incomeButton.Checked) { Console.WriteLine("income selected      ??? ");}
				if (expenseButton.Checked) { Console.WriteLine("expense selected      ??? "); }
			};
		}

		private void saveInput()
		{
			Button addEntryButton = FindViewById<Button>(Resource.Id.addEntryButton);
			addEntryButton.Click += delegate
			{
				EditText dateEditText = FindViewById<EditText>(Resource.Id.dateEditText);
				string date = dateEditText.Text;

				EditText descriptionEditText = FindViewById<EditText>(Resource.Id.descriptionEditText);
				string description = descriptionEditText.Text;

				Entry newEntry = new Entry(date, description);
				bookkeeper.addEntry(newEntry);
			};
		}

		private void equitySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}
	}
}
