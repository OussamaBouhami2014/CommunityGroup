using System;
using CommunityGroup.Controls;
using CommunityGroup.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(EntryMoveNextEffect), nameof(EntryMoveNextEffect))]

namespace CommunityGroup.Droid.Effects
{
    public class EntryMoveNextEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // Check if the attached element is of the expected type and has the NextEntry
            // property set. if so, configure the keyboard to indicate there is another entry
            // in the form and the dismiss action to focus on the next entry
            if (base.Element is CustomEntry xfControl && xfControl.NextView != null)
            {
                var entry = (Android.Widget.EditText)Control;

                entry.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
                entry.EditorAction += (sender, args) =>
                {
                    xfControl.OnNext();
                };
            }
        }

        protected override void OnDetached()
        {
            // Intentionally empty
        }
    }
}