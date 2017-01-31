
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
		private BookkeeperManager bookkeeper;
		private string typeOfAccount;
		private string toFromAccount;
		private string taxRate;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.new_entry_layout);
			bookkeeper = new BookkeeperManager();

			Spinner equitySpinner = FindViewById<Spinner>(Resource.Id.type_equity_spinner);
			equitySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(EquitySpinnerItemSelected);
			var adapterOne = ArrayAdapter.CreateFromResource(
				this, Resource.Array.account_type_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapterOne.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			equitySpinner.Adapter = adapterOne;

			Spinner ToFromSpinner = FindViewById<Spinner>(Resource.Id.account_spinner);
			ToFromSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ToFromSpinnerItemSelected);
			var adapterTwo = ArrayAdapter.CreateFromResource(
				this, Resource.Array.account_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapterTwo.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			ToFromSpinner.Adapter = adapterTwo;

			Spinner taxRateSpinner = FindViewById<Spinner>(Resource.Id.taxSpinner);
			taxRateSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(TaxRateSelected);
			var adapterThree = ArrayAdapter.CreateFromResource(
				this, Resource.Array.tax_rate_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapterThree.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			taxRateSpinner.Adapter = adapterThree;

			SelectAccount();
			SaveInput();
		}

		private void SelectAccount()
		{
			RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.incomeOrExpenseRadioGroup);
			RadioButton incomeButton = FindViewById<RadioButton>(Resource.Id.incomeRadioButton );
			RadioButton expenseButton = FindViewById<RadioButton>(Resource.Id.expensesRadioButton);

			radioGroup.CheckedChange += delegate {
				if (incomeButton.Checked) { Console.WriteLine("income selected      ??? ");}
				if (expenseButton.Checked) { Console.WriteLine("expense selected      ??? "); }
			};
		}

		private void SaveInput()
		{
			Button addEntryButton = FindViewById<Button>(Resource.Id.addEntryButton);
			addEntryButton.Click += delegate
			{
				EditText dateEditText = FindViewById<EditText>(Resource.Id.dateEditText);
				string date = dateEditText.Text;

				EditText descriptionEditText = FindViewById<EditText>(Resource.Id.descriptionEditText);
				string description = descriptionEditText.Text;

				EditText totalAmmountEditText = FindViewById<EditText>(Resource.Id.totalTaxEditText);
				string totalAmmount = totalAmmountEditText.Text;

				Entry newEntry = new Entry(date, description, typeOfAccount, toFromAccount, totalAmmount, taxRate );
				bookkeeper.addEntry(newEntry);
			};
		}

		private void EquitySpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			typeOfAccount = spinner.GetItemAtPosition(e.Position).ToString();
		}

		private void ToFromSpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			toFromAccount = spinner.GetItemAtPosition(e.Position).ToString();
		}

		private void TaxRateSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			taxRate = spinner.GetItemAtPosition(e.Position).ToString();
		}
	}
}
