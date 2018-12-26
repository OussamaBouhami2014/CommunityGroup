using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace CommunityGroup
{
    public static class NavigationExtensions
    {
        public static async Task PushPopupAsyncSingle(this IPopupNavigation nav, PopupPage page, bool animated = true)
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0 || Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Last().GetType() != page.GetType())
                await nav.PushAsync(page, animated);
        }

        public static async Task PushAsyncSingle(this INavigation nav, Page page, bool animated = true)
        {
            if (nav.NavigationStack.Count == 0 || nav.NavigationStack.Last().GetType() != page.GetType())
                await nav.PushAsync(page, animated);
        }

        public static async Task PushModalAsyncSingle(this INavigation nav, Page page, bool animated = true)
        {
            if (nav.ModalStack.Count == 0 || nav.ModalStack.Last().GetType() != page.GetType())
                await nav.PushModalAsync(page, animated);
        }
    }
}