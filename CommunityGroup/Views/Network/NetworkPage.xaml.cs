using System;
using System.Collections.Generic;
using CommunityGroup.Models;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Network
{
    public partial class NetworkPage : ContentPage
    {
        private NetworkViewModel Vm;

        public NetworkPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new NetworkViewModel();
            this.BindingContext = Vm;

        }

        private void NetworksListView_Refreshing(object sender, System.EventArgs e)
        {
            NetworksListView.IsRefreshing = false;
        }

        private async void NetworksListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = ((ListView)sender).SelectedItem as DtoNetwork;
                if (item == null)
                    return;

                //await Application.Current.MainPage.Navigation.PushAsyncSingle(new Chat.ChatPage(item));

                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
           
        }

    }
}