
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
	[Activity(Label = "Skapa Rapporter")]
	public class GenerateReportActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.generate_report_layout);
			BookkeeperManager bookkeeper = BookkeeperManager.Instance;

			Button taxReportButton = FindViewById<Button>(Resource.Id.TaxReport);
			taxReportButton.Click += delegate
			{
				SetContentView(Resource.Layout.show_tax_report_layout);
				TextView textView = FindViewById<TextView>(Resource.Id.TaxReportTextView);
				textView.Text = bookkeeper.GetTaxReport();
			};
		}
	}
}
