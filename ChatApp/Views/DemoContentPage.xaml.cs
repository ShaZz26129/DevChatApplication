using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp.Views;

public partial class DemoContentPage : ContentPage
{
    HubConnection hubConnection;
    public ObservableCollection<Message> Messages { get; set; }
    public DemoContentPage()
	{
		InitializeComponent();
        Messages = new ObservableCollection<Message>();
        MessagesList.ItemsSource = Messages;
        ConnectToHub();
    }
    private async void ConnectToHub()
    {
                  hubConnection = new HubConnectionBuilder()
                 .WithUrl("http://192.168.0.103:5067/chatHub?chatUsername=")
                 .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            // Display the received message
            DisplayMessage(user, message);
        });

        await hubConnection.StartAsync();
    }
    private void DisplayMessage(string user, string message)
    {
        // Logic to display message in the UI
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Messages.Add(new Message { User = user, Text = message });
        });
    }
    private async void SendMessageToUser(string user, string message)
    {
        await hubConnection.InvokeAsync("SendMessageToUser", user, message);
    }

    private async void SendMessageToGroup(string groupName, string message)
    {
        await hubConnection.InvokeAsync("SendMessageToGroup", groupName, message);
    }
    private async void JoinGroup(string groupName)
    {
        await hubConnection.InvokeAsync("JoinGroup", groupName);
    }

    private async void LeaveGroup(string groupName)
    {
        await hubConnection.InvokeAsync("LeaveGroup", groupName);
    }

    private void OnSendButtonClicked(object sender, EventArgs e)
    {
        string message = MessageEntry.Text;
        // Call SendMessageToUser or SendMessageToGroup based on your requirement
        if (!string.IsNullOrEmpty(message))
        {
            // Example sending to group, adjust as needed
            SendMessageToGroup("groupName", message);
            MessageEntry.Text = string.Empty;
        } // or SendMessageToGroup("groupName", message);
    }

    private void OnJoinGroupButtonClicked(object sender, EventArgs e)
    {
        string groupName = GroupEntry.Text;
        if (!string.IsNullOrEmpty(groupName))
        {
            JoinGroup(groupName);
            GroupEntry.Text = string.Empty;
        }
    }
}