using Android.Content;
using CommunityGroup.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using CommunityGroup.Controls;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]
namespace CommunityGroup.Droid.Renderers
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        CustomTimePicker element;
        public CustomTimePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            element = (CustomTimePicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.RightImage))
            {
                Control.Background = this.Resources.GetDrawable(Resource.Layout.PickerStyle);

                //Control.Background = AddPickerStyles(element.RightImage);

            }

        }
        public LayerDrawable AddPickerStyles(string imagePath)
        {
            ShapeDrawable border = new ShapeDrawable();
            border.Paint.Color = Android.Graphics.Color.Gray;
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);

            Drawable[] layers = { border, GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 70, 70, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }
    }
}