
using ChatApp.Helpers;
//using static Java.Util.Jar.Attributes;

namespace ChatApp.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    private string _email;

    public string Email
    {
        get { return _email; }
        set { 
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    private bool _busyIndicator;

    public bool  BusyIndicator
    {
        get { return _busyIndicator; }
        set { 
            _busyIndicator = value;
            OnPropertyChanged(nameof(BusyIndicator));
        }
    }

    private string  _password;

    public string  Password
    {
        get { return _password; }
        set {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    private string _companyName = "gkv group";

    public string CompanyName
    {
        get { return _companyName; }
        set { 
            _companyName = value;
            OnPropertyChanged(nameof(CompanyName));
        }
    }


    IWebServiceHelper Webhelper;
    public LoginViewModel()
    {
        user = new User();
        Webhelper = new WebServiceHelper();
    }

    [ObservableProperty]
    User user;

    [RelayCommand]
    private async void Login()
    {   
        if (!string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_password))
        {
            BusyIndicator = true;
            var userInfo = await Webhelper.Login(_companyName,_email,_password);
            if (userInfo != null)
            {
                // Connect to chat hub
                string chatUsername = App.Username + "*" + App.EmpName + "*" + App.UserProfilePic;
                await ChatHelper.Connect(chatUsername);

                // Save to local storage
                Preferences.Set("ChatUserName", chatUsername);
                BusyIndicator = false;
                // Navigate to chat user list page
                await AppShell.Current.GoToAsync("//ChatListPage");
                //await AppShell.Current.GoToAsync("//GroupChatPage");
                //await AppShell.Current.GoToAsync("//DemoContentPage");
            }
            else
            {
                BusyIndicator = false;
                await Shell.Current.DisplayAlert("Alert!", "Invalid username or password!", "OK");
            }  
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert!", "Username or password! is not Empty", "OK");
        }
        // Read the values set in registration page
        //var username = Preferences.Get("Username", "");
        //var password = Preferences.Get("Password", "");
        //var name = Preferences.Get("Name", "");
        //var location = Preferences.Get("Location", "");
        //string imageName = Preferences.Get("ProfilePhoto", "");

        //if (User.Username != username || User.Password != password)
        //{
        //    await Shell.Current.DisplayAlert("Alert!", "Invalid username or password!", "OK");
        //}
        //else
        //{
        //    // Connect to chat hub
        //    string chatUsername = User.Username + "_" + name + "_" + imageName + "_" + location;
        //    await ChatHelper.Connect(chatUsername);

        //    // Save to local storage
        //    Preferences.Set("ChatUserName", chatUsername);

        //    // Navigate to chat user list page
        //    await AppShell.Current.GoToAsync("//ChatListPage");
        //}
    }

    [RelayCommand]
    private void Register()
    {
        AppShell.Current.GoToAsync("//RegisterPage");
    }
}

