using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace CommunityGroup.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            Lottie.Forms.iOS.Renderers.AnimationViewRenderer.Init();

            global::Xamarin.Forms.Forms.Init();
            XamForms.Controls.iOS.Calendar.Init();

            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            //FFImageLoading.ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration
            //{
            //    HttpClient = new System.Net.Http.HttpClient(new AuthenticatedHttpImageClientHandler())
            //});

            //Xamarin.FormsMaps.Init();

            string dbName = "OTN_DB.db3";
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"..","Library");
            string fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullPath));

            //Change TabBar Color To PrimaryColor
            UITabBar.Appearance.TintColor = new UIColor(red: 0.00f, green: 0.68f, blue: 0.71f, alpha: 1.0f);

            return base.FinishedLaunching(app, options);
        }
    }
}