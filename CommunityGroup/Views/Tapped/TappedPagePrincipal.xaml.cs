using System;
using System.Collections.Generic;
using FormsToolkit;
using Xamarin.Forms;

namespace CommunityGroup.Views.Tapped
{
    public partial class TappedPagePrincipal : Controls.BottomNavTabPage
    {
        public TappedPagePrincipal()
        {
            InitializeComponent();

            this.CurrentPageChanged += OnCurrentPageChanged;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (height > -1)
            {
                App.StandardPageHeight = height;
                App.StandardPageWidth = width;
            }

        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            //page1.Icon = "info";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingService.Current.SendMessage(MessageKeys.Message_ExitFullScreen);

            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(App.PrimaryColor);
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex(App.WhiteColor);

            ////MessagingCenter.Send<A4CTappedPage, string>(this, MessageKeys.ChangeStatutBarColor, App.PrimaryDarkColor);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(App.PrimaryColor);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex(App.WhiteColor);
            MessagingService.Current.SendMessage(MessageKeys.ChangeStatutBarColor, App.PrimaryColor);
        }
    }
}
