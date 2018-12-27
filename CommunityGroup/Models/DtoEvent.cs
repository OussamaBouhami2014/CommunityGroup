using System;
using Xamarin.Forms;

namespace CommunityGroup.Models
{
    public partial class DtoEvent
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Details { get; set; }
        public string Introduction { get; set; }
        public string Image { get; set; }
        public string CodeUnivers { get; set; }
        public DateTime DateEvent { get; set; }
        public DateTime DatePublication { get; set; }
        public bool IsVue { get; set; }
    }

    public partial class DtoEvent : BindableObject
    {
        public string ColorUnivers { get; set; }
        public int NbrLike { get; set; }
        public int NbrComment { get; set; }

        private string imageEvent = "loading_placeholder.png";
        public string ImageEvent { get { return imageEvent; } set { imageEvent = value; OnPropertyChanged(); } }

        private Color _actualiteRowColor = Color.FromHex(App.BlueColor);
        public Color EventRowColor
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
