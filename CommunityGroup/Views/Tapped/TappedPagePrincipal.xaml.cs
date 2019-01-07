using System;
using System.Collections.Generic;
using CommunityGroup.Helpers;
using CommunityGroup.Views.Actualite;
using CommunityGroup.Views.Network;
using FormsToolkit;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Tapped
{
    public partial class TappedPagePrincipal : Controls.BottomNavTabPage
    {
        private ActualiteFilterPopup ActualiteFilterPopup;

        public TappedPagePrincipal()
        {
            InitializeComponent();

            //this.CurrentPageChanged += OnCurrentPageChanged;
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

        //private void OnCurrentPageChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var currentPage = this.Children[this.Children.IndexOf(this.CurrentPage)];

        //        imgToolbarFilter.IsVisible = currentPage.GetType() == typeof(ActualitePage) ? true : false;
        //        imgToolbarRecherche.IsVisible = currentPage.GetType() == typeof(NetworkPage) ? true : false;

        //        foreach (var item in this.Children)
        //        {
        //            if (item != currentPage)
        //            {
        //                item.Icon = item.Icon.File.Replace("Active","");
        //            }
        //            else
        //            {
        //                currentPage.Icon = currentPage.Icon.File + "Active";
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        AppsHelper.Snack(Ex.Message);
        //    }
        //}

        private async void Filter_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (ActualiteFilterPopup == null)
                {
                    ActualiteFilterPopup = new ActualiteFilterPopup();
                }

                await PopupNavigation.Instance.PushPopupAsyncSingle(ActualiteFilterPopup, true);
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }
        private async void Notification_Clicked  (object sender, System.EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsyncSingle(new Notification.NotificationPage());
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }
        private async void Profil_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsyncSingle(new Profile.ProfilePage());
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(App.LightBackgroundColor);
            MessagingService.Current.SendMessage(MessageKeys.Message_ChangeStatutBarColor, App.ColorStatutBar);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(App.PrimaryColor);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex(App.WhiteColor);
            MessagingService.Current.SendMessage(MessageKeys.Message_ChangeStatutBarColor, App.PrimaryColor);
        }
    }
}