using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CommunityGroup.Interfaces;
//using CommunityGroup.Models;
using CommunityGroup.Popups;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup
{
    public static class AppsHelper
    {

        public static bool AreInputsNullOrEmpty(string[] strings, List<byte[]> byteArrays = null)
        {
            foreach (var item in strings)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return false;
                }
            }

            if (byteArrays != null)
            {
                foreach (var byteArray in byteArrays)
                {
                    if (byteArray == null || byteArray?.Length == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        public static string TrimLowerText(string text)
        {
            return text.Trim().ToLower();
        }

        public static string TrimText(string text)
        {
            return text.Trim();
        }

        public static void FillUserNameField(Entry entry)
        {
            if (!string.IsNullOrEmpty(Helpers.Settings.userName))
                entry.Text = Helpers.Settings.userName;
        }

        public static bool IsTokenStillValid(string TokenValidUntil)
        {
            DateTime ValidUntil;
            var parsedToken = DateTime.TryParse(TokenValidUntil, out ValidUntil);

            if (parsedToken && ValidUntil.Subtract(DateTime.Now).Hours > 0)
                return true;
            else
                return false;
        }

        public static void Snack(string message, int durationInMs = 3000)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                DependencyService.Get<IToast>().ShortAlert(message);
            }
            else
            {
                UserDialogs.Instance.Toast(new ToastConfig(message)
                {
                    Duration = TimeSpan.FromMilliseconds(durationInMs),
                    //BackgroundColor = System.Drawing.Color.FromArgb(252, 179, 42)
                });
            }
        }

        public static void ShortAlert(string message)
        {
            DependencyService.Get<IToast>().ShortAlert(message);
        }

        public static void LongAlert(string message)
        {
            DependencyService.Get<IToast>().LongAlert(message);
        }

        public static async Task Alert(string message, string title = "info!", string okText = "OK", Action action = null, bool useFormsAlert = true)
        {
            if (useFormsAlert)
            {
                var currentPage = Xamarin.Forms.Application.Current?.MainPage;
                if (currentPage != null)
                {
                    await currentPage.DisplayAlert(title, message, okText);
                }

            }
            else
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig()
                {
                    Title = title,
                    Message = message,
                    OkText = okText,
                    OnAction = action,
                });
            }
        }

        public static IDisposable Confirm(string message, string title = "info!", string okText = "OK", string cancelText = "Cancel", Action<bool> action = null)
        {
            return UserDialogs.Instance.Confirm(new ConfirmConfig()
            {
                Title = title,
                Message = message,
                OkText = okText,
                CancelText = cancelText,
                OnAction = action,
            });

        }

        public static void DialogLoadingShow(string message = "")
        {
            UserDialogs.Instance.ShowLoading(message, MaskType.Gradient);
        }

        public static void DialogLoadingHide()
        {
            UserDialogs.Instance.HideLoading();
        }

        public async static void LoadingShow()
        {
            try
            {
                //await PopupNavigation.Instance.PushPopupAsyncSingle(App.LoadingPopup);
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public async static void LoadingHide()
        {
            try
            {
                foreach (var item in PopupNavigation.Instance.PopupStack)
                {
                    //if (item.GetType() == typeof(LoadingPopup) && PopupNavigation.Instance.PopupStack.Count > 0)
                    //{
                    //    await Task.Delay(250);
                    //    await Task.WhenAll(PopupNavigation.Instance.RemovePageAsync(item));
                    //}
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public static View DisableView(View view)
        {
            view.IsEnabled = false;
            return view;
        }

        public static View EffectClick(View view)
        {
            if (!view.AnimationIsRunning("EffectClickAnimation"))
            {
                view.IsEnabled = false;

                /*Setups*/
                Animation EffectClickAnimations = new Animation();
                //SetupPage
                EffectClickAnimations.Add(0.0, 0.5, new Animation(f => view.Scale = f, 1, 0.95, Easing.CubicOut));
                EffectClickAnimations.Add(0.5, 1, new Animation(f => view.Scale = f, 0.95, 1, Easing.CubicIn));

                EffectClickAnimations.Commit(
                  owner: view,
                  name: "EffectClickAnimation",
                  length: 100,

              finished: (x, y) =>
              {
                  view.IsEnabled = true;
              });

            }
            return view;
        }

        public static View EnableView(View view)
        {
            view.IsEnabled = true;
            return view;
        }

        public static List<View> DisableViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsEnabled = false;
            });
            return views;
        }

        public static List<View> EnableViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsEnabled = true;
            });
            return views;
        }

        public static List<View> DivisibleViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsVisible = false;
            });
            return views;
        }

        public static List<View> VisibleViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsVisible = true;
            });
            return views;
        }

        //public static async Task<Uri> DownloadFileAsync(string fileUrl, string token, string fileName, string fileExtension = ".pdf")
        //{
        //    var progress = AppsHelper.ProgressDonut("Chargement...");

        //    if (!AppsHelper.IsConnected())
        //    {
        //        AppsHelper.Snack("Vous n'êtes pas connectés");
        //        return null;
        //    }

        //    using (var client = new WebClient())
        //    {
        //        client.Headers.Clear();
        //        var authorization = "Bearer " + token;
        //        if (!string.IsNullOrWhiteSpace(authorization))
        //            client.Headers.Add(HttpRequestHeader.Authorization, authorization);
        //        client.Headers.Add("From", AppUrls.AppHash);


        //        progress.Show();

        //        client.DownloadProgressChanged += async (ss, ee) =>
        //        {
        //            progress.PercentComplete = ee.ProgressPercentage;

        //            if (ee.ProgressPercentage == 100)
        //            {
        //                progress.Hide();
        //                progress.Dispose();
        //            }
        //        };

        //        var documentBytes = await client.DownloadDataTaskAsync(fileUrl);

        //        var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), (fileName + fileExtension));

        //        using (Stream stream = new MemoryStream(documentBytes))
        //        {
        //            using (var file = File.Create(appdataPath))
        //            {
        //                await stream.CopyToAsync(file);
        //            }
        //        }

        //        return new Uri(appdataPath);
        //    }
        //}

        //public static async Task<ImageSource> GetImageAsync(string imageUrl, string token)
        //{
        //    try
        //    {
        //        using (var client = new System.Net.Http.HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            var authorization = "Bearer " + Helpers.Settings.auth;
        //            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("From", AppUrls.AppHash);


        //            var byteArray = await client.GetByteArrayAsync(imageUrl);
        //            Stream stream = new MemoryStream(byteArray);

        //            return ImageSource.FromStream(() => { return stream; });
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        return default(ImageSource);
        //    }
        //}

        public static IProgressDialog ProgressDonut(string title = "info!", string cancelText = "Cancel", Action cancelAction = null)
        {
            var config = new ProgressDialogConfig()
            {
                Title = title,
                CancelText = cancelText,
                MaskType = MaskType.Gradient,
                IsDeterministic = true,
                AutoShow = false,
                OnCancel = cancelAction
            };
            var progress = Acr.UserDialogs.UserDialogs.Instance.Progress(config);

            return progress;
        }
    }
}