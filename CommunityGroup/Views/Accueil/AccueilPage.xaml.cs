using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityGroup.Models;
using CommunityGroup.Popups;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Accueil
{
    public partial class AccueilPage : ContentPage
    {
        private CommentPopup CommentPopup;

        private EventViewModel Vm;

        public AccueilPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new EventViewModel();
            this.BindingContext = Vm;

            carouselEvenment.ItemsSource = Vm.ListEvent;
            carouselIndicators.ItemsSource = Vm.ListEvent;


            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    while (true)
                    {
                        await Task.Delay(2000);

                        Vm.Position++;
                        if (Vm.Position == (Vm.ListEvent.Count))
                        {
                            Vm.Position = 0;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    AppsHelper.Snack(Ex.Message);
                }

            });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void More_Clicked(object sender, System.EventArgs e)
        {
            try
            {
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

        private async void Commenter_Clicked(object sender, System.EventArgs e)
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
      
        private async void Share_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var view = sender as View;
                var item = view?.BindingContext as DtoActualite;

                //if (CommentPopup == null)
                //{
                //    CommentPopup = new CommentPopup(item.ActualiteId, new List<CommentDTO>());
                //    //CommentPopup.ParamsCommentAcquired += CommentPopup_ParamsCommentAcquired;
                //}
                //await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushPopupAsyncSingle(CommentPopup, true);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void Carousel_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Item = e.SelectedItem as CarouselViewPageModel;
            if (Item != null)
            {
                //currentPage = Item;
            }
        }

        private void CarouselEvenment_PositionSelected(object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
        {
        }
    }
}