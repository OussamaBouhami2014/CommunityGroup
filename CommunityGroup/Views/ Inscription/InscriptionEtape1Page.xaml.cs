using System;
using System.Collections.Generic;
using FormsToolkit;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape1Page : ContentView
    {
        public InscriptionEtape1Page()
        {
            InitializeComponent();



            MessagingService.Current.Subscribe<int>(MessageKeys.Message_InscriptionChangePage, async (page, index) =>
            {
                try
                {
                    if (index == 1)
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

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (height > -1 && this.Content.TranslationY == 0)
            {
                //this.Content.TranslationY = this.Content.Height / 2;
            }
        }

    }
}
