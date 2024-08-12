//using AudioUnit;
using ChatApp.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ChatApp.ViewModel;

public partial class ChatListViewModel : BaseViewModel
{
    HubConnection hubConnection;
    public ObservableCollection<ChatUser> ChatUserList { get; } = new();
    private Timer refreshTimer;
    public ChatListViewModel()
    {
        //yahan se ap ko chat User yani jis id se ap login hain wo user milta hai
        // Hook up hubConnection
        string chatUserName = Preferences.Get("ChatUserName", "");
        hubConnection = ChatHelper.GetInstanse(chatUserName);
        hubConnection.On<List<ChatUser>>("ChatUserList", (chatUserList) =>
        {
            RenderList(chatUserName, chatUserList);
        });

        // Load list data
        LoadData();
        //InitializeRefreshTimer();
    }


    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    string title;
    
    [RelayCommand]
    private void Login()
    {
        AppShell.Current.GoToAsync("//LoginPage");
    }
    //Jis k Sath Hum Chat Krna Chahte hain 
    [RelayCommand]
    private void Select(ChatUser chatUser)
    {        
        AppShell.Current.GoToAsync("//ChatMessagePage?",
                new Dictionary<string, object>
                {
                    ["userId"] = chatUser.Username,
                    ["connectionId"] = chatUser.ConnectionId,
                    ["name"] = chatUser.Name,
                    ["photo"] = chatUser.PhotoPath
                }
            );
        //Dispose();
    }
    [RelayCommand]
    private void AddToGroupChat()
    {
        AppShell.Current.GoToAsync("//GroupChatPage");
        //Dispose();
    }
    async private void LoadData()
    {
        await hubConnection.InvokeAsync("GetConnectedUsers");
    }

    //private void RenderList(string chatUserName, List<ChatUser> chatUserList)
    //{
    //    ObservableCollection<ChatUser> formatedList = new ObservableCollection<ChatUser>();
    //    foreach (ChatUser item in chatUserList)
    //    {
    //        if (item.ChatUsername != chatUserName) // Exclude myself in chat user list
    //        {
    //            formatedList.Add(GetFormatedChatUser(item.ConnectionId, item.ChatUsername));
    //        }
    //    }

    //    foreach (var item in formatedList)
    //    {
    //        ChatUserList.Add(item);
    //    }

    //    this.Title = "Chat Members (" + this.ChatUserList.Count.ToString() + ")";
    //}
    private void RenderList(string chatUserName, List<ChatUser> chatUserList)
    {
        // Clear the existing chat user list to avoid duplicates
        ChatUserList.Clear();
        foreach (ChatUser item in chatUserList)
        {
            if (item.ChatUsername != chatUserName) // Exclude myself in chat user list
            {
                ChatUserList.Add(GetFormatedChatUser(item.ConnectionId, item.ChatUsername));
            }
        }

        //foreach (var item in formatedList)
        //{
        //    ChatUserList.Add(item);
        //}

        this.Title = "Chat Members (" + this.ChatUserList.Count.ToString() + ")";
        IsRefreshing = false;
    }

    private ChatUser GetFormatedChatUser(string connectionId, string chatUsername)
    {
        ChatUser formatedChatUser = new ChatUser();

        string username = String.Empty;
        string name = String.Empty;
        string photo = String.Empty;
        string location = String.Empty;
        int count = 1;
        string[] datas = chatUsername.Split('*');
        foreach (string data in datas)
        {
            switch (count)
            {
                case 1:
                    username = data;
                    break;
                case 2:
                    name = data;
                    break;
                case 3:
                    photo = data;
                    break;
                case 4:
                    location = data;
                    break;
                default:
                    break;
            }

            count++;
        } // End foreach
        //Data of the user thats we connected like (server..)
        formatedChatUser.ConnectionId = connectionId;
        //formatedChatUser.UserId = userId;
        formatedChatUser.ChatUsername = username;
        formatedChatUser.Name = name;
        formatedChatUser.Location = location;
        formatedChatUser.PhotoPath = photo;
        formatedChatUser.IsOnline = true;

        return formatedChatUser;
    }

    [RelayCommand]
    public  void RefreshChatUsersAsync()
    {
        IsRefreshing = true;
        LoadData();
        IsRefreshing = false;
    }
    //private void InitializeRefreshTimer()
    //{
    //    refreshTimer = new System.Timers.Timer(30000); // Set interval to 60 seconds (60000 milliseconds)
    //    refreshTimer.Elapsed += OnRefreshTimerElapsed;
    //    refreshTimer.AutoReset = true;
    //    refreshTimer.Enabled = true;
    //}
    //private void OnRefreshTimerElapsed(object sender, ElapsedEventArgs e)
    //{
    //    RefreshChatUsersAsync();
    //}
    // Ensure timer is stopped when the view model is disposed
    //public void Dispose()
    //{
    //    refreshTimer?.Stop();
    //    refreshTimer?.Dispose();
    //}
}

