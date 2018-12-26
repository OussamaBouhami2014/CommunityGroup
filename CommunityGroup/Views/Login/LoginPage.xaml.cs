using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityGroup.Helpers;
using FormsToolkit;
using Xamarin.Forms;

namespace CommunityGroup.Views.Login
{
    public partial class LoginPage : BasePage
    {
        private bool isPageAnimationFinished;

        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            this.SizeChanged += OnPageSizeChanged;
        }
        #region OnPageSizeChanged
        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            //if (!isPageAnimationFinished)
            //{
            //    isPageAnimationFinished = true;
            //    StartAnimation();
            //}
        }

        private void StartAnimation()
        {
            var newHeight = this.Height;
            var newWidth = this.Width;

            //viewMain.Opacity = 1;

            if (newHeight > 0 && newWidth > 0)
            {
                if (this.AnimationIsRunning("LoginEnterAnimation") || this.AnimationIsRunning("LoginBackAnimation"))
                    return;

                if (!App.isLoginAnimationDone)
                {
                    App.isLoginAnimationDone = true;

                    #region Parallel Animations

                    /*Setups*/
                    Animation ParallelAnimations = new Animation();

                    //SetupLogo
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewLogo.TranslationY = f, viewLogo.TranslationY, (newHeight / 2) - (viewLogo.Height / 2)));
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewLogo.Opacity = f, 1, 0));
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewLogo.Scale = f, 1, 0));

                    //Setup background splash
                    //ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewBackground.Scale = f, 1.0, 1.1));

                    //Setup Input Controls
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewInputs.Opacity = f, 1, 0));

                    //Animate Logo
                    ParallelAnimations.Add(0.02, 0.1, new Animation(f => this.viewLogo.Opacity = f, 0, 1));
                    ParallelAnimations.Add(0.02, 0.3, new Animation(f => this.viewLogo.Scale = f, 1, 1.2, Easing.CubicIn));
                    ParallelAnimations.Add(0.3, 0.6, new Animation(f => this.viewLogo.Scale = f, 1.2, 1, Easing.BounceOut));

                    ParallelAnimations.Add(0.6, 0.9, new Animation(f => this.viewLogo.TranslationY = f, (newHeight / 2) - (viewLogo.Height / 2) - (Device.RuntimePlatform == Device.Android ? 0 : 20), viewLogo.TranslationY, Easing.SpringIn));

                    //animate splash
                    //ParallelAnimations.Add(0.02, 1.0, new Animation(f => this.viewBackground.Scale = f, 1.1, 1.0, Easing.SinOut, null));

                    //animate input
                    ParallelAnimations.Add(0.9, 1, new Animation(f => this.viewInputs.Opacity = f, 0, 1));

                    ParallelAnimations.Commit(
                        owner: this,
                        name: "LoginEnterAnimation",
                           finished: (x, y) =>
                           {
                               MessagingService.Current.SendMessage(MessageKeys.Message_ExitFullScreen);
                               viewPage.TranslationY = Device.RuntimePlatform == Device.Android ? -24 : 0; // Android status bar height: 24dp 
                           },
                        length: 5000
                    );

                    #endregion
                }
                else
                {
                    if (this.AnimationIsRunning("LoginBackAnimation"))
                        return;

                    MessagingService.Current.SendMessage(MessageKeys.Message_ExitFullScreen);
                    /*Setups*/
                    Animation ParallelAnimations = new Animation();

                    //SetupPage
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewMain.TranslationX = f, viewMain.TranslationX, newWidth));
                    ParallelAnimations.Add(0.0, 0.01, new Animation(f => this.viewMain.Scale = f, 1, 0.5));


                    //animate page
                    ParallelAnimations.Add(0.02, 0.5, new Animation(f => this.viewMain.Opacity = f, 0, 1));
                    ParallelAnimations.Add(0.02, 1, new Animation(f => this.viewMain.Scale = f, 0.5, 1));
                    ParallelAnimations.Add(0.02, 1, new Animation(f => this.viewMain.TranslationX = f, newWidth / 2, viewMain.TranslationX, Easing.SinInOut));

                    ParallelAnimations.Commit(
                      owner: this,
                      name: "LoginBackAnimation",
                      length: 500
                  );

                }
            }
        }
        #endregion


        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Send<LoginPage, string>(this, MessageKeys.ChangeStatutBarColor, App.LightBackgroundColor);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await OnLogin();
        }

        private async Task OnLogin()
        {
            #region Get User Input & Validate It

            //var domain = PickerDomaine.SelectedItem.ToString();
            //var username = EntryUsername.Text;
            //var password = EntryPassword.Text;

            //var isValidInput = AppsHelper.AreInputsNullOrEmpty(new string[] { username, password });

            //if (!isValidInput)
            //{
            //    AppsHelper.Snack($"Nom d'utilisateur ou mot de passe vide");
            //    //IsShakeActionRunning = false;
            //    return;
            //}
            #endregion

            try
            {
                EntryPassword.IsPassword = true;
                btnShowPassword.CBImage = "iconShowPasswordGray.png";

                //#region Web Service Call with activity indicator
                //AppsHelper.LoadingShow();
                ////var result = await ApiCalls.Login($"{domain}\\{username}", password);
                //var result = await ApiCalls.Login($"{username}", password);
                //AppsHelper.LoadingHide();
                //#endregion

                #region web service response is null or error

                //if (result == null)
                //{
                //    AppsHelper.Snack($"Nom d'utilisateur ou mot de passe incorrect.");
                //    //IsShakeActionRunning = false;
                //    return;
                //}

                //if (result.error_description?.Length > 0)
                //{
                //  AppsHelper.Snack(result.error_description);
                //  //IsShakeActionRunning = false;

                //  return;
                //}
                #endregion

                #region isTokenEmpty
                //var isTokenValid = AppsHelper.AreInputsNullOrEmpty(new string[] { result.access_token });
                //if (!isTokenValid)
                //{
                //    AppsHelper.Snack($"Token est vide");
                //    //IsShakeActionRunning = false;
                //    return;
                //}
                #endregion

                #region Fill user settings info
                //if (!Settings.userName.Equals(result.userName))
                //{
                //  //Settings.ClickedAppsList = string.Empty;
                //  //IsShakeActionRunning = false;
                //}

                //Settings.auth = result.access_token;
                //Settings.userName = result.userName;
                //Settings.FullName = result.FullName;
                //Settings.UserId = result.UserId;
                //Settings.Role = result.Role;
                //Settings.Expires = result.expires;

                //    Settings.UserInfo = result.UserInfo;
                //    if (!string.IsNullOrEmpty(result.authorizedWsServices))
                //        Settings.AuthorizedWsServices = result.authorizedWsServices;
                //DateTime ValidUntil = DateTime.Now.AddSeconds(result.expires_in);
                //    Settings.DeviceWidth = this.Width.ToString();
                //    Settings.DeviceHeight = this.Height.ToString();
                //    Settings.ValidSession = DateTime.Now.AddMinutes(20).ToString();

                #endregion

                //#region Set Constants.isLoggedIn variable to true & go to homepage
                //AppSettings.isLoggedIn = true;

                //if (App.UserInfo.HasAcceptedCNDPMobile)
                //{
                //  IsShakeActionRunning = false;
                //  Application.Current.MainPage = new NavigationPage(new Views.TabbedPagePrincipale());
                //}
                //else
                //{
                //  IsShakeActionRunning = false;
                //  await Navigation.PushModalAsync(new Views.Welcome.Confidentialite.ConfidentialitePage());
                //}

                //#endregion

                //Plugin.FirebasePushNotification.CrossFirebasePushNotification.Current.Subscribe(AppSettings.PushGeneralTopic);

                //AppsHelper.Snack("Welcome " + result.FullName);

                //Settings.IsLogOut = false;

                //Application.Current.MainPage = new NavigationPage(new Tapped.A4CTappedPage());

            }
            catch (Exception ex)
            {
                AppsHelper.Snack(ex.Message);
            }
            finally
            {
                AppsHelper.LoadingHide();
                //Helperino.AEnableViews(ViewsList);
                //IsShakeActionRunning = false;
            }
        }

        private void ShowPassword_Clicked(object sender, EventArgs e)
        {
            if (EntryPassword.IsPassword)
            {
                EntryPassword.IsPassword = false;
                btnShowPassword.CBImage = "iconShowPassword.png";
            }
            else
            {
                EntryPassword.IsPassword = true;
                btnShowPassword.CBImage = "iconShowPasswordGray.png";
            }

            //Only for iOS
            if (!string.IsNullOrEmpty(EntryPassword.Text))
            {
                EntryPassword.CursorPosition = EntryPassword.Text.Length;
                EntryPassword.Focus();
            }
        }

        private void EntryUsername_Completed(object sender, EventArgs e)
        {
            EntryPassword.Focus();
        }

        private async void Inscription_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsyncSingle(new Login.LoginPage(), true);
        }

    }
}   