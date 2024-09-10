using ChatServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        // Method to send a message to a specific client
        public void SendMessage(string connectionId,string userId, string name, string photo, string message)
        {
            string unniqueId = Guid.NewGuid().ToString();
            // Send message to the recipient client
            Clients.Client(connectionId).SendAsync("ReceiveMessage",Context.ConnectionId, userId, name, photo, message, unniqueId, false);
            // Send confirmation to the sender client
            //Clients.Caller.SendAsync("ReceiveMessage",connectionId, "", "", "", message, unniqueId, true);
        }
        public async Task SendMessageToGroup(string groupName, string message, string user,string profilePic)
        {
            try
            {
                var localUserData = HubHelper.ChatUserList.ToList();
                await Clients.Group(groupName).SendAsync("ReceiveMessage",message, user,profilePic,false);
                //await Clients.Caller.SendAsync("ReceiveMessage",message,user,true);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in SendMessageToGroup: {ex.Message}");
                throw;
            }
            // Add message to in-memory storage
            //if (!groupMessages.ContainsKey(groupName))
            //{
            //    groupMessages[groupName] = new List<string>();
            //}
            //groupMessages[groupName].Add($"{user}: {message}");
            //await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //var user = Context.ConnectionId;
            //await Clients.Group(groupName).SendAsync("ReceiveMessage",user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage",user,message,true);
        }
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        //public async Task AddToGroup(string groupName, string userName)
        //{


        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    if (ConnectedUsers.Count > 0)
        //    {
        //        var user = ConnectedUsers.FirstOrDefault(u => u.UserName == userName);
        //        if (user != null)
        //        {
        //            ConnectedUsers.Remove(user);
        //        }
        //    }
        //    ConnectedUsers.Add(new UserDetail { ConnectionId = Context.ConnectionId, UserName = userName });
        //    //await Clients.Group(groupName).SendAsync("ReceiveMessage",Context.ConnectionId,userName);

        //}
        public Task Typing(string groupName,string name)
        {
            return Clients.Group(groupName).SendAsync("TypingMessage", name);
            //var localUserData = HubHelper.ChatUserList.ToList();
            //foreach (var item in localUserData)
            //{
            //    if (item.ChatUsername == name)
            //    {
            //        var connectionId = item.ConnectionId;

            //    }
            //}
            //return Task.CompletedTask;
        }
        public Task TypingInSingle(string connectionId, string name)
        {
            //typing in Private
            return Clients.Client(connectionId).SendAsync("TypingMessage", connectionId, name);
        }
        public void Disconnect()
        {
            Context.Abort();
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var chatUsername = Context.GetHttpContext().Request.Query["chatUsername"];
            if (!String.IsNullOrEmpty(chatUsername))
            {
                // Remove the user if already exists in the list
                HubHelper.ChatUserList.RemoveAll(x => x.ChatUsername == chatUsername);

                // Add the user
                HubHelper.ChatUserList.Add(new ChatUser { ConnectionId = Context.ConnectionId, ChatUsername = chatUsername, ActionTime = DateTime.Now });

                await Clients.All.SendAsync("UserConnected", Context.ConnectionId, HubHelper.ChatUserList);
            }            
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var connectionId = Context.ConnectionId;

            var item = HubHelper.ChatUserList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                HubHelper.ChatUserList.Remove(item);                                
                await Clients.All.SendAsync("UserDisconnected", connectionId, HubHelper.ChatUserList);
            }

            await base.OnDisconnectedAsync(ex);
        }

        public Task GetConnectedUsers()
        {
            return Clients.Caller.SendAsync("ChatUserList", HubHelper.ChatUserList);
        }
    }
}
