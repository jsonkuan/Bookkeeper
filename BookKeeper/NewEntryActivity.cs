
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
		List<Account> accountList = new List<Account>() {new Account("a1", "12345678"), new Account("a2", "98765432")};

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.new_entry_layout);
			bookkeeper = new BookkeeperManager();

			Spinner accountTypeSpinner = FindViewById<Spinner>(Resource.Id.type_equity_spinner);
			accountTypeSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(AccountTypeSelected);
			var adapterOne = ArrayAdapter.CreateFromResource(
				this, Resource.Array.account_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapterOne.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			accountTypeSpinner.Adapter = adapterOne;

			Spinner selectAccountSpinner = FindViewById<Spinner>(Resource.Id.account_spinner);
			selectAccountSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ToFromAccountSelected);
			ArrayAdapter<Account> adapterTwo = new ArrayAdapter<Account>(	
			this, Android.Resource.Layout.SimpleSpinnerItem, accountList);
			adapterTwo.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			selectAccountSpinner.Adapter = adapterTwo;

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

		private void AccountTypeSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			typeOfAccount = spinner.GetItemAtPosition(e.Position).ToString();
		}

		private void ToFromAccountSelected(object sender, AdapterView.ItemSelectedEventArgs e)
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
