using System;
using CommunityGroup.Views.Inscription;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CarouselViewInscriptionTemplateSelector : DataTemplateSelector
    {
        private DataTemplate p1 = new DataTemplate(typeof(InscriptionEtape1Page));
        private DataTemplate p2 = new DataTemplate(typeof(InscriptionEtape2Page));
        private DataTemplate p3 = new DataTemplate(typeof(InscriptionEtape3Page));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var swipeType = item as CarouselViewPageModel;

            switch (swipeType.Type)
            {
                case 1: return p1;
                case 2: return p2;
                case 3: return p3;
                default: return null;
            }
        }

    }
}