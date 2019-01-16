using System;
using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;

namespace CommunityGroup.Models
{
    public partial class DtoEvent
    {
        [PrimaryKey,AutoIncrement]
        public int EventId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }

        [MaxLength(25)]
        public string Details { get; set; }

        public string Introduction { get; set; }
        public string Image { get; set; }
        public string CodeUnivers { get; set; }
        public DateTime DateEvent { get; set; }
        public DateTime DatePublication { get; set; }
        public bool IsVue { get; set; }
        public string ColorUnivers { get; set; }
            public int NbrLike { get; set; }
            public int NbrComment { get; set; }

         private string imageEvent = "loading_placeholder.png";
            public string ImageEvent { get { return imageEvent; } set { imageEvent = value; } }

        public DtoEvent()
        {

        }

        public static int InsertEvent(DtoEvent _event)
        {
            using (SQLite.SQLiteConnection cnx = new SQLiteConnection(App.DBPath))
            {
                cnx.CreateTable<DtoEvent>();
                return cnx.Insert(_event);
            }
        }

        public static List<DtoEvent> GetEvents()
        {
            using (SQLite.SQLiteConnection cnx = new SQLiteConnection(App.DBPath))
            {
                cnx.CreateTable<DtoEvent>();
                return cnx.Table<DtoEvent>().ToList();
            }
        }
    }

    //public partial class DtoEvent : BindableObject
    //{
    //    public string ColorUnivers { get; set; }
    //    public int NbrLike { get; set; }
    //    public int NbrComment { get; set; }

    //    private string imageEvent = "loading_placeholder.png";
    //    public string ImageEvent { get { return imageEvent; } set { imageEvent = value; OnPropertyChanged(); } }

    //    private Color _actualiteRowColor = Color.FromHex(App.BlueColor);
    //    public Color EventRowColor
    //    {
    //        get
    //        {
    //            var cl = _actualiteRowColor;
    //            return Color.FromRgba(cl.R, cl.G, cl.B, 0.5);
    //        }
    //        set { _actualiteRowColor = value; }
    //    }


    //}
}