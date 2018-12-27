using System;
using System.Collections.Generic;
using FormsToolkit;
using CommunityGroup.ViewModels;
using Xamarin.Forms;
using CommunityGroup.Models;

namespace CommunityGroup.Views.Actualite
{
    public partial class ActualitePage : BasePage
    {
       private void Like_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var view = sender as Controls.CustomButton;
                view.CBImage = view.CBImage.Contains("Active") ? "iconLike" : "iconLikeActive";
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var view = sender as View;
                var item  = view?.BindingContext as DtoActualite;
                await Application.Current.MainPage.Navigation.PushAsyncSingle(new Views.Actualite.ActualiteDetailPage(item));
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void Comment_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                //var view = sender as Image;
                //view.Source = (view.Source as FileImageSource).File.Contains("Active") ? "iconLike" : "iconLikeActive";
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private ActualiteViewModel Vm;

        public ActualitePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new ActualiteViewModel();
            this.BindingContext = Vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F5F5F5");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#F5F5F5");
            MessagingService.Current.SendMessage(MessageKeys.Message_ChangeStatutBarColor, "#696969");
        }

        private void ActualiteTachesListView(object sender, System.EventArgs e)
        {
            ActualiteListView.IsRefreshing = false;
        }

        private async void ActualiteListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DtoActualite;
            if (item == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsyncSingle(new Views.Actualite.ActualiteDetailPage(item));

            ((ListView)sender).SelectedItem = null;
        }
    
    }
}