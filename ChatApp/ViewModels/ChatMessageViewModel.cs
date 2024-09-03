using ChatApp.DbOperation;
using ChatApp.DbOperation.Table;
using ChatApp.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using System.Data;

namespace ChatApp.ViewModel;

public partial class ChatMessageViewModel : BaseViewModel,IQueryAttributable
{
    HubConnection hubConnection;

    private CancellationTokenSource tokenSource;

    public ObservableCollection<ChatMessage> ChatMessageList { get; set; } = new();
    //public ObservableCollection<ChatMessage> ChatMessageList { get; set; }

    [ObservableProperty]
    string sendingMessage;

    [ObservableProperty]
    string typingText;

    [ObservableProperty]
    bool showTyping;

    [ObservableProperty]
    string pairPhoto;

    [ObservableProperty]
    string pairName;
    private MessageServiceHelper helper;
    private static int startpageid { get; set; }

    public static int EndPageID { get; set; }

    public string MyUserId { get; set; }
    public string MyName { get; set; }
    public string MyPhoto { get; set; }
    public string PairConnectionId { get; set; }
    public string PairUserId { get; set; }
    public string ParentID { get; private set; }
    public string SelectedUserName { get; set; }
    public string selectedUserID { get; set; }
    public string GroupName { get; private set; }
    //ChatMessageViewModel(CommonChatModel chatModel)
    public ChatMessageViewModel()
    {
        //SelectedUserName = chatModel.OldSystemEmpCode;
        //selectedUserID = chatModel.ParticipantID;
        //GroupName = chatModel.Subject;
        ChatMessageList = new ObservableCollection<ChatMessage>();
        string chatUserName = Preferences.Get("ChatUserName", "");
        this.MyUserId = Utils.GetUserId(chatUserName);
        this.MyName = Utils.GetName(chatUserName);
        this.MyPhoto = Utils.GetUserProfile(chatUserName);
        //this.MyPhoto = Preferences.Get("ProfilePhoto", "");
        hubConnection = ChatHelper.GetInstanse(chatUserName);
        //This is the user Credentials Like this time its Gives Arun's Sir Credential because we login to him Account..
        //string chatUserName = Preferences.Get("ChatUserName", "");
        //this.PairConnectionId = chatUser.ConnectionId;
        //this.MyUserId = Utils.GetUserId(chatUserName);
        //this.MyName = Utils.GetName(chatUserName);
        //this.MyName = Preferences.Get("MyName",App.EmpName);
        //this.MyPhoto = Preferences.Get("ProfilePhoto", App.UserProfilePic);
        //this.MyPhoto = App.UserProfilePic;
        //idhr yeh check krta hai k Connection is Open Closed Or something Else
        
        //await hubConnection.StartAsync();
        hubConnection.Closed += async (error) =>
        {
            SendLocalMessage("---Connection closed---");
            ChatHelper.IsConnected = false;
            await Task.Delay(2000);
            await ChatHelper.Connect(chatUserName);
        };

        hubConnection.On<string, ObservableCollection<ChatUser>>("UserDisconnected", (connectionId, chatUserList) =>
        {
            SendLocalMessage("---User disconnected---");
        });

        hubConnection.On<string, string>("TypingMessage", (connectionId, name) =>
        {
            TaskCancel();
            this.TypingText = name + " is typing...";
            this.ShowTyping = true;
            TaskDelay();
        });
        hubConnection.On<string, string, string, string, string, string, bool>("ReceiveMessage", (pairConnectionId, pairUserId, pairName, pairPhoto, message, uniqueId, isMe) =>
        {
            if (!isMe)
            {
                this.PairConnectionId = pairConnectionId;
                this.PairUserId = pairUserId;
                this.PairName = pairName;
                this.PairPhoto = pairPhoto;
            }

            ChatMessageList.Add(new ChatMessage() { Message = message, IsOwnMessage = isMe, MyPhoto = this.MyPhoto, PairPhoto = this.PairPhoto, IsSystemMessage = false, ActionTime = DateTime.Now.ToString("hh:mm tt") });

        });
        //hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        //{
        //    //if (!isMe)
        //    //{
        //    //    //this.PairConnectionId = pairConnectionId;
        //    //    //this.PairUserId = pairUserId;
        //    //    //this.PairName = user;
        //    //    //this.PairPhoto = pairPhoto;
        //    //}
        //    //DisplayMessage(user, message);
        //    ChatMessageList.Add(new ChatMessage() { Message = message, MyPhoto = this.MyPhoto, PairPhoto = this.PairPhoto, IsSystemMessage = false, ActionTime = DateTime.Now.ToString("hh:mm tt") });
        //});
        //Yahan py yeh chat message list hai k Agr ap ko koi message receive hua hai 
        //Means agr ap ko user ny koi message send kiya hai to wo yahan py receive ho ga aur chat me add kr diya jaaye ga ..

        //helper = new MessageServiceHelper();
    }
    //[RelayCommand]
    //private async Task SendMessageToGroupChat()
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(this.sendingMessage) && hubConnection.State == HubConnectionState.Connected)
    //        {
    //            await hubConnection.InvokeAsync("SendMessageToGroup", GroupName, MyUserId, this.SendingMessage);
    //            this.SendingMessage = string.Empty;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //Console.WriteLine($"Error in SendMessage: {ex.Message}");
    //        await Application.Current.MainPage.DisplayAlert("Error", $"Error in SendMessage: {ex.Message}", "OK");
    //    }
    //}

    //public async void GetMessage()
    //{
    //    var GetOnlyDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
    //    if (startpageid == 0)
    //    {
    //        startpageid = startpageid + 1;
    //        EndPageID = 5;
    //    }
    //    else
    //    {
    //        startpageid = EndPageID;
    //        EndPageID = startpageid + 5;
    //    }
    //    var apiTask = helper.GetOldChildMessMail(App.TenantId, "10", "16", "5", true, "M", ParentID, Convert.ToString(115), Objtype, GetOnlyDate, startpageid, EndPageID);
    //    if (apiTask != null && apiTask.Result != null)
    //    {

    //    }
    //}
    //public async Task AddmsgInTable(string TextMsg)
    //{
    //    var MessageTable = new SendMessageTable();
    //    var MessageDbOperation = new SendMessageDbOperation();

    //    if (ParentID != null)
    //    {
    //        MessageTable.UnqID = 1;
    //        MessageTable.Id = ParentID;
    //        MessageTable.mid = 0;
    //        MessageTable.OId = Convert.ToString(ParentID);
    //        MessageTable.Otype = 115;
    //        MessageTable.Replyto = null;
    //        MessageTable.Parentid = ParentID;
    //        MessageTable.ThreadId = ParentID;
    //        MessageTable.Author = App.DefaultDesignationShortName;
    //        MessageTable.Priority = 0;
    //        MessageTable.Status = 0;
    //        MessageTable.ActionType = null;
    //        MessageTable.ParentSubject = ParentSubjectName;
    //        MessageTable.Subject = TitleName;
    //        MessageTable.Content = TextMsg;
    //        MessageTable.ObjectType = Convert.ToInt32(Objtype);
    //        MessageTable.Participant = ParticipantsName;
    //        MessageTable.followup = 0;
    //        MessageTable.ReadStatus = 0;
    //        MessageTable.eventname = "C";
    //        MessageTable.VersionSource = App.DefaultDesignationShortName;
    //        MessageTable.AttachId = null;
    //        MessageTable.liveStatus = 0;
    //        MessageTable.LogEntry = false;
    //        MessageTable.pMid = null;
    //        MessageTable.VersionDate = "Date(1549966137985)";
    //        MessageTable.UserId = App.EmpId;
    //        MessageTable.DefaultDesignation = null;
    //        MessageTable.IpAddress = null;
    //        MessageTable.Username = App.EmpName;
    //        MessageTable.EmpCode = null;
    //        MessageTable.LoadTimeStamp = null;
    //        MessageTable.AcceptTimeStamp = null;
    //        MessageTable.Modified = null;
    //        MessageTable.NewDivId = 0;
    //        MessageTable.SwitchTenantId = 0;
    //        MessageTable.SwitchOuid = 0;
    //        MessageTable.SwitchConnectionString = null;
    //        MessageTable.ApiCallParameters = null;
    //        MessageTable.AppParameter = null;
    //        MessageTable.ApplicationId = "16";
    //        MessageTable.TenantId = App.TenantId;
    //        MessageTable.OUId = App.TenantOuId;
    //        MessageTable.ConnectionString = null;
    //        MessageTable.MailCC = "";
    //        MessageTable.MailBcc = "";
    //        MessageTable.IsAttachment = false;
    //        MessageTable.SendStatus = 0;
    //        MessageTable.Tries = 0;
    //        MessageTable.InReplyTo = "";
    //        MessageTable.Sync = 0;
    //        MessageTable.MailFromName = App.EmpName;
    //        MessageTable.MailToName = GetEmpchatData.OldSystemEmpCode;
    //        MessageTable.MailCcName = "";
    //        MessageTable.MailBccName = "";
    //        MessageTable.Reference = "";
    //        MessageTable.ObjectId = "5";
    //        MessageTable.SentDate = "Date(-62135596800000)";
    //        MessageTable.MailFolderId = 1;
    //        MessageTable.ServiceTenantId = 0;
    //        MessageTable.ServiceUserName = null;
    //        MessageTable.ServiceUserPassowrd = null;
    //        MessageTable.JobId = null;
    //        MessageTable.RecDateTime = "Date(-62135596800000)";
    //        MessageTable.Duration = 0;
    //        MessageTable.Complete = 0;
    //        MessageTable.EndDateTime = null;
    //        MessageTable.Approval = null;
    //        MessageTable.ActualDuration = 0;
    //        MessageTable.TaskId = null;
    //        MessageTable.Startdate = null;
    //        MessageTable.IsTodolist = false;
    //        MessageTable.CategoryId = 0;
    //        MessageTable.ConnApplicationId = null;
    //        MessageTable.AppName = null;
    //        MessageTable.UserSession = null;
    //        MessageTable.FormId = 25;
    //        MessageTable.Admin = 0;
    //        MessageTable.Token = null;
    //        MessageTable.UTCTimeDifference = "Date(-62135596800000)";
    //    }
    //    else
    //    {
    //        MessageTable.UnqID = 1;
    //        var newID = Convert.ToString(App.EmpId);
    //        MessageTable.Id = null;
    //        MessageTable.mid = 0;
    //        MessageTable.OId = null;
    //        MessageTable.Otype = 115;
    //        MessageTable.Replyto = null;
    //        MessageTable.Parentid = null;
    //        MessageTable.ThreadId = newID;
    //        MessageTable.Author = App.DefaultDesignationShortName;
    //        MessageTable.Priority = 0;
    //        MessageTable.Status = 0;
    //        MessageTable.ActionType = null;
    //        MessageTable.ParentSubject = ParentSubjectName;
    //        MessageTable.Subject = TitleName;
    //        MessageTable.Content = TextMsg;
    //        MessageTable.ObjectType = 0;
    //        MessageTable.Participant = ParticipantsName;
    //        MessageTable.followup = 0;
    //        MessageTable.ReadStatus = 0;
    //        MessageTable.eventname = "C";
    //        MessageTable.VersionSource = App.DefaultDesignationShortName;
    //        MessageTable.AttachId = null;
    //        MessageTable.liveStatus = 0;
    //        MessageTable.LogEntry = false;
    //        MessageTable.pMid = null;
    //        MessageTable.VersionDate = "Date(1549966137985)";
    //        MessageTable.UserId = App.EmpId;
    //        MessageTable.DefaultDesignation = null;
    //        MessageTable.IpAddress = null;
    //        MessageTable.Username = App.EmpName;
    //        MessageTable.EmpCode = null;
    //        MessageTable.LoadTimeStamp = null;
    //        MessageTable.AcceptTimeStamp = null;
    //        MessageTable.Modified = null;
    //        MessageTable.NewDivId = 0;
    //        MessageTable.SwitchTenantId = 0;
    //        MessageTable.SwitchOuid = 0;
    //        MessageTable.SwitchConnectionString = null;
    //        MessageTable.ApiCallParameters = null;
    //        MessageTable.AppParameter = null;
    //        MessageTable.ApplicationId = "16";
    //        MessageTable.TenantId = App.TenantId;
    //        MessageTable.OUId = App.TenantOuId;
    //        MessageTable.ConnectionString = null;
    //        MessageTable.MailCC = "";
    //        MessageTable.MailBcc = "";
    //        MessageTable.IsAttachment = false;
    //        MessageTable.SendStatus = 0;
    //        MessageTable.Tries = 0;
    //        MessageTable.InReplyTo = "";
    //        MessageTable.Sync = 0;
    //        MessageTable.MailFromName = App.EmpName;
    //        MessageTable.MailToName = GetEmpchatData.OldSystemEmpCode;
    //        MessageTable.MailCcName = "";
    //        MessageTable.MailBccName = "";
    //        MessageTable.Reference = "";
    //        MessageTable.ObjectId = "5";
    //        MessageTable.SentDate = "Date(-62135596800000)";
    //        MessageTable.MailFolderId = 1;
    //        MessageTable.ServiceTenantId = 0;
    //        MessageTable.ServiceUserName = null;
    //        MessageTable.ServiceUserPassowrd = null;
    //        MessageTable.JobId = null;
    //        MessageTable.RecDateTime = "Date(-62135596800000)";
    //        MessageTable.Duration = 0;
    //        MessageTable.Complete = 0;
    //        MessageTable.EndDateTime = null;
    //        MessageTable.Approval = null;
    //        MessageTable.ActualDuration = 0;
    //        MessageTable.TaskId = null;
    //        MessageTable.Startdate = null;
    //        MessageTable.IsTodolist = false;
    //        MessageTable.CategoryId = 0;
    //        MessageTable.ConnApplicationId = null;
    //        MessageTable.AppName = null;
    //        MessageTable.UserSession = null;
    //        MessageTable.FormId = 25;
    //        MessageTable.Admin = 0;
    //        MessageTable.Token = null;
    //        MessageTable.UTCTimeDifference = "Date(-62135596800000)";
    //    }
    //    MessageDbOperation.AddMember(MessageTable);
    //    await SendMessagetoApi();
    //}
    //public async Task SendMessagetoApi()
    //{
    //    try
    //    {
    //        var sendMessageDbOperation = new SendMessageDbOperation();
    //        var findMsgData = sendMessageDbOperation.GetMembers();
    //        if (findMsgData != null && findMsgData.Count() > 0)
    //        {
    //            foreach (var item in findMsgData)
    //            {
    //                var AddDatainList = new List<ApplyLeaveMessMailRequestModel>();
    //                AddDatainList.Add(new ApplyLeaveMessMailRequestModel
    //                {
    //                    Id = item.Parentid,
    //                    mid = item.mid,
    //                    OId = item.Parentid,
    //                    Otype = item.Otype,
    //                    Replyto = item.Replyto,
    //                    Parentid = item.Parentid,
    //                    ThreadId = item.Parentid,
    //                    Author = item.Author,
    //                    Priority = item.Priority,
    //                    Status = item.Status,
    //                    ActionType = item.ActionType,
    //                    ParentSubject = item.ParentSubject,
    //                    Subject = item.Subject,
    //                    Content = item.Content,
    //                    ObjectType = item.ObjectType,
    //                    Participant = item.Participant,
    //                    followup = item.followup,
    //                    ReadStatus = item.ReadStatus,
    //                    eventname = "C",
    //                    VersionSource = item.VersionSource,
    //                    AttachId = null,
    //                    liveStatus = 0,
    //                    LogEntry = false,
    //                    pMid = null,
    //                    VersionDate = "Date(1549966137985)",
    //                    UserId = item.UserId,
    //                    DefaultDesignation = null,
    //                    IpAddress = null,
    //                    Username = item.Username,
    //                    EmpCode = null,
    //                    LoadTimeStamp = null,
    //                    AcceptTimeStamp = null,
    //                    Modified = null,
    //                    NewDivId = 0,
    //                    SwitchTenantId = 0,
    //                    SwitchOuid = 0,
    //                    SwitchConnectionString = null,
    //                    ApiCallParameters = null,
    //                    AppParameter = null,
    //                    ApplicationId = "16",
    //                    TenantId = item.TenantId,
    //                    OUId = item.OUId,
    //                    ConnectionString = null,
    //                    MailCC = "",
    //                    MailBcc = "",
    //                    IsAttachment = false,
    //                    SendStatus = 0,
    //                    Tries = 0,
    //                    InReplyTo = "",
    //                    Sync = 0,
    //                    MailFromName = item.MailFromName,
    //                    MailToName = item.MailToName,
    //                    MailCcName = "",
    //                    MailBccName = "",
    //                    Reference = "",
    //                    ObjectId = item.ObjectId,
    //                    SentDate = "Date(-62135596800000)",
    //                    MailFolderId = 1,
    //                    ServiceTenantId = 0,
    //                    ServiceUserName = null,
    //                    ServiceUserPassowrd = null,
    //                    JobId = null,
    //                    RecDateTime = "Date(-62135596800000)",
    //                    Duration = 0,
    //                    Complete = 0,
    //                    EndDateTime = null,
    //                    Approval = null,
    //                    ActualDuration = 0,
    //                    TaskId = null,
    //                    Startdate = null,
    //                    IsTodolist = false,
    //                    CategoryId = 0,
    //                    ConnApplicationId = null,
    //                    AppName = null,
    //                    UserSession = null,
    //                    FormId = 25,
    //                    Admin = 0,
    //                    Token = null,
    //                    UTCTimeDifference = "Date(-62135596800000)"
    //                });
    //                var MessmailApiResult = await helper.PostApplyLeaveMessmail(AddDatainList);
    //                if (ParentID == null || ParentID == string.Empty)
    //                {
    //                    ParentID = MessmailApiResult.Result;
    //                }
    //                AddDatainList.Clear();
    //                var GetUnqId = item.UnqID;
    //                sendMessageDbOperation.DeleteMember(GetUnqId);
    //            }
    //        }
    //        else
    //        {
    //            //App.StopSendmsgTimer = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        var aa = ex.Message;
    //    }
    //}

    public void TaskCancel()
    {
        tokenSource?.Cancel();
    }

    public async void TaskDelay()
    {
        tokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(3000, tokenSource.Token);
            this.ShowTyping = false;
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (tokenSource != null)
            {
                tokenSource.Dispose();
                tokenSource = null;
            }
        }
    }

    [RelayCommand]
    private void GoToChatList()
    {
        AppShell.Current.GoToAsync("//ChatListPage");
    }
    //Jb ap ny msg send krna hai wo yahan se jata hai 
    //Post ka model post ki api yahan lagy gi....
    //private async void SendMessageToGroup(string groupName, string message)
    //{
    //    await hubConnection.InvokeAsync("SendMessageToGroup", groupName, message);
    //}
    //[RelayCommand]
    //async private void SendMessageGroup()
    //{
    //    try
    //    {
    //        await hubConnection.InvokeAsync("SendMessageToGroup", GroupName, this.MyUserId, this.SendingMessage);
    //        this.SendingMessage = "";
    //    }
    //    catch (Exception ex)
    //    {
    //        SendLocalMessage($"Send failed: {ex.Message}");
    //    }
    //}
    [RelayCommand]
    async private void SendMessage()
    {
        try
        {

            await hubConnection.InvokeAsync("SendMessage", this.PairConnectionId, this.MyUserId, this.MyName, this.MyPhoto, this.SendingMessage);
            this.SendingMessage = "";
        }
        catch (Exception ex)
        {
            //SendLocalMessage($"Send failed: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error", $"Error in SendMessage: {ex.Message}", "OK");
        }
    }

    public async Task Typing()
    {
        await hubConnection.InvokeAsync("TypingInSingle", this.PairConnectionId, this.MyName);
    }

    private void SendLocalMessage(string message)
    {
        //ChatMessageList.Add(new ChatMessage
        //{
        //    Message = message,
        //    IsOwnMessage = false,
        //    IsSystemMessage = true
        //});
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("connectionId"))
        {
            this.PairConnectionId = query["connectionId"] as string;
            this.PairUserId = query["userId"] as string;
            this.PairName = query["name"] as string;
            this.PairPhoto = query["photo"] as string;
            ChatMessageList.Clear();
            // Debug statements to verify the parameters
            Console.WriteLine($"PairConnectionId: {this.PairConnectionId}");
            Console.WriteLine($"PairUserId: {this.PairUserId}");
            Console.WriteLine($"PairName: {this.PairName}");
            Console.WriteLine($"PairPhoto: {this.PairPhoto}");
        }
        else
        {
            // Log if the expected parameters are not found
            Console.WriteLine("Query parameters are missing or incorrect.");
        }
    }
}