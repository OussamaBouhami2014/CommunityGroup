using System;
using CommunityGroup.Helpers;
using CommunityGroup.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CommunityGroup
{
    public partial class App : Application
    {
        public static string PrimaryColor = "#00adb5";
        public static string PrimaryDarkColor = "#082b4b";
        public static string Accent = "#3b5998";

        public static string BlueColor = "#62acda";
        public static string YellowColor = "#F9B64C";
        public static string RedColor = "#e41b76";
        public static string OrangeColor = "#e6811f";
        public static string DarkOrangeColor = "#f76262";
        public static string GreenColor = "#F9B64C";
        public static string DarkBlueColor = "#f76262";
        public static string GrayColor = "#f4f4f4";
        public static string BorderColor = "#dcdcdc";
        public static string VioletColor = "#3f51b5";
        public static string WhiteColor = "#ffffff";
        public static string DarkTextColor = "#696969";
        public static string ColorStatutBar = "#696969";
        public static string LightBackgroundColor = "#f5f5f5";

        public static Color TopicLightBackgroundColor = Color.FromHex("#F8F8F8");
        public static Color TopicOneColor = Color.FromHex("#9000adb5");
        public static Color TopicTwoColor = Color.FromHex("#90F9B64C");
        public static Color TopicThreeColor = Color.FromHex("#90e41b76");
        public static Color TopicFourColor = Color.FromHex("#903f51b5");
        public static Color TopicFiveColor = Color.FromHex("#90F9B64C");
        public static Color TopicSixColor = Color.FromHex("#90e6811f");

        public static bool IsLogout = true;
        public static bool IsLogin = false;
        public static bool IsShakeActionRunning = false;
        public static bool isLoginAnimationDone = false;

        public static bool hasPermissionLocation = false;
        public static bool hasPermissionCamera = false;

        public static double StandardPageHeight;
        public static double StandardPageWidth;


        public static LoadingPopup LoadingPopup = new LoadingPopup();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Tapped.TappedPagePrincipal());
            return;

            if (Settings.IsLogOut)
            {
                MainPage = new NavigationPage(new Views.Login.LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Tapped.TappedPagePrincipal());
            }
              
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}