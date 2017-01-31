
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

		//KEEPS TRACK OF ACCOUNT TYPE
		String accountType;
		string[] equity = { "FirstEq", "SecondEq", "ThirdEq" };
		string[] accounts = { "FirstAcc", "SecondAcc", "ThirdAcc" };
		int[] taxRates = { 5, 10, 15 };

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.new_entry_layout);


			RadioButton incomeRadioButton = FindViewById<RadioButton>(Resource.Id.incomeRadioButton);
			if (incomeRadioButton.IsShown) 
			{
				accountType = "Income Account";
			} 

			RadioButton expenseRadioButton = FindViewById<RadioButton>(Resource.Id.expensesRadioButton);
			if (expenseRadioButton.IsShown)
			{
				accountType = "Expense Account";
			}

			EditText dateEditText = FindViewById<EditText>(Resource.Id.dateEditText);
			string date = dateEditText.Text;

			EditText descriptionEditText = FindViewById<EditText>(Resource.Id.descriptionEditText);
			string description = descriptionEditText.Text;

			Spinner type = FindViewById<Spinner>(Resource.Id.type_equity_spinner);
			ArrayAdapter typeArrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, accounts);

			Spinner accountOverview = FindViewById<Spinner>(Resource.Id.account_spinner);
			ArrayAdapter overviewArrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, accounts);

			EditText totalAmmountInt = FindViewById<EditText>(Resource.Id.totalTaxEditText);
			string total = totalAmmountInt.Text;
			//int totalAmmount = Convert.ToInt32(total);

			Spinner taxRate = FindViewById<Spinner>(Resource.Id.taxSpinner);
			ArrayAdapter taxrateArrayAdapter = new ArrayAdapter<int>(this, Android.Resource.Layout.SimpleListItem1, taxRates);



			Entry newEntry = new Entry(date, description, equity[1], accounts[2], 1, taxRates[1], accountType);
			BookkeeperManager bookkeeper = new BookkeeperManager();
			bookkeeper.addEntry(newEntry); 
		}

		//public Entry(string date, string description, string[] type, string accountOverview, int totalAmmount, int[] tax, string typeOfAccount)
		//{
		//	this.date = date;
		//	this.description = description;
		//	this.type = type;
		//	this.accountOverview = accountOverview;
		//	this.totalAmmount = totalAmmount;
		//	this.tax = tax;
		//	this.typeOfAccount = typeOfAccount;
		//}


	}
}
