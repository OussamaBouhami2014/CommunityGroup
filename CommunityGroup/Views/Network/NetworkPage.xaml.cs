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

        private void MessagesListView_Refreshing(object sender, System.EventArgs e)
        {
            MessagesListView.IsRefreshing = false;
        }

        private async void MessagesListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DtoMessage;
            if (item == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsyncSingle(new Chat.ChatPage(item));

            ((ListView)sender).SelectedItem = null;
        }


    }
}