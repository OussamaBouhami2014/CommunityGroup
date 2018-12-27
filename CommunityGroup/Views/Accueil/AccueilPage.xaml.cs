using System;
using System.Collections.Generic;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Accueil
{
    public partial class AccueilPage : ContentPage
    {
        private ActualiteViewModel Vm;

        public AccueilPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new ActualiteViewModel();
            this.BindingContext = Vm;

            carouselEvenment.ItemsSource = Vm.ListActualite;
            carouselIndicators.ItemsSource = Vm.ListActualite;

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