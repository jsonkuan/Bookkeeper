
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

using SQLite;

namespace BookKeeper
{
	[Activity(Label = "New Entry")]
	public class NewEntryActivity : Activity
	{
		BookkeeperManager bookkeeper = BookkeeperManager.Instance;
		string typeOfAccount;
		string toFromAccount;
		double taxRate;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.new_entry_layout);

			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			SQLiteConnection database = new SQLiteConnection(path + @"\database.db");
		
			SelectAccountToConfigureSpinners(database);
			SaveInput();
		}

		void SelectAccountToConfigureSpinners(SQLiteConnection db)
		{
			RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.incomeOrExpenseRadioGroup);
			RadioButton incomeButton = FindViewById<RadioButton>(Resource.Id.incomeRadioButton);
			RadioButton expenseButton = FindViewById<RadioButton>(Resource.Id.expensesRadioButton);


			radioGroup.CheckedChange += delegate
			{
				Spinner accountTypeSpinner = FindViewById<Spinner>(Resource.Id.type_equity_spinner);
				accountTypeSpinner.ItemSelected += AccountTypeSelected;
				TableQuery<Account> moneyAccounts = db.Table<Account>().Where(x => x.Type == "M-");
				var adapterOne = new ArrayAdapter<Account>(
					this, Android.Resource.Layout.SimpleSpinnerItem, moneyAccounts.ToList());
				adapterOne.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
				accountTypeSpinner.Adapter = adapterOne;
				
				Spinner taxRateSpinner = FindViewById<Spinner>(Resource.Id.taxSpinner);
				taxRateSpinner.ItemSelected += TaxRateSelected;
				TableQuery<TaxRate> tax = db.Table<TaxRate>();
				var adapterThree = new ArrayAdapter<TaxRate>(
					this, Android.Resource.Layout.SimpleSpinnerItem, tax.ToList());
				adapterThree.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
				taxRateSpinner.Adapter = adapterThree;

				if (incomeButton.Checked)
				{
					Console.WriteLine("Income selected: ");
					Spinner selectAccountSpinner = FindViewById<Spinner>(Resource.Id.account_spinner);
					selectAccountSpinner.ItemSelected += ToFromAccountSelected;

					TableQuery<Account> incomeAccounts = db.Table<Account>().Where(x => x.Type == "I-");
					var adapterTwo = new ArrayAdapter<Account>(
						this, Android.Resource.Layout.SimpleSpinnerItem, incomeAccounts.ToList());
					adapterTwo.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					selectAccountSpinner.Adapter = adapterTwo;
				}

				if (expenseButton.Checked)
				{
					Console.WriteLine("Expenses selected: ");
					Spinner selectAccountSpinner = FindViewById<Spinner>(Resource.Id.account_spinner);
					selectAccountSpinner.ItemSelected += ToFromAccountSelected;

					TableQuery<Account> expenseAccounts = db.Table<Account>().Where(x => x.Type == "E-");
					var adapterTwo = new ArrayAdapter<Account>(
						this, Android.Resource.Layout.SimpleSpinnerItem, expenseAccounts.ToList());
					adapterTwo.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					selectAccountSpinner.Adapter = adapterTwo;
				}
			};
		}

		void SaveInput()
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

				Entry newEntry = new Entry(date, description, typeOfAccount, toFromAccount, totalAmmount, taxRate);
				bookkeeper.addEntry(newEntry);

				//TODO: Reset method with "New entry added" or "Saved" toast and exit activity
			};
		}

		void AccountTypeSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			typeOfAccount = spinner.GetItemAtPosition(e.Position).ToString();
		}

		void ToFromAccountSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			toFromAccount = spinner.GetItemAtPosition(e.Position).ToString();
		}

		void TaxRateSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			//TODO: FIX THIS
			//taxRate = double.Parse(spinner.GetItemAtPosition(e.Position).ToString());
		}
	}
}
