using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Multilingual.Example.Droid
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, Immersive = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);
            ThreadPool.QueueUserWorkItem(o => LoadActivity());
        }

        private void LoadActivity()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            RunOnUiThread(() =>
            {
                StartActivity(typeof(MainActivity));
            });
        }
    }
}