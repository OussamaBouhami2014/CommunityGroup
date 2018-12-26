using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionPage : ContentPage
    {

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

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (!isAnimationViewHeightChanged)
            {
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

        private void MyCarouselView_PositionSelected(object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
        {

            if (Position < (CarouselCount - 1))
            {
                if (txtSuivant.CBText != "SUIVANT")
                {
                    txtSuivant.CBText = "SUIVANT";
                }
            }
            else if (Position == (CarouselCount - 1))
            {
                txtSuivant.CBText = "TERMINER";
            }

        }
        private void Suivant_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Position < (CarouselCount - 1))
                {
                    Position++;
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new Tapped.TappedPagePrincipal());

                }
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }

        }

    }
}