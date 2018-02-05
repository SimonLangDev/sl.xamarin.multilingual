using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Multilingual.Example.Pages;
using Xamarin.Forms;

namespace Multilingual.Example
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    var page = new NavigationPage(new HomePage())
		    {
		        BarBackgroundColor = Color.FromHex("#212121")
		    };
		    MainPage = page;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
