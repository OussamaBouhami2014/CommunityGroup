using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CommunityGroup.Views.Chat
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }
        #region Entry Message text changed
        private void entryMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(entryMessage.Text))
            //    btnSend.IsVisible = true;
            //else
                //btnSend.IsVisible = false;
        }
        #endregion


        private void Join_Clicked(object sender, EventArgs e)
        {

        }

        private void Camera_Clicked(object sender, EventArgs e)
        {

        }

        private async void Comment_Completed(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

            #region Button envoyer message
            private void btnSend_Clicked(object sender, EventArgs e)
            {
                //if (!string.IsNullOrEmpty(entryMessage.Text))
                //{
                //    SendMessage(entryMessage.Text);
                //}
            }
        #endregion

        private async void Confirmer_Clicked(object sender, System.EventArgs e)
        {
            //if (CommentsArg != null)
            //{
            //    ParamsCommentAcquired?.Invoke(sender, CommentsArg);

            //    await PopupNavigation.Instance.PopAsync();
            //}

        }
    }
}