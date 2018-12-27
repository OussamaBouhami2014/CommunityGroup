using System;
using System.Collections.Generic;
using FormsToolkit;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionPage : ContentPage
    {
        private InscriptionCompletePopup InscriptionCompletePopup;

        public CarouselViewPageModel currentPage;

        private int _position = 0;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        private int CarouselCount = 0;

        private bool isAnimationViewHeightChanged = false;

        public InscriptionPage()
        {
            InitializeComponent();

            var List = new ViewModels.CarouselViewPageViewModel().MyCarouselViewPageList;
            MyCarouselView.ItemsSource = List;
            carouselIndicators.ItemsSource = List;
            CarouselCount = List.Count;
            BindingContext = this;

            MessagingService.Current.Subscribe<string>(MessageKeys.Message_CarouselNextPage, (page, choix) =>
            {
                try
                {
                    Position++;
                }
                catch (Exception Ex)
                {
                    AppsHelper.Snack(Ex.Message);
                }
            });
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (!isAnimationViewHeightChanged)
            {
                //MessagingService.Current.SendMessage(MessageKeys.Message_InscriptionChangePage, (Position + 1));

                animationView.HeightRequest = Width / 3;
                isAnimationViewHeightChanged = true;
            }
        }


        private void Carousel_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Item = e.SelectedItem as CarouselViewPageModel;
            if (Item != null)
            {
                currentPage = Item;
            }
        }
        private async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        private async void MyCarouselView_PositionSelected(object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
        {
            MessagingService.Current.SendMessage(MessageKeys.Message_InscriptionChangePage,(Position+1));

            if (Position < (CarouselCount - 1))
            {
                if (txtSuivant.CBText != "SUIVANT")
                {
                    txtSuivant.CBText = "SUIVANT";
                    viewLogo.TranslateTo(0, 0, 1000, Easing.SpringOut);
                }
            }
            else if (Position == (CarouselCount - 1))
            {
                txtSuivant.CBText = "TERMINER";
                viewLogo.TranslateTo(0, -viewLogo.HeightRequest * 2, 1000,Easing.SpringIn);
            }

        }

        private async void Suivant_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Position < (CarouselCount - 1))
                {
                    Position++;
                }
                else
                {
                    AppsHelper.LoadingShow();
                    await System.Threading.Tasks.Task.Delay(3000);
                    AppsHelper.LoadingHide();

                    if (InscriptionCompletePopup == null)
                    {
                        InscriptionCompletePopup = new InscriptionCompletePopup();
                    }

                    await PopupNavigation.Instance.PushPopupAsyncSingle(InscriptionCompletePopup, true);

                }
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }
    }
}