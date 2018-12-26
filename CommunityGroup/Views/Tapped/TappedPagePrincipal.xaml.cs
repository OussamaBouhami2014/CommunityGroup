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
            try
            {
                var currentPage = this.Children[this.Children.IndexOf(this.CurrentPage)];

                foreach (var item in this.Children)
                {
                    //if (string.IsNullOrWhiteSpace(item.Title))
                    //{
                    //    await Navigation.PushModalAsyncSingle(new Inscription.InscriptionPage(), true);
                    //    return;
                    //}

                    if (item != currentPage)
                    {
                        item.Icon = "icon" + item.Title + ".png";
                    }
                    else
                    {
                        currentPage.Icon = "icon" + currentPage.Title + "Active" + ".png";
                    }

                }
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
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
