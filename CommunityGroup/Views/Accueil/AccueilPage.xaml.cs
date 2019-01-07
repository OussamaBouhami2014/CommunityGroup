using System;
using System.Collections.Generic;
using System.Linq;
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

        private StatusViewModel Vm;

        Dictionary<string, bool> Topics = new Dictionary<string, bool>()
        {
            {"Innovation",false},
            {"Digital",false},
            {"Agriculture",false},
            {"Mining",false},
            {"International",false},
            {"Eco-systeme",false},
            {"Autre",false},
        };

        public AccueilPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new StatusViewModel();
            this.BindingContext = Vm;

            //AccueilScrollView.Scrolled += AccueilScrollViewOnScrolled;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (height > 0)
            {
                //AccueilScrollView.Margin = new Thickness(0,viewTopics.Height,0,0) ;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        double OldY = 0;
        int i = 0;
        private void AccueilScrollViewOnScrolled(object sender, ScrolledEventArgs e)
        {
            //if (e.ScrollY >= 0)
            //{

            //    if (viewTopics.TranslationY >= -viewTopics.Height)
            //    {
            //        viewTopics.TranslationY = -e.ScrollY;
            //        viewMur.TranslationY = -e.ScrollY;
            //        i = 0;
            //    }
            //    else if (e.ScrollY < OldY)
            //    {

            //        var newPosition = viewTopics.TranslationY - 10;

            //        i++;
            //        //viewTopics.TranslationY = (viewTopics.TranslationY + (e.ScrollY - OldY)) - viewTopics.Height;
            //        //viewMur.TranslationY =  (viewTopics.TranslationY + (e.ScrollY - OldY)) - viewTopics.Height;

            //        viewTopics.TranslationY = i;
            //        viewMur.TranslationY = i;
            //    }

            //    OldY = e.ScrollY;
            //}
         }

        private void TopicOne_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicOne.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicOne.BackgroundColor =  App.TopicOneColor;
                    Topics["Innovation"] = true;
                }
                else
                {
                    viewTopicOne.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["Innovation"] = false;
                }

                Vm.Filtrer.Execute(Topics);
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicTwo_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicTwo.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicTwo.BackgroundColor = App.TopicTwoColor;
                    Topics["Digital"] = true;
                }
                else
                {
                    viewTopicTwo.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["Digital"] = false;
                }

                Vm.Filtrer.Execute(Topics);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicThree_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicThree.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicThree.BackgroundColor = App.TopicThreeColor;
                    Topics["Agriculture"] = true;
                }
                else
                {
                    viewTopicThree.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["Agriculture"] = false;
                }

                Vm.Filtrer.Execute(Topics);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicFour_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicFour.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicFour.BackgroundColor = App.TopicFourColor;
                    Topics["Mining"] = true;
                }
                else
                {
                    viewTopicFour.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["Mining"] = false;
                }

                Vm.Filtrer.Execute(Topics);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicFive_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicFive.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicFive.BackgroundColor = App.TopicFiveColor;
                    Topics["International"] = true;
                }
                else
                {
                    viewTopicFive.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["International"] = false;
                }

                Vm.Filtrer.Execute(Topics);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicSix_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (viewTopicSix.BackgroundColor == App.TopicLightBackgroundColor)
                {
                    viewTopicSix.BackgroundColor = App.TopicSixColor;
                    Topics["Eco-systeme"] = true;
                }
                else
                {
                    viewTopicSix.BackgroundColor = App.TopicLightBackgroundColor;
                    Topics["Eco-systeme"] = false;
                }

                Vm.Filtrer.Execute(Topics);

            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void TopicMore_Clicked(object sender, System.EventArgs e)
        {
            try
            {
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
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
        private void GoTop_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var firstItem = StatutsListView.ItemsSource.Cast<object>().FirstOrDefault();
                StatutsListView.ScrollTo(firstItem, ScrollToPosition.End, true);
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
            try
            {
                var Item = e.SelectedItem as CarouselViewPageModel;
                if (Item != null)
                {
                    //currentPage = Item;
                }
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private void CarouselEvenment_PositionSelected(object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private async void MurListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //var item = ((ListView)sender).SelectedItem as DtoEvent;
            //if (item == null)
                //return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}