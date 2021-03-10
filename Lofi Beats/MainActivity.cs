﻿using Android.App;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace Lofi_Beats
{
    /// <summary>
    /// Entry Point for program
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            MusicNode.MainAct = this;
            MusicNode.Resources = this.Resources;

            //Generate Rules
            Rules.GenerateRules();

            //Starts Audio
            TrackManager Manager = new TrackManager();

            //Event Handler for Play Button
            bool PlayButtonStatus = true;
            ImageButton PlayBtn = FindViewById<ImageButton>(Resource.Id.playButton);
            PlayBtn.Click += (sender, e) =>
            {
                if (PlayButtonStatus) //Pause
                {
                    Manager.pause();
                    PlayBtn.SetImageResource(Android.Resource.Drawable.IcMediaPlay);
                    PlayButtonStatus = !PlayButtonStatus;
                }
                else //Play
                {
                    Manager.play();
                    PlayBtn.SetImageResource(Android.Resource.Drawable.IcMediaPause);
                    PlayButtonStatus = !PlayButtonStatus;
                }
            };

            /*System.Diagnostics.Debug.WriteLine(Resources.GetResourceEntryName(n));
            System.Diagnostics.Debug.WriteLine(Resources.GetResourceTypeName(n));
            System.Diagnostics.Debug.WriteLine(Resources.GetResourcePackageName(n));
            System.Diagnostics.Debug.WriteLine("....." + Resources.GetIdentifier("testsound", "raw", "com.companyname.lofi_beats"));*/
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}