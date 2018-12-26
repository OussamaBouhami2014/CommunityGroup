﻿using System;
using CommunityGroup.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CommunityGroup
{
    public partial class App : Application
    {
        public static string PrimaryColor = "#55968f";
        public static string PrimaryDarkColor = "#082b4b";
        public static string Accent = "#44b98c";

        public static string BlueColor = "#62acda";
        public static string YellowColor = "#F9B64C";
        public static string RedColor = "#3fc1c9";
        public static string OrangeColor = "#e6811f";
        public static string DarkOrangeColor = "#f76262";
        public static string GreenColor = "#F9B64C";
        public static string DarkBlueColor = "#f76262";
        public static string GrayColor = "#f4f4f4";
        public static string BorderColor = "#dcdcdc";
        public static string VioletColor = "#3f51b5";
        public static string WhiteColor = "#ffffff";
        public static string DarkTextColor = "#696969";
        public static string LightBackgroundColor = "#f5f5f5";

        public static bool IsLogout = true;
        public static bool IsLogin = false;
        public static bool IsShakeActionRunning = false;
        public static bool isLoginAnimationDone = false;

        public static bool hasPermissionLocation = false;
        public static bool hasPermissionCamera = false;

        public static double StandardPageHeight;
        public static double StandardPageWidth;

        public App()
        {
            InitializeComponent();

            if (Settings.IsLogOut)
            {
                MainPage = new NavigationPage(new Views.Login.LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Tapped.TappedPagePrincipal());
            }
                //MainPage = new NavigationPage(new MainPage());
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