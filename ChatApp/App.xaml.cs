using ChatApp.Controls;
using MonkeyCache.FileStore;

namespace ChatApp;

public partial class App : Application
{
    public static string accessToken;
    public static string accessTokenExpiresOn;
    public static DateTime accessTokenReceivedOn;
    public static string refreshToken;
    public static string ClientId = "35";
    public static string ApplicationId = "31";
    public static string ClientSecret = "EE02BE685D6D85029F5D34664F60B76D9B979292";
    public static string TenantId = "5";
    public static string ClientIpAddress = "::1";
    public static string ApiAccessToken = "de4402ed5cf40764b6bf26100a0ceaca02a95066";
    public static string TenantOuId = "1";
    public static string JobId;
    public static bool GetApiResponce { get; set; }
    public static bool Connection { get; set; }
    public static string Username { get; set; }
    public static string UserId { get; set; }
    public static string EmpName { get; set; }
    public static int EmpId { get; internal set; }
    public static string UserProfilePic { get; set; }
    public static string MessageBoxId { get; set; }
    public static string DesignationID { get; set; }
    public static string DefaultDesignationShortName { get; set; }
    public static string EmailId { get; set; }
    public static string ParticiapplicationId = "16";
    public static string ParticipageId = "5";
    public static string GetParticipantData = "/ParticipantData";


    public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cW2hIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjW35YcHRRRWFeVExyXw==");
        InitializeComponent();

		MainPage = new AppShell();

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderLessEntry), (handler, value) =>
		{
			#if __ANDROID__
				handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
			#elif __IOS__
				handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;				
			#endif
		});
        Barrel.ApplicationId = "ChatApp";

    }
}
