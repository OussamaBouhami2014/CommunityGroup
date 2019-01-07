using System;
using System.Collections.Generic;
using FormsToolkit;
using CommunityGroup.ViewModels;
using Xamarin.Forms;
using CommunityGroup.Models;
using CommunityGroup.Popups;
using System.Linq;
using Rg.Plugins.Popup.Services;

namespace CommunityGroup.Views.Actualite
{
    public partial class ActualitePage : BasePage
    {
        private CommentPopup CommentPopup;

        private ActualiteViewModel Vm;

        public ActualitePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new ActualiteViewModel();

            this.BindingContext = Vm;
            ActualiteListView.ItemsSource = Vm.ListActualite;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F5F5F5");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#F5F5F5");
            MessagingService.Current.SendMessage(MessageKeys.Message_ChangeStatutBarColor, "#696969");
        }

        private  void GestureSwitchOne(object sender, EventArgs e)
        {
            ActualiteListView.ItemsSource = null;
            ActualiteListView.ItemsSource = Vm.ListActualite;
        }

        private  void GestureSwitchTwo(object sender, EventArgs e)
        {
            ActualiteListView.ItemsSource = null;
            ActualiteListView.ItemsSource = Vm.ListActualite.Where(x=>x.CodeUnivers.Equals("OFFRE")).ToList();
        }

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

        private async void Comment_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var view = sender as View;
                var item = view?.BindingContext as DtoActualite;

                if (CommentPopup == null)
                {
                    CommentPopup = new CommentPopup(1, new List<CommentDTO>());
                    //CommentPopup.ParamsCommentAcquired += CommentPopup_ParamsCommentAcquired;
                }
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushPopupAsyncSingle(CommentPopup, true);
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void Star_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var view = sender as Controls.CustomButton;
                view.CBImage = view.CBImage.Contains("Active") ? "iconStar" : "iconStarActive";
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
                var item = view?.BindingContext as DtoActualite;
                await Application.Current.MainPage.Navigation.PushAsyncSingle(new Views.Actualite.ActualiteDetailPage(item));
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
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