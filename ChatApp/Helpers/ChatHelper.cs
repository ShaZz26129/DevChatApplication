using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    public static class ChatHelper
    {
        public static HubConnection hubConnection;

        public static bool IsConnected { get; set; }

        public static HubConnection GetInstanse(string chatUsername)
        {

            //if (hubConnection == null || hubConnection.State == HubConnectionState.Disconnected)
            //{
            //    hubConnection = new HubConnectionBuilder()
            //    .WithUrl("http://192.168.0.105:5067/chatHub?chatUsername=" + chatUsername)
            //    .Build();
            //}
            //return hubConnection;
            if (hubConnection == null || hubConnection.State == HubConnectionState.Disconnected)
            {
                hubConnection = new HubConnectionBuilder()
                .WithUrl("https://chathub.tiptopmail.com/chatHub?chatUsername=" + chatUsername)
                .Build();
            }
            return hubConnection;

        }

        public static async Task Connect(string chatUsername = null)
        {
            if (IsConnected)
            {
                return;
            }

            try
            {
                await GetInstanse(chatUsername).StartAsync();
                IsConnected = true;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Error!", $"Error in Connect:{ex.Message}", "OK");
            }
        }
        
        public static async Task Disconnect(string chatUsername = null)
        {
            if (!IsConnected)
            {
                return;
            }

            try
            {
                await GetInstanse(chatUsername).StopAsync();
                IsConnected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
