using Android.App;
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

            Rules.GenerateRules();

            //Event Handler for Play Button
            bool playButtonStatus = true;
            ImageButton playBtn = FindViewById<ImageButton>(Resource.Id.playButton);
            playBtn.Click += (sender, e) =>
            {
                if (playButtonStatus)
                {
                    playBtn.SetImageResource(Android.Resource.Drawable.IcMediaPlay);
                    playButtonStatus = !playButtonStatus;
                }
                else
                {
                    playBtn.SetImageResource(Android.Resource.Drawable.IcMediaPause);
                    playButtonStatus = !playButtonStatus;
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