using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CommunityGroup.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }


        #region DeviceHeight

        private const string DeviceHeight_key = "DeviceHeight_key";
        private static readonly string DeviceHeight_default = string.Empty;

        public static string DeviceHeight
        {
            get
            {
                return AppSettings.GetValueOrDefault(DeviceHeight_key, DeviceHeight_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DeviceHeight_key, value);
            }
        }

        #endregion

        #region DeviceWidth

        private const string DeviceWidth_key = "DeviceWidth_key";
        private static readonly string DeviceWidth_default = string.Empty;

        public static string DeviceWidth
        {
            get
            {
                return AppSettings.GetValueOrDefault(DeviceWidth_key, DeviceWidth_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DeviceWidth_key, value);
            }
        }

        #endregion

        #region App Settings 

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;




        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        #endregion

        #region ClickedAppsList
        private const string ClickedAppsListKey = "ClickedAppsListKey";
        private static readonly string ClickedAppsListDefault = string.Empty;

        public static string ClickedAppsList
        {
            get
            {
                return AppSettings.GetValueOrDefault(ClickedAppsListKey, ClickedAppsListDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ClickedAppsListKey, value);
            }
        }
        #endregion

        #region IsAppInit
        private const string IsAppInitKey = "IsAppInitKey";
        private static readonly bool IsAppInitDefault = false;

        public static bool IsAppInit
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsAppInitKey, IsAppInitDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsAppInitKey, value);
            }
        }
        #endregion


        #region IsCommandStarted
        private const string IsCommandStartedKey = "IsCommandStartedKey";
        private static readonly bool IsCommandStartedDefault = false;

        public static bool IsCommandStarted
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsCommandStartedKey, IsCommandStartedDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsCommandStartedKey, value);
            }
        }
        #endregion

        #region Adresse
        private const string AdresseKey = "AdresseKey";
        private static readonly string AdresseDefault = string.Empty;

        public static string Adresse
        {
            get
            {
                return AppSettings.GetValueOrDefault(AdresseKey, AdresseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AdresseKey, value);
            }
        }
        #endregion

        #region Matricule
        private const string MatriculeKey = "MatriculeKey";
        private static readonly string MatriculeDefault = string.Empty;

        public static string Matricule
        {
            get
            {
                return AppSettings.GetValueOrDefault(MatriculeKey, MatriculeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(MatriculeKey, value);
            }
        }
        #endregion
        #region NavigationKey
        private const string NavigationKey = "NavigationKey";
        private static readonly string NavigationDefault = "0";

        public static string Navigation
        {
            get
            {
                return AppSettings.GetValueOrDefault(NavigationKey, NavigationDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(NavigationKey, value);
            }
        }
        #endregion


        #endregion





        #region auth

        private const string auth_key = "auth_key";
        private static readonly string auth_default = string.Empty;

        public static string auth
        {
            get
            {
                return AppSettings.GetValueOrDefault(auth_key, auth_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(auth_key, value);
            }
        }

        #endregion



        #region RefreshToken

        private const string RefreshToken_key = "RefreshToken_key";
        private static readonly string RefreshToken_default = string.Empty;

        public static string RefreshToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(RefreshToken_key, RefreshToken_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RefreshToken_key, value);
            }
        }

        #endregion

        #region userName

        private const string userName_key = "userName_key";
        private static readonly string userName_default = string.Empty;

        public static string userName
        {
            get
            {
                return AppSettings.GetValueOrDefault(userName_key, userName_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userName_key, value);
            }
        }

        #endregion


        #region ValidUntil

        private const string TokenValidUntil_key = "TokenValidUntil_key";
        private static readonly string TokenValidUntil_default = string.Empty;

        public static string TokenValidUntil
        {
            get
            {
                return AppSettings.GetValueOrDefault(TokenValidUntil_key, TokenValidUntil_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TokenValidUntil_key, value);
            }
        }

        #endregion

        #region ValidSession

        private const string ValidSession_key = "ValidSession_key";
        private static readonly string ValidSession_default = string.Empty;

        public static string ValidSession
        {
            get
            {
                return AppSettings.GetValueOrDefault(ValidSession_key, ValidSession_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ValidSession_key, value);
            }
        }

        #endregion

        #region ServiceParProfil

        private const string ServiceParProfil_key = "ServiceParProfil_key";
        private static readonly string ServiceParProfil_default = string.Empty;

        public static string ServiceParProfil
        {
            get
            {
                return AppSettings.GetValueOrDefault(ServiceParProfil_key, ServiceParProfil_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ServiceParProfil_key, value);
            }
        }

        #endregion

        #region AuthorizedWsServices

        private const string AuthorizedWsServices_key = "AuthorizedWsServices_key";
        private static readonly string AuthorizedWsServices_default = string.Empty;

        public static string AuthorizedWsServices
        {
            get
            {
                return AppSettings.GetValueOrDefault(AuthorizedWsServices_key, AuthorizedWsServices_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AuthorizedWsServices_key, value);
            }
        }

        #endregion

        #region WsErrorMessageCode

        private const string WsErrorMessageCode_key = "WsErrorMessageCode_key";
        private static readonly string WsErrorMessageCode_default = string.Empty;

        public static string WsErrorMessageCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(WsErrorMessageCode_key, WsErrorMessageCode_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(WsErrorMessageCode_key, value);
            }
        }

        #endregion

        #region UserInfo

        private const string UserInfo_key = "UserInfo_key";
        private static readonly string UserInfo_default = string.Empty;

        public static string UserInfo
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserInfo_key, UserInfo_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserInfo_key, value);
            }
        }

        #endregion

        #region Expires

        private const string Expires_key = "Expires_key";
        private static readonly string Expires_default = string.Empty;

        public static string Expires
        {
            get
            {
                return AppSettings.GetValueOrDefault(Expires_key, Expires_default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Expires_key, value);
            }
        }

        #endregion


        #region IsLogOut
        private const string IsLogOutKey = "IsLogOutKey";
        private static readonly bool IsLogOutDefault = true;

        public static bool IsLogOut
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLogOutKey, IsLogOutDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLogOutKey, value);
            }
        }
        #endregion

        //#region IsLogOut
        //private const string IsLogOutKey = "IsLogOutKey";
        //private static readonly bool IsLogOutDefault = false;

        //public static bool IsLogOut
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(IsLogOutKey, IsLogOutDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(IsLogOutKey, value);
        //    }
        //}
        //#endregion

        public static void ClearSettings()
        {
            Settings.auth = string.Empty; //access_token
            Settings.RefreshToken = string.Empty;
            Settings.TokenValidUntil = string.Empty;
            //Settings.userName = string.Empty;
            Settings.ServiceParProfil = string.Empty;
            Settings.AuthorizedWsServices = string.Empty;
            Settings.WsErrorMessageCode = string.Empty;
            //App.IsLogout = true;

            //Settings.ClickedAppsList = string.Empty;
            //Settings.IsLogOut = true;
        }
    }
}