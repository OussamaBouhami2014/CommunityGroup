using System;
using Xamarin.Forms;

namespace CommunityGroup.Views
{
    public abstract class BasePage : ContentPage
    {
        protected bool IsPageAppearing;

        public BasePage()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}