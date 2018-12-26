using Android.Content;
using Android.Graphics.Drawables;
using CommunityGroup.Controls;
using CommunityGroup.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CommunityGroup.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;


            if (((CustomEntry)this.Element).IsCustom)
            {
                UpdateControl();
            }
            else
            {
                Control.Background = this.Resources.GetDrawable(Resource.Layout.EditTextStyle);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (Control == null || this.Element == null) return;

            if (e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateControl();
        }

        private void UpdateControl()
        {

            var element = (CustomEntry)Element;

            if (element.IsCustom)
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetShape(ShapeType.Rectangle);
                shape.SetCornerRadius(float.Parse(element.CornerRaduis));
                shape.SetColor(element.BackgroundColor.ToAndroid());
                shape.SetStroke(3, element.BorderColor.ToAndroid());
                this.Control.Background = shape;
                var padding = element.Padding;
                this.Control.SetPadding(padding.Item1, padding.Item1, padding.Item1, padding.Item4);
                this.Control.Gravity = (Android.Views.GravityFlags)element.HorizontalTextAlignment;
            }
            else
            {
                Control.Background = this.Resources.GetDrawable(Resource.Layout.EditTextStyle);
            }

            if (element.IsBorderErrorVisible)
                this.Control.Error = element.ErrorText;
        }
    }
}