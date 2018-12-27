using System;
using System.Collections.Generic;
using CommunityGroup.Models;
using Xamarin.Forms;
using System.Text;
//using System.Drawing;
//using Android.Graphics;
using System.Threading.Tasks;
using FormsToolkit;
using CommunityGroup.ViewModels;

namespace CommunityGroup.Views.Actualite
{
    public partial class ActualiteDetailPage : BasePage
    {
        #region Paralax Field
        private const double TextSpeed = 0.1;
        private const double ShadowSpeed = 0.1;
        private const double ActualiteImageSpeed = 0.4;

        private double _parallaxLabelStartY;
        private double _parallaxShadowStartY;
        private double _parallaxActualiteStartY;

        #endregion Paralax Field
        DtoActualite DetailActualite;
        public ActualiteDetailPage(DtoActualite _detailActualite)
        {
            InitializeComponent();
            MessagingService.Current.SendMessage(MessageKeys.Message_ChangeStatutBarColor, App.PrimaryColor);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(App.PrimaryColor);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;

            DetailActualite = _detailActualite;
            this.Title = DetailActualite.Title;

            this.BindingContext = DetailActualite;

            ParallaxScrollView.Scrolled += ParallaxScrollViewOnScrolled;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //var img = await GetImageFromUriAsync(DetailActualite.ImageActualite);
            //var color = DependencyService.Get<IAverageColor>().GetAverageColor(img);
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = color;
            //MessagingService.Current.SendMessage(MessageKeys.ChangeStatutBarColor, NavColor);
        }

        #region Paralax 
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Init start position for parallax elements
            ActualiteImage.WidthRequest = width;
            BackgroundShadow.WidthRequest = width;

            ParallaxLabel.TranslationY =
                             _parallaxLabelStartY = ParalaxContainer.Height -
                             (ParallaxLabel.Height / 2) - 40;
        }
        private void ParallaxScrollViewOnScrolled(object sender, ScrolledEventArgs e)
        {
            ParalaxTextAnimation(e.ScrollY);
            ParalaxImageAnimation(e.ScrollY);
        }
        private void ParalaxImageAnimation(double scrollY)
        {
            ParalaxAnimation(ImageContainer, scrollY, _parallaxLabelStartY, 0,
                             ParalaxContainer.HeightRequest - ParallaxLabel.Height, TextSpeed, true);
        }
        private void ParalaxTextAnimation(double scrollY)
        {
            ParalaxAnimation(ParallaxLabel, scrollY, _parallaxLabelStartY, 0,
                ParalaxContainer.HeightRequest - ParallaxLabel.Height, TextSpeed);
        }
        double newScale = 1;
        double newOpacity = 0;
        private void ParalaxAnimation(View control,
                                      double scrollY,
                                      double startPosition,
                                      double minPosition,
                                      double maxPosition,
                                      double speed, bool Agm = false)
        {
            var newPosition = startPosition - scrollY * speed;
            if (scrollY >= 0)
            {
                if (Agm)
                    newScale = 1 + (scrollY / 1000);
                else
                    newScale = 1 - (scrollY / 1000);

                newOpacity = 0.2 + ((scrollY / _parallaxLabelStartY) / 2.5);
            }
            else
            {
                newScale = 1;
                newOpacity = 0.2;
            }

            if (newPosition > minPosition && newPosition < maxPosition)
            {
                if (!Agm)
                    control.TranslationY = newPosition;

                control.Scale = newScale;
                BackgroundShadow.Opacity = newOpacity;

            }

            #endregion Paralax
        }
        public async Task<byte[]> GetImageFromUriAsync(string uri)
        {
            var webClient = new System.Net.WebClient();
            byte[] imageBytes = await webClient.DownloadDataTaskAsync(new Uri(uri));

            return imageBytes;
        }
    }
}