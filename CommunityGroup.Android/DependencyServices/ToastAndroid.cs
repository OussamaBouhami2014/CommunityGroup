[assembly: Xamarin.Forms.Dependency(typeof(CommunityGroup.Droid.DependencyServices.ToastAndroid))]
namespace CommunityGroup.Droid.DependencyServices
{
    public class ToastAndroid : CommunityGroup.Interfaces.IToast
    {
        public void LongAlert(string message)
        {
            var context = Plugin.CurrentActivity.CrossCurrentActivity.Current.AppContext;
            Android.Widget.Toast.MakeText(context, message, Android.Widget.ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            var context = Plugin.CurrentActivity.CrossCurrentActivity.Current.AppContext;
            Android.Widget.Toast.MakeText(context, message, Android.Widget.ToastLength.Short).Show();
        }
    }
}