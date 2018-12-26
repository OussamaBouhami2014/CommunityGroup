using System;
using Xamarin.Forms;
namespace CommunityGroup.Models
{
    public partial class DtoActualite
    {
        public int ActualiteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Details { get; set; }
        public string Introduction { get; set; }
        public string Image { get; set; }
        public string CodeUnivers { get; set; }
        public DateTime DateActualite { get; set; }
        public DateTime DatePublication { get; set; }
        public bool IsVue { get; set; }
    }

    public partial class DtoActualite : BindableObject
    {
        public string ColorUnivers { get; set; }

        private string imageActualite = "loading_placeholder.png";
        public string ImageActualite { get { return imageActualite; } set { imageActualite = value; OnPropertyChanged(); } }

        private Color _actualiteRowColor = Color.FromHex(App.BlueColor);
        public Color ActualiteRowColor
        {
            get
            {
                var cl = _actualiteRowColor;
                return Color.FromRgba(cl.R, cl.G, cl.B, 0.5);
            }
            set { _actualiteRowColor = value; }
        }
    }
}