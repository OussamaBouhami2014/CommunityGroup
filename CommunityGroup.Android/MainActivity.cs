using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using FormsToolkit;
//using Plugin.Permissions;
using Android.Widget;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CommunityGroup.Droid
{
    [Activity(Label = "OTN", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            #region Initialize plugins
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Acr.UserDialogs.UserDialogs.Init(this);
            //Lottie.Forms.Droid.Renderers.AnimationViewRenderer.Init();
            //Lottie.Forms.AnimationView.

            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            //FFImageLoading.ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration
            //{
            //    //HttpClient = new System.Net.Http.HttpClient(new AuthenticatedHttpImageClientHandler())
            //});
            #endregion

            //Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

            #region Log Exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            #endregion



            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            XamForms.Controls.Droid.Calendar.Init();

            #region Log Exceptions: Display Crash Report
            DisplayCrashReport();
            #endregion

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string dbName = "OTN_DB.db3";
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            string fullPath = Path.Combine(folderPath, dbName);


            LoadApplication(new App(fullPath));

            #region MessagingServices
            // Change staut bar color.
            MessagingService.Current.Subscribe<string>(MessageKeys.Message_ChangeStatutBarColor, (page, color) =>
            {
                try
                {
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    {
                        // Change the StatutBarColor
                        Window.SetStatusBarColor(new Android.Graphics.Color(Android.Graphics.Color.ParseColor(color)));
                    }
                }
                catch (Exception Ex)
                {
                    Toast.MakeText(this, Ex.Message, ToastLength.Short).Show();
                }
            });

            MessagingService.Current.Subscribe(MessageKeys.Message_EnterFullScreen, (page) =>
            {
                try
                {
                    //RequestedOrientation = ScreenOrientation.Landscape;
                    base.SetTheme(Android.Resource.Style.ThemeNoTitleBarFullScreen);
                    Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
                }
                catch (Exception Ex)
                {
                    Toast.MakeText(this, Ex.Message, ToastLength.Short).Show();
                }
            });
            MessagingService.Current.Subscribe(MessageKeys.Message_ExitFullScreen, (page) =>
            {
                try
                {
                    //RequestedOrientation = ScreenOrientation.Portrait;
                    base.SetTheme(Resource.Style.MainTheme);
                    Window.ClearFlags(WindowManagerFlags.Fullscreen);
                }
                catch (Exception Ex)
                {
                    Toast.MakeText(this, Ex.Message, ToastLength.Short).Show();
                }
            });
            #endregion



        }

        #region Rg Plugin Override OnBackButtonPressed
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                //// Do something if there are some pages in the PopupStack
            }
            else
            {
                //// Do something if there are no pages in the PopupStack
            }
        }
        #endregion


        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        #region Error handling
        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var newExc = new Exception("CurrentDomainOnUnhandledException", e.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", e.Exception);
            LogUnhandledException(newExc);
        }

        internal static void LogUnhandledException(Exception exception)
        {
            try
            {
                const string errorFileName = "Fatal.log";
                var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // iOS: Environment.SpecialFolder.Resources
                var errorFilePath = Path.Combine(libraryPath, errorFileName);
                var errorMessage = String.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}",
                DateTime.Now, exception.ToString());
                File.WriteAllText(errorFilePath, errorMessage);

                // Log to Android Device Logging.
                Android.Util.Log.Error("Crash Report", errorMessage);
            }
            catch
            {
                // just suppress any error logging exceptions
            }
        }

        /// <summary>
        // If there is an unhandled exception, the exception information is diplayed 
        // on screen the next time the app is started (only in debug configuration)
        /// </summary>
        [Conditional("DEBUG")]
        private void DisplayCrashReport()
        {
            const string errorFilename = "Fatal.log";
            var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var errorFilePath = Path.Combine(libraryPath, errorFilename);

            if (!File.Exists(errorFilePath))
            {
                return;
            }

            var errorText = File.ReadAllText(errorFilePath);
            new AlertDialog.Builder(this)
                .SetPositiveButton("Clear", (sender, args) =>
                {
                    File.Delete(errorFilePath);
                })
                .SetNegativeButton("Close", (sender, args) =>
                {
                    // User pressed Close.
                })
                .SetMessage(errorText)
                .SetTitle("Crash Report")
                .Show();
        }

        #endregion

    }
}