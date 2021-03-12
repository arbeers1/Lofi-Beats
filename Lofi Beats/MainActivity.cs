using Android.App;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.Core.Content;
using Android.Graphics;
using Android.Views;

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

            ImageButton RefreshBtn = FindViewById<ImageButton>(Resource.Id.refreshButton);
            RefreshBtn.SetColorFilter(Color.Argb(255,123,123,123));
            RefreshBtn.Click += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("...............REFRESH BRUH");
                Manager.Refresh();
            };

            RefreshBtn.Touch += (sender, e) =>
            {
                if(e.Event.Action == MotionEventActions.Down)
                {
                    RefreshBtn.SetColorFilter(Color.Argb(255, 255, 255, 255));
                }
                if(e.Event.Action == MotionEventActions.Up)
                {
                    RefreshBtn.SetColorFilter(Color.Argb(255, 123, 123, 123));
                    Manager.Refresh();
                }
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}