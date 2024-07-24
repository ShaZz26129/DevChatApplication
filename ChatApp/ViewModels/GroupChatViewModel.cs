using ChatApp.Helpers;
using ChatApp.Models;
using ChatApp.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.ViewModels
{
    public partial class GroupChatViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ICommand NewChatCommand { get; set; }
        public string Oldtext { get; set; }
        public string AddPartici { get; set; }
        private string ParticipantsName;

        private bool participantVisible;
        public bool ParticipantVisible
        {
            get
            {
                return participantVisible;
            }
            set
            {
                participantVisible = value;
                OnPropertyChanged(nameof(ParticipantVisible));
            }
        }
        private List<ParticipantsModel1> participantsList;
        public List<ParticipantsModel1> ParticipantsList
        {
            get
            {
                return participantsList;
            }
            set
            {
                participantsList = value;
                OnPropertyChanged(nameof(ParticipantsList));
            }
        }
        private ParticipantsModel1 selectedParticipant;
        public ParticipantsModel1 SelectedParticipant
        {
            get
            {
                return selectedParticipant;
            }
            set
            {
                selectedParticipant = value;
                if (selectedParticipant != null)
                {
                    _ = Addparticipant();
                }
                OnPropertyChanged(nameof(SelectedParticipant));
            }
        }
        private string participantNames;
        public string ParticipantNames
        {
            get
            {
                return participantNames;
            }
            set
            {
                participantNames = value;
                OnPropertyChanged(nameof(ParticipantNames));
            }
        }

        private string ParticipantID;
        private string chatGroupName;
        public string ChatGroupName
        {
            get
            {
                return chatGroupName;
            }
            set
            {
                chatGroupName = value;
                OnPropertyChanged(nameof(ChatGroupName));
            }
        }

        public object PairConnectionId { get; private set; }
        public object PairUserId { get; private set; }
        public object PairName { get; private set; }
        public object PairPhoto { get; private set; }

        List<string> AllName = new List<string>();
        List<string> SelectedParticipantUesrId = new List<string>();
        //ISignalRChatService signalRChatService;
        HubConnection hubConnection;
        public ObservableCollection<ChatUser> ChatUserList { get; } = new();
        public GroupChatViewModel()
        {
            NewChatCommand = new Command(NewChatCommandAsync);
            string chatUserName = Preferences.Get("ChatUserName", "");
            //string connectionId = Preferences.Get("connectionId", "");
            //hubConnection = ChatHelper.GetInstanse(chatUserName);
            //signalRChatService = DependencyService.Get<ISignalRChatService>();
            //_ = CallparticipantApi();
        }
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string title;
        //}
        //public async void ChatServerConnect()
        //{
        //    await signalRChatService.Connect();
        //}
        //public async Task ChatServerDisconnect()
        //{
        //    await signalRChatService.Disconnect();
        //}
        private async void NewChatCommandAsync(object obj)
        {
            if (AllName.Count > 0)
            {
                var GetAddpartici = AllName;
                AddPartici = string.Join(",", GetAddpartici);
                ParticipantsName = App.DefaultDesignationShortName + "," + AddPartici;
            }
            var SetCommonChat = new CommonChatModel
            {
                OldSystemEmpCode = ParticipantsName,
                Subject = ChatGroupName,
                ParticipantID = ParticipantID,
            };

            if (ChatGroupName != null)
            {
                if (ParticipantsName != null)
                {
                    //await AddToGroupChat();
                    //await Shell.Current.GoToAsync($"//ChatMessagePage?connectionId={PairConnectionId}&userId={PairUserId}&name={PairName}&photo={PairPhoto}");

                    //await AppShell.Current.GoToAsync("//ChatMessagePage");
                    //await NavigateToChatMessagePage(chatUser.ChatUsername, chatUser.ConnectionId, chatUser.Name, chatUser.PhotoPath);
                    //AddGroupChat();

                    await Application.Current.MainPage.Navigation.PushAsync(new GroupChatMessagePage(SetCommonChat));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Enter participant name", "Ok");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Enter group name.", "Ok");
            }
        }
        [RelayCommand]
        private async Task AddGroupChat()
        {
            await hubConnection.InvokeAsync("AddToGroup", ChatGroupName);
        }
        //public async Task NavigateToChatMessagePage(CommonChatModel SetCommonChat,string userId, string connectionId, string name, string photo)
        //{
        //    var chatMessagePage = new ChatMessagePage(SetCommonChat,userId, connectionId, name, photo);
        //    await Application.Current.MainPage.Navigation.PushAsync(chatMessagePage);
        //}
        public async Task CallparticipantApi()
        {
            MessageServiceHelper helper = new MessageServiceHelper();
            List<string> PartiList = new List<string>();
            var ParticipantApiResult = await helper.GetParticipants(App.TenantId, App.MessageBoxId, App.ParticiapplicationId, App.ParticipageId, App.TenantId, App.Username);
            if (ParticipantApiResult != null)
            {
                ParticipantsList = new List<ParticipantsModel1>(ParticipantApiResult.Result);
            }
        }
        public async Task Addparticipant()
        {
            var name = SelectedParticipant;
            ParticipantNames = Oldtext + name + ",";
            ParticipantID = SelectedParticipant.UserID;
            ParticipantVisible = false;
            AllName.Add(Convert.ToString(name));

            SelectedParticipantUesrId.Add(ParticipantID);
        }
        //[RelayCommand]
        //private async Task AddToGroupChat()
        //{
        //    try
        //    {
        //        if (hubConnection.State == HubConnectionState.Connected)
        //        {
        //            await hubConnection.InvokeAsync("AddToGroup", ChatGroupName,"Sumit");
        //            //this.SendingMessage = string.Empty;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in SendMessage: {ex.Message}");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
