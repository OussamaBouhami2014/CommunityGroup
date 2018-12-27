using System;
using FormsToolkit;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape3Page : ContentView
    {
        private AjouterDiplomePopup AjouterDiplomePopup;

        public InscriptionEtape3Page()
        {
            InitializeComponent();
            PickerNiveauEtude.SelectedIndex = 0;
            PickerDiplome.SelectedIndex = 0;

          
            MessagingService.Current.Subscribe<int>(MessageKeys.Message_InscriptionChangePage, async (page, index) =>
            {
                try
                {
                    if (index == 3)
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
        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);

        //    if (height > -1 && this.Content.TranslationY == 0)
        //    {
        //        this.Content.TranslationY = this.Content.Height /2;
        //    }
        //}

        private async void AddDiplome_Clicked(object sender, EventArgs e)
        {
            if (AjouterDiplomePopup == null)
            {
                AjouterDiplomePopup = new AjouterDiplomePopup();
            }

            await PopupNavigation.Instance.PushPopupAsyncSingle(AjouterDiplomePopup, true);
        }

        private void Inscription_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tapped.TappedPagePrincipal());
        }

        private async void Galerie_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var action = await Application.Current.MainPage.DisplayActionSheet("Prendre Photo :", "Annuler", null, "Camera", "Galerie");

                if (action.Equals("Camera"))
                {

                        await Plugin.Media.CrossMedia.Current.Initialize();

                        if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
                        {
                            AppsHelper.Snack("Caméra Introuvable !", 3000);
                            return;
                        }

                        var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            AllowCropping = true,
                            RotateImage = true,
                            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                        });

                        if (photo == null) return;

                        imgPhotoProfil.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                        viewPhotoProfil.IsVisible = true;

                    }
                else
                {
               
                await Plugin.Media.CrossMedia.Current.Initialize();
                if (!Plugin.Media.CrossMedia.Current.IsPickPhotoSupported)
                {
                    AppsHelper.Snack("Autorisation non accordée aux photos", 3000);
                    return;
                }
                var photo = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (photo == null) return;
                //else
                    //ActionImage = AppHelpers.ImageToByteArray(photo.GetStream());

                imgPhotoProfil.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

                viewPhotoProfil.IsVisible = true;
                }
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }


        private async void Camera_Clicked(object sender, System.EventArgs e)
        {
            try
            {
              await Plugin.Media.CrossMedia.Current.Initialize();

              if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
              {
                  AppsHelper.Snack("Caméra Introuvable !", 3000);
                  return;
              }

              var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
              {
                  SaveToAlbum = true,
                  AllowCropping = true,
                  RotateImage = true,
                  PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
              });

              if (photo == null) return;

              imgPhotoProfil.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
              viewPhotoProfil.IsVisible = true;

            }
            catch (Exception Ex)
            {
              AppsHelper.Snack(Ex.Message);
            }
        }
    }
}