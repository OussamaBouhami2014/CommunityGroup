using System;
using System.Collections.Generic;
using FormsToolkit;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape2Page : ContentView
    {
        public InscriptionEtape2Page()
        {
            InitializeComponent();

           

            MessagingService.Current.Subscribe<int>(MessageKeys.Message_InscriptionChangePage, async (page, index) =>
            {
                try
                {
                    if (index == 2)
                    {
                        this.Content.FadeTo(1, 1000);
                        await this.Content.TranslateTo(0, 0, 1000);
                    }
                    else
                    {
                        this.Content.Opacity = 0;
                        this.Content.TranslationY = this.Content.Height / 3;
                    }
                }
                catch (Exception Ex)
                {
                    AppsHelper.Snack(Ex.Message);
                }
            });

        }

        private void Inscription_Clicked(object sender, System.EventArgs e)
        {
            MessagingService.Current.SendMessage(MessageKeys.Message_CarouselNextPage,string.Empty);
        }
    }
}