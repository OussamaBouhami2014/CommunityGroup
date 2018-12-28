using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Accueil
{
    public partial class AccueilPage : ContentPage
    {
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