using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityGroup.Helpers;
using CommunityGroup.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;


namespace CommunityGroup.Popups
{
    public partial class CommentPopup : PopupPage
    {
        public event EventHandler<List<CommentDTO>> ParamsCommentAcquired;
        private List<CommentDTO> CommentsArg;

        private ObservableCollection<CommentDTO> commentsList = new ObservableCollection<CommentDTO>();
        public ObservableCollection<CommentDTO> CommentsList { get { return commentsList; } set { commentsList = value; OnPropertyChanged(); } }

        private long SourceId;

        public CommentPopup(long sourceId, List<CommentDTO> comments)
        {
            InitializeComponent();
            SourceId = sourceId;
            if (comments != null)
            {
                CommentsList = new ObservableCollection<CommentDTO>(comments);
            }

            this.BindingContext = this;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }


        private async void Close_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Confirmer_Clicked(object sender, System.EventArgs e)
        {
            if (CommentsArg != null)
            {
                ParamsCommentAcquired?.Invoke(sender, CommentsArg);

                await PopupNavigation.Instance.PopAsync();
            }

        }

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
                //AppHelpers.LoadingShow();

                var postParams = new CommentDTO()
                {
                    Text = entryComment.Text,
                    SourceId = SourceId,
                    CreatedBy = Settings.userName,
                };

                    CommentsList.Add(postParams);

                    listViewCommentList.ScrollTo(postParams, ScrollToPosition.End, false);
             
                entryComment.Text = string.Empty;

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
            finally
            {
                //AppHelpers.LoadingHide();
            }

        }
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return true;
        }
    }
}